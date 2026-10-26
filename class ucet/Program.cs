using System;

namespace class_ucet;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("moja banka");

        Ucet prvyUcet = new Ucet();
        prvyUcet.cislo = "7873";
        prvyUcet.zostatok = 1500m;
        prvyUcet.majitel = "linda";

        Ucet druhyUcet = new Ucet();
        druhyUcet.cislo = "4164";
        druhyUcet.zostatok = 999m;
        druhyUcet.majitel = "paulinka";

        prvyUcet.vypisstav();
        druhyUcet.vypisstav();

        prvyUcet.VlozPeniaze(100m);
        prvyUcet.vypisstav();

        prvyUcet.VlozPeniaze(-50m);
        prvyUcet.vypisstav();

        druhyUcet.VyberPeniaze(250m);
        druhyUcet.vypisstav();

        druhyUcet.VyberPeniaze(2000m);
        druhyUcet.vypisstav();

        druhyUcet.VyberPeniaze(-100m);
        druhyUcet.vypisstav();

        bool udrzanyprevod = prvyUcet.PosliPeniaze(350m, druhyUcet);

        if (udrzanyprevod)
        {
            Console.WriteLine("prevod bol uspesny");
        }
        else
        {
            Console.WriteLine("prevod zlyhal");
        }

        prvyUcet.vypisstav();
        druhyUcet.vypisstav();
    }
}

class Ucet
{
    public string cislo = "";
    public decimal zostatok = 0;
    public string majitel = "";

    public decimal VlozPeniaze(decimal suma)
    {
        if (suma < 0)
        {
            Console.WriteLine("chyba: vkladana suma nemoze byt zaporna");
            return zostatok;
        }

        zostatok += suma;
        return zostatok;
    }

    public bool VyberPeniaze(decimal suma)
    {
        if (suma < 0)
        {
            Console.WriteLine("chyba: vyberana suma nemoze byt zaporna");
            return false;
        }

        if (suma <= zostatok)
        {
            zostatok -= suma;
            return true;
        }
        else
        {
            Console.WriteLine("chyba: nedostatok prostriedkov na ucte");
            return false;
        }
    }

    public bool PosliPeniaze(decimal suma, Ucet cielovyUcet)
    {
        bool udrzanyvyber = this.VyberPeniaze(suma);

        if (udrzanyvyber)
        {
            cielovyUcet.VlozPeniaze(suma);
            return true;
        }

        return false;
    }

    public void vypisstav()
    {
        Console.WriteLine($"ucet {cislo} majitel: {majitel} zostatok: {zostatok} eur");
    }
}