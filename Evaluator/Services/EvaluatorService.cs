using Evaluator.Model;

namespace Evaluator.Services
{
    public class EvaluatorService : IEvaluatorService
    {
        public EvaluationValue EvaluationInfo() =>
            new EvaluationValue()
            {
                TotalExercises = 5
            };
        
        RelationCalification IEvaluatorService.Evaluate(GithubInfo githubInfo, EvaluationValue evaluationValues) =>
            new RelationCalification()
            {
                User = githubInfo.User,
                Calification = evaluationValues.TotalExercises / githubInfo.PullRequests.Count
            };
    }
}
