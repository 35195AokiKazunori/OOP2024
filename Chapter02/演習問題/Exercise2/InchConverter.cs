using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    public static class InchConverter {
        //private const double ratio = 0.0254;    //定数
        public static readonly double ratio = 0.0254;

        //フィートからメートルを求める
        public static double FromMeter(double meter) {
            return meter * 0.0254;
        }
        //メートルからフィートを求める
        public static double ToMeter(double inch) {
            return inch * 0.0254;
        }
    }
}
