﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Posts
{
    public class ActionPost<TMessage> : Post<TMessage>
    {
        public override void ReciveMessage(TMessage message)
        {
            actions.ForEach(a => a(message));
        }
    }
}
