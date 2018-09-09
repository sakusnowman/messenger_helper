using MessengerHelper.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Messengers
{
    public interface IMessenger
    {
        /// <summary>
        /// Register post in messenger.
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="action"></param>
        /// <returns>Returns value is same as registered in messenger.</returns>
        IPost<TMessage> Register<TMessage>(Action<TMessage> action, bool onTaskRun = false);

        /// <summary>
        /// Post to registered post which can be recived message type.
        /// </summary>
        /// <param name="message"></param>
        void PostMessage(object message);
    }
}
