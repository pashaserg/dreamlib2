using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DreamLib2.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; }
        public Genre()
        {
            Songs = new List<Song>();
        }
    }
}