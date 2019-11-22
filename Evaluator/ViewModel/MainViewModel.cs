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

        private List<Repository> _repositories = new List<Repository>();

        private Qualification _qualification = new Qualification();
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
        private List<RelationCalification> _califications;
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

        public List<RelationCalification> Califications
        {
            get => _califications;
            set
            {
                _califications = value;
                RaiseProperty();
            }
        }

        public Qualification Qualification
        {
            get => _qualification;
            set
            {
                _qualification = value;
                RaiseProperty();
            }
        }

        private async void PerformEvaluate()
        {
            Califications = (await GetPRsPerUser())
                .Select(x => _evaluatorService.Evaluate(x, _evaluatorService.EvaluationInfo(), _repositories)).ToList();             
        }
        
        private async Task<List<GithubInfo>> GetPRsPerUser()
        {
            List<PullRequest> pullRequests = new List<PullRequest>();

            _repositories = await _githubService.GetRepositories(EvaluatorLink);
            var exercises = _repositories.Where(x => x.Name.Contains("Ejer")).ToList();
            foreach (var exer in exercises)
            {
                pullRequests.AddRange(await _githubService.GetPullRequests(EvaluatorLink, exer.Name));
            }

            return pullRequests.GroupBy(x => x.User.Login)
                .Select(x => new GithubInfo() { User = x.Key, PullRequests = x.ToList() }).ToList();
        }

        private bool CanEvaluate()
        {
            return !string.IsNullOrEmpty(EvaluatorLink);
        }
    }
}
