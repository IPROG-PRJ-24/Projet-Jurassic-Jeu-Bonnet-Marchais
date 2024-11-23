using System;
using System.Windows.Forms;

Console.Clear();

/*Innitialisation de la grille*/
int tailleGrilleX = 10;
int tailleGrilleY = 10;
char[,] grille = new char[tailleGrilleY, tailleGrilleX];

void DefineGrid(){
    for (int i = 0; i < tailleGrilleY; i++){
        for (int j = 0; j < tailleGrilleX; j++){
            grille[i, j] = '.';
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


/*Affichage de la grille*/

void ShowOwen(int x, int y){
    if ((x == owenPositionX)&&(y == owenPositionY)){
        grille[y,x] = owen;
    }
}

void ShowBlue(int x, int y){
    
}

void ShowMaisie(int x, int y){
    
}

void ShowIndominusRex(int x, int y){

}

void ShowGrenadeG(int x, int y){
    if ((x == grenadePositionX)&&(y == grenadePositionY)){
    grille[y,x] = grenade;
    }
}

void ShowGrid()
{
    DefineGrid();
    Console.Clear();
    for (int i = 0; i < tailleGrilleY; i++){
        for (int j = 0; j < tailleGrilleX; j++)
        {
            ShowOwen(j,i);
            ShowBlue(j,i);
            ShowMaisie(j,i);
            ShowIndominusRex(j,i);
            ShowGrenadeG(j,i);
            Console.Write($" {grille[i, j]} ");
        }
        Console.WriteLine("");
    }
}

void MoveObject(){
    bool again = true;
    while (again){
        ShowGrid();
        Console.WriteLine("C'est zqsd pour bouger f pour lancer grenade");
        Console.WriteLine($"Il vous reste {nbGrenade} grenade(s)");
        char action = Console.ReadKey().KeyChar;
        switch (action){
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

void ThrowGrenade(){
    grenadePositionX = owenPositionX;
    grenadePositionY = owenPositionY;
    int distanceToOwen = 0;
    bool again = true;
    while (again){
        ShowGrid();
        Console.WriteLine(" Vous avez choisi de lancer une grenade (rayon 3 ) zqsd pour bouger et 'r' pour retour et 'c' pour confirmer");
        char action = Console.ReadKey().KeyChar;
        switch (action){
            case 'z':
                if ((grenadePositionY > 0) && (distanceToOwen < 4))
                {
                    grenadePositionY--;
                    distanceToOwen = Convert.ToInt32(Math.Sqrt((owenPositionX-grenadePositionX)*(owenPositionX-grenadePositionX) + (owenPositionY-grenadePositionY)*(owenPositionY-grenadePositionY)));
                }
                break;

            case 's':
                if ((grenadePositionY < tailleGrilleY - 1) && (distanceToOwen < 4))
                {
                    grenadePositionY++;
                    distanceToOwen = Convert.ToInt32(Math.Sqrt((owenPositionX-grenadePositionX)*(owenPositionX-grenadePositionX) + (owenPositionY-grenadePositionY)*(owenPositionY-grenadePositionY)));
                }
                break;

            case 'q':
                if ((grenadePositionX > 0) && (distanceToOwen < 4))
                {
                    grenadePositionX--;
                    distanceToOwen = Convert.ToInt32(Math.Sqrt((owenPositionX-grenadePositionX)*(owenPositionX-grenadePositionX) + (owenPositionY-grenadePositionY)*(owenPositionY-grenadePositionY)));
                }
                break;

            case 'd':
                if ((grenadePositionX < tailleGrilleX - 1) && (distanceToOwen < 4))
                {
                    grenadePositionX++;
                    distanceToOwen = Convert.ToInt32(Math.Sqrt((owenPositionX-grenadePositionX)*(owenPositionX-grenadePositionX) + (owenPositionY-grenadePositionY)*(owenPositionY-grenadePositionY)));
                }
                break;
            case 'r':
                again = false;
                break;
            case 'c':
                /*Fonction PlaceGrenade*/
                again = false;
                break;
        }
    }
}


MoveObject();