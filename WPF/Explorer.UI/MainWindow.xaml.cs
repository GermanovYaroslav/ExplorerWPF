using Explorer.Shared.ViewModels;

namespace Explorer.UI
{

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

        }
    }
}
