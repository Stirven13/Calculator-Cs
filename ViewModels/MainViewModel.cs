using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ViewModels
{
    public class MainViewModel: ViewModelBase
    {

        private string display = "display";

        public string Display {
            get => display;

            set { 
                display = value;
                OnPropertyChanged("Display");
            }
        }

        private string expression = "expression";


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
