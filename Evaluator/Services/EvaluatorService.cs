using Evaluator.Model;
using System.Linq;
using System;
using Evaluator.Utils;
using System.Collections.Generic;

namespace Evaluator.Services
{
    public class EvaluatorService : IEvaluatorService
    {
        public EvaluationValue EvaluationInfo() =>
            new EvaluationValue()
            {
                TotalExercises = 6,
                MaxNoteForPRs = 3
            };

        RelationCalification IEvaluatorService.Evaluate(GithubInfo githubInfo, EvaluationValue evaluationValues, List<Repository> repositories) =>
            new RelationCalification()
            {
                User = githubInfo.User,
                Ejer1 = githubInfo.PullRequests.GetEvaluation(repositories.FirstOrDefault(x => x.Name.Contains("Ejer1"))),
                Ejer2 = githubInfo.PullRequests.GetEvaluation(repositories.FirstOrDefault(x => x.Name.Contains("Ejer2"))),
                Ejer3 = githubInfo.PullRequests.GetEvaluation(repositories.FirstOrDefault(x => x.Name.Contains("Ejer3"))),
                Ejer4 = githubInfo.PullRequests.GetEvaluation(repositories.FirstOrDefault(x => x.Name.Contains("Ejer4"))),
                Ejer5 = githubInfo.PullRequests.GetEvaluation(repositories.FirstOrDefault(x => x.Name.Contains("Ejer5")))                
            };                            
    }
}
