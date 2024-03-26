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
        private ICommand _startAnimationCommand;
        public ICommand StartAnimationCommand {
            get { return _startAnimationCommand; }
            set {
                _startAnimationCommand = value;
                RaisePropertyChanged(nameof(StartAnimationCommand));
            }
        }

        public FlowViewModel() {
            StartAnimationCommand = new RelayCommand(StartEventHandling);
        }
        private async void StartEventHandling() {
            cancellationTokenSource = new CancellationTokenSource();
            await StartPeriodicWork(cancellationTokenSource.Token);
        }
        private void StopEventHandling() {
            cancellationTokenSource?.Cancel();
        }
        private async Task StartPeriodicWork(CancellationToken cancellationToken) {
            while (!cancellationToken.IsCancellationRequested) {
                try {
                    // 주기적으로 작업 수행
                    Messenger.Default.Send(new StartAnimationMessage());
                    await Task.Delay(2000, cancellationToken);
                } catch (TaskCanceledException) {
                    // 취소 요청이 발생하면 예외가 발생하므로, 여기서 작업 중단 처리를 수행할 수 있습니다.
                    // 필요한 경우 추가적인 작업을 수행할 수 있습니다.
                    Console.WriteLine("TEST END " + DateTime.Now);
                    break; // 작업 중단
                }
            }
        }
        private void OnStartAnimation() {
            // 애니메이션 시작 이벤트 발행
            Messenger.Default.Send(new StartAnimationMessage());
        }
    }
}
