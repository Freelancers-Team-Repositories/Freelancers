namespace Freelancers.Service.Settings;
public class MailSettings
{
    public string Email { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int port { get; set; }
}