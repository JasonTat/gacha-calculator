<Query Kind="Program">
  <Connection>
    <ID>5dfab689-fc64-4ed4-b509-50ab8fad1a36</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DESKTOP-2ODKKIF</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>GachaGameCalculator</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	//calculator for genshin resin
// 1 per 8min

int gameId = 1;
int currentResinAmount = 0;
int replenishTime;
Game game = null;
//need to fetch game object with gameid

game = FetchGameFromId(gameId);
//game.Dump();

replenishTime = GenshinResinCalculator(currentResinAmount, game);

replenishTime.Dump();

}

// You can define other methods, fields, classes and namespaces here

//how much resin are they at?
//maybe pass in the Genshin game object so we can destructure it and get the max cap value and regen rate 
//instead of passing in multiple values
	//so we only have to pass in the current resin amount + game object



public int GenshinResinCalculator(int currentResinAmount, Game game) {	
	//declare totalTime to replenish resin in minutes
	int totalTimeToReplenish;
	
	//figure out how much resin is missing
	int difference = (int)game.MaximumEnergyCap - currentResinAmount;
	
	//now that we have the difference, we figure out how long it will take to get that amount.
	totalTimeToReplenish = difference * (int)game.MinutesPerEnergy;	

	return totalTimeToReplenish;
}

public Game FetchGameFromId (int id) {		
	Game game = Games
					.Where(x => x.ID == id)
					.Select(x => new Game {
						ID = x.ID,
						GameName = x.GameName,
						MinutesPerEnergy = x.MinutesPerEnergy,
						MaximumEnergyCap = x.MaximumEnergyCap
						
					})
					.FirstOrDefault();
					
	return game;
}


public class Game
{
    public int ID { get; set; }
    public string GameName { get; set; }    
    public int? MinutesPerEnergy { get; set; }
    public int? MaximumEnergyCap { get;set; }
}