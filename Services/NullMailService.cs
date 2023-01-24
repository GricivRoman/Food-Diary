

namespace FoodDiary.Services
{
    public class NullMailService : IMailService
    {
        private readonly ILogger<NullMailService> _logger;
        public NullMailService(ILogger<NullMailService> logger)
        {
            _logger = logger;
        }

        public void SendMessage(string to, string subject, string message)
        {
            _logger.LogInformation("To: {0} Subject: {1} Message: {2}", to, subject, message);
        }
    }
}