using Evaluator.Model;
using Evaluator.Utils;
using Evaluator.ViewModel;
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
using System.Windows.Shapes;

namespace Evaluator.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var cell = e.AddedCells[0];
            var q = (RelationCalification)cell.Item;

            MessageBox.Show($"{q.Ejer1.ToExplain()} {System.Environment.NewLine} " +
                $"{q.Ejer2.ToExplain()} {System.Environment.NewLine} " +
                $"{q.Ejer3.ToExplain()} {System.Environment.NewLine}" +
                $"{q.Ejer4.ToExplain()} {System.Environment.NewLine}" +
                $"{q.Ejer5.ToExplain()}");
        }
    }
}
