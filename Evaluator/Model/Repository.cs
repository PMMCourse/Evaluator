using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Model
{
    public class Repository
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Html_Url { get; set; }

        public DateTime Created_at { get; set; }
    }
}
