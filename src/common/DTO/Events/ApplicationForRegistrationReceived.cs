namespace DTO.Events;

public class ApplicationForRegistrationReceived : EventArgs
{
    public DateTime OccuredOn { get; set; }
    public string Email { get; set; }
}