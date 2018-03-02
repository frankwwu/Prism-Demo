using System.Windows.Controls;
using Module2.ViewModels;

namespace Module2.Views
{
    /// <summary>
    /// Interaction logic for ChartView.xaml
    /// </summary>
    public partial class ChartView : UserControl
    {
        public ChartView(ChartViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
