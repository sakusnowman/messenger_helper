using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Posts
{
    class PostService : IPostsService
    {
        public IPost<TMessage> CreatePost<TMessage>()
        {
            return new ActionPost<TMessage>();
        }
    }
}
