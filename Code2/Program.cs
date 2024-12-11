using System;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms;
Random rnd = new Random();
Console.Clear();


#region Initialisation
/*-----------------------------------------------------*/
/*1- INNITIALISATION DE TOUTES LES VARIABLES ET OBJETS */
/*-----------------------------------------------------*/


/*Tailles de la grille*/
int tailleGrilleX = 10;
int tailleGrilleY = 10;



string nextPrint = "";//Servira pour le placement du curseur au milieu lors de l'affichage du texte

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

    nextPrint = "(Appuyer sur n'importe quel touche pour jouer.)";
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
    nextPrint = "Choississez avec z et s puis 'espace' pour confirmer";
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

        Console.ForegroundColor = ConsoleColor.Red;
        nextPrint = ">-  Play  -<";
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

        nextPrint = "Play";
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
void SelectScreen()//-> Permet la selection des différents écran de selection
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


void ChooseLengthGrid()//-> Permmet de choisir la taille de la grille
{
    Console.Clear();
    PrintAscii();
    Console.WriteLine();
    Console.WriteLine();
    nextPrint = "Veuillez rentrer la largeur de la grille:";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    nextPrint = "(La grille ne peut pas être plus petite que 5x5)";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    int tailleGrilleXTemp = 0;
    bool tailleGrilleXOk = false;
    while (!tailleGrilleXOk || tailleGrilleXTemp < 5)
    {
        Console.SetCursorPosition((Console.WindowWidth)/ 2, Console.CursorTop);
        tailleGrilleXOk = int.TryParse(Console.ReadLine()!, out tailleGrilleXTemp);
        if (!tailleGrilleXOk || tailleGrilleXTemp < 5)
        {
            nextPrint = " !!! Veuillez rentrer une taille valide. !!! ";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
        }
    }


    nextPrint = "Veuillez rentrer la hauteur de la grille:";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    nextPrint = "(La grille ne peut pas être plus petite que 5x5)";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);

    int tailleGrilleYTemp = 0;
    bool tailleGrilleYOk = false;
    while (!tailleGrilleYOk || tailleGrilleYTemp < 5)
    {
        Console.SetCursorPosition((Console.WindowWidth)/ 2, Console.CursorTop);
        tailleGrilleYOk = int.TryParse(Console.ReadLine()!, out tailleGrilleYTemp);
        if (!tailleGrilleYOk || tailleGrilleYTemp < 5)
        {
            nextPrint = " !!! Veuillez rentrer une taille valide. !!! ";
            Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
            Console.WriteLine(nextPrint);
        }
    }
    tailleGrilleX = tailleGrilleXTemp;
    tailleGrilleY = tailleGrilleYTemp;
}


/*Choix de la difficulté*/


void PrintSelectOptions(string difficulty)//-> Affiche l'écran de selection en fonction de l'entier x (il y a 3 possibilités)
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
    nextPrint = "Choississez avec z et s puis 'espace' pour confirmer";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();

    nextPrint = "Choississez votre difficulté";
    Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
    Console.WriteLine(nextPrint);
    Console.WriteLine();
    Console.WriteLine();
    if (difficulty == "Normal")
    {
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
        Console.WriteLine();

        nextPrint = "L'IndominusRex ne sait pas ou donner de la tête, sesn mouvements semblent aléatoires";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);
        Console.WriteLine();
    }
    else if (difficulty == "Difficile")
    {
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
        PrintSelectOptions(difficulty);
        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        char action = Console.ReadKey().KeyChar;
        Console.Beep(440,100);
        switch (action)
        {
            case 'z':
                if (difficulty == "Impossible")
                {
                    difficulty = "Difficile";
                }
                else
                {
                    difficulty = "Normal";
                }
                break;
            case 's':
                if (difficulty == "Normal")
                {
                    difficulty = "Difficile";
                }
                else
                {
                    difficulty = "Impossible";
                }
                break;
            case ' ':
                again = false;
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


void InterfaceJeu()//-> Effectue toutes les interfaces et actions avant le lancement réel du jeu 
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

/*Matrice avec la position des crevasses*/
char[,] crevasses = new char[tailleGrilleY, tailleGrilleX];
for (int i = 0; i < tailleGrilleY; i++)
{
    for (int j = 0; j < tailleGrilleX; j++)
    {
        crevasses[i, j] = '.';
    }
}

/*Création grille colorié pour condition victoire*/
char[,] colorBackground = new char[tailleGrilleY, tailleGrilleX];
void DefineColorBackground()    //-> créer une grille identique aux crevasse pour l'utiliser dans la condition de victoire
{
    for (int i = 0; i < tailleGrilleY; i++)
    {
        for (int j = 0; j < tailleGrilleX; j++)
        {
            colorBackground[i, j] = crevasses[i, j];
        }
    }
}


/*Innitialisation de la grille de jeu*/
char[,] grille = new char[tailleGrilleY, tailleGrilleX];
void DefineGrid()   //-> Permet de mettre à jours la grille lors des déplacements des différents personnages
{
    for (int i = 0; i < tailleGrilleY; i++)
    {
        for (int j = 0; j < tailleGrilleX; j++)
        {
            grille[i, j] = crevasses[i, j];
        }
    }
}

/* Innitialisation Owen*/
char owen = 'O';
int owenPositionX = tailleGrilleX - rnd.Next(1, 3);
int owenPositionY = rnd.Next(1, 3);
int nbGrenade = (tailleGrilleX + tailleGrilleY)/2;

/* Innitialisation de l'objet grenade*/
char grenade = 'G';
int grenadePositionX = -1;
int grenadePositionY = -1;

/* Innitialisation Blue*/
char blue = 'B';
int bluePositionX = rnd.Next(1, 3);
int bluePositionY = tailleGrilleY - rnd.Next(1, 3);

/* Innitialisation Indominus Rex*/
char indominusRex = 'I';
int indominusRexPositionX = tailleGrilleX - rnd.Next(1, 3);
int indominusRexPositionY = tailleGrilleY - rnd.Next(1, 3);

/* Innitialisation Maisie*/
char maisie = 'M';
int maisiePositionX = rnd.Next(1, 3);
int maisiePositionY = rnd.Next(1, 3);
#endregion

#region Affichage de la grille
/*-----------------------------------------------------*/
/*------------- 2- AFFICHAGE DE LA GRILLE -------------*/
/*-----------------------------------------------------*/

void ShowOwen(int x, int y) //-> Permet de mettre Owen sur la grille lors de l'affichage de la grille
{
    if ((x == owenPositionX) && (y == owenPositionY))
    {
        grille[y, x] = owen;
    }
}

void ShowBlue(int x, int y) //-> Permet d'afficher Blue sur la grille lors de l'affichage de la grille
{
    if ((x == bluePositionX) && (y == bluePositionY))
    {
        grille[y, x] = blue;
    }
}

void ShowMaisie(int x, int y) //-> Permet d'afficher Maisie sur la grille lors de l'affichage de la grille
{
    if ((x == maisiePositionX) && (y == maisiePositionY))
    {
        grille[y, x] = maisie;
    }
}

void ShowIndominusRex(int x, int y) //-> Permet d'afficher IndominusRex sur la grille lors de l'affichage de la grille
{
    if ((x == indominusRexPositionX) && (y == indominusRexPositionY))
    {
        grille[y, x] = indominusRex;
    }
}

void ShowGrenadeG(int x, int y) //-> Permet d'afficher la ou on lance la grenade sur la grille lors de l'affichage de la grille pendant un lancer de grenade de Owen
{
    if ((x == grenadePositionX) && (y == grenadePositionY))
    {
        grille[y, x] = grenade;
    }
}

void ShowGrid() //-> Affichage de la grille 
{
    DefineGrid();
    Console.Clear();
    Console.WriteLine();
    Console.WriteLine();
    for (int i = 0; i < tailleGrilleY; i++)
    {
        Console.SetCursorPosition((Console.WindowWidth - tailleGrilleX*3) / 2, Console.CursorTop);
        for (int j = 0; j < tailleGrilleX; j++)
        {
            ShowOwen(j, i);
            ShowBlue(j, i);
            ShowMaisie(j, i);
            ShowIndominusRex(j, i);
            ShowGrenadeG(j, i);
            if (grille[i, j] == 'O') 
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (grille[i, j] == 'B') 
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (grille[i, j] == 'M') 
                Console.ForegroundColor = ConsoleColor.Magenta;
            else if (grille[i, j] == 'I') 
                Console.ForegroundColor = ConsoleColor.Red;
            else if (grille[i, j] == '*')
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {grille[i, j]} ");
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
    while(again)
    {
        again = false;
        ShowGrid();

        nextPrint = "Vous jouez Owen, c'est zqsd pour bouger f pour lancer grenade";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);

        nextPrint = $"Il vous reste {nbGrenade} grenade(s)";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);       
        Console.WriteLine();

        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        char action = Console.ReadKey().KeyChar;
        switch (action)
        {
            case 'z':
                if ((owenPositionY > 0) && ((grille[owenPositionY - 1, owenPositionX] == '.') || (grille[owenPositionY - 1, owenPositionX] == indominusRex)))
                {
                    owenPositionY--;
                }
                else
                {
                    again = true;
                }
                break;
            case 's':
                if ((owenPositionY < tailleGrilleY - 1) && ((grille[owenPositionY + 1, owenPositionX] == '.') || (grille[owenPositionY + 1, owenPositionX] == indominusRex)))
                {
                    owenPositionY++;
                }
                else
                {
                    again = true;
                }
                break;
            case 'q':
                if ((owenPositionX > 0) && ((grille[owenPositionY, owenPositionX - 1] == '.') || (grille[owenPositionY, owenPositionX - 1] == indominusRex)))
                {
                    owenPositionX--;
                }
                else
                {
                    again = true;
                }
                break;
            case 'd':
                if ((owenPositionX < tailleGrilleX - 1) && ((grille[owenPositionY, owenPositionX + 1] == '.') || (grille[owenPositionY, owenPositionX + 1] == indominusRex)))
                {
                    owenPositionX++; 
                }
                else
                {
                    again = true;
                }
                break;
            case 'f':
                ThrowGrenade();
                break;
            default:
                again = true;
                break;
        }
    }
}

void MoveBlue() //-> Pour faire bouger Blue et reculer l'IndominusRex
{
    char finalChar = ' ';
    bool again = true;
    while(again)
    {
        again = false;
        ShowGrid();
        nextPrint = "Vous jouez Blue, c'est zqsd pour bouger. Si même case que IndominusRex, elle la fait reculer de 3 case dans la direction d'où elle provient";
        Console.SetCursorPosition((Console.WindowWidth - nextPrint.Length) / 2, Console.CursorTop);
        Console.WriteLine(nextPrint);

        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
        char action = Console.ReadKey().KeyChar;
        finalChar = action;
        switch (action)
        {
            case 'z':
                if ((bluePositionY > 0) && ((grille[bluePositionY - 1, bluePositionX] == '.') || (grille[bluePositionY - 1, bluePositionX] == indominusRex)))
                {
                    bluePositionY--;
                }
                else
                {
                    again = true;
                }
                break;
            case 's':
                if ((bluePositionY < tailleGrilleY - 1) && ((grille[bluePositionY + 1, bluePositionX] == '.') || (grille[bluePositionY + 1, bluePositionX] == indominusRex)))
                {
                    bluePositionY++;
                }
                else
                {
                    again = true;
                }
                break;
            case 'q':
                if ((bluePositionX > 0) && ((grille[bluePositionY, bluePositionX - 1] == '.') || (grille[bluePositionY, bluePositionX - 1] == indominusRex)))
                {
                    bluePositionX--;
                }
                else
                {
                    again = true;
                }
                break;
            case 'd':
                if ((bluePositionX < tailleGrilleX - 1) && ((grille[bluePositionY, bluePositionX + 1] == '.') || (grille[bluePositionY, bluePositionX + 1] == indominusRex)))
                {
                    bluePositionX++;
                }
                else
                {
                    again = true;
                }
                break;
            default:
                again = true;
                break;
        }
    }
    StepBackIndominusRex(finalChar);
}

/*Déplacements PNJ*/
void MoveIndominusRex() //-> Pour déplacer IndominusRex
{
    bool again = true;
    bool isSmartIR = (difficulty != "Normal" );
    int directionMouvement = 0;
    while(again)
    {
        again = false;
        ShowGrid();
        if (isSmartIR)
        {
            directionMouvement = SmartIR(ClosestPlayer(indominusRexPositionX,indominusRexPositionY));
            isSmartIR = false;
        }
        else
        {
            directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest 
        }
        switch (directionMouvement)
        {
            case 1:
                if ((indominusRexPositionY > 0) && (grille[indominusRexPositionY - 1, indominusRexPositionX] != '*') && (grille[indominusRexPositionY - 1, indominusRexPositionX] != blue))
                {
                    indominusRexPositionY--;
                }
                else
                {
                    again = true;
                }
                break;
            case 2:
                if ((indominusRexPositionX < tailleGrilleX - 1) && (grille[indominusRexPositionY, indominusRexPositionX + 1] != '*') && (grille[indominusRexPositionY, indominusRexPositionX + 1] != blue))
                {
                    indominusRexPositionX++;
                }
                else
                {
                    again = true;
                }
                break;
            case 3:
                if ((indominusRexPositionY < tailleGrilleY - 1) && (grille[indominusRexPositionY + 1, indominusRexPositionX] != '*') && (grille[indominusRexPositionY + 1, indominusRexPositionX] != blue))
                {
                    indominusRexPositionY++;
                }
                else
                {
                    again = true;
                }
                break;
            case 4:
                if ((indominusRexPositionX > 0) && (grille[indominusRexPositionY, indominusRexPositionX - 1] != '*') && (grille[indominusRexPositionY, indominusRexPositionX - 1] != blue))
                {
                    indominusRexPositionX--;
                }
                else
                {
                    again = true;
                }
                break;
        }
    }
}

void MoveMaisie() //-> Pour déplacer Maisie
{
    bool again = true;
    while(again)
    {
        again = false;
        ShowGrid();
        int directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest
        switch (directionMouvement)
        {
            case 1:
                if ((maisiePositionY > 0) && (grille[maisiePositionY - 1, maisiePositionX] == '.'))
                {
                    maisiePositionY--;
                }
                else
                {
                    again = true;
                }
                break;
            case 2:
                if ((maisiePositionX < tailleGrilleX - 1) && (grille[maisiePositionY, maisiePositionX + 1] == '.'))
                {
                    maisiePositionX++;
                }
                else
                {
                    again = true;
                }
                break;
            case 3:
                if ((maisiePositionY < tailleGrilleY - 1) && (grille[maisiePositionY + 1, maisiePositionX] == '.'))
                {
                    maisiePositionY++;
                }
                else
                {
                    again = true;
                }
                break;
            case 4:
                if ((maisiePositionX > 0) && (grille[maisiePositionY, maisiePositionX - 1] == '.'))
                {
                    maisiePositionX--;
                }
                else
                {
                    again = true;
                }
                break;
        }
    }
}

/*Actions Des joueurs*/
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
        Console.WriteLine(" Vous avez choisi de lancer une grenade (rayon 3 ) zqsd pour bouger et 'r' pour retour et 'c' pour confirmer");
        char action = Console.ReadKey().KeyChar;
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
                if ((grenadePositionY < tailleGrilleY - 1) && (distanceY < 3))
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
                if ((grenadePositionX < tailleGrilleX - 1) && (distanceX < 3))
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
            case 'c':
                PlaceGrenade();
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
    crevasses[grenadePositionY, grenadePositionX] = '*';
    int direction = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest
    switch (direction)
    {
        case 1:
            if (grenadePositionY > 0)
            {
                crevasses[grenadePositionY - 1, grenadePositionX] = '*';
            }
            break;
        case 2:
            if (grenadePositionX < tailleGrilleX - 1)
            {
                crevasses[grenadePositionY, grenadePositionX + 1] = '*';
            }
            break;
        case 3:
            if (grenadePositionY < tailleGrilleY - 1)
            {
                crevasses[grenadePositionY + 1, grenadePositionX] = '*';
            }
            break;
        case 4:
            if (grenadePositionX > 0)
            {
                crevasses[grenadePositionY, grenadePositionX - 1] = '*';
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
                    && (grille[indominusRexPositionY - 3, indominusRexPositionX] != '*')
                    && (grille[indominusRexPositionY - 2, indominusRexPositionX] != '*')
                    && (grille[indominusRexPositionY - 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY -= 3;
                }
                else if ((indominusRexPositionY > 1)
                    && (grille[indominusRexPositionY - 2, indominusRexPositionX] != '*')
                    && (grille[indominusRexPositionY - 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY -= 2;
                }
                else if ((indominusRexPositionY > 0)
                    && (grille[indominusRexPositionY - 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY--;
                }
                break;

            case 's':
                bool isCrevasseS1 = grille[indominusRexPositionY + 1, indominusRexPositionX] != '*';
                if ((indominusRexPositionY < tailleGrilleY - 3)
                    && (grille[indominusRexPositionY + 3, indominusRexPositionX] != '*')
                    && (grille[indominusRexPositionY + 2, indominusRexPositionX] != '*')
                    && (grille[indominusRexPositionY + 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY += 3;
                }
                else if ((indominusRexPositionY < tailleGrilleY - 2)
                    && (grille[indominusRexPositionY + 2, indominusRexPositionX] != '*')
                    && (grille[indominusRexPositionY + 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY += 2;
                }
                else if ((indominusRexPositionY < tailleGrilleY - 1)
                    && (grille[indominusRexPositionY + 1, indominusRexPositionX] != '*'))
                {
                    indominusRexPositionY++;
                }
                break;

            case 'q':
                if ((indominusRexPositionX > 2)
                    && (grille[indominusRexPositionY, indominusRexPositionX - 3] != '*')
                    && (grille[indominusRexPositionY, indominusRexPositionX - 2] != '*')
                    && (grille[indominusRexPositionY, indominusRexPositionX - 1] != '*'))
                {
                    indominusRexPositionX -= 3;
                }
                else if ((indominusRexPositionX > 1)
                    && (grille[indominusRexPositionY, indominusRexPositionX - 2] != '*')
                    && (grille[indominusRexPositionY, indominusRexPositionX - 1] != '*'))
                {
                    indominusRexPositionX -= 2;
                }
                else if ((indominusRexPositionX > 0)
                    && (grille[indominusRexPositionY, indominusRexPositionX - 1] != '*'))
                {
                    indominusRexPositionX--;
                }
                break;

            case 'd':
                if ((indominusRexPositionX < tailleGrilleX - 3)
                    && (grille[indominusRexPositionY, indominusRexPositionX + 3] != '*')
                    && (grille[indominusRexPositionY, indominusRexPositionX + 2] != '*')
                    && (grille[indominusRexPositionY, indominusRexPositionX + 1] != '*'))
                {
                    indominusRexPositionX += 3;
                }
                else if ((indominusRexPositionX < tailleGrilleX - 2)
                    && (grille[indominusRexPositionY, indominusRexPositionX + 2] != '*')
                    && (grille[indominusRexPositionY, indominusRexPositionX + 1] != '*'))
                {
                    indominusRexPositionX += 2;
                }
                else if ((indominusRexPositionX < tailleGrilleX - 1)
                    && (grille[indominusRexPositionY, indominusRexPositionX + 1] != '*'))
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
    if (x < 0 || x >= tailleGrilleX || y < 0 || y >= tailleGrilleY)
        return;
    if (colorBackground[y, x] != '.')
        return;
    colorBackground[y, x] = 'C';

    if (y > 0)
    {
        IndominusRexPossibilities(x, y - 1);
    }
    if (y < tailleGrilleY - 1)
    {
        IndominusRexPossibilities(x, y + 1);
    }
    if (x > 0)
    {
        IndominusRexPossibilities(x - 1, y);
    }

    if (x < tailleGrilleX - 1)
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
    if (crevasses[bluePositionY, bluePositionX] == '*')
    {
        conditionWinLose = 2 ;
        lose = false;
    }
    if (crevasses[maisiePositionY, maisiePositionX] == '*')
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
    for (int i = 0; i < tailleGrilleY; i++)
    {
        for (int j = 0; j < tailleGrilleX; j++)
        {
            Console.Write($" {matrix[i, j]} ");
        }
        Console.WriteLine("");
    }
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

char ClosestPlayer(int x, int y)
{
    double distanceOwen = Math.Sqrt((x-owenPositionX)*(x-owenPositionX)+(y-owenPositionY)*(y-owenPositionY));
    double distanceMaisie = Math.Sqrt((x-maisiePositionX)*(x-maisiePositionX)+(y-maisiePositionY)*(y-maisiePositionY));
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
        int test = rnd.Next(1,5);
        MoveOwen();
        lose1 = LosingConditionGrenadePerdu();
        lose2 = LosingConditionGrenade();
        MoveBlue();
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