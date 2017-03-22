using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
namespace Test
{
  [TestClass]
  public class TestMreže
  {
    [TestMethod]
    public void Mreža_DajSlobodnaPoljaVraćaSvaPoljaZaPočetnuMrežu()
    {
      Mreža m1 = new Mreža(5, 5);
      Assert.AreEqual(25, m1.DajSlobodnaPolja().Count());
    }

    [TestMethod]
    public void Mreža_DajSlobodnaPoljaVraća24PoljaZaMrežu5x5NakonJednogUklonjenogPoljaZadanogRetkomIStupcem()
    {
      Mreža m1 = new Mreža(5, 5);
      m1.UkloniPolje(1, 1);
      Assert.AreEqual(24, m1.DajSlobodnaPolja().Count());
      Assert.IsFalse(m1.DajSlobodnaPolja().Contains(new Polje(1, 1)));
    }

    [TestMethod]
    public void Mreža_DajSlobodnaPoljaVraća24PoljaZaMrežu5x5NakonJednogUklonjenogPolja()
    {
      Mreža m1 = new Mreža(5, 5);
      m1.UkloniPolje(new Polje(1, 1));
      Assert.AreEqual(24, m1.DajSlobodnaPolja().Count());
      Assert.IsFalse(m1.DajSlobodnaPolja().Contains(new Polje(1, 1)));
    }

    [TestMethod]
    public void Mreža_DajSlobodnaPoljaVraća223PoljaZaMrežu5x5NakonDvaUklonjenogPolja()
    {
      Mreža m = new Mreža(5, 5);
      m.UkloniPolje(1, 1);
      m.UkloniPolje(4, 4);
      Assert.AreEqual(23, m.DajSlobodnaPolja().Count());
      Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
      Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(4, 4)));
    }
    [TestMethod]
    public void Mreža_UkloniPoljeBacaIznimkuZaNepostojećiRedak()
    {
      try
      {
        Mreža m = new Mreža(5, 5);
        m.UkloniPolje(6, 1);
        Assert.Fail();
      }
      catch (IndexOutOfRangeException)
      {
        Assert.IsTrue(true);
      }
      catch(Exception)
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    public void Mreža_UkloniPoljeBacaIznimkuZaNepostojećiStupac()
    {
      try
      {
        Mreža m = new Mreža(5, 5);
        m.UkloniPolje(1, 6);
        Assert.Fail();
      }
      catch (IndexOutOfRangeException)
      {
        Assert.IsTrue(true);
      }
      catch (Exception)
      {
        Assert.Fail();
      }
    }
  }
}
