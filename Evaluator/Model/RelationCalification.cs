using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Model
{
    public class RelationCalification
    {
        public string User { get; set; }
        public double Ejer1 { get; set; }
        public double Ejer2 { get; set; }
        public double Ejer3 { get; set; }
        public double Ejer4 { get; set; }
        public double Ejer5 { get; set; }

        public double Total => Ejer1 + Ejer2 + Ejer3 + Ejer4 + Ejer5;
    }
}
