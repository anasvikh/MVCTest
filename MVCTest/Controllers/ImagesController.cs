using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCTest.Model;
using Newtonsoft.Json;

namespace MVCTest.Controllers
{
    public class ImagesController : Controller
    {
        ApplicationContext _db;
        IHostingEnvironment _appEnvironment;

        public ImagesController(ApplicationContext db, IHostingEnvironment env)
        {
            _db = db;
            _appEnvironment = env;
        }

        public IActionResult Index()
        {
            //Image image1 = new Image("1.jpg", "“A journey is best measured in friends, rather than miles.” – Tim Cahill"); //Image image2 = new Image("2.jpg", "“We travel, some of us forever, to seek other places, other lives, other souls.” – Anais Nin"); //Image image3 = new Image("3.jpg", "“To awaken alone in a strange town is one of the pleasantest sensations in the world.” – Freya Stark"); //Image image4 = new Image("4.jpg", "“A mind that is stretched by a new experience can never go back to its old dimensions.” – Oliver Wendell Holmes"); //Image image5 = new Image("5.jpg", "“The world is a book, and those who do not travel read only one page.” – Saint Augustine"); //Image image6 = new Image("6.jpg", "“Man cannot discover new oceans unless he has the courage to lose sight of the shore.” – Andre Gide"); //Image[] images = new Image[3] { image1, image2, image3 }; //db.Images.Add(image1); //db.Images.Add(image2); //db.Images.Add(image3); //db.Images.Add(image4); //db.Images.Add(image5); //db.Images.Add(image6); //db.SaveChanges();
            var images = _db.Images.Where(i => i.Hidden == false).ToList(); 
            return Json(images);
        }

        public void HideImage(int imageId)
        {
            int selectedImage = imageId;
            Image image = _db.Images.Find(selectedImage);
            image.Hidden = true;
            _db.SaveChanges();
        }

        public IActionResult LikeImage(int imageId)
        {
            int selectedImage = imageId;
            int userId = 2;

            Like like = _db.Likes.FirstOrDefault(p => p.UserId == userId && p.ImageId == selectedImage);
            if (like == null)
            {
                like = new Like(userId, imageId);
                _db.Likes.Add(like);
                _db.SaveChanges();
            }

            int likes = _db.Likes.Where(p => p.ImageId == selectedImage).Count();
            return Json(likes);
        }

        public IActionResult DislikeImage(int imageId)
        {
            int selectedImage = imageId;
            int userId = 2;

            Like like = _db.Likes.Where(p => p.UserId == userId && p.ImageId == selectedImage).FirstOrDefault();
            if (like != null)
            {
                _db.Likes.Remove(like);
            }
            
            _db.SaveChanges();

            int likes = _db.Likes.Where(p => p.ImageId == selectedImage).Count();
            return Json(likes);
        }

        public IActionResult LikeShow(int imageId)
        {
            int selectedImage = imageId;
            int likes = _db.Likes.Where(p => p.ImageId == selectedImage).Count();
            return Json(likes);
        }

        public IActionResult LikeOrNot(int imageId)
        {
            int selectedImage = imageId;
            int userId = 2;

            var number = _db.Likes.Where(p => p.UserId==userId && p.ImageId==selectedImage).Count();
            return Json(number);
        }

        //[HttpPost("Upload")]
        //public async Task<IActionResult> Upload(List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);

        //    // full path to file in temp location
        //    var filePath = Path.GetTempFileName();

        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }


        //    // process uploaded files
        //    // Don't rely on or trust the FileName property without validation.

        //    return Ok(new { count = files.Count, size, filePath });
        //}

        [HttpPost("Images")]
        public async Task<IActionResult> LoadImage(IFormFile uploadedFile, IFormFile textImage)
        {
            if (uploadedFile != null)
            {

                // путь к папке Files
                string path = "/images/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                Image img = new Image(uploadedFile.FileName, "Это текст для картиночки", false);
                _db.Images.Add(img);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

    }
}