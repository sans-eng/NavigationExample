using NavigationExample.Contracts.Services;
using NavigationExample.ViewModels;
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

namespace NavigationExample.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : UserControl
    {
        #region Private fields
        private INavigationViewService _navigationViewService;
        private INavigationService _navigationService;
        #endregion Private fields
        public ShellView(ShellViewModel viewModel, INavigationViewService navigationViewService, INavigationService navigationService)
        {
            DataContext = viewModel;
            _navigationViewService = navigationViewService;
            _navigationService = navigationService;
            InitializeComponent();

            _navigationViewService.Initialize(navigationBox);
            _navigationService.SetFrame(navigationFrame);
        }
    }
}
