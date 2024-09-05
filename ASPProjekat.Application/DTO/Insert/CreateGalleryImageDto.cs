using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Application.DTO.Insert
{
    public class CreateGalleryImageDto
    {
        public int GalleryId { get; set; }
        public IFormFile Src { get; set; }
    }
}
