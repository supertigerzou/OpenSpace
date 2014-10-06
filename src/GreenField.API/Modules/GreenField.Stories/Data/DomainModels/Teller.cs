using GreenField.Framework.Data.DomainModels;
using System.Collections.Generic;

namespace GreenField.Books.Data.DomainModels
{
    public class Teller : Person
    {
        private ICollection<Story> _stories;
        private ICollection<TellerEntityPicture> _tellerEntityPictures;

        public virtual ICollection<TellerEntityPicture> EntityEntityPictures
        {
            get { return _tellerEntityPictures ?? (_tellerEntityPictures = new List<TellerEntityPicture>()); }
            protected set { _tellerEntityPictures = value; }
        }

        public virtual ICollection<Story> Stories
        {
            get { return _stories ?? (_stories = new List<Story>()); }
            protected set { _stories = value; }
        }
    }
}
