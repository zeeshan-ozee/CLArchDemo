using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLArch.Application.Interfaces
{
    public interface INotificationService
    {


        Task SendInvitationViaEmailAsync(string text, string receiptent, string sender);
    }
}