using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Posts
{
    public abstract class Post<TMessage> : IPost<TMessage>
    {
        public abstract void ReciveMessage(TMessage message);

        protected readonly List<Action<TMessage>> actions;

        public Post()
        {
            actions = new List<Action<TMessage>>();
        }

        public void AddAction(Action<TMessage> action)
        {
            actions.Add(action);
        }

        public void ReciveMessage(object message)
        {
            ReciveMessage((TMessage)message);
        }
    }
}
