using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Data.Contexts;
using AbcYazilim.OgrenciTakip.Dll.Base;
using AbcYazilim.OgrenciTakip.Dll.Interfaces;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AbcYazilim.OgrenciTakip.Model.Entities.Base;

namespace AbcYazilim.OgrenciTakip.Dll.General
{
    public class IlBll : BaseBll<Il, OgrenciTakipContext>, IBaseGenelBll
    {
        public IlBll() { }

        public IlBll(Control ctrl) : base(ctrl) { }



        public BaseEntity Single(Expression<Func<Il, bool>> filter)
        {
            return BaseSingle(filter, x => x
            //{
            //    Id = x.Id,
            //    Kod = x.Kod,
            //    IlAdi = x.IlAdi,
            //    Aciklama = x.Aciklama,
            //    Durum = x.Durum
            //}
            );
        }

        public IEnumerable<BaseEntity> List(Expression<Func<Il, bool>> filter)
        {
            return BaseList(filter, x => x
            //{
            //    Id = x.Id,
            //    Kod = x.Kod,
            //    IlAdi = x.IlAdi,
            //    Aciklama = x.Aciklama,
            //    //  Durum = x.Durum

            //}
            ).OrderBy(x => x.Kod).ToList();
        }

        //public bool Insert(BaseEntity entity, Expression<Func<Ilce, bool>> filter)
        //{
        //    return BaseInsert(entity, x => x.Kod == entity.Kod);
        //}

        //public bool Update(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<Ilce, bool>> filter)
        //{
        //    return BaseUpdate(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod);
        //}

        public bool Insert(BaseEntity entity)
        {
            return BaseInsert(entity, x => x.Kod == entity.Kod);
        }

        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity)
        {
            return BaseUpdate(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod);
        }

        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, KartTuru.Il);
        }

        public string YeniKodVer()
        {
            return BaseYeniKodVer(KartTuru.Il, x => x.Kod);
        }
    }
}