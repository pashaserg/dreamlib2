using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DreamLib2.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        public string Src { get; set; }
        public string Cover { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime CreatedDate { get; set; }
        // public int UserId { get; set; } //  -   creator

        [Required]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public Song()
        {
            Genres = new List<Genre>();
        }
    }
}