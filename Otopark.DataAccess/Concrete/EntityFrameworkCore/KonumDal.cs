using Otopark.DataAccess.Abstract;
using Otopark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;

namespace Otopark.DataAccess.Concrete.EntityFrameworkCore
{
    public class KonumDal:IKonumDal
    {
        OtoparkDbContext _context;

        public KonumDal(OtoparkDbContext context)
        {
            _context = context;
        }

        public void Add(Konum entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(Konum entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Konum Get(Expression<Func<Konum, bool>> filter)
        {
            return _context.Konumlar.Include(c => c.Arac).FirstOrDefault(filter);
        }

        public List<Konum> List(Expression<Func<Konum, bool>> filter = null)
        {
            return filter == null ? _context.Konumlar.Include(c => c.Arac).ToList() : _context.Konumlar.Include(c => c.Arac).Where(filter).ToList();
        }

        public void Update(Konum entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
