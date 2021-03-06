﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Posts
{
    public class PostService : IPostsService
    {
        public IPost<TMessage> CreatePost<TMessage>()
        {
            return new ActionPost<TMessage>();
        }

        public IPost<TMessage> CreateTaskPost<TMessage>()
        {
            return new TaskPost<TMessage>();
        }
    }
}
