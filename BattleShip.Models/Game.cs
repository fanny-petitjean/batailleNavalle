using BattleShip.Models;
using System.Numerics;

namespace BattleShip.App
{
    public class Game
    {
        public List<Player> player { get; set; }

        public Player? winner { get; set; }
        public bool isWinner { get; set; }
        public GameHistory history { get; private set; } = new GameHistory();
        private static readonly char[] shipLetter = { 'A', 'B', 'C', 'D', 'E', 'F' };
        private static readonly int[] shipSize = { 2, 3, 3, 4, 5 };  


        public Game(List<Player> player)
        {
            this.player = player;
        }

        public void attack(Command command)
        {
        }

        public bool checkWinner()
        {
            return true;
        }

        public void placeShip(Ship ship, int x, int y, string orientation)
        {
        }

        public void displayGrid()
        {

        }

    }
}