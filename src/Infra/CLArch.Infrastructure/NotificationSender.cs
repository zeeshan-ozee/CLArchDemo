using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Interfaces;

namespace CLArch.Infrastructure
{
    public class NotificationSender : INotificationService
    {
        public async Task SendInvitationViaEmailAsync(string text, string receiptent, string sender)
        {
            await Task.FromResult(true);
            System.Console.WriteLine($"Email send to {receiptent} from {sender} and body is {text}");
        }
    }
}