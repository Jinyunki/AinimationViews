using AnimationViews.ViewModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnimationViews.DataModels {
    public class MainModel : ViewModelBase {
        public ICommand BtnGetFirstView { get; set; }
        public ICommand BtnTestOneView { get; set; }
        #region window Base Button Event
        public ICommand BtnMinmize { get; set; }
        public ICommand BtnMaxsize { get; set; }
        public ICommand BtnClose { get; set; }

        private WindowState _windowState;
        public WindowState WindowState {
            get { return _windowState; }
            set {
                if (_windowState != value) {
                    _windowState = value;
                    RaisePropertyChanged(nameof(WindowState));
                }
            }
        }
        #endregion

        public ViewModelLocator _locator = new ViewModelLocator();
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel {
            get {
                return _currentViewModel;
            }
            set {
                // 이전 View 종료
                if (_currentViewModel != null) {
                    _currentViewModel = null;
                }
                _currentViewModel = value;
                RaisePropertyChanged(nameof(CurrentViewModel));
            }
        }
    }
}
