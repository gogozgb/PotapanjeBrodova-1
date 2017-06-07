﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
<<<<<<< HEAD
  public class SlučajniPucač : IPucač
  {
    public SlučajniPucač(Mreža mreža, int duljinaBroda)
    {
      this.mreža = mreža;
      this.duljinaBroda = duljinaBroda;
    }

    public Polje Gađaj()
    {
      var kandidati = DajKandidate();
      Debug.Assert(kandidati.Count > 0);
      gađanoPolje = kandidati[izbornik.Next(kandidati.Count)];
      return gađanoPolje;
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
          Debug.Assert(false);
          break;
      }
    }

    public IEnumerable<Polje> PogođenaPolja
    {
      get
      {
        return pogođenaPolja.Sortiraj();
      }
    }

    private List<Polje> DajKandidate()
    {
      return mreža.DajNizoveSlobodnihPolja(duljinaBroda).SelectMany(niz => niz).ToList();
=======
    public class SlučajniPucač : Pucač, IPucač
    {
        public SlučajniPucač(Mreža mreža, int duljinaBroda) 
            : base(mreža, duljinaBroda)
        {
        }

        public override Polje Gađaj()
        {
            var kandidati = DajKandidate();
            Debug.Assert(kandidati.Count > 0);
            gađanoPolje = kandidati[izbornik.Next(kandidati.Count)];
            return gađanoPolje;
        }

        protected virtual List<Polje> DajKandidate()
        {
            return mreža.DajNizoveSlobodnihPolja(duljinaBroda).SelectMany(niz => niz).ToList();
        }
>>>>>>> Upstream/master
    }

    private Mreža mreža;
    private int duljinaBroda;
    private Polje gađanoPolje;
    private List<Polje> pogođenaPolja = new List<Polje>();
    private Random izbornik = new Random();
  }
}
