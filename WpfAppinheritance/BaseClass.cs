using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfAppinheritance
{
    public class BaseClass:BindableBase
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int s { get; set; }

        public int State
        {
            get { return GetProperty(() => State); }
            set { SetProperty(() => State, value); }
        }

    }
}
