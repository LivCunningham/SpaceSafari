using System;
using System.Linq;

namespace SpaceSafari
{
  class Program
  {
    static void Main(string[] args)
    {
      var input = "";
      var db = new Space_SafariContext();
      //   while (input != "quit") {}

      Console.WriteLine("Want to add a species you've seen?...");
      Console.WriteLine(":=========================:");

      input = Console.ReadLine();
      if (input == "yes")
      {
        // expected input: species name, home planet, language spoken, location last seen, & temperament 
        Console.WriteLine("Who have you encountered on your space journey?");
        input = Console.ReadLine();

        var data = input.Split(',');
        var newSpecies = new Races
        {
          Species = data[0],
          Home = data[1],
          Language = data[2],
          LocationOfLastSeen = data[3],
          Temperament = data[4],
          CountOfTimesSeen = int.Parse(data[5])
        };
        db.AlienTypes.Add(newSpecies);
        db.SaveChanges();
        Console.WriteLine($"Successfully Saved {newSpecies.Species}");
      }
      else if (input == "all")
      {
        var allSpecies = db.AlienTypes.OrderBy(o => o.Species).ThenBy(t => t.CountOfTimesSeen);
        foreach (var Races in allSpecies)
        {
          Console.WriteLine($"{Races.Species}, {Races.CountOfTimesSeen} ");

        }
      }
    }
  }
}

