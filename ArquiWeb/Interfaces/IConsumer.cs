using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArquiWeb.Interfaces
{
    public interface IConsumer
    {
        Task<string> GetGreeting();
        Task<bool> ExecuteCommandMessageAsync(string message);
        Task<bool> ExecuteCommandAsync(string passcode);
        Task<bool> ExecuteOptionAsync(string v);
        Task<bool> Ping();
        Task<string> GetCurrentMessage();
        bool HasUrl();
        void SetUrl(string url);
    }
}
