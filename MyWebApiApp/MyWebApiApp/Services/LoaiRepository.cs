using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Services
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDBContext _context;

        public LoaiRepository(MyDBContext context) { _context = context; }
        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new Loai()
            {
                tenLoai = loai.tenLoai
            };
            _context.Add(_loai);
            _context.SaveChanges();
            return new LoaiVM
            {
                maLoai = _loai.maLoai,
                tenLoai = _loai.tenLoai
            };
        }

        public List<LoaiVM> getAll()
        {
            var loais = _context.Loais.Select(lo => new LoaiVM
            {
                maLoai = lo.maLoai,
                tenLoai = lo.tenLoai
            });
            return loais.ToList();
        }

        public LoaiVM getById(int id)
        {
            var loai = _context.Loais.FirstOrDefault(lo => lo.maLoai == id);
            if (loai != null)
            {
                return new LoaiVM
                {
                    maLoai = loai.maLoai,
                    tenLoai = loai.tenLoai
                };
            }
            return null;
        }

        public void Delete(int id)
        {
            var loai = _context.Loais.FirstOrDefault(lo => lo.maLoai == id);
            if (loai != null)
            {
                _context.Remove(loai); 
                _context.SaveChanges();
            }
        }

        public void Update(LoaiVM loai)
        {
            var _loai = _context.Loais.FirstOrDefault(lo => lo.maLoai == loai.maLoai);
            if (_loai != null)
            {
                _loai.tenLoai = loai.tenLoai;
                _context.SaveChanges();
            }
        }
    }
}
