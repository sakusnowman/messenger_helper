using System;
using System.Collections.Generic;
using System.Text;
using MessengerHelper.Posts;

namespace MessengerHelper.Messengers
{
    public class MessageHub : IMessenger
    {
        readonly IPostsService postService;

        public MessageHub(IPostsService postService)
        {
            this.postService = postService;
        }

        public void PostMessage<TMessage>(TMessage message)
        {
        }

        public IPost<TMessage> Register<TMessage>(Action<TMessage> action)
        {
            var actionPost = postService.CreatePost<TMessage>();
            actionPost.AddAction(action);
            return actionPost;
        }
    }
}
