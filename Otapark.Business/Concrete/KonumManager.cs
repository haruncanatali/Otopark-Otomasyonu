using Otapark.Business.Abstract;
using Otapark.Business.Validation.FluentValidation;
using Otopark.DataAccess.Abstract;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Otapark.Business.Concrete
{
    public class KonumManager : IKonumService
    {
        IKonumDal _dal;

        public KonumManager(IKonumDal dal)
        {
            _dal = dal;
        }

        public void Add(Konum entity)
        {
            ValidationTools.Validate(new KonumValidator(), entity);
            _dal.Add(entity);
        }

        public void Delete(Konum entity)
        {
            _dal.Delete(entity);
        }

        public Konum Get(Expression<Func<Konum, bool>> filter)
        {
            return _dal.Get(filter);
        }

        public List<Konum> List(Expression<Func<Konum, bool>> filter = null)
        {
            return _dal.List(filter);
        }

        public void Update(Konum entity)
        {
            ValidationTools.Validate(new KonumValidator(), entity);
            _dal.Update(entity);
        }
    }
}
