using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NoteService.Models;
using NoteService.Cache;

namespace NoteService.Controllers
{
    public class NotesController : ApiController
    {
        // GET: api/notes
        public IEnumerable<Note> Get()
        {
            var cache = NotesCache.Instance;
            return cache.Notes.Values;
        }

        // GET: api/notes?query=test
        public IEnumerable<Note> Get(string query)
        {
            var cache = NotesCache.Instance;
            return cache.Notes.Values.Where(note => note.Body.Contains(query));
        }

        // GET: api/notes/5
        public Note Get(int id)
        {
            var cache = NotesCache.Instance;
            if (!cache.Notes.ContainsKey(id))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, String.Format("Note {0} not found.", id)));
            }
            else 
            {
                return cache.Notes[id];
            }
        }

        // POST: api/notes
        public Note Post([FromBody]Note newNote)
        {
            var cache = NotesCache.Instance;
            if (newNote.Id == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Id must be defined."));
            }
            else
            {
                cache.Notes[newNote.Id.Value] = newNote;
                return newNote;
            }
        }
    }
}
