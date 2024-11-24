using System;
using System.Windows.Forms;
Random rnd = new Random();
Console.Clear();

/*Innitialisation de la grille*/
int tailleGrilleX = 10;
int tailleGrilleY = 10;
char[,] grille = new char[tailleGrilleY, tailleGrilleX];

/*Position des crevasses*/
char[,] crevasses = new char[tailleGrilleY, tailleGrilleX];


for (int i = 0; i < tailleGrilleY; i++)
{
    for (int j = 0; j < tailleGrilleX; j++)
    {
        crevasses[i, j] = '.';
    }
}

void DefineGrid()
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
int owenPositionX = 5;
int owenPositionY = 5;
int nbGrenade = 10;

/* Objet grenade*/
char grenade = 'G';
int grenadePositionX = -1;
int grenadePositionY = -1;

/* Objet Indominus Rex*/
char indominusRex = 'I';
int indominusRexPositionX = 9;
int indominusRexPositionY = 9;


/*Affichage de la grille*/

void ShowOwen(int x, int y)
{
    if ((x == owenPositionX) && (y == owenPositionY))
    {
        grille[y, x] = owen;
    }
}

void ShowBlue(int x, int y)
{

}

void ShowMaisie(int x, int y)
{

}

void ShowIndominusRex(int x, int y)
{
    if ((x == indominusRexPositionX) && (y == indominusRexPositionY))
    {
        grille[y, x] = indominusRex ;
    }
}

void ShowGrenadeG(int x, int y)
{
    if ((x == grenadePositionX) && (y == grenadePositionY))
    {
        grille[y, x] = grenade;
    }
}

void ShowGrid()
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

void MoveOwen()
{
    bool again = true;
    while (again)
    {
        ShowGrid();
        Console.WriteLine(" Vous jouez Owen, c'est zqsd pour bouger f pour lancer grenade");
        Console.WriteLine($"Il vous reste {nbGrenade} grenade(s)");
        char action = Console.ReadKey().KeyChar;
        switch (action)
        {
            case 'z':
                if (owenPositionY > 0)
                {
                    owenPositionY--;
                }
                break;

            case 's':
                if (owenPositionY < tailleGrilleY - 1)
                {
                    owenPositionY++;
                }
                break;

            case 'q':
                if (owenPositionX > 0)
                {
                    owenPositionX--;
                }
                break;

            case 'd':
                if (owenPositionX < tailleGrilleX - 1)
                {
                    owenPositionX++;
                }
                break;

            case 'f':
                ThrowGrenade();
                break;
        }

    }
}

void ThrowGrenade()
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

void PlaceGrenade()
{
    nbGrenade--;
    crevasses[grenadePositionY, grenadePositionX] = '*';
    int direction = rnd.Next(1, 5); /* 1 -> Nord; 2 -> Est; 3 -> Sud; 4 -> Ouest*/
    switch (direction)
    {
        case 1:
            crevasses[grenadePositionY - 1, grenadePositionX] = '*';
            break;
        case 2:
            crevasses[grenadePositionY, grenadePositionX + 1] = '*';
            break;
        case 3:
            crevasses[grenadePositionY + 1, grenadePositionX] = '*';
            break;
        case 4:
            crevasses[grenadePositionY, grenadePositionX - 1] = '*';
            break;
    }

    grenadePositionX = -1;
    grenadePositionY = -1;
}

void MoveIndominusRex()
{
    bool again = true;
    while (again)
    {
        ShowGrid();
        int directionMouvement = rnd.Next(1,5);
        switch (directionMouvement)
        {
            case 1:
                if (owenPositionY > 0)
                {
                    owenPositionY--;
                }
                break;

            case 's':
                if (owenPositionY < tailleGrilleY - 1)
                {
                    owenPositionY++;
                }
                break;

            case 'q':
                if (owenPositionX > 0)
                {
                    owenPositionX--;
                }
                break;

            case 'd':
                if (owenPositionX < tailleGrilleX - 1)
                {
                    owenPositionX++;
                }
                break;

            case 'f':
                ThrowGrenade();
                break;
        }

    }
}

MoveOwen();