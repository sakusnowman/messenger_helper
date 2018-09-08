using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Posts
{
    public class ActionPost<TMessage> : IPost<TMessage>
    {
        readonly List<Action<TMessage>> actions;

        public ActionPost()
        {
            actions = new List<Action<TMessage>>();
        }

        public void AddAction(Action<TMessage> action)
        {
            actions.Add(action);
        }

        public void ReciveMessage(TMessage message)
        {
            actions.ForEach(a => a(message));
        }

        public void ReciveMessage(object message)
        {
            try
            {
                ReciveMessage((TMessage)message);
            }catch(InvalidCastException e)
            {
                var mes = "This cannot be recived " + message.GetType().ToString() + Environment.NewLine + ".";
                mes += "This can recive " + typeof(TMessage).ToString() + ".";
                throw new Exceptions.MessageHelperException(mes);
            }
        }
    }
}
