using System;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Zbrojnice {
    public class MeneniRychlosti {
        //--------------------------------
        //todo:
        //bug:
        //--------------------------------
        public static void ZmenaRychlosti(Timer timer,Label label,bool vestsiRychlost) {
            float rychlost = float.Parse(label.Text);
            if (vestsiRychlost == true) {
                if (timer.Interval > 50) {
                    timer.Interval -= 50;
                    rychlost += 0.5f;
                }
            }
            else {
                if (timer.Interval < 200) {
                    timer.Interval += 50;
                    rychlost -= 0.5f;
                }
            }

            label.Text = rychlost + "";
        }
    }
}