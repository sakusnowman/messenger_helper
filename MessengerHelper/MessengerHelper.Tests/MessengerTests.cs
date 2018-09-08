using MessengerHelper.Exceptions;
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
            postService.Verify(ps => ps.CreatePost<SimpleMessage>());
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
            postService.Verify(ps => ps.CreatePost<NumberMessage>());
            Assert.IsInstanceOf<IPost<NumberMessage>>(post);
        }

        [Test]
        public void PostMessage_RegisterdSimpleMessagePost_PostRecivedMessage()
        {
            // Arrange
            var result = "";
            Action<SimpleMessage> action = new Action<SimpleMessage>(m => result = m.From);
            Mock <IPost<SimpleMessage>> mockPost = new Mock<IPost<SimpleMessage>>();
            postService.Setup(ps => ps.CreatePost<SimpleMessage>()).Returns(mockPost.Object);

            var post = messenger.Register<SimpleMessage>(action);
            var message = new SimpleMessage() { From = "John" };
            // Act
            messenger.PostMessage(message);
            // Assert
            mockPost.Verify(mp => mp.ReciveMessage((object)message));
        }

        [Test]
        public void PostMessage_RegisterdSimpleMessagePost_AllPostsAreRecivedMessage()
        {
            // Arrange
            var result = "";
            Action<SimpleMessage> action = new Action<SimpleMessage>(m => result = m.From);

            Mock<IPost<SimpleMessage>> mockPost = new Mock<IPost<SimpleMessage>>();
            postService.Setup(ps => ps.CreatePost<SimpleMessage>()).Returns(mockPost.Object);

            var post = messenger.Register(action);

            Mock<IPost<SimpleMessage>> mockPost2 = new Mock<IPost<SimpleMessage>>();
            postService.Setup(ps => ps.CreatePost<SimpleMessage>()).Returns(mockPost2.Object);

            var post2 = messenger.Register(action);

            var message = new SimpleMessage() { From = "John" };
            // Act
            messenger.PostMessage(message);
            // Assert
            mockPost.Verify(mp => mp.ReciveMessage((object)message));
            mockPost2.Verify(mp => mp.ReciveMessage((object)message));
        }

        [Test]
        public void PostMessage_NotRegisteredPost_ThrowsException()
        {
            Assert.Throws<NotRegisterdMessageException>(() => messenger.PostMessage(new SimpleMessage()));
        }

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