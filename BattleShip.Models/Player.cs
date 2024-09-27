using BattleShip.App;

namespace BattleShip.App
{
    public class Player
    {
        public Guid id { get; }
        public string Name { get; set; }
        public PlaceShipGrid placeShipGrid { get; set; }

        public List<Ship> ships { get; set; }

        public Player(string Name, List<Ship> ships)
        {
            this.id = Guid.NewGuid();
            this.Name = Name;
            this.ships = ships;
            this.placeShipGrid = new PlaceShipGrid();
        }
    }
}