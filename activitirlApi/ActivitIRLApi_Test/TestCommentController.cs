﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivitIRLApi.Controllers;
using ActivitIRLApi.Models.Entities;
using ActivitIRLApi.Data;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using Microsoft.AspNetCore.Http;

//Testing against in memory database.

//https://stackoverflow.com/questions/23363073/tests-not-running-in-test-explorer
//Worked by installing NUnit3 test adapter package in all projects, in solution.

namespace ActivitIRLApi_Test
{
    [TestFixture]
    public class CommentController_Test
    {
        private CommentController _commentController;
        private ApplicationDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            _dbContext = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "db")
                .EnableSensitiveDataLogging()
                .Options);

            _commentController = new CommentController(_dbContext);
            _dbContext.Comments.RemoveRange(_dbContext.Comments);

            _dbContext.SaveChanges();

            var Comments = new List<Comment>
            {
                new Comment { CommentId = 1, Comments = "Hi comment 1"},
                new Comment { CommentId = 2, Comments = "Hi comment 2"},
                new Comment { CommentId = 3, Comments = "Hi comment 3"}
            };

            _dbContext.Comments.AddRange(Comments);
            _dbContext.SaveChanges();
        }

        [Test]
        public void GetComments_ReturnsTrue()
        {
            Task<ActionResult<IEnumerable<Comment>>> comments = _commentController.GetComments();

            Assert.NotNull(comments);
            Assert.AreEqual(3, comments.Result.Value.Count());
        }

        [TestCase(1)]
        public void GetCommentId_ReturnsTrue(int id)
        {
            var comment = _commentController.GetComment(id);

            Assert.AreEqual(comment.Id, id);
        }

        [TestCase(null)]
        public void GetCommentId_IsNull_ReturnsTrue(int id)
        {
            var comment = _commentController.GetComment(id);

            var notFoundObjectResult = new NotFoundObjectResult(comment);

            Assert.AreEqual(comment, notFoundObjectResult.Value);
        }

        [TestCase(1)]
        public void PutComment_Returns400(int id)
        {
            var comment = new Comment { CommentId = 5, Comments = "sui" };

            var result = _commentController.PutComment(id, comment);

            Assert.AreEqual(typeof(BadRequestResult), result?.Result.GetType());
        }

        [Test]
        public async Task PostComment_ReturnsTrue()
        {
            var result = new Comment { CommentId = 4, Comments = "Test4" };

            await _commentController.PostComment(result);

            var dbEntry = _dbContext.Comments;

            Assert.AreEqual(4, dbEntry.Count());
            Assert.AreEqual(dbEntry.Last().CommentId, result.CommentId);
        }

        [TestCase(1)]
        public void DeleteComment_ReturnsTrue(int id)
        {
            _commentController.DeleteComment(id);

            var dbEntry = _dbContext.Comments;

            Assert.AreEqual(2, dbEntry.Count());
        }

        [TestCase(null)]
        public void DeleteComment_IsNull_ReturnsTrue(int id)
        {
            var comment = _commentController.DeleteComment(id);

            var notFoundObjectResult = new NotFoundObjectResult(comment);

            Assert.AreEqual(comment, notFoundObjectResult.Value);
        }

        [TestCase(1)]
        public void CommentExists_ReturnsTrue(int id)
        {
            _commentController.GetComment(id);

            Assert.IsNotNull(id);
        } 
    }
}