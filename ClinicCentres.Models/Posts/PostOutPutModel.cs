using System;
using System.Collections.Generic;
using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Core.DomainEntities.Paging;

namespace ClinicCentres.Models
{
    public class PostOutPutModel
    {
        public int PageNumber { get; private set; }
        public int PageCount { get; private set; }
        public int PageSize { get; private set; }
        public int RowCount { get; private set; }
        public List<PostModel> Result { get; set; }
        public static PostOutPutModel Create(List<PostModel> posts, PaginationResult<Post> paginationResult)
        {
            return new PostOutPutModel
            {
                PageNumber = paginationResult.PageNumber,
                PageSize = paginationResult.PageSize,
                PageCount = paginationResult.PageCount,
                RowCount = paginationResult.RowCount,
                Result = posts
            };
        }
    }
}
