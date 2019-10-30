using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Model
{
    public class GithubInfo
    {
        public List<PullRequest> PullRequests { get; set; } = new List<PullRequest>();

        public string User { get; set; }
    }
}
