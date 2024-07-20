using Microsoft.AspNetCore.Identity.UI.Services;

namespace Shopy.Utilities;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        //write the code to handle the email sender
        return Task.CompletedTask;
    }
}