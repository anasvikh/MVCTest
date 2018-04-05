using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Model
{
    public class Like
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int UserId { get; set; }

        public Like()
        {
        }

        public Like(int userId, int imageId)
        {
            UserId = userId;
            ImageId = ImageId;
        }
    }
}
