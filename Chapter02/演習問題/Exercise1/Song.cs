using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    public class Song {
        //題名
        public String Title { get; set; }
        //演奏者名
        public String ArtistName { get; set; }
        //演奏時間(秒単位)
        public int Length { get; set; }

        public Song(String title, String artistname, int length) {
            Title = title;
            ArtistName = artistname;
            Length = length;
        }
    }
}
