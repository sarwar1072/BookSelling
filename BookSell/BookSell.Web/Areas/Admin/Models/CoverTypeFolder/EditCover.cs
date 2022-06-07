using Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSell.Web.Areas.Admin.Models.CoverTypeFolder
{
    public class EditCover:CoverTypeBaseModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public EditCover(ICoverTypeService coverTypeService) : base(coverTypeService) { }
        public EditCover():base()
        {
        }
        public void Edit()
        {
            var edit = new Framework.Entities.CoverType
            {
                Id=Id,
                Name = Name
            };
            _coverTypeService.EditCover(edit);
        }
        public void Load(int id)
        {
            var cover = _coverTypeService.GetId(id);
            if (cover != null)
            {
               Id = cover.Id;
                Name = cover.Name;
            }
        }

    }
}
