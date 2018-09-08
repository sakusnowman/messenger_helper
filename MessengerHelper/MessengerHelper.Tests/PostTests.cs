using System;
using System.Collections.Generic;
using System.Text;
using MessengerHelper.Posts;
using NUnit.Framework;

namespace MessengerHelper.Tests
{
    [TestFixture]
    public class PostTests
    {
        [Test]
        public void ReciveMessage_RegistedSomeActions_ActAllAction()
        {
            // Arrange
            var result = "";
            var result2 = "";
            var message = new SimpleMessage() { From = "John" };
            IPost<SimpleMessage> post = new ActionPost<SimpleMessage>();
            post.AddAction(m => result = m.From);
            post.AddAction(m => result2 = m.From + "2");
            // Act
            post.ReciveMessage(message);
            // Assert
            Assert.AreEqual("John", result);
            Assert.AreEqual("John2", result2);
        }

        [Test]
        public void ReviceMessage_NotCorrectMessage_ThrowConvertException()
        {
            // Arrange
            var result = "";
            IPost<SimpleMessage> post = new ActionPost<SimpleMessage>();
            post.AddAction(m => result = m.From);
            var message = new NumberMessage() { Num = 3 };

            // Assert
            Assert.Throws<InvalidCastException>(() => post.ReciveMessage(message));
        }
    }
}
