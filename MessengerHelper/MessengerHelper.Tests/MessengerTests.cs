using MessengerHelper.Messengers;
using MessengerHelper.Posts;
using Moq;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class MessengerTests
    {
        IMessenger messenger;
        Mock<IPostsService> postService;

        [SetUp]
        public void Setup()
        {
            postService = new Mock<IPostsService>();
            messenger = new MessageHub(postService.Object);
        }

        [Test]
        public void Register_SimpleMessage_MakeSimpleMessageActionPost()
        {
            var result = "";
            Mock<IPost<SimpleMessage>> mockPost = new Mock<IPost<SimpleMessage>>();
            postService.Setup(ps => ps.CreatePost<SimpleMessage>()).Returns(mockPost.Object);
            // Act
            var post = messenger.Register<SimpleMessage>((SimpleMessage m) => result = "A");
            // Assert
            Assert.IsInstanceOf<IPost<SimpleMessage>>(post);
        }

        [Test]
        public void Register_NumberMessage_MakeNumberMessageActionPost()
        {
            var result = "";
            Mock<IPost<NumberMessage>> mockPost = new Mock<IPost<NumberMessage>>();
            postService.Setup(ps => ps.CreatePost<NumberMessage>()).Returns(mockPost.Object);
            // Act
            var post = messenger.Register<NumberMessage>((NumberMessage m) => result = "A");
            // Assert
            Assert.IsInstanceOf<IPost<NumberMessage>>(post);
        }

        //[Test]
        //public void PostMessage()
        //{
        //    // Arrange
        //    var result = "";
        //    Action<SimpleMessage> action = new Action<SimpleMessage>(m => result = m.From);
        //    var post = messenger.Register<SimpleMessage>(action);
        //    // Act
        //    messenger.PostMessage<SimpleMessage>(new SimpleMessage() { From = "John" });
        //    // Assert
        //    Assert.AreEqual("John", result);
        //}


        public class SimpleMessage
        {
            public string From { get; set; }
        }

        public class NumberMessage
        {
            public int Num { get; set; }
        }
    }
}