using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Linq;

namespace Test
{
  [TestClass]
  public class TestTerminatoraPolja
  {
    private Mreža mreža;
    private TerminatorPolja terminator;
    [TestInitialize]
    public void PripremiMrežuITerminatora()
    {
      Mreža mreža = new Mreža(10, 10);
      terminator = new TerminatorPolja(mreža);
    }

    [TestMethod]
    public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUSrediniMreže()
    {
      IEnumerable<Polje> polja = new Polje[] { new Polje(3, 3), new Polje(3, 4) };
      terminator.UkloniPolja(polja);
      Assert.AreEqual(88, mreža.DajSlobodnaPolja().Count());

      //Dodaj provjeru da su izbačeni (3,3 i 3,4... 2,2 ili 2,5 ili 4,2, 4,5)
    }

    [TestMethod]
    public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUzGornjiRubMreže()
    {

    }

    [TestMethod]
    public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUzGornjiLijevomRubMreže()
    {

    }
    [TestMethod]
    public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUzGornjiDesniRubMreže()
    {

    }
    [TestMethod]
    public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUzDonjiRubMreže()
    {

    }
    [TestMethod]
    public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUzDonjiLijevomRubMreže()
    {

    }
    [TestMethod]
    public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUzDonjiDesnomRubMreže()
    {

    }
  }
}
