using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Zbrojnice {
    public class Sberac : Personal {
        //--------------------------------
        //todo:
        //bug:
        //--------------------------------
        private int id;
        public Panel sberacPanel = new Panel();
        public static List<int> sberacListId = new List<int>();
        public Sberac(Panel fronta) {
            id = personalList.Count;
                sberacPanel.Location = new Point(fronta.Width/2 + 10, fronta.Height/2);
                pridejPersonal(fronta, sberacPanel, Color.White, id.ToString(),sberacListId);
        }
        public static void pridejSberace(int pocet, Panel fronta, Label labelPocetSberacu) {
            for (int i = 0; i < pocet; i++) {
                Personal.personalList.Add(new Sberac(fronta));
            }
            labelPocetSberacu.Text = "sberačů: " + Sberac.sberacListId.Count;
        }

        public static void zabijSberace() {
            if (sberacListId.Count == 0) {
                return;
            }
            int max = sberacListId.Count;
            for (var i = 0; i < max-1;) {
                if (rn.Next(0,100) >= 50) {
                    sberacListId = najdiId(sberacListId, typeof(Sberac));
                    Sberac sberac = (Sberac) personalList[sberacListId[i]];
                    Panel fronta = (Panel)sberac.sberacPanel.Parent;
                    odstranPersonal(fronta, sberac.sberacPanel);
                    personalList.Remove(personalList[sberacListId[i]]);
                    sberacListId.RemoveAt(0);
                    max--;
                }
                i++;
            }
        }
    }
}