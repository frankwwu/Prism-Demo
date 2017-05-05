using System;
using System.Reflection;
using log4net;
using Prism.Commands;
using Prism.Logging;
using Prism.Mvvm;

namespace Module1.ViewModels
{
    public class GreenViewModel : BindableBase
    {
        private readonly ILog _logger = LogManager.GetLogger("Module1");

        public GreenViewModel()
        {
            ThrowExceptionCommand = new DelegateCommand<object>(ThrowException);
        }

        public DelegateCommand<object> ThrowExceptionCommand { get; private set; }

        private void ThrowException(object parameter)
        {
            try
            {
                throw new System.IO.InvalidDataException();
            }
            catch (Exception ex)
            {
                switch (parameter.ToString())
                {
                    case "Debug":
                        _logger.Debug(ex.Message);
                        break;
                    case "Error":
                        _logger.Error(ex.Message);
                        break;
                    case "Fatal":
                        _logger.Fatal(ex.Message);
                        break;
                    case "Info":
                        _logger.Info(ex.Message);
                        break;
                    case "Warn":
                        _logger.Warn(ex.Message);
                        break;
                }
            }
        }
    }
}
