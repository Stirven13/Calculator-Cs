using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Globalization;

namespace ViewModels
{
    public class MainViewModel: ViewModelBase
    {

        private string display = "7+8";
        private readonly string comma = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString();
        public string Comma => comma;


        public string Display {
            get => display;

            set { 
                display = value;
                OnPropertyChanged("Display");
            }
        }

        private string expression = "48549844.555";


        public string Expression
        {
            get => expression;

            set
            {
                expression = value;
                OnPropertyChanged("Expression");
            }
        }

    }
}
