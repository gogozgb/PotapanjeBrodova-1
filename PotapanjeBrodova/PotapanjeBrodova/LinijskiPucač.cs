using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
<<<<<<< HEAD
  public class LinijskiPucač : IPucač
  {
    public LinijskiPucač(Mreža mreža, IEnumerable<Polje> pogođena, int duljinaBroda)
    {
      this.mreža = mreža;
      this.pogođenaPolja = new List<Polje>(pogođena);
      this.duljinaBroda = duljinaBroda;
=======
    public class LinijskiPucač : Pucač, IPucač
    {
        public LinijskiPucač(Mreža mreža, IEnumerable<Polje> pogođena, int duljinaBroda)
            : base(mreža, pogođena, duljinaBroda)
        {
            Debug.Assert(pogođena.Count() == 2);
        }

        public override Polje Gađaj()
        {
            List<IEnumerable<Polje>> nizoviPolja = DajNizovePoljaUNastavku();
            // ako niz postoji samo na jednu stranu, gađamo njegovo prvo (najbliže) polje:
            if (nizoviPolja.Count == 1)
                gađanoPolje = nizoviPolja[0].First();
            // inače, slučajnim odabirom:
            else
            {
                int indeks = izbornik.Next(2);
                gađanoPolje = nizoviPolja[indeks].First();
            }
            return gađanoPolje;
        }

        private List<IEnumerable<Polje>> DajNizovePoljaUNastavku()
        {
            if (PogođenaPolja.First().Redak == PogođenaPolja.Last().Redak)
                return DajNizovePoljaLijevoDesno();
            return DajNizovePoljaGoreDolje();
        }

        private List<IEnumerable<Polje>> DajNizovePoljaLijevoDesno()
        {
            return DajNizovePoljaUNastavku(Smjer.Lijevo, Smjer.Desno);
        }

        private List<IEnumerable<Polje>> DajNizovePoljaGoreDolje()
        {
            return DajNizovePoljaUNastavku(Smjer.Gore, Smjer.Dolje);
        }

        private List<IEnumerable<Polje>> DajNizovePoljaUNastavku(Smjer odPrvogPolja, Smjer odZadnjegPolja)
        {
            List<IEnumerable<Polje>> nizovi = new List<IEnumerable<Polje>>();
            Polje prvoPolje = PogođenaPolja.First();
            var nizDoPrvogPolja = mreža.DajNizSlobodnihPolja(prvoPolje, odPrvogPolja);
            if (nizDoPrvogPolja.Count() > 0)
                nizovi.Add(nizDoPrvogPolja);
            Polje zadnjePolje = PogođenaPolja.Last();
            var nizDoZadnjegPolja = mreža.DajNizSlobodnihPolja(zadnjePolje, odZadnjegPolja);
            if (nizDoZadnjegPolja.Count() > 0)
                nizovi.Add(nizDoZadnjegPolja);
            return nizovi;
        }
>>>>>>> Upstream/master
    }

    public Polje Gađaj()
    {
      var kandidati = DajKandidate();
      return kandidati[izbornik.Next(kandidati.Count())];

    }

    public void ObradiGađanje(RezultatGađanja rezultat)
    {
      mreža.UkloniPolje(gađanoPolje);
      switch (rezultat)
      {
        case RezultatGađanja.Promašaj:
          return;
        case RezultatGađanja.Pogodak:
          pogođenaPolja.Add(gađanoPolje);
          return;
        case RezultatGađanja.Potopljen:
          pogođenaPolja.Add(gađanoPolje);
          TerminatorPolja terminator = new TerminatorPolja(mreža);
          terminator.UkloniPolja(pogođenaPolja);
          return;
        default:
          break;
      }
    }

    public IEnumerable<Polje> PogođenaPolja
    {
      get
      {
        return pogođenaPolja;
      }
    }

    private List<Polje> DajKandidate()
    {
      if (pogođenaPolja.First().Redak == pogođenaPolja.Last().Redak)
      return   DajHorizontalnaPolja();
      return DajVertikalnaPolja();
    }

    List<Polje> DajHorizontalnaPolja()
    {
      List<Polje> polja = new List<Polje>();
      Polje prvo = pogođenaPolja.First();
      Polje zadnje = pogođenaPolja.Last();

      var lijevaPolja = mreža.DajNizSlobodnihPolja(prvo, Smjer.Lijevo);
      if (lijevaPolja.Count() > 0)
        polja.Add(lijevaPolja.First());
      var desnaPolja = mreža.DajNizSlobodnihPolja(prvo, Smjer.Desno);
      if (desnaPolja.Count() > 0)
        polja.Add(desnaPolja.First());
      return polja;
    }

    List<Polje> DajVertikalnaPolja()
    {
      List<Polje> polja = new List<Polje>();
      return polja;

    }
    private Mreža mreža;
    private List<Polje> pogođenaPolja;
    private int duljinaBroda;
    private Random izbornik = new Random();
    private Polje gađanoPolje;
  }
}
