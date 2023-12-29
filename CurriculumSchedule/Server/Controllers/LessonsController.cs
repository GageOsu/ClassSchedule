using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Model;
using System;
using System.Collections.ObjectModel;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : Controller
    {

        private readonly ScheduleContext _context;

        public LessonsController(ScheduleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLessons()
        {
            var lessons = _context.Groups.ToList();
            return Ok(lessons);
        }
    }
}