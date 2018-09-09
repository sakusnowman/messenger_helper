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
            try
            {
                ReciveMessage((TMessage)message);
            }catch(InvalidCastException e)
            {
                var mes =  "This post cannot be recived " + message.GetType().ToString() + Environment.NewLine;
                mes += "Message type should be " + typeof(TMessage).ToString() + ".";
                throw new Exceptions.MessageHelperException(mes, e);
            }
        }
    }
}
