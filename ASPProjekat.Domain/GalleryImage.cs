using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Domain
{
    public class GalleryImage : Entity
    {
        public string Src { get; set; }
        public int GalleryId { get; set; }

        public virtual Gallery Gallery { get; set; }

    }
}
