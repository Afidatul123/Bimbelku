using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bimbelku.Models
{
    public class Materi
    {
        [Key]
        public string Id { get; set; }
        public string NamaMateri { get; set; }
        public string Mapel { get; set; }
        public string Keterangan { get; set; }
        public string FileMateri { get; set; }
    }
}
