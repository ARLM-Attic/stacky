using System;
using Newtonsoft.Json;

namespace Stacky
{
    public class QuestionTimeline : Entity
    {
        private TimelineType timelineType;
        [JsonProperty("timeline_type")]
        public TimelineType TimelineType
        {
            get { return timelineType; }
            set { timelineType = value; NotifyOfPropertyChange(() => TimelineType); }
        }

        private int questionId;
        [JsonProperty("question_id")]
        public int QuestionId
        {
            get { return questionId; }
            set { questionId = value; NotifyOfPropertyChange(() => QuestionId); }
        }

        private int postId;
        [JsonProperty("post_id")]
        public int PostId
        {
            get { return postId; }
            set { postId = value; NotifyOfPropertyChange(() => PostId); }
        }

        private int commentId;
        [JsonProperty("comment_id")]
        public int CommentId
        {
            get { return commentId; }
            set { commentId = value; NotifyOfPropertyChange(() => CommentId); }
        }

        private Guid revisionGuid;
        [JsonProperty("revision_guid")]
        public Guid RevisionGuid
        {
            get { return revisionGuid; }
            set { revisionGuid = value; NotifyOfPropertyChange(() => RevisionGuid); }
        }

        private int upVoteCount;
        [JsonProperty("up_vote_count")]
        public int UpVoteCount
        {
            get { return upVoteCount; }
            set { upVoteCount = value; NotifyOfPropertyChange(() => UpVoteCount); }
        }

        private int downVoteCount;
        [JsonProperty("down_vote_count")]
        public int DownVoteCount
        {
            get { return downVoteCount; }
            set { downVoteCount = value; NotifyOfPropertyChange(() => DownVoteCount); }
        }

        private DateTime creationDate;
        [JsonProperty("creation_date")]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; NotifyOfPropertyChange(() => CreationDate); }
        }

        private ShallowUser user;
        [JsonProperty("user")]
        public ShallowUser User
        {
            get { return user; }
            set { user = value; NotifyOfPropertyChange(() => User); }
        }

        private ShallowUser owner;
        [JsonProperty("owner")]
        public ShallowUser Owner
        {
            get { return owner; }
            set { owner = value; NotifyOfPropertyChange(() => Owner); }
        }
    }
}