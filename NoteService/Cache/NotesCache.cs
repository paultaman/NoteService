using NoteService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteService.Cache
{
    public class NotesCache
    {
        // simple singleton implementation, normally would redirect to the db
        private static NotesCache instance;
        public static NotesCache Instance
        {
            get
            {
                return instance ?? (instance = new NotesCache());
            }
        }

        private Dictionary<int, Note> notes = new Dictionary<int, Note>();
        public Dictionary<int, Note> Notes
        {
            get
            {
                return notes;
            }
        }
        
    }
}