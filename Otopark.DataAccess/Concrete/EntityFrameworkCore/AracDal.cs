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
    public class AracDal:IAracDal
    {
        OtoparkDbContext _context;

        public AracDal(OtoparkDbContext context)
        {
            _context = context;
        }

        public void Add(Arac entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(Arac entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Arac Get(Expression<Func<Arac, bool>> filter)
        {
            return _context.Araclar.Include(c => c.Fatura).FirstOrDefault(filter);
        }

        public List<Arac> List(Expression<Func<Arac, bool>> filter = null)
        {
            return filter!=null ? _context.Araclar.Include(c => c.Fatura).Where(filter).ToList() : _context.Araclar.Include(c=>c.Fatura).ToList();
        }

        public void Update(Arac entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
