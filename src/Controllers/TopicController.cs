using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers {
    [Route ("api/[controller]")]
    public class TopicController : ControllerBase {

        private readonly TodoContext _context;
        public TopicController (TodoContext context) {
            this._context = context;
        }

        // GET api/topic
        [HttpGet ("")]
        public ActionResult<IList<Topic>> Gets () {
            return _context.Topics.ToList ();
        }

        // GET api/topic/5
        [HttpGet ("{id}")]
        public ActionResult<Topic> GetById (long id) {
            var topic = _context.Topics.Find (id);
            if (topic == null) {
                return NotFound ();
            }
            return topic;
        }

        // POST api/topic
        [HttpPost ("")]
        public ActionResult<Topic> Post ([FromBody] Topic topic) {
            _context.Topics.Add (topic);
            _context.SaveChanges ();
            return CreatedAtAction (nameof (GetById), new { id = topic.TopicId }, topic);
        }
    }
}