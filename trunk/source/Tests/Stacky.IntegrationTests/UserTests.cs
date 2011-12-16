using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class UserTests : IntegrationTest
    {
        [TestMethod]
        public void User_GetUsers()
        {
            var users = Client.GetUsers();
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void User_GetUsers_ContainsPagingInformation()
        {
            var users = Client.GetUsers();
            Assert.IsNotNull(users);
            Assert.IsTrue(users.PageSize > 0);
            Assert.IsTrue(users.CurrentPage > 0);
            Assert.IsTrue(users.TotalItems > 0);
        }

        //[TestMethod]
        //public void User_GetUserMentions()
        //{
        //    var mentions = Client.GetUserMentions(22656);
        //    Assert.IsNotNull(mentions);
        //}

        //[TestMethod]
        //public void User_GetUserMentions_ContainsPagingInformation()
        //{
        //    var mentions = Client.GetUserMentions(22656);
        //    Assert.IsNotNull(mentions);
        //    Assert.IsTrue(mentions.PageSize > 0);
        //    Assert.IsTrue(mentions.CurrentPage > 0);
        //    Assert.IsTrue(mentions.TotalItems > 0);
        //}

        [TestMethod]
        public void User_GetQuestionAnswers()
        {
            var answers = Client.GetQuestionAnswers(31415);
            Assert.IsNotNull(answers);
        }

        [TestMethod]
        public void User_GetQuestionAnswers_ContainsPagingInformation()
        {
            var answers = Client.GetQuestionAnswers(31415);
            Assert.IsNotNull(answers);
            Assert.IsTrue(answers.PageSize > 0);
            Assert.IsTrue(answers.CurrentPage > 0);
            Assert.IsTrue(answers.TotalItems > 0);
        }

        [TestMethod]
        public void User_GetUserTimeline()
        {
            var events = Client.GetUserTimeline(22656);
            Assert.IsNotNull(events);
        }

        [TestMethod]
        public void User_GetUserReputation()
        {
            var rep = Client.GetUserReputation(22656);
            Assert.IsNotNull(rep);
        }

        [TestMethod]
        public void User_Returns_Badge_Counts()
        {
            var user = Client.GetUser(22656);

            Assert.IsNotNull(user);
            Assert.IsNotNull(user.BadgeCounts);
            Assert.IsTrue(user.BadgeCounts.Bronze > 0);
        }

        [TestMethod]
        public void GetModerators()
        {
            var users = Client.GetModerators();
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void GetElectedModerators()
        {
            var users = Client.GetElectedModerators();
            Assert.IsNotNull(users);
        }

        //[TestMethod]
        //public void User_GetTopTaggedAnswers()
        //{
        //    var answers = Client.GetTopTaggedAnswers(646, "c#");
        //    Assert.IsNotNull(answers);
        //}

        //[TestMethod]
        //public void User_GetTopTaggedQuestions()
        //{
        //    var questions = Client.GetTopTaggedQuestions(646, "c#");
        //    Assert.IsNotNull(questions);
        //}

        [TestMethod]
        public void User_GetTopAnswerTags()
        {
            var topTags = Client.GetUserTopAnswersByTag(646);
            Assert.IsNotNull(topTags);
        }

        [TestMethod]
        public void User_GetTopQuestionTags()
        {
            var topTags = Client.GetUserTopQuestionsByTag(646);
            Assert.IsNotNull(topTags);
        }
    }
}