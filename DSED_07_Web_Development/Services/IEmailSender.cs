using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSED_07_Web_Development.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
