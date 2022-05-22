namespace EmailManagementService.Repositories;

public interface IPlatformEmailDataRepository
{
    Task<string> GetPlatformEmailAddress();
    Task<string> GetSmtpHost();
    Task<int> GetSmtpPort();
    Task<string> GetEmailUserName();
    Task<string> GetEmailPassword();
}