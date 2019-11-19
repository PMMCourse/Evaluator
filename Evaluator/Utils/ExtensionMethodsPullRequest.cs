using Evaluator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Utils
{
    public static class ExtensionMethodsPullRequest
    {
        public static double GetEvaluation(this IEnumerable<PullRequest> prs, Repository repository)
        {
            double valoration = 0;
            var prSelected = prs.FirstOrDefault(x => x.Title == repository.Name);
            if(prSelected != null)
            {
                valoration += 0.25;
                if(prSelected.ThereAreAnyChange())
                {
                    valoration += 0.25;
                }
                if(prSelected.Created_at <= repository.Created_at.AddDays(5))
                {
                    valoration += 0.25;
                }
                if(valoration == 0.75)
                {
                    valoration = 1;
                }
            }
            return valoration;
        }

        public static PullRequest AddTitle(this PullRequest pr, string title)
        {
            pr.Title = title;
            return pr;
        }

        public static bool ThereAreAnyChange(this PullRequest pr) =>
            pr.Created_at != pr.Updated_at;
    }
}
