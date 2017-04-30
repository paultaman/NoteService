using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteService.Models
{
    public class Note
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}