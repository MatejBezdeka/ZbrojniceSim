using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using Zbrojnice.Properties;

namespace Zbrojnice {
    public class Vojak : Personal {
        //--------------------------------
        //todo:
        //bug:
        //--------------------------------
        private int id;
        public Panel vojakPanel = new Panel();
        public static List<int> vojakListId = new List<int>();
        public string zbran;
        public Vojak(Panel fronta, Point p) {
            id = personalList.Count;
            zbran = "bez";
            vojakPanel.Location = p;
            pridejPersonal(fronta, vojakPanel, Color.Gold, id.ToString(),vojakListId);
        }
        public static void pridejVojaka(int pocet, Panel fronta) {
            for (int i = 0; i < pocet; i++) {
                Point p = new Point(rn.Next(fronta.Width - fronta.Width/3, fronta.Width-5), rn.Next(0, fronta.Height - 5));
                Personal.personalList.Add(new Vojak(fronta, p));
            }
        }

        public static void zmenaZbraniVojaku(Label lBez, Label lMosin, Label lGewehr) {
            int bez = 0;
            int mosin = 0;
            int gewehr = 0;
            for (int i = 0; i < personalList.Count; i++) {
                if (personalList[i].GetType() == typeof(Vojak)) {
                    Vojak vojak = (Vojak)personalList[i];
                    switch (vojak.zbran) {
                        case "bez":
                            bez++;
                            break;
                        case "mosin":
                            mosin++;
                            break;
                        case "gewehr":
                            gewehr++;
                            break;
                    }
                }
            }
            lBez.Text = "bez zbraně: " + bez;
            lMosin.Text = "mosin: " + mosin;
            lGewehr.Text = "gewehr " + gewehr;
        }

        public static void umirajiVojaci() {
            if (vojakListId.Count == 0) {
                return;
            }
            int sanceNaPreziti;
            int max = vojakListId.Count;
            for (var i = max-1; i >= 0; i--) {
                vojakListId = najdiId(vojakListId, typeof(Vojak));
                Vojak vojak = (Vojak) personalList[vojakListId[i]];
                if (vojak.zbran == "bez") {
                    sanceNaPreziti = 26;
                }
                else {
                    sanceNaPreziti = 76;
                }
                if (rn.Next(0, 100) >= sanceNaPreziti) {
                    Panel fronta = (Panel)vojak.vojakPanel.Parent;
                    odstranPersonal(fronta, vojak.vojakPanel);
                    personalList.Remove(personalList[vojakListId[i]]);
                    vojakListId.RemoveAt(0);
                }
            }
        }
    }
}