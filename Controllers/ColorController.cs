using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnettest;
using dotnettest.Context;
using System.Linq.Expressions;
using dotnettest.Repository;


namespace dotnettest.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ColorController : ControllerBase
    {
        private readonly IColorRepository db;


        public ColorController(IColorRepository _db)
        {
            db = _db;
        }
        [HttpGet("{colorId}")]

        public IActionResult GetColor(int colorId)
        {
            var color=db.GetColorById(colorId);
            if (color != null)
            {
                return Ok(new ResponseModel<Color>(color, "Ekleme İşlemi Başarılı", true));
            }

            return NotFound();

        }

        [HttpDelete("{colorId}")]
        public IActionResult DeleteColor(int colorId)
        {
            if (db.GetColorById(colorId) != null)
            {
                db.DeleteColor(colorId);
                return Ok(new ResponseModel<string>("Success", "Silme İşlemi Başarılı", true));
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddColor(Color color)
        {
            if (ModelState.IsValid)
            {
                db.InsertColor(color);
                db.Save();
                return Ok(new ResponseModel<Color>(color, "Ekleme İşlemi Başarılı", true));
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult GetColors()
        {
            return Ok(new ResponseModel<List<Color>>(db.GetColors(), "Renk Listesi", true));
        }
        [HttpPost]
        public IActionResult findFilterColor([FromBody] FilterModel filter)
        {
            var colorList = db.Find(x => x.Name.Contains(filter.name));
            return Ok(new ResponseModel<List<Color>>(colorList, "Filtreleme", true));
        }
    }

    public class FilterModel
    {
        public string name { get; set; }
    }
}

