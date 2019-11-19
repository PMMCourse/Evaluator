using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Evaluator.Model;
using Evaluator.Utils;
using Newtonsoft.Json;

namespace Evaluator.Services
{
    public class GithubService : IGithubService
    {
        private const string Host = "https://api.github.com";

        public async Task<List<PullRequest>> GetPullRequests(string name, string repoName)
        {
            var response = await GetHttpClient().GetAsync($"{Host}/repos/{name}/{repoName}/pulls");
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PullRequest>>(jsonString)
                .Select(x => x.AddTitle(repoName)).ToList();
        }

        public async Task<List<Repository>> GetRepositories(string name)             
        {            
            var response = await GetHttpClient().GetAsync($"{Host}/orgs/{name}/repos");
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Repository>>(jsonString);
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Awesome Octocat App");

            return httpClient;
        }
    }
}
