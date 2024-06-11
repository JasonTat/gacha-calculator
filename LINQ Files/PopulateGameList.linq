<Query Kind="Program">
  <Connection>
    <ID>e9418aee-71b0-440d-8303-65d086c86da8</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>localhost</Server>
    <Database>GachaGameCalculator</Database>
    <DisplayName>GachaGameCalculator</DisplayName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	
	
	
	List<Game> list = PopulateGameList();
	list.Dump();
	
	
	
	
}


// You can define other methods, fields, classes and namespaces here








public List<Game> PopulateGameList() {
	List<Game> list = new List<Game>();
	
	list = Games
				.Select(x => new Game {
					ID = x.ID,
					GameName = x.GameName,
					MinutesPerEnergy = x.MinutesPerEnergy == null ? 0 : (int)x.MinutesPerEnergy,
					MaximumEnergyCap = x.MaximumEnergyCap == null ? 0 : (int)x.MaximumEnergyCap
				})
				.ToList();	
	return list;
}









public class Game
{
    public int ID { get; set; }
    public string GameName { get; set; }    
    public int MinutesPerEnergy { get; set; }
    public int MaximumEnergyCap { get;set; }
}

