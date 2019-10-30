using Evaluator.Model;
using Evaluator.Services;
using Evaluator.Utils;
using Evaluator.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Evaluator.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IGithubService _githubService;
        private readonly IEvaluatorService _evaluatorService;


        public MainViewModel()
        {
            _githubService = SimpleContainerService.Get<IGithubService>();
            _evaluatorService = SimpleContainerService.Get<IEvaluatorService>();

            InitCommands();
        }

        private void InitCommands()
        {
            _evaluateCommand = new RelayCommand(PerformEvaluate, CanEvaluate);
        }
        
        private string _evaluatorLink;
        
        private RelayCommand _evaluateCommand;

        public ICommand EvaluateCommand => _evaluateCommand;

        public string EvaluatorLink
        {
            get => _evaluatorLink;
            set
            {
                _evaluatorLink = value;
                RaiseProperty();
                _evaluateCommand.RaiseCanExecute();
            }
        }

        private async void PerformEvaluate()
        {
            (await GetPRsPerUser()).Select(_evaluatorService.Evaluate(x, _evaluatorService.EvaluationInfo()));

               
        }
        
        private async Task<List<GithubInfo>> GetPRsPerUser()
        {
            List<PullRequest> pullRequests = new List<PullRequest>();

            var repos = await _githubService.GetRepositories(EvaluatorLink);
            var exercises = repos.Where(x => x.Name.Contains("Ejer")).ToList();
            foreach (var exer in exercises)
            {
                pullRequests.AddRange(await _githubService.GetPullRequests(EvaluatorLink, exer.Name));
            }

            return pullRequests.GroupBy(x => x.User.Login).Select(x => new GithubInfo() { User = x.Key, PullRequests = x.ToList() }).ToList();
        }

        private bool CanEvaluate()
        {
            return !string.IsNullOrEmpty(EvaluatorLink);
        }
    }
}
