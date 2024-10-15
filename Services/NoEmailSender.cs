using Microsoft.AspNetCore.Identity.UI.Services;

namespace CareWithLoveApp.Services
{
    public class NoEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Classe que não faz absolutamente nada, apenas para retornar um true e o código compilar direito 
            // NÃO APAGAR ESSA CLASSE
            return Task.CompletedTask;
        }
    }
}
