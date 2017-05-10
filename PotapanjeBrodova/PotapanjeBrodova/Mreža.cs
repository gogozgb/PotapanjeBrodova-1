using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Mreža
    {
        public Mreža(int redaka, int stupaca)
        {
            this.redaka = redaka;
            this.stupaca = stupaca;
            polja = new Polje[redaka, stupaca];
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                    polja[r, s] = new Polje(r, s);
            }
        }

        public IEnumerable<Polje> DajSlobodnaPolja()
        {
            List<Polje> p = new List<Polje>();
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                {
                    if (polja[r, s] != null)
                        p.Add(polja[r, s]);
                }
            }
            return p;
        }

        public void UkloniPolje(int redak, int stupac)
        {
            polja[redak, stupac] = null;
        }

        public void UkloniPolje(Polje p)
        {
            UkloniPolje(p.Redak, p.Stupac);
        }

        public IEnumerable<IEnumerable<Polje>> DajNizoveSlobodnihPolja(int duljinaNiza)
        {
            List<IEnumerable<Polje>> nizovi = DajNizoveSlobodnihPoljaUHorizontalnomSmjeru(duljinaNiza);
            nizovi.AddRange(DajNizoveSlobodnihPoljaUVertikalnomSmjeru(duljinaNiza));
            return nizovi;
        }

        private List<IEnumerable<Polje>> DajNizoveSlobodnihPoljaUHorizontalnomSmjeru(int duljinaNiza)
        {
            List<IEnumerable<Polje>> nizovi = new List<IEnumerable<Polje>>();
            for (int r = 0; r < redaka; ++r)
            {
                RedFiksneDuljine<Polje> red = new RedFiksneDuljine<Polje>(duljinaNiza);
                for (int s = 0; s < stupaca; ++s)
                {
                    if (polja[r, s] == null)
                        red.Clear();
                    else
                    {
                        red.Enqueue(polja[r, s]);
                        if (red.Count == duljinaNiza)
                            nizovi.Add(new List<Polje>(red));
                    }
                }
            }
            return nizovi;
        }

        private List<IEnumerable<Polje>> DajNizoveSlobodnihPoljaUVertikalnomSmjeru(int duljinaNiza)
        {
            List<IEnumerable<Polje>> nizovi = new List<IEnumerable<Polje>>();
            for (int s = 0; s < stupaca; ++s)
            {
                RedFiksneDuljine<Polje> red = new RedFiksneDuljine<Polje>(duljinaNiza);
                for (int r = 0; r < redaka; ++r)
                {
                    if (polja[r, s] == null)
                        red.Clear();
                    else
                    {
                        red.Enqueue(polja[r, s]);
                        if (red.Count == duljinaNiza)
                            nizovi.Add(new List<Polje>(red));
                    }
                }
            }
            return nizovi;
        }


        private Polje[,] polja;
        private int redaka;
        private int stupaca;
    }
}
