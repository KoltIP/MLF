using PetProject.RabbitMqService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.RabbitMqService
{
    public interface IRabbitMqTask
    {
        public Task SendEmail(EmailModel email);
    }
}
