using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DreamLib2.Models
{
    public class SongEdit
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Artist { get; set; }

        public string Src { get; set; }
        public string Cover { get; set; }
        public string Genre { get; set; }
    }
}