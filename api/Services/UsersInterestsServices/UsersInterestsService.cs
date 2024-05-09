using api.Contracts;
using api.DataTransferObjects.UsersInterestsDtos;
using api.Enumerations;
using api.Exceptions;
using api.Models;
using AutoMapper;
using System.Globalization;
namespace api.Services.UsersInterestsServices;

public class UsersInterestsService : IUsersInterestsService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly List<string> _allowedInterests = Enum.GetValues(typeof(Categories))
        .Cast<Categories>()
        .Select(e => e.ToString().ToLower())
        .ToList();

    public UsersInterestsService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IList<string>> GetInterestsForUserAsync(string userId)
    {
        await CheckIfUserExistsAsync(userId);
        var usersInterests = await _repository
            .UsersInterests.GetUsersInterestsForUserAsync(userId);
        IList<string> interestsToReturn = new List<string>();
        foreach (var interest in usersInterests)
        {
            if (interest.Interest != null) interestsToReturn.Add(interest.Interest);
        }

        return interestsToReturn;
    }

    public async Task AddInterestsForUserAsync(string userId, IList<string> interests)
    {
        await CheckIfUserExistsAsync(userId);
        ValidateInterestsInput(interests);
        List<UsersInterestsDto> usersInterestsDtos = interests
            .Select(interest => new UsersInterestsDto { UserId = userId, Interest = interest.ToLower() })
            .ToList();

        var usersInterestsToCreate = _mapper.Map<List<UsersInterests>>(usersInterestsDtos);

        foreach (var userInterest in usersInterestsToCreate)
        {
            _repository.UsersInterests.CreateUsersInterests(userInterest);
        }

        await _repository.SaveAsync();
    }
    
    public async Task UpdateInterestsForUserAsync(string userId, IList<string> interests)
    {
        await CheckIfUserExistsAsync(userId);
        ValidateInterestsInput(interests);
       var usersInterests = await _repository.UsersInterests
            .GetUsersInterestsForUserAsync(userId);
            
            foreach (var currentInterest in usersInterests)
            {
                if (interests is null)
                {
                    _repository.UsersInterests.DeleteUsersInterests(currentInterest);
                }
                else if (!interests.Any(i => i.Contains(currentInterest.Interest)))
                {
                    _repository.UsersInterests.DeleteUsersInterests(currentInterest);
                }
                else if (interests.Any(i => i.ToLower().Equals(currentInterest.Interest)))
                {
                    interests.Remove(currentInterest.Interest);
                }
               
            }

            if (interests != null)
            {
                List<UsersInterestsDto> usersInterestsDtos = interests
                    .Select(interest => new UsersInterestsDto { UserId = userId, Interest = interest.ToLower() })
                    .ToList();
                var usersInterestsToCreate = _mapper.Map<List<UsersInterests>>(usersInterestsDtos);

                foreach (var userInterest in usersInterestsToCreate)
                {
                    _repository.UsersInterests.CreateUsersInterests(userInterest);
                }
            }

            await _repository.SaveAsync();
    }
    
    private async Task CheckIfUserExistsAsync(string userId)
    {
        var user = await _repository.User.GetUserAsync(userId);
        if (user is null) throw new NotFoundException($"User with id {userId} not found.");
    }

    private void ValidateInterestsInput(IList<string> interests)
    {
        var duplicateItems = interests.GroupBy(x => x.ToLower())
            .Where(group => group.Count() > 1)
            .Select(group => group.Key);
        if (duplicateItems.Any()) throw new BadRequestException("Duplicate inputs");
        if (interests.Any(interest => !_allowedInterests.Contains(interest, StringComparer.OrdinalIgnoreCase)))
            throw new BadRequestException("Interest not in categories list.");
    }
}