using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Zbrojnice {
    
    public class Skladnik : Personal {
        //--------------------------------
        //todo:
        //bug:
        //--------------------------------
        public int id { get; set; }
        public Panel skladnikPanel = new Panel();
        public static List<int> skladnikListId = new List<int>();
        private int casVzhuru;
        public int casNaspano;
        private bool spi;

        public Skladnik(Panel fronta, int casVzhuru) {
            this.casVzhuru = casVzhuru;
            spi = false;
            casNaspano = 0;
            id = personalList.Count;
            skladnikPanel.Location = new Point(fronta.Width / 2 + 10, fronta.Height / 2 + 10);
            pridejPersonal(fronta, skladnikPanel, Color.Purple, id.ToString(), skladnikListId);
        }
        public static void pridejSkladnika(int pocet, Panel fronta, Label labelPocetSkladniku) {
            for (int i = 0; i < pocet; i++) {
                Personal.personalList.Add(new Skladnik(fronta, rn.Next(0,8)));
            }
            labelPocetSkladniku.Text = "skladníků: " + Skladnik.skladnikListId.Count;
        }
        public static int pocetSkladnikuVzhuru() {
            najdiId(skladnikListId, typeof(Skladnik));
            int pocet = 0;
            for (int i = 0; i < skladnikListId.Count; i++) {
                Skladnik skladnik = (Skladnik) personalList[skladnikListId[i]];
                if (skladnik.spi == false) {
                    pocet++;
                    skladnikNespi(skladnik);
                }
                else {
                    skladnikSpi(skladnik);
                }
            }
            return pocet;
        }
        
        private static void skladnikNespi(Skladnik skladnik) {
            skladnik.casVzhuru++;
            if (skladnik.casVzhuru % 16 == 0) {
                skladnik.spi = true;
            }
        }

        public static void odstranSkladniky() {
            int max = 2;
            if (skladnikListId.Count == 2) {
                max = 1;
            }
            for (var i = 0; i < max;) {
                skladnikListId = najdiId(skladnikListId, typeof(Skladnik));
                    Skladnik skladnik = (Skladnik) personalList[skladnikListId[i]];
                    Panel fronta = (Panel)skladnik.skladnikPanel.Parent;
                    odstranPersonal(fronta, skladnik.skladnikPanel);
                    personalList.Remove(personalList[skladnikListId[i]]);
                    skladnikListId.RemoveAt(0);
                    i++;
            }
        }
        private static void skladnikSpi(Skladnik skladnik) {
            skladnik.casNaspano++;
            if (skladnik.casNaspano % 8 == 0) {
                skladnik.spi = false;
                skladnik.casVzhuru = 0;
            }
        }

        public static int celkemNaspano() {
            int celkem = 0;
            for (int i = 0; i < skladnikListId.Count; i++) {
                Skladnik skladnik = (Skladnik) personalList[skladnikListId[i]];
                celkem += skladnik.casNaspano;
            }
            return celkem;
        }
    }
}