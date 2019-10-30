using Evaluator.Model;
using System;

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

        RelationCalification IEvaluatorService.Evaluate(GithubInfo githubInfo, EvaluationValue evaluationValues) =>
            new RelationCalification()
            {
                User = githubInfo.User,
                Calification = Math.Round(((double)githubInfo.PullRequests.Count / (double)evaluationValues.TotalExercises) * evaluationValues.MaxNoteForPRs, 2)
            };                            
    }
}
