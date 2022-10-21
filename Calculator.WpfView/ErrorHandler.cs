using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ViewModels;

namespace Calculator.WpfView
{
    class ErrorHandler : IErrorHandler
    {
        public void ErrorHandle(Exception exception)
        {
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
