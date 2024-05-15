using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(hangHoas);
        }
        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVm)
        {
            var hanghoa = new HangHoa
            {
                maHangHoa = Guid.NewGuid(),
                tenHangHoa = hangHoaVm.tenHangHoa,
                donGia = hangHoaVm.donGia
            };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true, Data = hanghoa
            });
        }

        [HttpGet("{id}")]

        public IActionResult getById(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.maHangHoa == Guid.Parse(id));
                if(hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]

        public IActionResult Edit(string id, HangHoa editHangHoa)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.maHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                hangHoa.tenHangHoa = editHangHoa.tenHangHoa;
                hangHoa.donGia = editHangHoa.donGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            

        }

        [HttpDelete ("{id}")]

        public IActionResult DeleteById(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.maHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                hangHoas.Remove(hangHoa);
                return Ok();              
            }
            catch
            {
                return BadRequest();
            }
        }
    
    }
}
