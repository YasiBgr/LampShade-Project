using _0_FramBase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.SliderAgg
{
   public class Slide:EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsRemove { get; private set; }
        public string Text { get; private set; }
        public string Title { get; private set; }
        public string Heading { get; private set; }
        public string BtnText { get; private set; }

        public Slide(string picture, string pictureAlt,
            string pictureTitle, string text, string title,
            string heading, string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Text = text;
            Title = title;
            Heading = heading;
            BtnText = btnText;
            IsRemove = false;
        }

        public void Edit(string picture, string pictureAlt,
            string pictureTitle, string text, string title,
            string heading, string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Text = text;
            Title = title;
            Heading = heading;
            BtnText = btnText;
            
        }

        public void IsRmoved()
        {
            IsRemove = true;
        }
        public void Restore()
        {
            IsRemove = false;
        }
    }
}
