using log4net;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Module2.ViewModels
{
    public class RedViewModel : BindableBase
    {
        private readonly ILog _logger;

        public RedViewModel(ILog logger)
        {
            _logger = logger;

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
