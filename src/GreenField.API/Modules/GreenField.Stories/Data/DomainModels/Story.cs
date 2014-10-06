using GreenField.Framework.Data.DomainModels;
using System.Collections.Generic;

namespace GreenField.Books.Data.DomainModels
{
    public class Story : BaseEntity
    {
        private ICollection<StoryEntityPicture> _storyEntityPictures;

        public virtual ICollection<StoryEntityPicture> EntityEntityPictures
        {
            get { return _storyEntityPictures ?? (_storyEntityPictures = new List<StoryEntityPicture>()); }
            protected set { _storyEntityPictures = value; }
        }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Cover { get; set; }
        public string Desc { get; set; }
        public int Duration { get; set; }
        public long TellerId { get; set; }
        public virtual Teller Teller { get; set; }
    }

}
