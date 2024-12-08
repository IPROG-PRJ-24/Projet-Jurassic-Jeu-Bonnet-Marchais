
Console.Clear();
string nextPrint = "";
int selectNumber = 1;
int tailleGrilleX = 10;
int tailleGrilleY = 10;

void PrintIntro()
{
    nextPrint = "JURENSIC WORLD";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();

    nextPrint = "Le plus grand prédateur de l'histoire est à vos trousses !";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "Saurez-vous l'enfermer dans sa cage ?";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    Console.WriteLine();

    nextPrint = "(Appuyer sur n'importe quel touche pour jouer.)";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
    char suite = Console.ReadKey().KeyChar;
    Console.Clear();
}

void PrintSelectScreen(int x)
{
    Console.Clear();
    nextPrint = "JURENSIC WORLD";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    nextPrint = "Choississez avec z et s puis 'espace pour confirmer";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    if (x == 1)
    {
        nextPrint = ">-  Options  -<";
        Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Play";
        Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Règles";
        Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
    }
    else if (x == 2)
    {
        nextPrint = "Options";
        Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = ">-  Play  -<";
        Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Règles";
        Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
    }
    else
    {
        nextPrint = "Options";
        Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Play";
        Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = ">-  Règles  -<";
        Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
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
    int tailleGrilleXTemp = 0;
    bool tailleGrilleXOk = false;
    while (!tailleGrilleXOk || tailleGrilleXTemp < 5)
    {
        tailleGrilleXOk = int.TryParse(Console.ReadLine()!, out tailleGrilleXTemp);
        if (!tailleGrilleXOk || tailleGrilleXTemp < 5)
        {
            nextPrint = " !!! Veuillez rentrer une taille valide. !!! ";
            Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
            Console.WriteLine(nextPrint);
        }
    }
    Console.WriteLine("veuillez rentrer une taille de grille");
    int tailleGrilleYTemp = 0;
    bool tailleGrilleYOk = false;
    while (!tailleGrilleYOk || tailleGrilleYTemp < 5)
    {
        tailleGrilleYOk = int.TryParse(Console.ReadLine()!, out tailleGrilleYTemp);
        if (!tailleGrilleYOk || tailleGrilleYTemp < 5)
        {
            nextPrint = " !!! Veuillez rentrer une taille valide. !!! ";
            Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
            Console.WriteLine(nextPrint);
        }
    }
    tailleGrilleX = tailleGrilleXTemp;
    tailleGrilleY = tailleGrilleYTemp;
}

void Options()
{
    Console.Clear();
    nextPrint = "La faut faire les options";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "(Appuyer sur n'importe quel touche pour revenir à l'écran de sélection)";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
    char suite = Console.ReadKey().KeyChar;
    Console.Clear();
}

void Rules()
{
    Console.Clear();
    nextPrint = "La faut écrire les règles";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "(Appuyer sur n'importe quel touche pour revenir à l'écran de sélection)";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
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


void PrintAscii()
{
    nextPrint = "                      ,";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "               ,  ;:._.-`''.";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "             ;.;'.;`      _ `.";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "              ',;`       ( \x5c ,`-.  ";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "           `:.`,         (_/ ;\x5c  `-.";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "            ';:              / `.   `-._";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "          `;.;'              `-,/ .     `-.";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "          ';;'              _    `^`       `.";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "         ';;            ,'-' `--._          ;";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "':      `;;        ,;     `.    ':`,,.__,,_ /";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = " `;`:;`;:`       ,;  '.    ;,      ';';':';;`";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "              .,; '    '-._ `':.;   ";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "            .:; `          '._ `';;,";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "          ;:` `    :'`'       ',__.)";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "        `;:;:.,...;'`'";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "      ';. '`'::'`''  .'`'";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "    ,'jgs`';;:,..::;`'`'";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = ", .;`      `'::''`";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = ",`;`.";
    Console.SetCursorPosition((Console.WindowWidth)/3, Console.CursorTop);
    Console.WriteLine(nextPrint);
}


PrintAscii();