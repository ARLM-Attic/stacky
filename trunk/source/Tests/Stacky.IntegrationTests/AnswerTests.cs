using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class AnswerTests : IntegrationTest
    {
        [TestMethod]
        public void Answer_GetAnswers_NoParams()
        {
            var answers = Client.GetAnswers();
            Assert.IsNotNull(answers);
        }

        protected T? Enum<T>()
            where T : struct
        {
            return GenerateValue.NullableEnum<T>();
        }

        protected SortDirection? SortDirection
        {
            get { return GenerateValue.NullableEnum<SortDirection>(); }
        }

        protected int? Page
        {
            get
            {
                return GenerateValue.NullableInt32(1, 250);
            }
        }

        protected int? PageSize
        {
            get
            {
                return GenerateValue.NullableInt32(1, 250);
            }
        }

        protected DateTime? FromDate
        {
            get { return GenerateValue.NullableDateTime(); }
        }

        protected DateTime? ToDate
        {
            get { return GenerateValue.NullableDateTime(); }
        }

        protected DateTime? DateMin
        {
            get { return GenerateValue.NullableDateTime(); }
        }

        protected DateTime? DateMax
        {
            get { return GenerateValue.NullableDateTime(); }
        }

        protected string Filter
        {
            get { return null; }
        }

        [TestMethod]
        public void Answer_GetAnswers_RandomParams()
        {
            var answers = Client.GetAnswers(Enum<AnswerSort>(), SortDirection, Page, PageSize, FromDate, ToDate, DateMin, DateMax, Filter);
            Assert.IsNotNull(answers);
        }

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

        
    }
}
