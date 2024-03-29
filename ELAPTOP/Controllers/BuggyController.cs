﻿using ELAPTOP.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ELAPTOP.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ApplicationDbContext _context;

        public BuggyController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("not found")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);

            if(thing==null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
