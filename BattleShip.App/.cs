namespace BattleShip.App;
using System;
public class PlaceShipGrid
{
    private List<Ship> ships = new List<Ship>
    {
        new Ship('A', 4, true),
        new Ship('B', 4, true),
        new Ship('C', 3, true),
        new Ship('C', 3, true),
        new Ship('D', 2,false),
        new Ship('E', 2, true),
        new Ship('F', 1, false)
    };
    

    public PlaceShipGrid(char[,] grid, Ship ship)
    {
        //////
        foreach (var ship in ships)
        {
            BattleShipGrid(grid, ship);
        } 

        /////
        bool placed = false;
        Random randomplace = Random.Shared;

        while (!placed)
        {
            ship.isHorizontal = randomplace.Next(2) == 0;
            int x = randomplace.Next(GridSize);
            int y = randomplace.Next(GridSize);

            if (ship.isHorizontal)
            {
                if (y + ship.size <= GridSize && IsSpaceAvailable(grid, x, y, ship.size, ship.isHorizontal))
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        grid[x,y+i] = ship.letter;
                    }
                    placed = true;
                    ship.Position = (x, y);
                }
            }
            else
            {
                if (x + ship.size <= GridSize && IsSpaceAvailable(grid, x, y, ship.size, ship.isHorizontal))
                {
                    for (int i = 0; i < ship.size; i++)
                    {
                        grid[x+i,y]=ship.letter;
                    }
                    placed = true;
                    ship.Position = (x, y);
                }
            }
        }
    }

    private bool IsSpaceAvailable(char[,] grid, int x, int y, int shipSize, bool isHorizontal)
    {
        for (int i = 0; i < shipSize; i++)
        {
            if (isHorizontal)
            {
                if (y + i >= GridSize || grid[x, y + i] != EmptyCell)
                    return false;
            }
            else
            {
                if (x + i >= GridSize || grid[x + i, y] != EmptyCell)
                    return false;
            }
        }

        return true;
    } 
    private void InitializeGrid(char[,] grid)
    {
        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                grid[i, j] = EmptyCell;  
            }
        }
    }
}