using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class AnswerTests : IntegrationTest
    {
        [TestMethod]
        public void Answer_GetQuestionAnswers()
        {
            var answers = Client.GetQuestionAnswers(31415);
            Assert.IsNotNull(answers);
        }

        [TestMethod]
        public void Answer_GetQuestionAnswers_ContainsPagingInformation()
        {
            var answers = Client.GetQuestionAnswers(31415);
            Assert.IsNotNull(answers);
            Assert.IsTrue(answers.PageSize > 0);
            Assert.IsTrue(answers.CurrentPage > 0);
            Assert.IsTrue(answers.TotalItems > 0);
        }

        [TestMethod]
        public void Answer_GetAnswer()
        {
            var answer = Client.GetAnswer(11738);
            Assert.IsNotNull(answer);
        }

        [TestMethod]
        public void Answer_GetAnswers()
        {
            var answers = Client.GetAnswers(new int[] { 11738, 122784 });
            Assert.IsNotNull(answers);
        }

        [TestMethod]
        public void Answer_GetAnswers_NoParams()
        {
            var answers = Client.GetAnswers();
            Assert.IsNotNull(answers);
        }
    }
}
