using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    public class PoundUnit : WeightUnit {
        private static List<PoundUnit> units = new List<PoundUnit> {
            new PoundUnit{Name = "gr",Coefficient = 1,},
            new PoundUnit{Name = "dr",Coefficient = 1,},
            new PoundUnit{Name = "oz",Coefficient = 1,},
            new PoundUnit{Name = "lb",Coefficient = 1,},
        };
        public static ICollection<PoundUnit> Units { get { return units; } }

        //グラム単位からポンド単位に変換
        public double FromGramUnit(GramUnit unit, double value) {
            return (value * unit.Coefficient) / 100 / this.Coefficient;
        }
    }
}
