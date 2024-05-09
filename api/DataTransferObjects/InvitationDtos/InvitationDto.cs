namespace api.DataTransferObjects.InvitationDtos;

public class InvitationDto
{
    public int Id { get; set; }
    public string SenderId { get; set; } = string.Empty;
    public string SenderUsername { get; set; } = string.Empty;
    public string? ReceiverId { get; set; }
    public string ReceiverUsername { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; } = string.Empty;
}