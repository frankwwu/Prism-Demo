using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AI.Infrastructure.Security;

namespace AI.Infrastructure.Mvvm
{
    public class AbstractViewModel : INotifyPropertyChanged
    {
        protected Credential _credential;

        public virtual bool IsUnlocked { get; set; }

        public bool IsWriterOrHigher { get { return _credential.IsWriter && !_credential.IsReader; } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] String name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
