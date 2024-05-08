using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    public class Program {
        static void Main(string[] args) {
            var songs = new Song[] {
                new Song("Alive","ReoNa",260),
                new Song("Kinishinai","ngya",240),
                new Song("over dose","kuha",220)
            };
            PrintSongs(songs);
        }

        private static void PrintSongs(Song[] songs) {
            foreach (var song in songs) {
                Console.WriteLine(@"{0:hh\:mm\:ss}", TimeSpan.FromSeconds(song.Length));
            }
        }
    }
}
