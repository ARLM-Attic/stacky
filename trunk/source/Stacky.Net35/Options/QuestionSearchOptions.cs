namespace Stacky
{
    using System.Collections.Generic;

    public class QuestionSearchOptions : TaggedOptions<QuestionSort>
    {
        public IEnumerable<string> NotTagged = null;
        public string InTitle = null;
    }

    public class SimiliarQuestionsOptions : TaggedOptions<QuestionSort>
    {
        public IEnumerable<string> NotTagged = null;
    }
}