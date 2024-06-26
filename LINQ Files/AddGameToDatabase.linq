<Query Kind="Program">
  <Connection>
    <ID>d5e27fa4-d4c5-4838-9a9e-0559fe6f37b9</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>localhost</Server>
    <Database>GachaGameCalculator</Database>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
  <RuntimeVersion>6.0</RuntimeVersion>
</Query>

void Main()
{
	try{
		GameClass game = new GameClass();
		List<Exception> errorList = new List<Exception>();
		
		
		game.GameName = "";
		game.MinutesPerEnergy = null;
		game.MaximumEnergyCap = null;
		
		
		if(string.IsNullOrWhiteSpace(game.GameName)){
			errorList.Add(new Exception($"Game Name cannot be blank."));
			//throw new Exception($"Game Name cannot be blank.");
		}
		if(game.MinutesPerEnergy == 0 || game.MinutesPerEnergy is null){
			errorList.Add(new Exception("Minutes per energy cannot be zero or empty"));
			//throw new Exception("Minutes per energy cannot be zero or empty");
		}
		if(game.MaximumEnergyCap == 0 || game.MaximumEnergyCap is null){
			errorList.Add(new Exception("Maximum Energy Cap cannot be zero or empty"));
			//throw new Exception("Maximum Energy Cap cannot be zero or empty");
		}
		if(errorList.Count > 0){
			throw new AggregateException(errorList);
		}
		else {
			AddGame(game);
		}	
		
		
	}
	catch(AggregateException ex){
		foreach(var error in ex.InnerExceptions){
			error.Message.Dump();
		}
	}
	catch(Exception ex){
		GetInnerException(ex).Message.Dump();
	}	




}

// You can define other methods, fields, classes and namespaces here

public class GameClass {
	public int ID {get;set;}
	public string GameName {get;set;}
	public int? MaximumEnergyCap{get;set;}
	public int? MinutesPerEnergy{get;set;}
}

//string name, int? max, int? minutes

public void AddGame(GameClass game){
	
	Game gameToAdd = new Game();
	
	gameToAdd.GameName = game.GameName;
	gameToAdd.MinutesPerEnergy = game.MinutesPerEnergy;
	gameToAdd.MaximumEnergyCap = game.MaximumEnergyCap;

	Games.Add(gameToAdd);
	SaveChanges();
}

private Exception GetInnerException(Exception ex)
{
	while (ex.InnerException != null)
	{
		ex = ex.InnerException;
	}
	return ex;
}