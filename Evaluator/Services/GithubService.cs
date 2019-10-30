using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Evaluator.Model;
using Newtonsoft.Json;

namespace Evaluator.Services
{
    public class GithubService : IGithubService
    {
        private const string Host = "https://api.github.com";

        public async Task<List<PullRequest>> GetPullRequests(string name, string repoName)
        {
            var response = await GetHttpClient().GetAsync($"{Host}/repos/{name}/{repoName}/pulls");
            return JsonConvert.DeserializeObject<List<PullRequest>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<Repository>> GetRepositories(string name)             
        {            
            var response = await GetHttpClient().GetAsync($"{Host}/orgs/{name}/repos");
            return JsonConvert.DeserializeObject<List<Repository>>(await response.Content.ReadAsStringAsync());
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Awesome Octocat App");

            return httpClient;
        }
    }
}
