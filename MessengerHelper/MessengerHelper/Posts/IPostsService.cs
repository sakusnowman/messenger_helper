using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerHelper.Posts
{
    public interface IPostsService
    {
        IPost<TMessage> CreatePost<TMessage>();
    }
}
