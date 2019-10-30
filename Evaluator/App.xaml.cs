using Evaluator.Services;
using Evaluator.ViewModel.Base;
using System.Windows;

namespace Evaluator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SimpleContainerService.Register<IGithubService>(new GithubService());
            SimpleContainerService.Register<IEvaluatorService>(new EvaluatorService());

            base.OnStartup(e);
        }
    }
}
