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
        }

        [TestMethod]
        public void GetPostsWithId()
        {
            int id = 8429231;
            var post = Client.GetPosts(id);
            Assert.IsNotNull(post);
            Assert.AreEqual(id, post.PostId);
        }
    }
}
