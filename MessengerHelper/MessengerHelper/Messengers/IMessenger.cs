using MessengerHelper.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Messengers
{
    public interface IMessenger
    {
        IPost<TMessage> Register<TMessage>(Action<TMessage> action);
        void PostMessage<TMessage>(TMessage message);
    }
}
