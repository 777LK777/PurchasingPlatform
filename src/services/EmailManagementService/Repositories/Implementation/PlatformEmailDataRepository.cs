namespace EmailManagementService.Repositories.Implementation;
public class PlatformEmailDataRepository : IPlatformEmailDataRepository
{
    public async Task<string> GetPlatformEmailAddress()
    {
        return "purchasing_platform_test";
    }

    public async Task<int> GetSmtpPort()
    {
        return 25;
    }

    public async Task<string> GetSmtpHost()
    {
        return "smtp.mail.ru";
    }

    public async Task<string> GetEmailUserName()
    {
        return "purchasing_platform_test@mail.ru";
    }

    public async Task<string> GetEmailPassword()
    {
        return "vdtLy7k7xGQwUd94vzgW";
    }
}