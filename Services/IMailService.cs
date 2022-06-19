using MailkitApi.Models;

namespace MailkitApi.Services
{
    public interface IMailService
    {
        void SendMail(MailDto request);
    }
}