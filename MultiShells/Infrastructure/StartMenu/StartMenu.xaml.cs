using Infrastructure.MultiShell;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Infrastructure.StartMenu
{
    /// <summary>
    /// Interaction logic for StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Popup, INotifyPropertyChanged
    {
        private readonly IShellService _shellService;

        public StartMenu(IShellService shellService)
        {
            _shellService = shellService;
            InitializeComponent();
            this.DataContext = this;
        }

        private UserControl _selectedModule;

        public UserControl SelectedModule
        {
            get { return _selectedModule; }
            set
            {
                _selectedModule = value;
                string moduleName = _selectedModule.ToString().Split('.')[0];
                _shellService.ShowShell(moduleName);
                IsMenuOpen = false;
            }
        }

        public bool IsMenuOpen
        {
            get { return IsOpen; }
            set
            {
                IsOpen = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
