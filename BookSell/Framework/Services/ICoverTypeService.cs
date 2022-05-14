using Framework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    public interface ICoverTypeService:IDisposable
    {
        void AddCover(CoverType coverType);
        CoverType DeleteCover(int id);
        void EditCover(CoverType coverType);
        CoverType GetId(int id);
        (IList<CoverType> coverTypes, int total, int totalDisplay) GetCoverType(int pageindex, int Pagesize,
                                                                                    string searchText, string orderBy);
    }
}
