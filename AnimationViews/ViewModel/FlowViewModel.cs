using AnimationViews.Utiles;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace AnimationViews.ViewModel {
    public class FlowViewModel : ViewModelBase {
        private CancellationTokenSource cancellationTokenSource;
        public string CommandFlag { get; set; }
        public bool IsAsync { get; set; }
        public ICommand GreenCommand { get; set; }
        public ICommand YellowCommand { get; set; }
        public FlowViewModel() {
            GreenCommand = new RelayCommand(GreenEventHandling);
            YellowCommand = new RelayCommand(YellowEventHandling);
        }

        private async void YellowEventHandling() {
            if (IsAsync) {
                IsAsync = false;
                StopEventHandling();
            } else {
                CommandFlag = "Yellow";
                IsAsync = true;
                cancellationTokenSource = new CancellationTokenSource();
                await StartPeriodicWork(cancellationTokenSource.Token);
            }
        }

        private async void GreenEventHandling() {
            if (IsAsync) {
                IsAsync = false;
                StopEventHandling();
            } else {
                CommandFlag = "Green";
                IsAsync = true;
                cancellationTokenSource = new CancellationTokenSource();
                await StartPeriodicWork(cancellationTokenSource.Token);
            }
        }
        private void StopEventHandling() {
            cancellationTokenSource?.Cancel();
        }
        private async Task StartPeriodicWork(CancellationToken cancellationToken) {
            while (!cancellationToken.IsCancellationRequested) {
                try {
                    // 주기적으로 작업 수행
                    Messenger.Default.Send(new StartAnimationMessage(CommandFlag, IsAsync));
                    await Task.Delay(2000, cancellationToken);
                } catch (TaskCanceledException) {
                    // 취소 요청이 발생하면 예외가 발생하므로, 여기서 작업 중단 처리를 수행할 수 있습니다.
                    // 필요한 경우 추가적인 작업을 수행할 수 있습니다.
                    Messenger.Default.Send(new StartAnimationMessage(CommandFlag, IsAsync));
                    break; // 작업 중단
                }
            }
        }
    }
}
