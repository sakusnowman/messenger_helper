using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MessengerHelper.Posts
{
    public class TaskPost<TMessage> : Post<TMessage>
    {
        public override void ReciveMessage(TMessage message)
        {
            Task.Run(() => actions.ForEach(a => a(message)));
        }
    }
}
