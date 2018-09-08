using System;
using System.Collections.Generic;
using System.Text;
using MessengerHelper.Exceptions;
using MessengerHelper.Posts;

namespace MessengerHelper.Messengers
{
    public class MessageHub : IMessenger
    {
        readonly IPostsService postService;
        readonly Dictionary<Type, List<IPost>> registeredPosts;

        public MessageHub(IPostsService postService)
        {
            this.postService = postService;
            registeredPosts = new Dictionary<Type, List<IPost>>();
        }

        public void PostMessage(object message)
        {
            if (registeredPosts.ContainsKey(message.GetType()) == false)
                throw new NotRegisterdMessageException();
            registeredPosts[message.GetType()].ForEach(rp => rp.ReciveMessage(message));
        }

        public IPost<TMessage> Register<TMessage>(Action<TMessage> action)
        {
            var actionPost = postService.CreatePost<TMessage>();
            actionPost.AddAction(action);
            AddPost(actionPost, typeof(TMessage));
            return actionPost;
        }

        private void AddPost(IPost post, Type type)
        {
            if (registeredPosts.ContainsKey(type) == false)
                registeredPosts.Add(type, new List<IPost>());
            registeredPosts[type].Add(post);
        }
    }
}
