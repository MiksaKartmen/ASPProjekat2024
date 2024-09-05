using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Domain
{
    public class Gallery : Entity
    {
        public string Title { get; set; }

        public virtual ICollection<GalleryImage> GalleryImages { get; set; } = new HashSet<GalleryImage>();
    }
}
