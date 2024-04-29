using EmailNotification.Models;

namespace EmailNotification.Interfaces;

public interface IEmailService
{
    public Task SendMessage(Message message);
}
