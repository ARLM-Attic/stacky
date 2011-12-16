using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/top-tag
    /// </summary>
    public class TopTag : Entity
    {
        private string tagName;
        [JsonProperty("tag_name")]
        public string TagName
        {
            get { return tagName; }
            set { tagName = value; NotifyOfPropertyChange(() => TagName); }
        }

        private int questionScore;
        [JsonProperty("question_score")]
        public int QuestionScore
        {
            get { return questionScore; }
            set { questionScore = value; NotifyOfPropertyChange(() => QuestionScore); }
        }

        private int questionCount;
        [JsonProperty("question_count")]
        public int QuestionCount
        {
            get { return questionCount; }
            set { questionCount = value; NotifyOfPropertyChange(() => QuestionCount); }
        }

        private int answerScore;
        [JsonProperty("answer_score")]
        public int AnswerScore
        {
            get { return answerScore; }
            set { answerScore = value; NotifyOfPropertyChange(() => AnswerScore); }
        }

        private int answerCount;
        [JsonProperty("answer_count")]
        public int AnswerCount
        {
            get { return answerCount; }
            set { answerCount = value; NotifyOfPropertyChange(() => AnswerCount); }
        }
    }
}