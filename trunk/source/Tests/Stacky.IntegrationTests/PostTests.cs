using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stacky.IntegrationTests
{
    [TestClass]
    public class PostTests : IntegrationTest
    {
        [TestMethod]
        public void GetPosts()
        {
            var posts = Client.GetPosts();
            Assert.IsNotNull(posts);
            Assert.IsTrue(posts.Count > 0);
        }

        [TestMethod]
        public void GetPostsWithId()
        {
            int id = 8429231;
            var post = Client.GetPosts(id);
            Assert.IsNotNull(post);
            Assert.AreEqual(id, post.PostId);
        }

        [TestMethod]
        public void GetPostRevisions()
        {
            var revisions = Client.GetPostRevisions(11);
            Assert.IsNotNull(11);
            Assert.IsTrue(revisions.Count > 0);
        }

        [TestMethod]
        public void GetPostSuggestedEdits()
        {
            var edits = Client.GetPostSuggestedEdits(8468297);
            Assert.IsNotNull(edits);
            Assert.IsTrue(edits.Count > 0);
        }
    }
}
