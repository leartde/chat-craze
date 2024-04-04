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
            interestsToReturn.Add(interest.Interest);
        }

        return interestsToReturn;
    }

    public async Task AddInterestsForUserAsync(string userId, IList<string> interests)
    {
        List<string> allowedInterests = Enum.GetValues(typeof(Categories))
            .Cast<Categories>()
            .Select(e => e.ToString())
            .ToList();

        if (interests.Any(interest => !allowedInterests.Contains(interest, StringComparer.OrdinalIgnoreCase)))
        {
            throw new BadRequestException("Interest not in categories list.");
        }

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

    

    public async Task UpdateInterestsForUserAsync(ICollection<UsersInterestsDto> usersInterests)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteInterestsForUserAsync(ICollection<UsersInterestsDto> usersInterests)
    {
        throw new NotImplementedException();
    }
    private async Task CheckIfUserExistsAsync(string userId)
    {
        var user = await _repository.User.GetUserAsync(userId);
        if (user is null) throw new NotFoundException($"User with id {userId} not found.");
    }
}