using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnnouncementsWeb.Model
{
    public class CAnnouncement
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 AnnId { get; set; }
        public Int32 Price { get; set; }
        public DateTime DateTimeCreation { get; set; }
        [MaxLength(200)]
        public String NameOfAnn { get; set; }
        [MaxLength(1000)]
        public String Comment { get; set; }
    }
}
