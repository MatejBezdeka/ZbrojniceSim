using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Zbrojnice {
    public class Zbrojnice {
        //--------------------------------
        //todo:
        //bug:
        //--------------------------------
        private Random rn = new Random();
        private int uskladneniZaHodinu = 30;
        private int rozdaniZaHodinu = 12;
        private int mosinVeZbrojnici = 0;
        private int gewehrVeZbrojnici = 0;
        public int mosinVeSklade = 0;
        public int gewehrVeSklade = 0;
        public int zbraneOdSberacu = 0;
        
        public void dodavkaOdSberacu() {
            zbraneOdSberacu += 3 * Sberac.sberacListId.Count;
        }
        public void uskladniZbrane() {
            int pocetSkladniků = Skladnik.pocetSkladnikuVzhuru();
            if (mosinVeSklade == 0 && gewehrVeSklade == 0) {
                for (int i = 0; i < Skladnik.skladnikListId.Count; i++) {
                    Skladnik s = (Skladnik) Personal.personalList[Skladnik.skladnikListId[i]];
                    s.casNaspano++;
                }
                return;
            }
            //skladnici nespí
            if (mosinVeSklade >= 30*pocetSkladniků ) {
                spocitejZbrane(30*pocetSkladniků,0);
            }
            else {
                if (mosinVeSklade + gewehrVeSklade >= 30*pocetSkladniků) {
                    spocitejZbrane(mosinVeSklade, 30*pocetSkladniků - mosinVeSklade);
                }
                else {
                    spocitejZbrane(mosinVeSklade, gewehrVeSklade);
                }
            }
        }

        private void spocitejZbrane(int mosinu, int gewehr) {
            mosinVeSklade -= mosinu;
            mosinVeZbrojnici += mosinu;
            gewehrVeSklade -= gewehr;
            gewehrVeZbrojnici += gewehr;
        }

        public void aktualizaceZbrani(Label mosinSklad, Label mosinZbroj, Label gewehrSklad, Label gewehrZbroj) {
            mosinSklad.Text = "mosin: " + mosinVeSklade;
            mosinZbroj.Text = "mosin: " + mosinVeZbrojnici;
            gewehrSklad.Text = "gewehr: " + gewehrVeSklade;
            gewehrZbroj.Text = "gewehr: " + gewehrVeZbrojnici;
        }
        public void dejZbraneVojakum() {
            List<Vojak> fifo = kontrolaStavuVojaku();
            int max = 13;
            for (int i = 0; i < max;) {
                if (mosinVeZbrojnici == 0 && gewehrVeZbrojnici == 0 || fifo.Count == 0) {
                    return;
                }
                Vojak v = fifo[i];
                if (mosinVeZbrojnici > 0) {
                    mosinVeZbrojnici--;
                    v.zbran = "mosin";
                    v.vojakPanel.BackColor = Color.Green;
                }else if (gewehrVeZbrojnici > 0) {
                    gewehrVeZbrojnici--;
                    v.zbran = "gewehr";
                    v.vojakPanel.BackColor = Color.Aqua;
                }

                fifo.Remove(fifo[0]);
                max--;
            }
        }

        public void vojaciNachazejiZbrane() {
            List<Vojak> vojaci = kontrolaStavuVojaku();
            for (int i = 0; i < vojaci.Count; i++) {
                Vojak vojak = vojaci[i];
                if (rn.Next(0,100) >= 85) {
                    if (rn.Next(0,50) >= 25) {
                        vojak.zbran = "mosin";
                        vojak.vojakPanel.BackColor = Color.Green;
                    }
                    else {
                        vojak.zbran = "gewehr";
                        vojak.vojakPanel.BackColor = Color.Aqua;
                    }
                }
            }
        }
        private List<Vojak> kontrolaStavuVojaku() {
            List<Vojak> list = new List<Vojak>();
            for (int i = 0; i < Personal.personalList.Count; i++) {
                if (Personal.personalList[i].GetType() == typeof(Vojak)) {
                    Vojak vojak = (Vojak)Personal.personalList[i];
                    if (vojak.zbran == "bez") {
                        list.Add(vojak);
                    }
                }
            }
            return list;
        }
        

        public void konvertujZbrane() {
            for (int i = 0; i < (zbraneOdSberacu*10) /16; i++) {
                if (rn.Next(0,100) >= 50) {
                    mosinVeSklade++;
                }
                else {
                    gewehrVeSklade++;
                }
            }

            zbraneOdSberacu = 0;
        }
    }
}