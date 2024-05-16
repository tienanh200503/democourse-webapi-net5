using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDBContext _context;

        public LoaisController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var loai = _context.Loais.FirstOrDefault(lo => lo.maLoai == id);
            if(loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
            var loai = new Loai
                {
                    tenLoai = model.tenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateLoaiById(int id, LoaiModel model)
        {
            var loai = _context.Loais.FirstOrDefault(lo => lo.maLoai == id);
            if(loai != null)
            {
                loai.tenLoai = model.tenLoai;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
