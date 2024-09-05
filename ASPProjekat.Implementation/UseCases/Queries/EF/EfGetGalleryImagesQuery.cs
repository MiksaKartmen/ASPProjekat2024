using ASPProjekat.Application.DTO.Gets;
using ASPProjekat.Application.DTO.Searches;
using ASPProjekat.Application.UseCases.Queries;
using ASPProjekat.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.UseCases.Queries.EF
{
    public class EfGetGalleryImagesQuery : EfUseCase, IGetGalleryImagesQuery
    {
         
        public EfGetGalleryImagesQuery(ASPContext context) : base(context)
        {    
        }

        public int Id => 33;

        public string Name => "Get images";

        public string Description => "Get images";

        public IEnumerable<GalleryImageDto> Execute(BaseSearch search)
        {
            var query = Context.GalleryImages.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Gallery.Title.ToLower().Contains(search.Keyword.ToLower()));
            }

           
            return query.Select(x => new GalleryImageDto
            {
                GalleryId = x.GalleryId,
                Src = x.Src

            });
        }
    }
}
