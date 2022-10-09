using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Zbrojnice {
    public class Personal {
        //--------------------------------
        //todo:
        //zmenšit ostatní a narvat to sem
        //bug:
        //--------------------------------
        public static Random rn = new Random();
        public static List<object> personalList = new List<object>();
        protected void pridejPersonal(Panel fronta, Panel personal, Color barva, string tag,List<int> list) {
            personal.Height = 5;
            personal.Width = 5;
            personal.BackColor = barva;
            personal.Tag = tag;
            list.Add(personalList.Count);
            fronta.Controls.Add(personal);
        }
        protected static void odstranPersonal(Panel fronta, Panel personal) {
            fronta.Controls.Remove(personal);
        }
        public static List<int> najdiId(List<int> list, Type typObjektu) {
            int j = 0;
            for (int i = 0; i < personalList.Count; i++) {
                Type typObjektuvListu = personalList[i].GetType();
                if (typObjektu == typObjektuvListu) {
                    list[j] = i;
                    j++;
                }
            }
            return list;
        }
    }   
}