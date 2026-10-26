namespace CvicenieClassers;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Morituri te salutant.");
        Hrdina nasPrvyHrdina = new Hrdina();
        nasPrvyHrdina.Meno = "Iron-man";
        nasPrvyHrdina.Zdravie = 50;
        nasPrvyHrdina.Energia = 150;

        Hrdina nasDruhyHrdina = new Hrdina();
        nasDruhyHrdina.Meno = "Augustin";
        nasDruhyHrdina.Zdravie = 45;
        nasDruhyHrdina.Energia = 100;

        int silaUtoku = 20;
        while (nasPrvyHrdina.Zdravie > 0 && nasDruhyHrdina.Zdravie > 0)
        {
            bool podarilSaUtok = nasPrvyHrdina.Utok(silaUtoku);
            if (podarilSaUtok)
            {
                nasDruhyHrdina.PrijmiZranenie(silaUtoku);
                Console.WriteLine(nasPrvyHrdina.Meno + " Trafil");
            }
            else
            {
                Console.WriteLine(nasPrvyHrdina.Meno +" je unaveny");
            }
            
             podarilSaUtok = nasDruhyHrdina.Utok(silaUtoku);
            if (podarilSaUtok)
            {
                Console.WriteLine(nasDruhyHrdina.Meno + " Trafil");
                nasPrvyHrdina.PrijmiZranenie(silaUtoku);
            }
            else
            {
                Console.WriteLine(nasDruhyHrdina.Meno +" je unaveny");
            }
        }
        
    }
}

class Hrdina
{
    public string Meno = "";
    public int Zdravie = 100;
    public int Energia = 50;

    public int PrijmiZranenie(int sila)
    {
        Zdravie = Zdravie - sila;
        if (Zdravie < 0)
        {
            Zdravie = 0;
        }

        return Zdravie;
    }

    public bool Utok(int cenaUtoku)
    {
        if (Energia < cenaUtoku)
        {
            return false;
        }
        else
        {
            Energia = Energia - cenaUtoku;
            return true;
        }

    }

    public void VypisAktualnyStav()
    {
        Console.WriteLine("Meno: "+Meno);
        Console.WriteLine("Zdravie: "+Zdravie);
        Console.WriteLine("Energia: "+Energia);
    }
}