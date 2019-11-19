using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Model
{
    public class PullRequest
    {
        public int Id { get; set; }

        public User User { get; set; }

        public string Title { get; set; }
        
        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }

    }
}
