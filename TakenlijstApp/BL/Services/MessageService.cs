using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class MessageService
    {
        public void Register<T>(object recipient, MessageHandler<object, T> messageHandler) where T : class
        {
            WeakReferenceMessenger.Default.Register<T>(recipient, messageHandler);
        }

        public void Send<T>(T message)
            where T : class
        {
            WeakReferenceMessenger.Default.Send(message);
        }
    }
}
