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
    public class AracManager : IAracService
    {

        IAracDal _dal;

        public AracManager(IAracDal dal)
        {
            _dal = dal;
        }

        public void Add(Arac entity)
        {
            ValidationTools.Validate(new AracValidator(), entity);
            _dal.Add(entity);
        }

        public void Delete(Arac entity)
        {
            _dal.Delete(entity);
        }

        public Arac Get(Expression<Func<Arac, bool>> filter)
        {
             return  _dal.Get(filter);
        }

        public List<Arac> List(Expression<Func<Arac, bool>> filter = null)
        {
            return _dal.List(filter);
        }

        public void Update(Arac entity)
        {
            ValidationTools.Validate(new AracValidator(), entity);
            _dal.Update(entity);
        }
    }
}
