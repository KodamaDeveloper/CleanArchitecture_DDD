

using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Models;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; set; }
        public ILogger _logger { get; set; }
        public Task<bool> SendEmail(Application.Models.Email email)
        {
            //here user library send email con _emailSettings.ApiKey
            throw new NotImplementedException();
        }
    }
}
