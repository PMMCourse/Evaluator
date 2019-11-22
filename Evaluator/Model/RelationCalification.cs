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
        public Qualification Ejer1 { get; set; }
        public Qualification Ejer2 { get; set; }
        public Qualification Ejer3 { get; set; }
        public Qualification Ejer4 { get; set; }
        public Qualification Ejer5 { get; set; }

        public double Total => Ejer1.Evaluation + Ejer2.Evaluation + Ejer3.Evaluation + Ejer4.Evaluation + Ejer5.Evaluation;
    }
}
