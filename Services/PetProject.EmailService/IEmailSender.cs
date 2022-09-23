using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetProject.RabbitMqService.Models;

namespace PetProject.EmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailModel model);
        Task SendEmailAsync(string email, string subject, string message);
    }
}
