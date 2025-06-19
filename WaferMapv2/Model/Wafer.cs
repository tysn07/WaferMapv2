using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WaferMapv2.Model
{
    public class Wafer
    {
        public int[][] DieMap { get; set; }
        public double DieSize { get; set; }
        public double DiePitchX { get; set; }
        public double DiePitchY { get; set; }
        public double WaferDiameter { get; set; }  
    }
}
