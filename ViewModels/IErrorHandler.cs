using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public interface IErrorHandler
    {
        void ErrorHandle(Exception exception);

    }
}
