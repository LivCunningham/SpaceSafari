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

      Console.WriteLine("Want to add a species you've seen?...");
      Console.WriteLine(":=========================:");

      input = Console.ReadLine();
      if (input.ToLower == "yes")
      {
        // expected input: species name, home planet, language spoken, location last seen, & temperament 
        Console.WriteLine("Who have you encountered on your space journey?");
        Console.WriteLine(":=========================:");
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
      else if (input.ToLower == "no")
      {
        Console.WriteLine("Would you like to review Species you've already encountered?...");
        Console.WriteLine(":=========================:");

        input = Console.ReadLine();
      }
      if (input.ToLower == "yes")
      {
        var allSpecies = db.AlienTypes.OrderBy(o => o.Species);
        foreach (var Races in allSpecies)
        {
          Console.WriteLine($"{Races.Species}, {Races.Language}, {Races.LocationOfLastSeen}, {Races.Temperament}, {Races.CountOfTimesSeen}  ");

          //CountOfTimesSeen
          Console.WriteLine("Do you want to update the (count) or (location)of species recorded?");
          Console.WriteLine(":=========================:");
          input = Console.ReadLine();
          // }
          // if (input.ToLower == "count")
          // {
          Console.WriteLine("Who did you encounter and how many times have you seen them along your space journey?");
          Console.WriteLine(":=========================:");
          input = Console.ReadLine();

          //example : (Romulan,2)
          var data = input.Split(',');
          var speciesChange = db.AlienTypes.FirstOrDefault(w => w.Species == data[0]);
          speciesChange.CountOfTimesSeen += int.Parse(data[1]);
          db.SaveChanges();
          Console.WriteLine($"Successfully Saved {Races.CountOfTimesSeen}");
          // }
          // if (input.ToLower == "location")
          // {
          Console.WriteLine("Where did you encounter them along your space journey?");
          Console.WriteLine(":=========================:");
          input = Console.ReadLine();

          //example : (Romulan,2)
          var data = input.Split(',');
          var locationChange = db.AlienTypes.FirstOrDefault(w => w.Species == data[0]);
          locationChange.LocationOfLastSeen = data[1];
          db.SaveChanges();
          Console.WriteLine($"Successfully Saved {Races.LocationOfLastSeen}");
          // }
          // else if (input.ToLower == "next") ;
          // {
          Console.WriteLine("Would you like to see all the species you've encountered in the ...spacejungle?");
          Console.WriteLine(":=========================:");
          input = Console.ReadLine();
          // }
          // if (input.ToLower == "yes")
          // {
          var spaceJungle = db.AlienTypes.Where(w => w.LocationOfLastSeen == "Space Jungle");
          foreach (var Races in spaceJungle) ;
          // }
          // else if (input.ToLower == "next") ;
          // {
          Console.WriteLine("Would you like to remove species that you have met in the SpaceDesert from your logs?");
          Console.WriteLine(":=========================:");
          input = Console.ReadLine();
          // }
          // if (input.ToLower == "yes")
          // {
          var spaceDesert = db.AlienTypes.Where(r => r.LocationOfLastSeen == "Space Desert");
          foreach (var Races in spaceDesert) ;
          {
            spaceDesert.Remove(Races);
          }
          db.SaveChanges();
          Console.WriteLine($"Successfully Saved {Races.Species}");
          // }
          // else if (input.ToLower == "next")
          // {
          Console.WriteLine(":=========================:");
          var seenThem = db.AlienTypes.Sum(s => s.CountOfTimesSeen);
          Console.WriteLine($"You've seen {seenThem} species on your journey");

          Console.WriteLine(":=========================:");
          var AllTheAliens = new[] { "borg", "romulan", "vulcan" };
          var Space = db.AlienTypes.Where(w => AllTheAliens.Contains(w.Species)).Sum(t => t.CountOfTimesSeen);
          Console.WriteLine($"You've seen {AllTheAliens} borg, romulan, and vulcan.");
        }
      }
    }
  }
}


