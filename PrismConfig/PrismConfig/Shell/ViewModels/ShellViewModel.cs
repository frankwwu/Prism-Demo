using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Shell.ViewModels
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        public ShellViewModel()
        {
        }

        private UserControl _selectedMenu;

        public UserControl SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;
                MessageBox.Show(_selectedMenu.ToString().Split('.')[0], _selectedMenu.ToString());
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
