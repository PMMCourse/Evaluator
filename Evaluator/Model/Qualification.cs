using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Model
{
    public class Qualification
    {
        public double Evaluation { get; set; }

        public bool Changes { get; set; }

        public bool DeliverInTime { get; set; }

        public bool Deliver { get; set; }

        public bool Total { get; set; }

        public override string ToString()
            => Evaluation.ToString();        
    }
}
