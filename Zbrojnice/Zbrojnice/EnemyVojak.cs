using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Zbrojnice {
    public class EnemyVojak {
        //--------------------------------
        //todo:
        //bug:
        //--------------------------------
        public Panel vojakPanel = new Panel();
        public static List<Panel> enemyPanelList = new List<Panel>();

        public EnemyVojak(Panel fronta, Point bod) {
            vojakPanel.Height = 5;
            vojakPanel.Width = 5;
            vojakPanel.Location = bod;
            vojakPanel.BackColor = Color.Maroon;
            enemyPanelList.Add(vojakPanel);
            fronta.Controls.Add(vojakPanel);
        }
    }
}