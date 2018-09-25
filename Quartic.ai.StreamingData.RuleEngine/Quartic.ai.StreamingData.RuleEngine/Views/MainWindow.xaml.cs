using System.Windows;
using Quartic.ai.StreamingData.RuleEngine.ViewModel;

namespace Quartic.ai.StreamingData.RuleEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TODO:Browse and get the file from UI.Pending due to time constraints 
        string filepath = "../../Rules/RuleSet.json";
        public MainWindow()
        {
            InitializeComponent();
            var vmObject = new RuleViewModel(filepath);
            DataContext = vmObject;           
        }
    }
}
