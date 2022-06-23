using System;
using System.Linq.Expressions;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AbcYazilim.OgrenciTakip.Model.Entities.Base;

namespace AbcYazilim.OgrenciTakip.Dll.Interfaces
{
    public interface IBaseGenelBll
    {
        bool Insert(BaseEntity entity);
        bool Update(BaseEntity oldEntity, BaseEntity currentEntity);
        // bool Delete(BaseEntity entity);
        // string YeniKodVer(Expression<Func<Ilce, bool>> filter);
        string YeniKodVer();

    }
}