using Microsoft.EntityFrameworkCore;
using Otopark.DataAccess.Abstract;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Otopark.DataAccess.Concrete.EntityFrameworkCore
{
    public class FaturaDal:IFaturaDal
    {
        OtoparkDbContext _context;

        public FaturaDal(OtoparkDbContext context)
        {
            _context = context;
        }

        public void Add(Fatura entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(Fatura entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Fatura Get(Expression<Func<Fatura, bool>> filter)
        {
            return _context.Faturalar.Include(c=>c.Arac).FirstOrDefault(filter);
        }

        public List<Fatura> List(Expression<Func<Fatura, bool>> filter = null)
        {
            return filter != null ? _context.Faturalar.Include(c => c.Arac).Where(filter).ToList() : _context.Faturalar.Include(c => c.Arac).ToList();
        }

        public void Update(Fatura entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
