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
	
	//HSRCalculator
	
	//1 per 6min
	//max 240	
	
	//fetch game with id 
	
	try{	
		int gameId = 2;
		int currentResinAmount = 2220;
		int replenishTime;
		Game game = null;		
			
		game = FetchGameFromId(gameId);
		replenishTime = GameEnergyCalculator(currentResinAmount, game);

		replenishTime.Dump();
	}
	catch(Exception ex){
		GetInnerException(ex).Message.Dump();
	}
	
	

	
}

// You can define other methods, fields, classes and namespaces here

public int GameEnergyCalculator(int currentAmount, Game game) {	

	if(currentAmount > game.MaximumEnergyCap){
		throw new ArgumentException($"Your current amount, {currentAmount}, is greater than the maximum cap ({game.MaximumEnergyCap}) of {game.GameName}");
	}
	else {
			//declare totalTime to replenish resin in minutes
		int totalTimeToReplenish;
		
		//figure out how much resin is missing
		int difference = (int)game.MaximumEnergyCap - currentAmount;
		
		//now that we have the difference, we figure out how long it will take to get that amount.
		totalTimeToReplenish = difference * (int)game.MinutesPerEnergy;	
		return totalTimeToReplenish;
	}
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

private Exception GetInnerException (Exception ex) {
	while(ex.InnerException != null){
		ex = ex.InnerException;
	}
	return ex;
}




public class Game
{
    public int ID { get; set; }
    public string GameName { get; set; }    
    public int? MinutesPerEnergy { get; set; }
    public int? MaximumEnergyCap { get;set; }
}