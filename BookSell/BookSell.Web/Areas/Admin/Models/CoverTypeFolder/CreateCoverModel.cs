using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CoverTypeFolder
{
    public class CreateCoverModel:CoverTypeBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CreateCoverModel(ICoverTypeService coverTypeService) : base(coverTypeService) { }
        public CreateCoverModel() : base() { }
        
        public void Create()
        {
            var cover = new Framework.Entities.CoverType{
                Name=Name
            };
            _coverTypeService.AddCover(cover);
        }
    }
}
