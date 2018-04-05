using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCTest.Model;

namespace MVCTest.Controllers
{
    public class CommentController : Controller
    {
        ApplicationContext _db;

        public CommentController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddComment(int imageId, string commentText)
        {
            int selectedImage = imageId;
            int userId = 2;
            string textMessage = commentText;

            string userName = _db.Users.Find(userId).UserName;

            Comment comment = new Comment(userId, selectedImage, textMessage);
            object obj = new
            {
                userid = comment.UserId,
                selectedImage = comment.ImageId,
                createDate = comment.CreateDate.ToShortDateString() + " " + comment.CreateDate.ToShortTimeString(),
                textMessage = comment.Text,
                username = userName
            };

            _db.Comments.Add(comment);
            _db.SaveChanges();

            return Json(obj);
        }

        public IActionResult ShowComment(int imageId)
        {
            int selectedImage = imageId;
            //int userId = 2;
            //string userName = _db.Users.Find(userId).userName;

            var comments = _db.Comments.Where(p => p.ImageId == selectedImage).ToList();
            int count = _db.Comments.Where(p => p.ImageId == selectedImage).Count();

            List<object> commentsList = new List<object>();
            for (int i = 0; i < count; i++)
            {
                int userid = comments[i].UserId;
                string userName = _db.Users.Find(userid).UserName;
                object comment = new
                {
                    userid = comments[i].UserId,
                    selectedImage = comments[i].ImageId,
                    createDate = comments[i].CreateDate.ToShortDateString() + " " + comments[i].CreateDate.ToShortTimeString(),
                    textMessage = comments[i].Text,
                    username = userName,
                    commentId = comments[i].Id
                };
                commentsList.Add(comment);
            }


            return Json(commentsList);
        }

        public void DeleteComment(int commentId)
        {
            Comment comment = _db.Comments.Find(commentId);
            if (comment != null)
            {
                _db.Comments.Remove(comment);
                _db.SaveChanges();
            }
        }
    }
}