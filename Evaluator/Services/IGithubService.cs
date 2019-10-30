using Evaluator.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evaluator.Services
{
    public interface IGithubService
    {
        Task<List<Repository>> GetRepositories(string name);

        Task<List<PullRequest>> GetPullRequests(string name, string repoName);
    }
}
