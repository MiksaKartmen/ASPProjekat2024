using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.DTO.Gets
{
    public class GalleryImageDto : BaseDto
    {
        public int GalleryId { get; set; }
        public string Src { get; set; }
    }
}
