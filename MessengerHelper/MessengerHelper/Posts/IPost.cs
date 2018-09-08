using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Posts
{
    public interface IPost
    {
        void ReciveMessage(object message);
    }

    public interface IPost<TMessage> : IPost
    {
        void AddAction(Action<TMessage> action);
        void ReciveMessage(TMessage message);
    }
}
