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
    public class FaturaManager : IFaturaService
    {

        IFaturaDal _dal;

        public FaturaManager(IFaturaDal dal)
        {
            _dal = dal;
        }

        public void Add(Fatura entity)
        {
            ValidationTools.Validate(new FaturaValidator(), entity);
            _dal.Add(entity);
        }

        public void Delete(Fatura entity)
        {
            _dal.Delete(entity);
        }

        public Fatura Get(Expression<Func<Fatura, bool>> filter)
        {
            return _dal.Get(filter);
        }

        public List<Fatura> List(Expression<Func<Fatura, bool>> filter = null)
        {
            return _dal.List(filter);
        }

        public void Update(Fatura entity)
        {
            ValidationTools.Validate(new FaturaValidator(), entity);
            _dal.Update(entity);
        }
    }
}
