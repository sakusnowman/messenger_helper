using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Posts
{
    class ActionPost<TMessage> : IPost<TMessage>
    {
        public void AddAction(Action<TMessage> action)
        {
        }

        public void ReciveMessage(TMessage message)
        {
        }

        public void ReciveMessage(object message)
        {
        }
    }
}
