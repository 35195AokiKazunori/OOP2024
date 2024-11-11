﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    public class GramUnit : WeightUnit {
        private static List<GramUnit> units = new List<GramUnit> {
            new GramUnit{Name = "mg",Coefficient = 1000 * 1000 * 1000,},
            new GramUnit{Name = "g",Coefficient = 1000 * 1000,},
            new GramUnit{Name = "kg",Coefficient = 1000,},
            new GramUnit{Name = "t",Coefficient = 1,},
        };
        public static ICollection<GramUnit> Units { get { return units; } }

        //ポンド単位からグラム単位に変換
        public double FromPoundUnit(PoundUnit unit, double value) {
            return (value * unit.Coefficient) / 100 / this.Coefficient;
        }
    }
}
