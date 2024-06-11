namespace GameCalculatorLibrary.Entities
{
    public class Game
    {
        public int ID { get; set; }
        public string GameName { get; set; }    
        public int MinutesPerEnergy { get; set; }
        public int MaximumEnergyCap { get;set; }
    }
}
