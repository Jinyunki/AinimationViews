using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AnimationViews.DataModels
{
    public class MainModel : ViewModelBase
    {
        public ICommand BtnMinmize { get; set; }
        public ICommand BtnMaxsize { get; set; }
        public ICommand BtnClose { get; set; }
        private WindowState _windowState;
        public WindowState WindowState
        {
            get { return _windowState; }
            set
            {
                if (_windowState != value)
                {
                    _windowState = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
