﻿using System;
using System.Windows.Forms;
Random rnd = new Random();
Console.Clear();

/*-----------------------------------------------------*/
/*1- INNITIALISATION DE TOUTES LES VARIABLES ET OBJETS */
/*-----------------------------------------------------*/

/*Tailles de la grille*/
int tailleGrilleX = 10;
int tailleGrilleY = 10;

void InterfaceJeu()
{
    Console.WriteLine("JURENSIC WORLD");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Le plus grand prédateur de l'histoire est à vos trousses !");
    Console.WriteLine("Saurez-vous l'enfermer dans sa cage ?");
    Console.WriteLine();
    Console.WriteLine("(Appuyer sur n'importe quel touche pour jouer.)");
    char suite = Console.ReadKey().KeyChar;
    Console.Clear();    
    Console.WriteLine("Definissez la taille du plateau de jeu:");
    Console.WriteLine("(Le plateau de jeu est un carré)");
    int tailleGrille = 0;
    bool tailleGrilleOk = false;
    while (!tailleGrilleOk) 
    {
        tailleGrilleOk = int.TryParse(Console.ReadLine()!, out tailleGrille);
        if (!tailleGrilleOk)
        {
            Console.WriteLine("Veuillez rentrer une taille valide.");
        }
    }
    Console.WriteLine(tailleGrille);
    tailleGrilleX = tailleGrille;
    tailleGrilleY = tailleGrille;
}

InterfaceJeu();

/*Position des crevasses*/
char[,] crevasses = new char[tailleGrilleY, tailleGrilleX];
for (int i = 0; i < tailleGrilleY; i++)
{
    for (int j = 0; j < tailleGrilleX; j++)
    {
        crevasses[i, j] = '.';
    }
}

/*Innitialisation de la grille*/
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
int owenPositionX = tailleGrilleX - 1;
int owenPositionY = 0;
int nbGrenade = 10;

/* Innitialisation grenade*/
char grenade = 'G';
int grenadePositionX = -1;
int grenadePositionY = -1;

/* Innitialisation Blue*/
char blue = 'B';
int bluePositionX = 0;
int bluePositionY = 0;

/* Innitialisation Indominus Rex*/
char indominusRex = 'I';
int indominusRexPositionX = tailleGrilleX - 1;
int indominusRexPositionY = tailleGrilleY - 1;

/* Innitialisation Maisie*/
char maisie = 'M';
int maisiePositionX = 0;
int maisiePositionY = tailleGrilleY - 1;



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
    for (int i = 0; i < tailleGrilleY; i++)
    {
        for (int j = 0; j < tailleGrilleX; j++)
        {
            ShowOwen(j, i);
            ShowBlue(j, i);
            ShowMaisie(j, i);
            ShowIndominusRex(j, i);
            ShowGrenadeG(j, i);
            Console.Write($" {grille[i, j]} ");
        }
        Console.WriteLine("");
    }
}


/*-----------------------------------------------------*/
/*---- 3- DEPLACEMENTS DES JOUEURS, OBJETS ET PNJ -----*/
/*-----------------------------------------------------*/


/*Déplacements Joueurs*/
void MoveOwen() //-> Pour faire bouger Owen et lancer ses grenades 
{
    ShowGrid();
    Console.WriteLine(" Vous jouez Owen, c'est zqsd pour bouger f pour lancer grenade");
    Console.WriteLine($"Il vous reste {nbGrenade} grenade(s)");
    char action = Console.ReadKey().KeyChar;
    switch (action)
    {
        case 'z':
            if ((owenPositionY > 0) && ((grille[owenPositionY - 1, owenPositionX] == '.') || (grille[owenPositionY - 1, owenPositionX] == indominusRex)))
            {
                owenPositionY--;
            }
            break;
        case 's':
            if ((owenPositionY < tailleGrilleY - 1) && ((grille[owenPositionY + 1, owenPositionX] == '.') || (grille[owenPositionY + 1, owenPositionX] == indominusRex)))
            {
                owenPositionY++;
            }
            break;
        case 'q':
            if ((owenPositionX > 0) && ((grille[owenPositionY, owenPositionX - 1] == '.') || (grille[owenPositionY, owenPositionX - 1] == indominusRex)))
            {
                owenPositionX--;
            }
            break;
        case 'd':
            if ((owenPositionX < tailleGrilleX - 1) && ((grille[owenPositionY, owenPositionX + 1] == '.') || (grille[owenPositionY, owenPositionX + 1] == indominusRex)))
            {
                owenPositionX++;
            }
            break;
        case 'f':
            ThrowGrenade();
            break;
    }
}



bool blueTouchIndominusRex = false;
void MoveBlue() //-> Pour faire bouger Blue et reculer l'IndominusRex
{
    ShowGrid();
    Console.WriteLine(" Vous jouez Blue, c'est zqsd pour bouger. Si même case que IndominusRex, elle la fait reculer de 3 case dans la direction d'où elle provient ");
    char action = Console.ReadKey().KeyChar;
    switch (action)
    {
        case 'z':
            if ((bluePositionY > 0) && ((grille[bluePositionY - 1, bluePositionX] == '.') || (grille[bluePositionY - 1, bluePositionX] == indominusRex)))
            {
                bluePositionY--;
            }
            break;
        case 's':
            if ((bluePositionY < tailleGrilleY - 1) && ((grille[bluePositionY + 1, bluePositionX] == '.') || (grille[bluePositionY + 1, bluePositionX] == indominusRex)))
            {
                bluePositionY++;
            }
            break;
        case 'q':
            if ((bluePositionX > 0) && ((grille[bluePositionY, bluePositionX - 1] == '.') || (grille[bluePositionY, bluePositionX - 1] == indominusRex)))
            {
                bluePositionX--;
            }
            break;
        case 'd':
            if ((bluePositionX < tailleGrilleX - 1) && ((grille[bluePositionY, bluePositionX + 1] == '.') || (grille[bluePositionY, bluePositionX + 1] == indominusRex)))
            {
                bluePositionX++;
            }
            break;
    }
    StepBackIndominusRex(action);
}


/*Déplacements PNJ*/
void MoveIndominusRex() //-> Pour déplacer IndominusRex
{
    ShowGrid();
    int directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest 
    switch (directionMouvement)
    {
        case 1:
            if ((indominusRexPositionY > 0) && (grille[indominusRexPositionY - 1, indominusRexPositionX] != '*') && (grille[indominusRexPositionY - 1, indominusRexPositionX] != blue))
            {
                indominusRexPositionY--;
            }
            break;
        case 2:
            if ((indominusRexPositionX < tailleGrilleX - 1) && (grille[indominusRexPositionY, indominusRexPositionX + 1] != '*') && (grille[indominusRexPositionY, indominusRexPositionX + 1] != blue))
            {
                indominusRexPositionX++;
            }
            break;
        case 3:
            if ((indominusRexPositionY < tailleGrilleY - 1) && (grille[indominusRexPositionY + 1, indominusRexPositionX] != '*') && (grille[indominusRexPositionY + 1, indominusRexPositionX] != blue))
            {
                indominusRexPositionY++;
            }
            break;
        case 4:
            if ((indominusRexPositionX > 0) && (grille[indominusRexPositionY, indominusRexPositionX - 1] != '*') && (grille[indominusRexPositionY, indominusRexPositionX - 1] != blue))
            {
                indominusRexPositionX--;
            }
            break;
    }
}

void MoveMaisie() //-> Pour déplacer Maisie
{
    ShowGrid();
    int directionMouvement = rnd.Next(1, 5); // 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest
    switch (directionMouvement)
    {
        case 1:
            if ((maisiePositionY > 0) && (grille[maisiePositionY - 1, maisiePositionX] == '.'))
            {
                maisiePositionY--;
            }
            break;
        case 2:
            if ((maisiePositionX < tailleGrilleX - 1) && (grille[maisiePositionY, maisiePositionX + 1] == '.'))
            {
                maisiePositionX++;
            }
            break;
        case 3:
            if ((maisiePositionY < tailleGrilleY - 1) && (grille[maisiePositionY + 1, maisiePositionX] == '.'))
            {
                maisiePositionY++;
            }
            break;
        case 4:
            if ((maisiePositionX > 0) && (grille[maisiePositionY, maisiePositionX - 1] == '.'))
            {
                maisiePositionX--;
            }
            break;
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
                break;
            case 'c':
                PlaceGrenade();
                again = false;
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

    grenadePositionX = -1;
    grenadePositionY = -1;
}

void StepBackIndominusRex(char action)
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

void WinningCondition()
{
    
    return 
}

bool LosingConditionGrenadePerdu()
{
    bool lose = true;
    if(crevasses[bluePositionY,bluePositionX] == '*')
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("C'est PERDU");
        Console.WriteLine("Blue à pris une grenade.");
        Console.WriteLine("Faudrait apprendre à visé....");
        lose = false;
    }
    if(crevasses[maisiePositionY,maisiePositionX] == '*')
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("C'est PERDU");
        Console.WriteLine("Maisie à pris une grenade.");
        Console.WriteLine("L'Indominus Rex n'était pas la plus grande menace il semblerait....");
        lose = false;
    }
    return lose;
}

bool LosingConditionGrenade()
{
    bool loseGrenade = true;
    if (nbGrenade == 0)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("C'est PERDU");
        Console.WriteLine("Owen n'as plus de grenades.");
        Console.WriteLine("Il ne reste plus qu'as espérer que les jambes de Owen et Maisie soit assez rapide....");
        loseGrenade = false;
    }
    return loseGrenade;
}

bool LosingConditionManger()
{
    bool lose = true;
    if(indominusRexPositionX == owenPositionX && indominusRexPositionY == owenPositionY)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("C'est PERDU");
        Console.WriteLine("L'Indominus Rex à manger Owen.");
        Console.WriteLine("Il ne reste plus personne pour defendre la Terre....");
        lose = false;
    }
    if(indominusRexPositionX == maisiePositionX && indominusRexPositionY == maisiePositionY)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("C'est PERDU");
        Console.WriteLine("L'Indominus Rex à manger Maisie.");
        Console.WriteLine("Owen à rater sa mission....");
        lose = false;
    }
    return lose;
}
/*-----------------------------------------------------*/
/*--------- 4- SQUELETTE ET STRUCTURE DU JEU ----------*/
/*-----------------------------------------------------*/


void MainGame() //-> Pour lancer le jeu en effectuant les différentes actions dans l'ordre
{
    bool again = true;
    while (again)
    {
        MoveOwen();
        again = LosingConditionGrenadePerdu();
        MoveBlue();
        MoveMaisie();
        if (!blueTouchIndominusRex)
        {
            MoveIndominusRex();
        }
        /*WinningCondition();*/
        again = LosingConditionManger();
        again = LosingConditionGrenade();

    }
}


MainGame();