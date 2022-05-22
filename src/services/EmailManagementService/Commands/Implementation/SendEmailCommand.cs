using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

using DTO.Events;
using Kernel.CustomExceptions.Utils;
using Kernel.CustomExceptions.Exceptions;
using EmailManagementService.Repositories;

namespace EmailManagementService.Commands.Implementation;

public class SendEmailCommand : ISendEmailCommand
{
    private readonly IPlatformEmailDataRepository _platformEmailDataRepository;
    private readonly ILogger<SendEmailCommand> _logger;
    private readonly SmtpClient _smtpClient;
    private readonly SendCompletedEventHandler _sendCompletedEventHandler;
    private readonly IErrorMessageFormatter _errorMessageFormatter;

    public SendEmailCommand(
        [FromServices] ILogger<SendEmailCommand> logger,
        [FromServices] IErrorMessageFormatter errorMessageFormatter,
        [FromServices] IPlatformEmailDataRepository platformEmailDataRepository
    )
    {
        _logger = logger;
        _errorMessageFormatter = errorMessageFormatter;
        _platformEmailDataRepository = platformEmailDataRepository;

        _smtpClient = new SmtpClient();
        _sendCompletedEventHandler = new SendCompletedEventHandler(SendCompletedCallback);
        _smtpClient.SendCompleted += _sendCompletedEventHandler;
    }
    public async Task Execute(ApplicationForRegistrationReceived mailAddress)
    {
        _smtpClient.Host = await _platformEmailDataRepository.GetSmtpHost();
        _smtpClient.Port = await _platformEmailDataRepository.GetSmtpPort();

        var from = new MailAddress(await _platformEmailDataRepository.GetPlatformEmailAddress());
        var to = new MailAddress(mailAddress.Email);

        var message = new MailMessage(from, to);
        message.Subject = "Confirmation";
        message.Body = "";
        message.IsBodyHtml = true;

        _smtpClient.Credentials = new NetworkCredential(
            await _platformEmailDataRepository.GetEmailUserName(),
            await _platformEmailDataRepository.GetEmailPassword());
        _smtpClient.EnableSsl = true;
        
        await _smtpClient.SendMailAsync(message);
    }

    private void SendCompletedCallback(object sender, AsyncCompletedEventArgs args)
    {
        var token = args.UserState as string;

        if (args.Cancelled)
        {
            _logger.LogInformation($"[{token}] Email send canceled");
        }

        if (args.Error != null)
        {
            var exception = new InternalServerException("Something went wrong during sent application for registration email", args.Error);
            _logger.LogWarning("Something went wrong during sent application for registration email", exception);
            throw exception;
        }

        _smtpClient.SendCompleted -= _sendCompletedEventHandler;
        _smtpClient.Dispose();
    }
}