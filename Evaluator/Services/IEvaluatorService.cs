using Evaluator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.Services
{
    public interface IEvaluatorService
    {
        RelationCalification Evaluate(GithubInfo githubInfo, EvaluationValue evaluationValues);

        EvaluationValue EvaluationInfo();
    }
}
