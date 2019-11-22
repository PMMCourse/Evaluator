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
        public static Qualification GetEvaluation(this IEnumerable<PullRequest> prs, Repository repository)
        {
            Qualification valoration = new Qualification();
            var prSelected = prs.FirstOrDefault(x => x.Title == repository.Name);
            if(prSelected != null)
            {
                valoration.Evaluation += 0.25;
                valoration.Deliver = true;
                if(prSelected.ThereAreAnyChange())
                {
                    valoration.Evaluation += 0.25;
                    valoration.Changes = true;
                }
                if(prSelected.Created_at <= repository.Created_at.AddDays(5))
                {
                    valoration.Evaluation += 0.25;
                    valoration.DeliverInTime = true;
                }
                if(valoration.Evaluation == 0.75)
                {
                    valoration.Evaluation = 1;
                    valoration.Total = true;
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

        public static string ToExplain(this Qualification q)
        {
            string explanation = string.Empty;

            explanation = $"Changes {q.Changes.ToString()}" +
                $"Deliver {q.Deliver.ToString()}" +
                $"Deliver in Time {q.DeliverInTime.ToString()}" +
                $"Total {q.Total.ToString()}";

            return explanation;
        }
    }
}
