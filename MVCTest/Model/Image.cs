using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
        public bool Hidden { get; set; }

        public Image()
        {
        }

        public Image(int idImage, string urlImage, string textImage, bool hiddenImage)
        {
            Id = idImage;
            Url = urlImage;
            Text = textImage;
            Hidden = hiddenImage;
        }

        public Image(string urlImage, string textImage, bool hiddenImage = false)
        {
            Url = urlImage;
            Text = textImage;
            Hidden = hiddenImage;
        }


    }
}
