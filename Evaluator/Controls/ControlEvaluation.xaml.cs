using Evaluator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Evaluator.Controls
{
    /// <summary>
    /// Interaction logic for ControlEvaluation.xaml
    /// </summary>
    public partial class ControlEvaluation : UserControl
    {
        public ControlEvaluation()
        {
            InitializeComponent();
            this.DataContextChanged += ControlEvaluation_DataContextChanged;
        }

        private void ControlEvaluation_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var evaluation = (Qualification)DataContext;

            LabelChanges.Content = evaluation.Changes.ToString();
            LabelDeliver.Content = evaluation.Deliver.ToString();
            LabelDeliverInTime.Content = evaluation.DeliverInTime.ToString();
            LabelTotal.Content = evaluation.Total.ToString();
        }

        
    }
}
