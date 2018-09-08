using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Posts
{
    public interface IPost
    {
        /// <summary>
        /// Reciver actions by message.
        /// </summary>
        /// <param name="message">It should be registered type of message.</param>
        void ReciveMessage(object message);
    }

    public interface IPost<TMessage> : IPost
    {
        /// <summary>
        /// Actions which act when recived message.
        /// </summary>
        /// <param name="action"></param>
        void AddAction(Action<TMessage> action);

        /// <see cref="IPost.ReciveMessage(object)"/>
        void ReciveMessage(TMessage message);
    }
}
