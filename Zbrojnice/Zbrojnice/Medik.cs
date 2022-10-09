using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Zbrojnice {
    public class Medik : Personal {
        //--------------------------------
        //todo:
        //bug:
        //--------------------------------
        private int id;
        public Panel medikPanel = new Panel();
        public static List<int> medikListId = new List<int>();
        public Medik(Panel fronta) {
            id = personalList.Count;
            medikPanel.Location = new Point(rn.Next(fronta.Width/2, fronta.Width - 20), rn.Next(5, fronta.Height - 5));
            pridejPersonal(fronta, medikPanel, Color.Blue, id.ToString(), medikListId);
        }

        public static void ozivVojaky(Panel fronta) {
            for (int i = 0; i < medikListId.Count; i++) {
                if (rn.Next(0,100) <= 4) {
                    Vojak.pridejVojaka(1, fronta);
                }
            }
        }

        public static void zabijMediky() {
            if (medikListId.Count == 0) {
                return;
            }
            int max = medikListId.Count;
            for (var i = 0; i < max;) {
                if (rn.Next(0, 1000) >= 997) {
                    medikListId = najdiId(medikListId, typeof(Medik));
                    Medik medik = (Medik) personalList[medikListId[i]];
                    Panel fronta = (Panel)medik.medikPanel.Parent;
                    odstranPersonal(fronta, medik.medikPanel);
                    personalList.Remove(personalList[medikListId[i]]);
                    medikListId.RemoveAt(0);
                    max--;
                }
                i++;
            }
        }
        public static void pridejMedika(int pocet, Panel fronta) {
            for (int i = 0; i < pocet; i++) {
                personalList.Add(new Medik(fronta));
            }
        }
    }
}