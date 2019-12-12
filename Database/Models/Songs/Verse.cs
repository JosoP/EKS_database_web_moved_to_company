﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models.Songs
{
    [Table("verses")]
    public partial class Verse
    {
        [Key]
        [Column("_id")]
        public long Id { get; set; }
        
        [Column("songId")]
        public long SongId { get; set; }
        
        [Required]
        [Column("title")]
        public string Title { get; set; }
        
        [Required]
        [Column("text")]
        public string Text { get; set; }

        [ForeignKey(nameof(SongId))]
        public virtual Song Song { get; set; }
    }
}