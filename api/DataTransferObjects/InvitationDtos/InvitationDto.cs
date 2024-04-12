namespace api.DataTransferObjects.InvitationDtos;

public class InvitationDto
{
    public int Id { get; set; }
    public string? SenderId { get; set; }
    public string? SenderUsername { get; set; }
    public string? ReceiverId { get; set; }
    public string? ReceiverUsername { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Status { get; set; }
}