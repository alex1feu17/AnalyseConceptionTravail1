using TP1;

class Program
{

    static Labyrinthe? labyrinthe;

    static void Main(String[] args)
    {
        creerLabyrinthe();
    }

    static void afficherOptions()
    {
        int option;

        do
        {
            Console.WriteLine("\n[1] Regénérer le labyrinthe");
            Console.WriteLine("[2] Créer un nouveau labyrinthe");
            Console.WriteLine("[3] Quitter");

            Console.Write("\nOption : ");
            option = Convert.ToInt32(Console.ReadLine());

            if (option == 1) regenererLabyrinthe();
            else if (option == 2) creerLabyrinthe();
            else if (option == 3) return;
        } while (option < 1 || option > 3);
    }

    static void creerLabyrinthe()
    {
        Console.Clear();
        Console.Write("Lignes : ");
        int row = Convert.ToInt32(Console.ReadLine());

        Console.Write("Colonnes : ");
        int col = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        labyrinthe = new Labyrinthe(row, col);

        afficherLabyrinthe();
        afficherOptions();
    }

    static void regenererLabyrinthe()
    {
        if (labyrinthe == null) return;
        labyrinthe.Regenerate();
        afficherLabyrinthe();
        afficherOptions();
    }

    static void afficherLabyrinthe()
    {
        if (labyrinthe == null) return;
        Console.Clear();
        Console.WriteLine("Résultât:\n");
        Console.Write(labyrinthe);
    }
}