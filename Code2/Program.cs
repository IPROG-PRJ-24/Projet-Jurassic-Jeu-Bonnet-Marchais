using System;
using System.Windows.Forms;

/*Innitialisation de la grille*/
int tailleGrilleX = 10;
int tailleGrilleY = 10;
char[,] grille = new char[tailleGrilleY, tailleGrilleX];

for (int i = 0; i < tailleGrilleY; i++)
{
    for (int j = 0; j < tailleGrilleX; j++)
    {
        grille[i, j] = '.';
    }
}

char player = 'P';
int playerPositionX = 5;
int playerPositionY = 5;

void AfficherGrille()
{
    Console.Clear();
    for (int i = 0; i < tailleGrilleY; i++)
    {
        for (int j = 0; j < tailleGrilleX; j++)
        {
            if ((i == playerPositionY) && (j == playerPositionX))
            {
                Console.Write($" {player} ");
            }
            else
            {
                Console.Write($" {grille[i, j]} ");
            }
        }
        Console.WriteLine("");
    }
}

void MovePlayer()
{
    bool again = true;
    while (again)
    {
        AfficherGrille();
        Console.WriteLine(" c'est zqsd pour bouger f pour lancer grenade");
        char action = Console.ReadKey().KeyChar;
        switch (action){
            case 'z':
                if (playerPositionY > 0)
                {
                    playerPositionY--;
                }
                break;

            case 's':
                if (playerPositionY < tailleGrilleY - 1)
                {
                    playerPositionY++;
                }
                break;

            case 'q':
                if (playerPositionX > 0)
                {
                    playerPositionX--;
                }
                break;

            case 'd':
                if (playerPositionX < tailleGrilleX - 1)
                {
                    playerPositionX++;
                }
                break;
            
            case 'f':
                ThrowGrenade();
                break;
        }

    }
}

void ThrowGrenade(){
    Console.Clear();
    Console.WriteLine("Vous avez décidé de lancer une grenade:");
    Console.WriteLine("Espace pour continuer 'r' pour retour");
    char continuer = Console.ReadKey().KeyChar;
    if (continuer == 'r'){
        MovePlayer();
    }
    else if(continuer == ' '){
        AfficherGrille();
        Console.WriteLine("Choisissez votre case ou lancer la grenade (rayon 3)");
    }
}

MovePlayer();