using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationViews.Utiles {
    public class StartAnimationMessage {
        public string CommandFlag { get; set; }
        public bool IsCommandFlag { get; set; }
        public StartAnimationMessage(string commandFlag, bool isCommandFlag) {
            CommandFlag = commandFlag;
            IsCommandFlag = isCommandFlag;
        }
    }
}
