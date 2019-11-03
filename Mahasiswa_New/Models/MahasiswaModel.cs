using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahasiswa_New.Models
{
    public class MahasiswaModel
    {
        public int Id { get; set; }

        public string NPM { get; set; }

        public string Nama { get; set; }

        public string JK { get; set; }

        public string IdJurusan { get; set; }

        public string Jurusan { get; set; }

        public string Alamat { get; set; }

        public string TglLahir { get; set; }

        public string Email { get; set; }
    }
}