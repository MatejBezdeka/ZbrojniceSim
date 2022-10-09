using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Zbrojnice {
    public class Animace {
        
        //------------------------------------------------------------
        //Todo:
        //více vláken?
        //merge pohyb mediků a vojáků do jedné
        //animace sberatelum - 2x denně vybehnou na frontu a po chvíli zdržování odběhnou na frontu
        //animace skladnikum - chodí do skladu a do kasáren
        //animace enemákům - upravit podmínky (možné další vlákno)
        //
        //bug:
        //medikové hlásí chyby (nestíhají si měnit id)
        //
        //------------------------------------------------------------
        
        private static Thread vlakno;
        private static Random rn = new Random();
        public static void animace() {
            vlakno = new Thread(animHodina);
            vlakno.Start();
        }

        private static void animHodina() {
            Personal.najdiId(Vojak.vojakListId, typeof(Vojak));
            for (int i = 0; i < Vojak.vojakListId.Count/2+1; i++) {
                if (rn.Next(0,50) >= 15) {
                    Vojak v = (Vojak) Personal.personalList[Vojak.vojakListId[i]];
                    Panel p = v.vojakPanel;
                    try {
                        if (p.Location.Y + 3 >= p.Parent.Height) {
                            p.Location = new Point(p.Location.X, p.Location.Y - 2);
                        }else if (p.Location.Y - 3 <= 5) {
                            p.Location = new Point(p.Location.X, p.Location.Y + 2);
                        }else if (p.Location.X + 3 >= p.Parent.Width) {
                            p.Location = new Point(p.Location.X - 2, p.Location.Y);
                        }else if (p.Location.X - 3 <= p.Parent.Width / 2) {
                            p.Location = new Point(p.Location.X + 2, p.Location.Y);
                        }
                        else {
                            p.Location = new Point(p.Left + rn.Next(-1, 2), p.Top + rn.Next(-2,2));
                        }
                    }
                    catch (Exception e) { }
                }
                Thread.Sleep(10);
            }
            Personal.najdiId(Medik.medikListId, typeof(Medik));
            Thread.Sleep(20);
            for (int i = 0; i < Medik.medikListId.Count/2+1; i++) {
                if (rn.Next(0,50) >= 25) {
                    try {
                        Medik m = (Medik) Personal.personalList[Medik.medikListId[i]];
                        Panel p = m.medikPanel;
                        try {
                            if (p.Location.Y + 3 >= p.Parent.Height) {
                                p.Location = new Point(p.Location.X, p.Location.Y - 2);
                            }else if (p.Location.Y + 3 <= 5) {
                                p.Location = new Point(p.Location.X, p.Location.Y + 2);
                            }else if (p.Location.X + 3 >= p.Parent.Width) {
                                p.Location = new Point(p.Location.X - 2, p.Location.Y);
                            }else if (p.Location.X - 3 <= p.Parent.Width / 2) {
                                p.Location = new Point(p.Location.X + 2, p.Location.Y);
                            }
                            else {
                                p.Location = new Point(p.Left + rn.Next(-1, 1), p.Top + rn.Next(-1,1));
                            }
                        }
                        catch (Exception e) { }
                    }
                    catch (Exception e) {
                        return;
                    }
                }
                Thread.Sleep(10);
            }
            for (int i = 0; i < EnemyVojak.enemyPanelList.Count/2+1; i++) {
                Panel p = EnemyVojak.enemyPanelList[i];
                    try {
                        if (p.Location.Y + 3 >= p.Parent.Height) {
                            p.Location = new Point(p.Location.X, p.Location.Y - 2);
                        }else if (p.Location.Y - 3 <= 5) {
                            p.Location = new Point(p.Location.X, p.Location.Y + 2);
                        }else if (p.Location.X + 3 >= p.Parent.Width) {
                            p.Location = new Point(p.Location.X - 2, p.Location.Y);
                        }else if (p.Location.X - 3 <= p.Parent.Width / 2 - 30) {
                            p.Location = new Point(p.Location.X + 2, p.Location.Y);
                        }
                        else {
                            p.Location = new Point(p.Left + rn.Next(-1, 2), p.Top + rn.Next(-2,2));
                        }
                    }
                    catch (Exception e) { }
                    Thread.Sleep(10);
            }
        }

        private static void animaSberaci() {
            
        }

        private static void animaSkladniciSpi() {
            
        }

        private static void animSkladniciSkladuji() {
            
        }
    }
}