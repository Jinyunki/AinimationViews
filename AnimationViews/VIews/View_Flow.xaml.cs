using AnimationViews.Utiles;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimationViews.VIews {
    /// <summary>
    /// View_Flow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class View_Flow : UserControl {
        public View_Flow() {
            InitializeComponent();

            // Messenger를 통한 애니메이션 시작 메시지의 구독
            Messenger.Default.Register<StartAnimationMessage>(this, OnStartAnimation);
        }
        private void OnStartAnimation(StartAnimationMessage message) {
            switch (message.CommandFlag) {
                case "Green":
                    var storyboard = Resources["GreenBallSignal"] as Storyboard;
                    storyboard.Begin();
                    break;
                case "Yellow":
                    storyboard = Resources["MoveControlSignal"] as Storyboard;
                    storyboard.Begin();
                    break;
                default:
                    // Handle other cases if needed
                    break;
            }
            // 애니메이션 트리거
            
        }
    }
}
