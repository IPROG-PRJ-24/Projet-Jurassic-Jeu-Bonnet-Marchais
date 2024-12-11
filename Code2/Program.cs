
using System.IO.Compression;

Random rnd = new Random();
Console.Clear();


#region Initialisation
/*-----------------------------------------------------*/
/*1- INITIALISATION DE TOUTES LES VARIABLES ET OBJETS */
/*-----------------------------------------------------*/


/*Tailles de la grille*/
int lengthGridX = 10;
int lengthGridY = 10;



string nextPrint = "";//Servira pour le placement du curseur au milieu lors de l'affichage du texte
bool playableBlue = true;
string difficulty = "Normal";
int selectNumber = 1;
void PrintIntro()//-> Affiche l'introduction du jeu
{
    nextPrint = "JURENSIC WORLD";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();
    PrintAscii();

    nextPrint = "Le plus grand prédateur de l'histoire est à vos trousses !";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "Saurez-vous l'enfermer dans sa cage ?";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    Console.WriteLine();

    nextPrint = "(Appuyer sur n'importe quelle touche pour jouer.)";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
    char suite = Console.ReadKey().KeyChar;
    Console.Clear();
}

void PrintSelectScreen(int x)//-> Affiche l'écran de selection en fonction de l'entier x (il y a 3 possibilités)
{
    Console.Clear();
    nextPrint = "JURENSIC WORLD";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();
    PrintAscii();
    nextPrint = "Naviguer avec z pour monter et s pour descendre";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    nextPrint = "Appuyer sur 'espace' pour confirmer votre choix";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();
    nextPrint = "Vous êtes en difficulté: " + difficulty;
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();

    if (x == 1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        nextPrint = ">-  Options  -<";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;

        nextPrint = "Jouer";
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

        Console.ForegroundColor = ConsoleColor.Red;
        nextPrint = ">-  Jouer  -<";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;

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

        nextPrint = "Jouer";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;
        nextPrint = ">-  Règles  -<";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
    }

}
void SelectScreen()//-> Permet la selection des différents écrans de selection
{
    Console.Clear();
    bool again = true;
    while (again)
    {
        PrintSelectScreen(selectNumber);
        Console.SetCursorPosition(Console.WindowWidth / 2, Console.CursorTop);
        char action = Console.ReadKey().KeyChar;
        Console.Beep(440, 100); // Beep pour un feedback de sélection
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


void ChooseLengthGrid()//-> Permet de choisir la taille de la grille
{
    Console.Clear();
    PrintAscii();
    Console.WriteLine();
    Console.WriteLine();
    nextPrint = "Veuillez rentrer la largeur de la grid:";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    nextPrint = "(La grid ne peut pas être plus petite que 5x5 ou plus grande que 40x40)";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    int tailleGrilleXTemp = 0;
    bool tailleGrilleXOk = false;
    while (!tailleGrilleXOk || tailleGrilleXTemp < 5 || tailleGrilleXTemp > 40)
    {
        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        tailleGrilleXOk = int.TryParse(Console.ReadLine()!, out tailleGrilleXTemp); // Vérification que le joueur rentre un int supérieur à 5
        if (!tailleGrilleXOk || tailleGrilleXTemp < 5 || tailleGrilleXTemp > 40)
        {
            nextPrint = " !!! Veuillez rentrer une taille valide. !!! ";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
        }
    }


    nextPrint = "Veuillez rentrer la hauteur de la grid:";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    nextPrint = "(La grid ne peut pas être plus petite que 5x5 ou plus grande que 40x40)";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    int lengthGridYTemp = 0;
    bool lengthGridYOk = false;
    while (!lengthGridYOk || lengthGridYTemp < 5 || lengthGridYTemp > 40)
    {
        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        lengthGridYOk = int.TryParse(Console.ReadLine()!, out lengthGridYTemp); // Vérification que le joueur rentre un int supérieur à 5
        if (!lengthGridYOk || lengthGridYTemp < 5 || lengthGridYTemp > 40)
        {
            nextPrint = " !!! Veuillez rentrer une taille valide. !!! ";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
        }
    }
    lengthGridX = tailleGrilleXTemp;
    lengthGridY = lengthGridYTemp;
}


/*Choix de la difficulté*/

int chooseOption = 1;
void PrintSelectOptions(int chooseOption)//-> Affiche l'écran des options en fonction de l'entier x (il y a 3 possibilités)
{
    Console.Clear();
    PrintAscii();
    Console.WriteLine();
    Console.WriteLine();

    nextPrint = "Naviguer avec z pour monter et s pour descendre";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    nextPrint = "Appuyer sur 'espace' pour confirmer votre choix";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    nextPrint = "Choississez votre difficulté";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();

    if (chooseOption == 1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        nextPrint = ">-  Contrôle de Blue : " + (playableBlue ? "ON  -<" : "OFF  -<");
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;

        nextPrint = "Normal";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Difficile";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Impossible";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;

    }
    else if (chooseOption == 2)
    {
        nextPrint = "Contrôle de Blue : " + (playableBlue ? "ON" : "OFF");
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;
        nextPrint = ">-  Normal  -<";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;

        nextPrint = "Difficile";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Impossible";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.WriteLine();

        nextPrint = "L'IndominusRex ne sait pas ou donner de la tête, ses mouvements semblent aléatoires";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
    }
    else if (chooseOption == 3)
    {
        nextPrint = "Contrôle de Blue : " + (playableBlue ? "ON" : "OFF");
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Normal";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;
        nextPrint = ">-  Difficile  -<";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;

        nextPrint = "Impossible";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.WriteLine();

        nextPrint = "!!!Attention!!!";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);

        nextPrint = "IndominusRex est attirée par les humains";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
    }
    else
    {
        nextPrint = "Contrôle de Blue : " + (playableBlue ? "ON" : "OFF");
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Normal";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Difficile";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;
        nextPrint = ">-  Impossible  -<";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;

        nextPrint = "Je ne peux que vous souhaiter bonne chance...";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
    }

}
void Options()//-> Permet la selection des différents écran de selection
{
    Console.Clear();
    bool again = true;
    while (again)
    {
        PrintSelectOptions(chooseOption);
        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        char action = Console.ReadKey().KeyChar;
        Console.Beep(440, 100);
        switch (action)
        {
            case 'z':
                if (chooseOption > 1)
                {
                    chooseOption--;
                }
                break;
            case 's':
                if (chooseOption < 4)
                {
                    chooseOption++;
                }
                break;
            case ' ':
                switch (chooseOption)
                {
                    case 1:
                        playableBlue = !playableBlue;
                        break;
                    case 2:
                        difficulty = "Normal";
                        again = false;
                        break;
                    case 3:
                        difficulty = "Difficile";
                        again = false;
                        break;
                    case 4:
                        difficulty = "Impossible";
                        again = false;
                        break;
                }
                break;
        }
    }
}

void Rules()//-> Affiche les règles du jeu
{
    Console.Clear();
    nextPrint = "Là faut écrire les règles";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "(Appuyer sur n'importe quel touche pour revenir à l'écran de sélection)";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
    char suite = Console.ReadKey().KeyChar;
    Console.Clear();
}


void InterfaceJeu()//-> Effectue toutes les interfaces et actions avant le lancement réel du jeu (Ecran de sélection/Options/Règles)
{
    PrintIntro();
    while (selectNumber != 2)
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

InterfaceJeu(); // Lancement d'interface avant la définition du plateau de jeu pour les variables lengthGridX/Y

/*Matrice avec la position des crevasses*/
char[,] trenches = new char[lengthGridY, lengthGridX];
for (int i = 0; i < lengthGridY; i++)
{
    for (int j = 0; j < lengthGridX; j++)
    {
        trenches[i, j] = '.';
    }
}

/*Création d'une grille remplissable pour vérifier la condition de victoire*/
char[,] colorBackground = new char[lengthGridY, lengthGridX];
void DefineColorBackground()    //-> créer une grille identique aux crevasses pour l'utiliser dans la condition de victoire
{
    for (int i = 0; i < lengthGridY; i++)
    {
        for (int j = 0; j < lengthGridX; j++)
        {
            colorBackground[i, j] = trenches[i, j];
        }
    }
}


/*Initialisation de la grille de jeu*/
char[,] grid = new char[lengthGridY, lengthGridX];
void DefineGrid()   //-> Permet de mettre à jours la grille lors des déplacements des différents personnages
{
    for (int i = 0; i < lengthGridY; i++)
    {
        for (int j = 0; j < lengthGridX; j++)
        {
            grid[i, j] = trenches[i, j];
        }
    }
}

/* Initialisation Owen*/
char owen = 'O';
int owenPositionX = lengthGridX - rnd.Next(1, 3);
int owenPositionY = rnd.Next(1, 3);
int nbGrenade = (lengthGridX + lengthGridY) / 2;

/* Initialisation de l'objet grenade*/
char grenade = 'G';
int grenadePositionX = -1;
int grenadePositionY = -1;

/* Initialisation Blue*/
char blue = 'B';
int bluePositionX = rnd.Next(1, 3);
int bluePositionY = lengthGridY - rnd.Next(1, 3);

/* Initialisation Indominus Rex*/
char indominusRex = 'I';
int indominusRexPositionX = lengthGridX - rnd.Next(1, 3);
int indominusRexPositionY = lengthGridY - rnd.Next(1, 3);

/* Initialisation Maisie*/
char maisie = 'M';
int maisiePositionX = rnd.Next(1, 3);
int maisiePositionY = rnd.Next(1, 3);
#endregion

#region Affichage de la grille
/*-----------------------------------------------------*/
/*------------- 2- AFFICHAGE DE LA GRILLE -------------*/
/*-----------------------------------------------------*/

void ShowOwen(int x, int y) //-> Permet de mettre Owen sur la grille lors de son affichage
{
    if ((x == owenPositionX) && (y == owenPositionY))
    {
        grid[y, x] = owen;
    }
}

void ShowBlue(int x, int y) //-> Permet d'afficher Blue sur la grille lors de son affichage
{
    if ((x == bluePositionX) && (y == bluePositionY))
    {
        grid[y, x] = blue;
    }
}

void ShowMaisie(int x, int y) //-> Permet d'afficher Maisie sur la grille lors de son affichage
{
    if ((x == maisiePositionX) && (y == maisiePositionY))
    {
        grid[y, x] = maisie;
    }
}

void ShowIndominusRex(int x, int y) //-> Permet d'afficher IndominusRex sur la grille lors de son affichage
{
    if ((x == indominusRexPositionX) && (y == indominusRexPositionY))
    {
        grid[y, x] = indominusRex;
    }
}

void ShowGrenadeG(int x, int y) //-> Permet d'afficher l'endroit où on lance la grenade sur la grille lors de son affichage pendant un lancer de grenade de Owen
{
    if ((x == grenadePositionX) && (y == grenadePositionY))
    {
        grid[y, x] = grenade;
    }
}

void ShowGrid() //-> Affichage de la grille 
{
    DefineGrid();
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine();
    for (int i = 0; i < lengthGridY; i++)
    {
        Console.SetCursorPosition((Console.WindowWidth - lengthGridX * 3) / 2, Console.CursorTop);
        for (int j = 0; j < lengthGridX; j++)
        {
            ShowOwen(j, i);
            ShowBlue(j, i);
            ShowMaisie(j, i);
            ShowIndominusRex(j, i);
            ShowGrenadeG(j, i);
            if (grid[i, j] == owen) // Pour les couleurs de chaque personnage
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (grid[i, j] == blue)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (grid[i, j] == maisie)
                Console.ForegroundColor = ConsoleColor.Magenta;
            else if (grid[i, j] == indominusRex)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (grid[i, j] == '*')
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {grid[i, j]} ");
            Console.ResetColor();
        }
        Console.WriteLine("");
    }
}
#endregion

#region Déplacements des joueurs, objets et PNJ
/*-----------------------------------------------------*/
/*---- 3- DEPLACEMENTS DES JOUEURS, OBJETS ET PNJ -----*/
/*-----------------------------------------------------*/


/*Déplacements Joueurs*/
void MoveOwen() //-> Pour faire bouger Owen et lancer ses grenades 
{
    bool again = true;
    while (again)
    {
        again = false;
        ShowGrid();

        nextPrint = "Vous jouez Owen";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        nextPrint = "Appuyer sur Z pour monter / Q pour aller à gauche / S pour descendre / D pour aller à droite et E pour lancer une grenade";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);

        nextPrint = $"Il vous reste {nbGrenade} grenade(s)";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        char action = Console.ReadKey().KeyChar;
        action = Char.ToLower(action);

        int tempX = owenPositionX;
        int tempY = owenPositionY;

        switch (action)
        {
            case 'z': 
                tempY--; 
                break; 
            case 'd': 
                tempX++; 
                break; 
            case 's': 
                tempY++; 
                break; 
            case 'q': 
                tempX--; 
                break;
            case 'e':
                ThrowGrenade();
                break;
            default: // Sécurité si le joueur appuie sur une touche non-valide. Recommence l'action.
                again = true;
                break; 
        }

        if (IsMoveOwenBlueValid(tempX, tempY))
        {
            owenPositionX = tempX;
            owenPositionY = tempY;
        }
        else
        {
            again = true;
        } 
    }
}

void MoveBlue() //-> Pour faire bouger Blue et reculer l'IndominusRex
{
    char finalChar = ' ';
    bool again = true;
    while (again)
    {
        again = false;
        ShowGrid();
        nextPrint = "Vous jouez Blue";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        nextPrint = "Appuyer sur Z pour monter / Q pour aller à gauche / S pour descendre / D pour aller à droite";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        nextPrint = "Vous faites reculer l'Indominus Rex si vous allez sur sa case";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);

        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        char action = Console.ReadKey().KeyChar;
        action = Char.ToLower(action);
        finalChar = action; // On garde en mémoire d'où provient Blue pour faire reculer l'Indominus Rex
        
        int tempX = bluePositionX;
        int tempY = bluePositionY;

        switch (action)
        {
            case 'z': 
                tempY--; 
                break; 
            case 'd': 
                tempX++; 
                break; 
            case 's': 
                tempY++; 
                break; 
            case 'q': 
                tempX--; 
                break;
            default:
                again = true;
                break; 
        }

        if (IsMoveOwenBlueValid(tempX, tempY))
        {
            bluePositionX = tempX;
            bluePositionY = tempY;
        }
        else
        {
            again = true;
        }
    }
    StepBackIndominusRex(finalChar);
}

/*Déplacements PNJ*/
void MoveIndominusRex() //-> Pour déplacer IndominusRex
{
    bool again = true;
    bool isSmartIR = difficulty != "Normal"; // Changer le comportement en fonction de la difficulté
    int directionMouvement = 0;
    while (again)
    {
        again = false;
        if (isSmartIR)
        {
            directionMouvement = SmartIR(ClosestPlayer(indominusRexPositionX, indominusRexPositionY));
            isSmartIR = false;
        }
        else
        {
            directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest 
        }
        
        int tempX = indominusRexPositionX;
        int tempY = indominusRexPositionY;

        switch (directionMouvement)
        {
            case 1: 
                tempY--; 
                break; 
            case 2: 
                tempX++; 
                break; 
            case 3: 
                tempY++; 
                break; 
            case 4: 
                tempX--; 
                break; 
        }

        if (IsMoveIRValid(tempX, tempY))
        {
            indominusRexPositionX = tempX;
            indominusRexPositionY = tempY;
        }
        else
        {
            again = true;
        }

    }
}

void MoveBluePNJ() //-> Pour déplacer Blue quand on ne la contrôle pas
{
    bool again = true;
    int finalMov = 0;
    bool isSmartBlue = true ; 
    int directionMouvement = 0;
    while (again)
    {
        again = false;
        if (isSmartBlue)
        {
            directionMouvement = SmartBlue();
            isSmartBlue = false;
        }
        else
        {
            directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest 
        }
        finalMov = directionMouvement;
        
        int tempX = bluePositionX;
        int tempY = bluePositionY;

        switch (directionMouvement)
        {
            case 1: 
                tempY--; 
                break; 
            case 2: 
                tempX++; 
                break; 
            case 3: 
                tempY++; 
                break; 
            case 4: 
                tempX--; 
                break; 
        }

        if (IsMoveOwenBlueValid(tempX, tempY))
        {
            bluePositionX = tempX;
            bluePositionY = tempY;
        }
        else
        {
            again = true;
        }
    }
    switch (finalMov)
    {
        case 1:
            StepBackIndominusRex('z');
            break;
        case 2:
            StepBackIndominusRex('d');
            break;
        case 3:
            StepBackIndominusRex('s');
            break;
        case 4:
            StepBackIndominusRex('q');
            break;
    }
}

void MoveMaisie() //-> Pour déplacer Maisie
{
    bool again = true;
    while (again)
    {
        again = false;
        int directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest
        
        int tempX = maisiePositionX;
        int tempY = maisiePositionY;

        switch (directionMouvement)
        {
            case 1: 
                tempY--; 
                break; 
            case 2: 
                tempX++; 
                break; 
            case 3: 
                tempY++; 
                break; 
            case 4: 
                tempX--; 
                break; 
        }

        if (IsMoveMaisieValid(tempX, tempY))
        {
            maisiePositionX = tempX;
            maisiePositionY = tempY;
        }
        else
        {
            again = true;
        }
    }
}

bool IsMoveIRValid(int x, int y)
{
    return x >= 0 && x < lengthGridX &&
           y >= 0 && y < lengthGridY &&
           grid[y, x] != '*' && grid[y, x] != blue;
}

bool IsMoveMaisieValid(int x, int y)
{
    return x >= 0 && x < lengthGridX &&
           y >= 0 && y < lengthGridY &&
           grid[y, x] != '*' && grid[y, x] != blue && grid[y, x] != owen && grid[y, x] != indominusRex;
}

bool IsMoveOwenBlueValid(int x, int y)
{
    return x >= 0 && x < lengthGridX &&
           y >= 0 && y < lengthGridY &&
           grid[y, x] != '*' && grid[y, x] != maisie;
}
/*Actions des joueurs*/
void ThrowGrenade() //-> Pour lancer une grenade d'Owen
{
    grenadePositionX = owenPositionX;
    grenadePositionY = owenPositionY;
    int distanceY = 0;
    int distanceX = 0;
    bool again = true;
    while (again)
    {
        ShowGrid();
        nextPrint = "Vous avez choisi de lancer une grenade. Owen a une portée de 3 cases.";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        nextPrint = "Appuyer sur Z pour monter / Q pour aller à gauche / S pour descendre / D pour aller à droite";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        nextPrint = "Appuyer sur Espace pour confirmer / R pour annuler";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        char action = Console.ReadKey().KeyChar;
        action = Char.ToLower(action);
        switch (action)
        {
            case 'z':
                if ((grenadePositionY > 0) && (distanceY > -3))
                {
                    distanceY--;
                    grenadePositionY--;
                }
                break;

            case 's':
                if ((grenadePositionY < lengthGridY - 1) && (distanceY < 3))
                {
                    distanceY++;
                    grenadePositionY++;
                }
                break;

            case 'q':
                if ((grenadePositionX > 0) && (distanceX > -3))
                {
                    distanceX--;
                    grenadePositionX--;
                }
                break;

            case 'd':
                if ((grenadePositionX < lengthGridX - 1) && (distanceX < 3))
                {
                    distanceX++;
                    grenadePositionX++;
                }
                break;
            case 'r':
                again = false;
                grenadePositionX = -1;
                grenadePositionY = -1;
                MoveOwen();
                break;
            case ' ':
                PlaceGrenade();
                again = false;
                break;
            default:
                again = true;
                break;
        }
    }
}

void PlaceGrenade() //-> Place la grenade sur la grid au moment de la confirmation du lancer
{
    nbGrenade--;
    trenches[grenadePositionY, grenadePositionX] = '*';
    int direction = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest
    switch (direction)
    {
        case 1:
            if (grenadePositionY > 0)
            {
                trenches[grenadePositionY - 1, grenadePositionX] = '*';
            }
            break;
        case 2:
            if (grenadePositionX < lengthGridX - 1)
            {
                trenches[grenadePositionY, grenadePositionX + 1] = '*';
            }
            break;
        case 3:
            if (grenadePositionY < lengthGridY - 1)
            {
                trenches[grenadePositionY + 1, grenadePositionX] = '*';
            }
            break;
        case 4:
            if (grenadePositionX > 0)
            {
                trenches[grenadePositionY, grenadePositionX - 1] = '*';
            }
            break;
    }
    DefineColorBackground();
    grenadePositionX = -1;
    grenadePositionY = -1;
}

bool blueTouchIndominusRex = false; // Variable pour savoir si on fait reculer
void StepBackIndominusRex(char action)//-> Fait reculer l'indominusRex quand Blue la touche
{
    if ((bluePositionX == indominusRexPositionX) && (bluePositionY == indominusRexPositionY))
    {
        blueTouchIndominusRex = true;
        switch (action)
        {
            case 'z':
                if ((indominusRexPositionY > 2)
                    && (grid[indominusRexPositionY - 3, indominusRexPositionX] != '*')
                    && (grid[indominusRexPositionY - 2, indominusRexPositionX] != '*')
                    && (grid[indominusRexPositionY - 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY -= 3;
                }
                else if ((indominusRexPositionY > 1)
                    && (grid[indominusRexPositionY - 2, indominusRexPositionX] != '*')
                    && (grid[indominusRexPositionY - 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY -= 2;
                }
                else if ((indominusRexPositionY > 0)
                    && (grid[indominusRexPositionY - 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY--;
                }
                break;

            case 's':
                bool isCrevasseS1 = grid[indominusRexPositionY + 1, indominusRexPositionX] != '*';
                if ((indominusRexPositionY < lengthGridY - 3)
                    && (grid[indominusRexPositionY + 3, indominusRexPositionX] != '*')
                    && (grid[indominusRexPositionY + 2, indominusRexPositionX] != '*')
                    && (grid[indominusRexPositionY + 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY += 3;
                }
                else if ((indominusRexPositionY < lengthGridY - 2)
                    && (grid[indominusRexPositionY + 2, indominusRexPositionX] != '*')
                    && (grid[indominusRexPositionY + 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY += 2;
                }
                else if ((indominusRexPositionY < lengthGridY - 1)
                    && (grid[indominusRexPositionY + 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY++;
                }
                break;

            case 'q':
                if ((indominusRexPositionX > 2)
                    && (grid[indominusRexPositionY, indominusRexPositionX - 3] != '*')
                    && (grid[indominusRexPositionY, indominusRexPositionX - 2] != '*')
                    && (grid[indominusRexPositionY, indominusRexPositionX - 1] != '*'))
                {
                    indominusRexPositionX -= 3;
                }
                else if ((indominusRexPositionX > 1)
                    && (grid[indominusRexPositionY, indominusRexPositionX - 2] != '*')
                    && (grid[indominusRexPositionY, indominusRexPositionX - 1] != '*'))
                {
                    indominusRexPositionX -= 2;
                }
                else if ((indominusRexPositionX > 0)
                    && (grid[indominusRexPositionY, indominusRexPositionX - 1] != '*'))
                {
                    indominusRexPositionX--;
                }
                break;

            case 'd':
                if ((indominusRexPositionX < lengthGridX - 3)
                    && (grid[indominusRexPositionY, indominusRexPositionX + 3] != '*')
                    && (grid[indominusRexPositionY, indominusRexPositionX + 2] != '*')
                    && (grid[indominusRexPositionY, indominusRexPositionX + 1] != '*'))
                {
                    indominusRexPositionX += 3;
                }
                else if ((indominusRexPositionX < lengthGridX - 2)
                    && (grid[indominusRexPositionY, indominusRexPositionX + 2] != '*')
                    && (grid[indominusRexPositionY, indominusRexPositionX + 1] != '*'))
                {
                    indominusRexPositionX += 2;
                }
                else if ((indominusRexPositionX < lengthGridX - 1)
                    && (grid[indominusRexPositionY, indominusRexPositionX + 1] != '*'))
                {
                    indominusRexPositionX++;
                }
                break;
        }
    }
}
#endregion

#region Squelette et structure du jeu 
/*-----------------------------------------------------*/
/*--------- 4- SQUELETTE ET STRUCTURE DU JEU ----------*/
/*-----------------------------------------------------*/



void IndominusRexPossibilities(int x, int y)//-> Cherche toutes les cases atteignables par l'IndominusRex
{
    if (x < 0 || x >= lengthGridX || y < 0 || y >= lengthGridY)
        return;
    if (colorBackground[y, x] != '.')
        return;
    colorBackground[y, x] = 'C';

    if (y > 0)
    {
        IndominusRexPossibilities(x, y - 1);
    }
    if (y < lengthGridY - 1)
    {
        IndominusRexPossibilities(x, y + 1);
    }
    if (x > 0)
    {
        IndominusRexPossibilities(x - 1, y);
    }

    if (x < lengthGridX - 1)
    {
        IndominusRexPossibilities(x + 1, y);
    }
}

bool CheckPosition()//-> regarde si l'IndominudRex est enfermée
{
    if (colorBackground[owenPositionY, owenPositionX] == 'C')
    {
        return false;
    }
    if (colorBackground[maisiePositionY, maisiePositionX] == 'C')
    {
        return false;
    }
    return true;
}

int conditionWinLose = 0;
bool CheckWin()//-> Regarde si la condition de victoire est vérifiée
{
    DefineColorBackground();
    IndominusRexPossibilities(indominusRexPositionX, indominusRexPositionY);
    if (CheckPosition())
    {
        conditionWinLose = 1;
        return false;
    }
    return true;
}

bool LosingConditionGrenadePerdu()//-> Regarde les conditions de perte concernant le nombre de grenade
{
    bool lose = true;
    if (trenches[bluePositionY, bluePositionX] == '*')
    {
        conditionWinLose = 2;
        lose = false;
    }
    if (trenches[maisiePositionY, maisiePositionX] == '*')
    {
        conditionWinLose = 3;
        lose = false;
    }
    return lose;
}

bool LosingConditionGrenade()//-> Regarde les conditions de perte concernant la grenade lancée sur d'autre
{
    bool loseGrenade = true;
    if (nbGrenade == 0)
    {
        conditionWinLose = 4;
        loseGrenade = false;
    }
    return loseGrenade;
}

bool LosingConditionManger()//-> Regarde les conditions de perte concernant l'IndominusRex qui mange les joueurs
{
    bool lose = true;
    if (indominusRexPositionX == owenPositionX && indominusRexPositionY == owenPositionY)
    {
        conditionWinLose = 5;
        lose = false;
    }
    if (indominusRexPositionX == maisiePositionX && indominusRexPositionY == maisiePositionY)
    {
        conditionWinLose = 6;
        lose = false;
    }
    return lose;
}

void TexteWinLose()//-> Affiche les texte une fois que l'on a gagné/perdu en fonction de la cause.
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine();
    switch (conditionWinLose)
    {
        case 1:

            Console.WriteLine("VICTOIRE!");
            Console.WriteLine("Vous avez triomphé face au terrible Indominus Rex.");
            Console.WriteLine("Elle n'avait aucune chance face à vos tirs.");
            break;

        case 2:

            Console.WriteLine("C'est PERDU");
            Console.WriteLine("Blue a pris une grenade.");
            Console.WriteLine("Il faudrait apprendre à visé....");
            break;

        case 3:

            Console.WriteLine("C'est PERDU");
            Console.WriteLine("Maisie a pris une grenade.");
            Console.WriteLine("L'Indominus Rex n'était pas la plus grande menace il semblerait....");
            break;

        case 4:

            Console.WriteLine("C'est PERDU");
            Console.WriteLine("Owen n'as plus de grenades.");
            Console.WriteLine("Il ne reste plus qu'a espérer que les jambes de Owen et Maisie soient assez rapides....");
            break;

        case 5:

            Console.WriteLine("C'est PERDU");
            Console.WriteLine("L'Indominus Rex a mangé Owen.");
            Console.WriteLine("Il ne reste plus personne pour defendre la Terre....");
            break;

        case 6:

            Console.WriteLine("C'est PERDU");
            Console.WriteLine("L'Indominus Rex a mangé Maisie.");
            Console.WriteLine("Owen a raté sa mission....");
            break;
    }
}
#endregion

#region Programmes en tout genre
/*-----------------------------------------------------*/
/*----------- 5- Programmes en tout genre ------------ */
/*-----------------------------------------------------*/

void ShowMatrix(char[,] matrix)//-> Affiche une matrice
{
    for (int i = 0; i < lengthGridY; i++)
    {
        for (int j = 0; j < lengthGridX; j++)
        {
            Console.Write($" {matrix[i, j]} ");
        }
        Console.WriteLine("");
    }
}

void PrintAscii()
{
    nextPrint = "                      ,";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "               ,  ;:._.-`''.";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "             ;.;'.;`      _ `.";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "              ',;`       ( \x5c ,`-.  ";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "           `:.`,         (_/ ;\x5c  `-.";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "            ';:              / `.   `-._";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "          `;.;'              `-,/ .     `-.";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "          ';;'              _    `^`       `.";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "         ';;            ,'-' `--._          ;";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "':      `;;        ,;     `.    ':`,,.__,,_ /";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = " `;`:;`;:`       ,;  '.    ;,      ';';':';;`";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "              .,; '    '-._ `':.;   ";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "            .:; `          '._ `';;,";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "          ;:` `    :'`'       ',__.)";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "        `;:;:.,...;'`'";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "      ';. '`'::'`''  .'`'";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = "    ,'jgs`';;:,..::;`'`'";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = ", .;`      `'::''`";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);

    nextPrint = ",`;`.";
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(nextPrint);
}

char ClosestPlayer(int x, int y)
{
    double distanceOwen = Math.Sqrt((x - owenPositionX) * (x - owenPositionX) + (y - owenPositionY) * (y - owenPositionY));
    double distanceMaisie = Math.Sqrt((x - maisiePositionX) * (x - maisiePositionX) + (y - maisiePositionY) * (y - maisiePositionY));
    return distanceOwen < distanceMaisie ? owen : maisie;
}

int SmartIR(char a)
{
    int PNJProcheX = 0;
    int PNJProcheY = 0;
    if (a == maisie)
    {
        PNJProcheX = maisiePositionX;
        PNJProcheY = maisiePositionY;
    }
    if (a == owen)
    {
        PNJProcheX = owenPositionX;
        PNJProcheY = owenPositionY;
    }

    int deltaX = PNJProcheX - indominusRexPositionX;
    int deltaY = PNJProcheY - indominusRexPositionY;

    if (Math.Abs(deltaX) > Math.Abs(deltaY))
    {
        return deltaX > 0 ? 2 : 4; // Déplacement horizontal
    }
    else
    {
        return deltaY > 0 ? 3 : 1; // Déplacement vertical
    }
}

int SmartBlue()
{
    int PNJProcheX = indominusRexPositionX;
    int PNJProcheY = indominusRexPositionY;

    int deltaX = PNJProcheX - bluePositionX;
    int deltaY = PNJProcheY - bluePositionY;

    if (Math.Abs(deltaX) > Math.Abs(deltaY))
    {
        return deltaX > 0 ? 2 : 4; // Déplacement horizontal
    }
    else
    {
        return deltaY > 0 ? 3 : 1; // Déplacement vertical
    }
}
#endregion

#region Lancement du jeu
/*-----------------------------------------------------*/
/*--------------- 6- Lancement du jeu ---------------- */
/*-----------------------------------------------------*/

void MainGame() //-> Pour lancer le jeu en effectuant les différentes actions dans l'ordre
{
    bool lose1 = true;
    bool lose2 = true;
    bool lose3 = true;
    bool win = true;
    while (lose1 && lose2 && lose3 && win)
    {
        int test = rnd.Next(1, 5);
        MoveOwen();
        lose1 = LosingConditionGrenadePerdu();
        lose2 = LosingConditionGrenade();
        if (playableBlue)
        {
            MoveBlue();
        }
        else
        {
            MoveBluePNJ();
        }

        if (blueTouchIndominusRex)
        {
            blueTouchIndominusRex = false;
        }
        else
        {
            MoveIndominusRex();
            if (difficulty == "Difficile")
            {
                if (test == 1)
                {
                    MoveIndominusRex();
                }

            }
            else if (difficulty == "Impossible")
            {
                MoveIndominusRex();
            }
        }
        lose3 = LosingConditionManger();
        MoveMaisie();
        win = CheckWin();

    }
    TexteWinLose();
}
MainGame();

#endregion