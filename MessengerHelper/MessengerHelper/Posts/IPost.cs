using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Posts
{
    public interface IPost<TMessage>
    {
        void AddAction(Action<TMessage> action);
    }
}
