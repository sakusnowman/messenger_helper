using System;
using System.Collections.Generic;
using System.Text;
using MessengerHelper.Messengers;
using MessengerHelper.Posts;
using NUnit.Framework;

namespace MessengerHelper.Tests.MessengerHelperTests
{
    [TestFixture]
    public class MessengerHelperTests
    {
        IMessenger messenger;
        IPostsService postsService;

        [SetUp]
        public void SetUp()
        {
            postsService = new PostService();
            messenger = new MessageHub(postsService);
        }

        [Test]
        public void Action_WhenReviced()
        {
            // Arrange
            var result = "";
            var action = new Action<SimpleMessage>(m => result = m.From);
            var message = new SimpleMessage() { From = "Micheal" };
            var post = messenger.Register(action);
            // Act
            messenger.PostMessage(message);
            // Assert
            Assert.AreEqual("Micheal", result);
        }
    }
}
