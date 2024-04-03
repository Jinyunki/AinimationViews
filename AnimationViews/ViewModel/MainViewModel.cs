using AnimationViews.DataModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace AnimationViews.ViewModel {
    public class MainViewModel : MainModel
    {
        public MainViewModel()
        {
            CurrentViewModel = _locator.FlowViewModel;
            BtnMinmize = new RelayCommand(WinMinmize);
            BtnMaxsize = new RelayCommand(WinMaxSize);
            BtnClose = new RelayCommand(WindowClose);

            BtnGetFirstView = new RelayCommand(() => { CurrentViewModel = _locator.FlowViewModel; });
            BtnTestOneView = new RelayCommand(ExcuteTestOneView);
        }

        private void ExcuteTestOneView() {
            CurrentViewModel = _locator.TestOneViewModel;
        }

        #region
        // Window Minimize
        private void WinMinmize()
        {
            Trace.WriteLine("==========   Start   ==========\nMethodName : " + MethodBase.GetCurrentMethod().Name + "\n");
            try
            {
                WindowState = WindowState.Minimized;
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + MethodBase.GetCurrentMethod().Name + "\nException : " + ex);
                throw;
            }
        }
        // Window Size
        private void WinMaxSize()
        {

            Trace.WriteLine("==========   Start   ==========\nMethodName : " + MethodBase.GetCurrentMethod().Name + "\n");
            try
            {
                WindowState = (WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + MethodBase.GetCurrentMethod().Name + "\nException : " + ex);
                throw;
            }

        }
        // Window ShutDown
        private void WindowClose()
        {

            Trace.WriteLine("==========   Start   ==========\nMethodName : " + MethodBase.GetCurrentMethod().Name + "\n");
            try
            {
                Application.Current.Shutdown();

            } catch (Exception ex)
            {
                Trace.WriteLine("========== Exception ==========\nMethodName : " + MethodBase.GetCurrentMethod().Name + "\nException : " + ex);
                throw;
            }

        }
        #endregion
    }
}