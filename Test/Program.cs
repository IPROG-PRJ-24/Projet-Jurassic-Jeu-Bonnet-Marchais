
Console.Clear();
string nextPrint = "";
int selectNumber = 1;
int tailleGrilleX = 10;
int tailleGrilleY = 10;

void PrintIntro()
{
    nextPrint = "JURENSIC WORLD";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
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

    Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
    char suite = Console.ReadKey().KeyChar;
    Console.Clear();
}

void PrintSelectScreen(int x)
{
    Console.Clear();
    nextPrint = "JURENSIC WORLD";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    nextPrint = "Choississez avec z et s puis 'espace pour confirmer";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    if (x == 1)
    {
        nextPrint = ">-  Options  -<";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Play";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Règles";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
    }
    else if (x == 2)
    {
        nextPrint = "Options";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = ">-  Play  -<";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Règles";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
    }
    else
    {
        nextPrint = "Options";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Play";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = ">-  Règles  -<";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
    }

}
void SelectScreen()
{
    Console.Clear();
    bool again = true;
    while (again)
    {
        PrintSelectScreen(selectNumber);
        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        char action = Console.ReadKey().KeyChar;
        Console.Beep(440,100);
        switch (action)
        {
            case 'z':
                if (selectNumber != 1)
                {
                    selectNumber--;
                }
                break;
            case 's':
                if (selectNumber != 3)
                {
                    selectNumber++;
                }
                break;
            case ' ':
                again = false;
                break;
        }
    }
}


void ChooseLengthGrid()
{
    Console.Clear();
    Console.WriteLine("veuillez rentrer une taille de grille");
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

void Options()
{
    Console.Clear();
    nextPrint = "La faut faire les options";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "(Appuyer sur n'importe quel touche pour revenir à l'écran de sélection)";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
    char suite = Console.ReadKey().KeyChar;
    Console.Clear();
}

void Rules()
{
    Console.Clear();
    nextPrint = "La faut écrire les règles";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "(Appuyer sur n'importe quel touche pour revenir à l'écran de sélection)";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
    char suite = Console.ReadKey().KeyChar;
    Console.Clear();
}


void InterfaceJeu()
{
    PrintIntro();
    while(selectNumber != 2)
    {
        SelectScreen();
        if (selectNumber == 1)
        {
            Options();
        }
        if (selectNumber == 3)
        {
            Rules();
        }
    }
    ChooseLengthGrid();
        
}






InterfaceJeu();