Console.Clear();
string nextPrint = "";

void PrintSuperAscii()
{
    nextPrint = "⣶⣿⣷⣦⡀";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⠈⠿⣿⣿⣿⣿⣷⣦";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⢈⣻⣿⣿⣿⣿⡆";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⣤⣤⣴⣿⣿⣿⣿⣿⣿⣦⡀";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⠙⠛⠛⠛⠛⢻⣿⣿⣿⣿⣿⣿⣿⣷⣦⡀";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⠙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⠠⠐⠤⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣀";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⠉⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣤⣄⡀";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⣿⣿⣿⠿⠟⠻⢿⣿⣿⣟⠛⠛⠛⠛⠛⠛⠻⠶⣤⡀";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⠘⢿⣿⣷⠀⠀⠀⠙⠿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠉⠓";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⢙⣿⡇⠀⠀⠀⠀⢸⣿⡃";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "⣀⣤⣤⣶⣿⣿⠀⠀⠀⢀⣠⣿⣿⠇";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    
    nextPrint = "⠉⠉⠋⠉⠀⠀⠀⠐⠺⠿⠿⠟⠛";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
}


int tailleGrilleX = 10;
int tailleGrilleY = 10;
void InterfaceJeu()
{   
    nextPrint = "JURENSIC WORLD";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    PrintSuperAscii();

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();

    nextPrint = "Le plus grand prédateur de l'histoire est à vos trousses !";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "Saurez-vous l'enfermer dans sa cage ?";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    Console.WriteLine();

    nextPrint = "(Appuyer sur n'importe quel touche pour jouer.)";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    char suite = Console.ReadKey().KeyChar;
    Console.Clear();    

    nextPrint = "Definissez la taille du plateau de jeu:";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "(Le plateau de jeu est un carré)";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    int tailleGrille = 0;
    bool tailleGrilleOk = false;
    while (!tailleGrilleOk) 
    {
        tailleGrilleOk = int.TryParse(Console.ReadLine()!, out tailleGrille);
        if (!tailleGrilleOk)
        {
            nextPrint = " !!! Veuillez rentrer une taille valide. !!! ";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
        }
    }
    Console.WriteLine(tailleGrille);
    tailleGrilleX = tailleGrille;
    tailleGrilleY = tailleGrille;
}

InterfaceJeu();
