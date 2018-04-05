using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Text { get; set; }

        public Comment()
        {
            
        }

        public Comment(int userId, int imageId, string text)
        {
            UserId = userId;
            ImageId = imageId;
            Text = text;
        }
    }
}
