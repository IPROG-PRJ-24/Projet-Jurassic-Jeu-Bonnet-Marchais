
using System.IO.Compression;

Random rnd = new Random();
Console.Clear(); //Réinitialisation de la console 


#region Initialisation
/*-----------------------------------------------------*/
/*1- INITIALISATION DE TOUTES LES VARIABLES ET OBJETS */
/*-----------------------------------------------------*/


/*Tailles de la grille*/
int lengthGridX = 10;
int lengthGridY = 10;



string nextPrint = "";//Servira pour le placement du curseur au milieu lors de l'affichage du texte
bool playableBlue = true;// Booléen qui permet de contrôler Blue ou non
string difficulty = "Normal";
int selectNumber = 1;
void PrintIntro()//-> Affiche l'introduction du jeu
{
    nextPrint = "JURENSIC WORLD";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop); // Placement du curseur au centre de la console
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();
    PrintAscii();
    Console.WriteLine();
    Console.WriteLine();

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

void PrintSelectScreen(int x)//-> Affiche l'écran de selection en fonction de l'entier x (il y a 4 possibilités)
{
    Console.Clear();
    nextPrint = "JURENSIC WORLD";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();
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

        nextPrint = "Jouer Classic";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Jouer Indominus Rex";
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
        nextPrint = ">-  Jouer Classic  -<";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;

        nextPrint = "Jouer Indominus Rex";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Règles";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
    }
    else if (x == 3)
    {
        nextPrint = "Options";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Jouer Classic";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Red;
        nextPrint = ">-  Jouer Indominus Rex  -<";
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

        nextPrint = "Jouer Classic";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();

        nextPrint = "Jouer Indominus Rex";
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
                if (selectNumber != 4)
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

        nextPrint = "IndominusRex est attirée par les humains. On vous a donné un filet qui l'empêche de bouger pour vous aider.";
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
void PrintColoredText(string input)//-> Affiche un texte avec les couleurs pour chaque personnage
{
    {
        string[] words = input.Split(' ');

        foreach (var word in words)
        {
            if (word.Contains("Owen"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (word.Contains("Blue"))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (word.Contains("l'Indominus"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (word.Contains("L'Indominus"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (word.Contains("Rex"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (word.Contains("Maisie"))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (word.Contains("grenade"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write(word + " ");
        }

        Console.ResetColor(); // Reset to default color
        Console.WriteLine();
    }
}
void Rules()//-> Affiche les règles du jeu
{
    Console.Clear();
    nextPrint = "Bienvenue dans JURENSIC WORLD. Nous allons vous expliquer comment jouer";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();

    string regle1 = "But du jeu :   ";
    string regle2 = "Vous incarnerez 2 personnages dans ce jeu : Owen Grady et la raptor Blue. \nIls luttent ensembles pour sauver la petite Maisie qui est poursuivie par l'Indominus Rex.";
    string regle3 = "Pour gagner une partie vous devrez enfermer L'Indominus Rex à l'aide de crevasse. \nCes crevasses sont provoquées par les grenades que Owen est capable de lancer. \nChaque grenade provoque deux crevasses côte à côte et Owen possède un nombre limité de grenade. \nIl ne peut lancer les grenades qu'à trois cases de lui maximum.";
    string regle4 = "Owen et Blue ne se déplacent que d'une case à la fois. \nA chaque tour, Owen à le choix entre se déplacer ou lancer une grenade. \nBlue quant à elle peut faire reculer l'Indominus Rex lorsqu'elle entre en contact avec elle. \nL'Indominus Rex recule alors de 3 cases (ou moins si elle rencontre une crevasse ou un bord du jeu) et est immobilisée pour ce tour.";
    string regle5 = "Maisie elle n'est pas un personnage jouable, elle panique face à la férocité de l'Indominus Rex et bouge donc aléatoirement d'une case par tour. \n( Cependant elle ne peut pas se jeter sur l'Indominus Rex )";
    string regle6 = "L'Indominus Rex est attirée par tout le monde, elle ne sait plus où donner de la tête. Ses mouvements sont donc aléatoires. \nL'Indominus Rex peut manger Owen ou Maisie la partie sera alors perdue. \nL'Indominus Rex ne mange pas ses compères, Blue ne peut donc pas être mangée. \nDe plus l'Indominus Rex à la peau trop dure pour craindre les grenades.";
    string regle7 = "Si n'importe quel personnage de votre équipe se prend une grenade, c'est la défaite. \nAttention donc à bien viser car une grenade provoque 2 crevasses, \nla première là où Owen l'a lancée et la deuxième aléatoirement entre les 4 positions possibles autour de la première crevasse";
    string regle8 = "Dans le mode Difficile, une fois sur cinq l'Indominus Rex bouge 2 fois et cherche constamment l'humain le plus proche. On vous fournit un filet qui l'empêche de bouger pendant 2 tours.";
    string regle9 = "Dans le mode Impossible, l'Indominus Rex bouge 2 fois à chaque tour tout en cherchant l'humain le plus proche à chaque tour. On vous fournit un filet qui l'empêche de bouger pendant 2 tours.";
    string regle10 = "Vous pouvez également choisir de ne pas controler Blue, dans quel cas elle se déplacera automatiquement vers l'Indominus Rex à chaque fois.";

    PrintColoredText(regle1);
    Console.WriteLine();
    PrintColoredText(regle2);
    Console.WriteLine();
    PrintColoredText(regle3);
    Console.WriteLine();
    PrintColoredText(regle4);
    Console.WriteLine();
    PrintColoredText(regle5);
    Console.WriteLine();
    PrintColoredText(regle6);
    Console.WriteLine();
    PrintColoredText(regle7);
    Console.WriteLine();
    PrintColoredText(regle8);
    Console.WriteLine();
    PrintColoredText(regle9);
    Console.WriteLine();
    PrintColoredText(regle10);
    Console.WriteLine();

    nextPrint = "Appuyer sur n'importe quelle touche pour revenir à l'écran de selection.";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    char suite = Console.ReadKey().KeyChar;
    Console.Clear();
}


void InterfaceJeu()//-> Effectue toutes les interfaces et actions avant le lancement réel du jeu (Ecran de sélection/Options/Règles)
{
    PrintIntro();
    while (selectNumber != 2 && selectNumber != 3)
    {
        SelectScreen();
        if (selectNumber == 1)
        {
            Options();
        }
        if (selectNumber == 4)
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
int nbNet = (lengthGridX + lengthGridY) / 5;

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
int indominusRexNoMove = 0;

/* Initialisation Maisie*/
char maisie = 'M';
int maisiePositionX = rnd.Next(1, 3);
int maisiePositionY = rnd.Next(1, 3);
#endregion

#region Affichage de la grille
/*-----------------------------------------------------*/
/*------------- 2- AFFICHAGE DE LA GRILLE -------------*/
/*-----------------------------------------------------*/

void DefineOwen(int x, int y) //-> Permet de mettre à jour la position d'Owen sur la grille lors de son affichage
{
    if ((x == owenPositionX) && (y == owenPositionY))
    {
        grid[y, x] = owen;
    }
}

void DefineBlue(int x, int y) //-> Permet de mettre à jour la position de Blue sur la grille lors de son affichage
{
    if ((x == bluePositionX) && (y == bluePositionY))
    {
        grid[y, x] = blue;
    }
}

void DefineMaisie(int x, int y) //-> Permet de mettre à jour la position de Maisie sur la grille lors de son affichage
{
    if ((x == maisiePositionX) && (y == maisiePositionY))
    {
        grid[y, x] = maisie;
    }
}

void DefineIndominusRex(int x, int y) //-> Permet de mettre à jour la position de l'IndominusRex sur la grille lors de son affichage
{
    if ((x == indominusRexPositionX) && (y == indominusRexPositionY))
    {
        grid[y, x] = indominusRex;
    }
}

void DefineGrenade(int x, int y) //-> Permet d'afficher l'endroit où on lance la grenade sur la grille lors de son affichage pendant un lancer de grenade de Owen
{
    if ((x == grenadePositionX) && (y == grenadePositionY))
    {
        grid[y, x] = grenade;
    }
}

void DefineCaracters(int x, int y)//-> Cette procédure réunit les 5 dernières en une seule
{
    DefineOwen(x, y);
    DefineBlue(x, y);
    DefineMaisie(x, y);
    DefineIndominusRex(x, y);
    DefineGrenade(x, y);
}

void ShowGrid() //-> Affichage de la grille 
{
    DefineGrid();
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine();
    for (int i = 0; i < lengthGridY; i++) // Parcours de la grille 
    {
        Console.SetCursorPosition((Console.WindowWidth - lengthGridX * 3) / 2, Console.CursorTop);
        for (int j = 0; j < lengthGridX; j++)
        {
            DefineCaracters(j, i);
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
            Console.Write($" {grid[i, j]} "); //Affichage des caractères
            Console.ResetColor();
        }
        Console.WriteLine("");
    }
}
#endregion

#region Déplacements et actions des joueurs, objets et PNJ
/*----------------------------------------------------------------*/
/*---- 3- DEPLACEMENTS ET ACTIONS DES JOUEURS, OBJETS ET PNJ -----*/
/*----------------------------------------------------------------*/


/*Déplacements Joueurs*/
void MoveOwen() //-> Pour faire bouger Owen et lancer ses grenades 
{
    bool again = true;
    bool accessNet = difficulty != "Normal";
    while (again) //Tant que l'on ne rentre pas un mouvement valide
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

        if (accessNet)
        {
            nextPrint = $"Puisque vous êtes en mode difficile, vous avez accès à {nbNet} filets. Appuyer sur F pour l'utiliser.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
        }

        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        char action = Console.ReadKey().KeyChar;
        action = Char.ToLower(action);


        //On ajoute en variable temporaire les position X et Y
        int tempX = owenPositionX;
        int tempY = owenPositionY;
        double distanceIR = Math.Sqrt((owenPositionX - indominusRexPositionX) * (owenPositionX - indominusRexPositionX) + (owenPositionY - indominusRexPositionY) * (owenPositionY - indominusRexPositionY));

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
            case 'f':
                if (accessNet && nbNet > 0 && distanceIR < 4)
                {
                    ThrowNet();
                }
                else
                {
                    again = true;
                }
                break;
            default: // Sécurité si le joueur appuie sur une touche non-valide. Cela recommence l'action.
                again = true;
                break;
        }

        if (IsMoveOwenBlueValid(tempX, tempY)) // Si le mouvement est valide, on actualise les positions temporaires
        {
            owenPositionX = tempX;
            owenPositionY = tempY;
        }
        else//Sinon on relance la boucle
        {
            again = true;
        }
    }
    DefineOwen(owenPositionX, owenPositionY); // On redéfinit la position dans la grille
    DefineGrid();//On actualise la grille de crevasses si Owen a lancé une grenade
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
        finalChar = action; // On garde en mémoire d'où provient Blue pour faire reculer l'Indominus Rex dans la bonne direction


        //Les lignes suivantes ont la même logique que MoveOwen()
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
    //

    StepBackIndominusRex(finalChar);
    DefineBlue(bluePositionX, bluePositionY);
    DefineIndominusRex(indominusRexPositionX, indominusRexPositionY);
}

void MoveIndominusRexPlayer() //-> Pour faire bouger Blue et reculer l'IndominusRex
{
    bool again = true;
    while (again)
    {
        again = false;
        ShowGrid();
        nextPrint = "Vous jouez la terrible Indominus Rex";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        nextPrint = "Appuyer sur Z pour monter / Q pour aller à gauche / S pour descendre / D pour aller à droite";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        nextPrint = "Vous devez manger Owen ou Maisie";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);

        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        char action = Console.ReadKey().KeyChar;
        action = Char.ToLower(action);

        //Les lignes suivantes ont la même logique que MoveOwen()
        int tempX = indominusRexPositionX;
        int tempY = indominusRexPositionY;

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
    //
    DefineIndominusRex(indominusRexPositionX, indominusRexPositionY);
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
        if (isSmartIR)//L'indominus Rex bouge vers le joueurs le plus proche 
        {
            directionMouvement = SmartIR(ClosestPlayer(indominusRexPositionX, indominusRexPositionY));
            isSmartIR = false;
        }
        else //Si elle ne peut pas, elle bouge aléatoirement
        {
            directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest 
        }

        //Les lignes suivantes ont la même logique que MoveOwen()
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
    //
    DefineIndominusRex(indominusRexPositionX, indominusRexPositionY);
}

void MoveBluePNJ() //-> Pour déplacer Blue quand on ne la contrôle pas
{
    bool again = true;
    int finalMov = 0; // On garde en mémoire d'où provient Blue pour faire reculer l'Indominus Rex dans la bonne direction
    bool isSmartBlue = true;
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

        //Les lignes suivantes ont la même logique que MoveOwen()
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
    //
    DefineBlue(bluePositionX, bluePositionY);
    DefineIndominusRex(indominusRexPositionX, indominusRexPositionY);
}

void MoveMaisie() //-> Pour déplacer Maisie
{
    bool again = true;
    while (again)
    {
        again = false;
        int directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest

        //Les lignes suivantes ont la même logique que MoveOwen()
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
    //
    DefineMaisie(maisiePositionX, maisiePositionY);
}

void MoveMaisieSmart() //-> Pour déplacer Maisie
{
    bool again = true;
    bool isSmartMaisie = true;
    int directionMouvement = 0;
    while (again)
    {
        if (isSmartMaisie)
        {
            directionMouvement = SmartOwenMaisie(maisiePositionX,maisiePositionY);
            isSmartMaisie = false;
        }
        else
        {
            directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest 
        }

        again = false;

        //Les lignes suivantes ont la même logique que MoveOwen()
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
    //
    DefineMaisie(maisiePositionX, maisiePositionY);
}

void MoveOwenPNJ() //-> Pour déplacer Owen
{
    bool again = true;
    bool isSmartOwen = true;
    int directionMouvement = 0;

    while (again)
    {
        if (isSmartOwen)
        {
            directionMouvement = SmartOwenMaisie(owenPositionX,owenPositionY);
            isSmartOwen = false;
        }
        else
        {
            directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest 
        }

        again = false;

        //Les lignes suivantes ont la même logique que MoveOwen()
        int tempX = owenPositionX;
        int tempY = owenPositionY;

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
            owenPositionX = tempX;
            owenPositionY = tempY;
        }
        else
        {
            again = true;
        }
    }
    //
    DefineOwen(owenPositionX, owenPositionY); // On redéfinit la position dans la grille
    DefineGrid();//On actualise la grille de crevasses si Owen a lancé une grenade  
}

bool IsMoveIRValid(int x, int y)//-> Test si le mouvement est possible pour l'Indominus Rex
{
    return x >= 0 && x < lengthGridX &&
           y >= 0 && y < lengthGridY &&
           grid[y, x] != '*' && grid[y, x] != blue;
}

bool IsMoveMaisieValid(int x, int y)//-> Test si le mouvement est possible pour Maisie
{
    return x >= 0 && x < lengthGridX &&
           y >= 0 && y < lengthGridY &&
           grid[y, x] != '*' && grid[y, x] != blue && grid[y, x] != owen && grid[y, x] != indominusRex;
}

bool IsMoveOwenBlueValid(int x, int y)//-> Test si le mouvement est possible pour Owen et Blue
{
    return x >= 0 && x < lengthGridX &&
           y >= 0 && y < lengthGridY &&
           grid[y, x] != '*' && grid[y, x] != maisie;
}
/*Actions des joueurs*/
void ThrowGrenade() //-> Pour lancer une grenade d'Owen
{
    grenadePositionX = owenPositionX;//on place la selection de la grenade sur Owen
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
        nextPrint = "Appuyer sur 'Espace' pour confirmer / R pour annuler";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        char action = Console.ReadKey().KeyChar;
        action = Char.ToLower(action);
        switch (action) //On déplace le caractère G de la même manière que les autres personnages.
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
            case 'r': //Retour au mouvement de Owen dans le cas où le joueur s'est trompé
                again = false;
                grenadePositionX = -1;
                grenadePositionY = -1;
                MoveOwen();
                break;
            case ' ': //Confirme le lancer de grenade
                PlaceGrenade();
                again = false;
                break;
            default:
                again = true;
                break;
        }
    }
}

void ThrowNet() //-> Pour lancer un filet
{
    bool again = true;
    while (again)
    {
        ShowGrid();
        nextPrint = "Vous avez choisi de lancer un filet. L'Indominus doit être à 2 cases de vous maximum. Elle ne pourra plus bouger pendant 2 tours (celui ci inclus).";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        nextPrint = "Appuyer sur 'Espace' pour confirmer / R pour annuler";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        char action = Console.ReadKey().KeyChar;
        action = Char.ToLower(action);
        switch (action)
        {
            case 'r':
                again = false;
                MoveOwen();
                break;
            case ' ':
                indominusRexNoMove += 2;
                nbNet --;
                again = false;
                break;
            default:
                again = true;
                break;
        }
    }
}

void PlaceGrenade() //-> Place la grenade sur la grille au moment de la confirmation du lancer
{
    nbGrenade--;
    trenches[grenadePositionY, grenadePositionX] = '*';//placement de la première grenade
    int direction = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest
    switch (direction)//Placemement de la deuxième grenade
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



void StepBackIndominusRex(char action)//-> Fait reculer l'indominusRex quand Blue la touche
{
    if ((bluePositionX == indominusRexPositionX) && (bluePositionY == indominusRexPositionY))
    {
        indominusRexNoMove ++; // Variable pour savoir si on a fait reculer (Pour empêcher un mouvement de l'IR si elle a été touchée)
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

#region Conditions de victoire ou de pertes
/*-----------------------------------------------------*/
/*------ 4- CONDITIONS DE VICTOIRE OU DE PERTES -------*/
/*-----------------------------------------------------*/

int conditionWinLose = 0; //Variable qui retient quelle condition d'arrêt a été validée 

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

bool CheckPosition()//-> Vérifie que les cases atteignables par l'Indominus Rex ne contiennent pas les autres personnages 
{
    if (colorBackground[owenPositionY, owenPositionX] == 'C')
    {
        return false;
    }
    if (colorBackground[maisiePositionY, maisiePositionX] == 'C')
    {
        return false;
    }
    if (colorBackground[bluePositionY, bluePositionX] == 'C')
    {
        return false;
    }
    return true;
}

bool CheckWin()//-> Regarde si la condition de victoire est vérifiée (Indominus Rex enfermée)
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

bool LosingConditionGrenadePerdu()//-> Regarde les conditions de perte concernant la grenade lancée sur d'autre 
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
    if (trenches[owenPositionY, owenPositionX] == '*')
    {
        conditionWinLose = 7;
        lose = false;
    }
    return lose;
}

bool LosingConditionGrenade()//-> Regarde les conditions de perte concernant le nombre de grenade
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

            nextPrint = "VICTOIRE!";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Vous avez triomphé face au terrible Indominus Rex.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Elle n'avait aucune chance face à vos tirs.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            break;

        case 2:
            bluePositionX = -1;
            bluePositionY = -1;

            nextPrint = "C'est PERDU";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Blue a pris une grenade.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Il faudrait apprendre à viser....";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();
            break;

        case 3:
            maisiePositionX = -1;
            maisiePositionY = -1;

            nextPrint = "C'est PERDU";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Maisie a pris une grenade.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "L'Indominus Rex n'était pas la plus grande menace il semblerait....";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();
            break;

        case 4:

            nextPrint = "C'est PERDU";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Owen n'as plus de grenade.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Il ne reste plus qu'a espérer que les jambes de Owen et Maisie soient assez rapides....";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();
            break;

        case 5:
            owenPositionX = -1;
            owenPositionY = -1;
            nextPrint = "C'est PERDU";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "L'Indominus Rex a mangé Owen.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Il ne reste plus personne pour défendre la Terre....";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();
            break;

        case 6:
            maisiePositionX = -1;
            maisiePositionY = -1;
            nextPrint = "C'est PERDU";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "L'Indominus Rex a mangé Maisie.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Owen a raté sa mission....";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();
            break;

        case 7:
            owenPositionX = -1;
            owenPositionY = -1;
            nextPrint = "C'est PERDU";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Owen a pris une grenade.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "C'est l'Indominus Rex qu'il faut viser si jamais....";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();
            break;
    }
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    DefineGrid();
    for (int i = 0; i < lengthGridY; i++) // Parcours de la grille 
    {
        Console.SetCursorPosition((Console.WindowWidth - lengthGridX * 3) / 2, Console.CursorTop);
        for (int j = 0; j < lengthGridX; j++)
        {
            DefineCaracters(j, i);
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
            Console.Write($" {grid[i, j]} "); //Affichage des caractères
            Console.ResetColor();
        }
        Console.WriteLine("");
    }
}

void TexteWinLoseAlternatif()//-> Affiche les texte une fois que l'on a gagné/perdu en fonction de la cause.
{
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine();
    switch (conditionWinLose)
    {
        case 1:

            nextPrint = "C'est PERDU";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Vous avez fini enfermer.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Normalement un T-Rex c'est plus fort que 2 humains non ?";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            break;

        case 5:
            owenPositionX = -1;
            owenPositionY = -1;
            nextPrint = "VICTOIRE!!";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "L'Indominus Rex a mangé Owen.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "La chaire d'Owen est délicieuse...";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();
            break;

        case 6:
            maisiePositionX = -1;
            maisiePositionY = -1;
            nextPrint = "VICTOIRE!!";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "L'Indominus Rex a mangé Maisie.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();

            nextPrint = "Personne ne peut vous arrêter.";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
            Console.WriteLine();
            break;
    }
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    DefineGrid();
    for (int i = 0; i < lengthGridY; i++) // Parcours de la grille 
    {
        Console.SetCursorPosition((Console.WindowWidth - lengthGridX * 3) / 2, Console.CursorTop);
        for (int j = 0; j < lengthGridX; j++)
        {
            DefineCaracters(j, i);
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
            Console.Write($" {grid[i, j]} "); //Affichage des caractères
            Console.ResetColor();
        }
        Console.WriteLine("");
    }
}


#endregion

#region Programmes en tout genre
/*-----------------------------------------------------*/
/*----------- 5- PROGRAMMES EN TOUT GENRE ------------ */
/*-----------------------------------------------------*/

void PrintAscii()//-> Affiche un motif de dinosaure
{
    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("                      ,");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("               ,  ;:._.-`''.");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("             ;.;'.;`      _ `.");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("              ',;`       ( \x5c ,`-.  ");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("           `:.`,         (_/ ;\x5c  `-.");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("            ';:              / `.   `-._");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("          `;.;'              `-,/ .     `-.");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("          ';;'              _    `^`       `.");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("         ';;            ,'-' `--._          ;");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("':      `;;        ,;     `.    ':`,,.__,,_ /");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(" `;`:;`;:`       ,;  '.    ;,      ';';':';;`");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("              .,; '    '-._ `':.;   ");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("            .:; `          '._ `';;,");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("          ;:` `    :'`'       ',__.)");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("        `;:;:.,...;'`'");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("      ';. '`'::'`''  .'`'");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine("    ,'jgs`';;:,..::;`'`'");


    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(", .;`      `'::''`");

    Console.SetCursorPosition((Console.WindowWidth) / 3, Console.CursorTop);
    Console.WriteLine(",`;`.");
}

char ClosestPlayer(int x, int y)//-> Recherche l'humain le plus proche
{
    double distanceOwen = Math.Sqrt((x - owenPositionX) * (x - owenPositionX) + (y - owenPositionY) * (y - owenPositionY));
    double distanceMaisie = Math.Sqrt((x - maisiePositionX) * (x - maisiePositionX) + (y - maisiePositionY) * (y - maisiePositionY));
    return distanceOwen < distanceMaisie ? owen : maisie;
}

int SmartIR(char a)//-> Choisie le déplacement vers l'humain le plus proche
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

int SmartBlue()//-> Choisie le déplacement vers l'Indominus Rex
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

int SmartOwenMaisie(int positionX, int positionY)//-> Choisie le déplacement vers l'Indominus Rex
{

    int deltaX = indominusRexPositionX - positionX;
    int deltaY = indominusRexPositionY - positionY;

    if (Math.Abs(deltaX) > Math.Abs(deltaY))
    {
        return deltaX > 0 ? 4 : 2; // Déplacement horizontal
    }
    else
    {
        return deltaY > 0 ? 1 : 3; // Déplacement vertical
    }
}

void RandomGrenades()
{
    bool again = true;
    while(again)
    {
        int randomPositionX = rnd.Next(0,lengthGridX);
        int randomPositionY = rnd.Next(0,lengthGridY);
        if (grid[randomPositionY,randomPositionX] == '.')
        {
            trenches[randomPositionY, randomPositionX] = '*';
            again = false;
        }
        DefineColorBackground();
    }
    

    
}
#endregion

#region Lancement du jeu
/*-----------------------------------------------------*/
/*--------------- 6- LANCEMENT DU JEU ---------------- */
/*-----------------------------------------------------*/

void MainGame() //-> Pour lancer le jeu en effectuant les différentes actions dans l'ordre
{
    bool lose1 = true;
    bool lose2 = true;
    bool lose3 = true;
    bool win = true;
    while (lose1 && lose2 && lose3 && win)
    {
        int test = rnd.Next(1, 5);// Variable pour faire bouger l'Indominus Rex une deuxième fois en difficile
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

        if (indominusRexNoMove != 0)//Si L'Indominus Rex a été repoussée par Blue ou bloqué par le filet, elle passe son tour
        {
            indominusRexNoMove--;
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

void MainGameAlternatif() //-> Pour lancer le jeu en effectuant les différentes actions dans l'ordre
{

    bool lose3 = true;
    bool win = true;
    while (lose3 && win)
    {
        MoveIndominusRexPlayer();
        lose3 = LosingConditionManger();
        MoveOwenPNJ();
        MoveBluePNJ();
        MoveMaisieSmart();
        RandomGrenades();
        win = CheckWin();
    }
    TexteWinLoseAlternatif();
}

if (selectNumber == 3)
{
    MainGameAlternatif();
}
else
{
    MainGame();
}

#endregion