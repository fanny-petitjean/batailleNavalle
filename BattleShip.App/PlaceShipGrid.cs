namespace DefaultNamespace;
using System;
public class PlaceShipGrid(char[,] grid)
{
    private var ships = new List<Ship>
    {
        new Ship('A' 4),
        new Ship('B', 4),
        new Ship('C', 3),
        new Ship('C', 3),
        new Ship('D', 2),
        new Ship('E', 2),
        new Ship('F', 1)
    };
    foreach (var ship in Ships)
    {
        BattleShipGrid(grid, ship);
    }

    private void PlaceShipGrid(char[,] grid, Ship ship)
    {
        bool placed = false;
        Random randomplace = Random.Shared;

        while (!placed)
        {
            ship.IsHorizontal = randomplace.Next(2) == 0;
            int x = randomplace.Next(GridSize);
            int y = randomplace.Next(GridSize);

            if (ship.IsHorizontal)
            {
                if (y + ship.Size <= GridSize && IsSpaceAvailable(grid, x, y, ship.Size, ship.IsHorizontal))
                {
                    for (int i = 0; i < ship.Size; i++)
                    {
                        grid[x,y+i] = ship.Symbol;
                    }
                    placed = true;
                    ship.Position = (x, y);
                }
            }
            else
            {
                if (x + ship.Size <= GridSize && IsSpaceAvailable(grid, x, y, ship.Size, ship.IsHorizontal))
                {
                    for (int i = 0; i < ship.Size; i++)
                    {
                        grid[x+i,y]=ship.Symbol;
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