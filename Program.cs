using QueryBuilder.Models;

namespace QueryBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string lineBreak = "\n- = - = - = - = - = - = - = - = - = - = -\n";
            if (File.Exists(@"../../../Data/data.db"))
            {
                // Setup: Create backup of current DB for recycling state (rollback)
                QueryBuilder qb = new(@"../../../Data/data.db");
                var Pokedex = qb.ReadAll<Pokemon>();
                var DexCPY = qb.ReadAll<Pokemon>();
                var ParentalControls = qb.ReadAll<BannedGame>();
                var BanCPY = qb.ReadAll<BannedGame>();

                // Delete Pokedex
                Console.WriteLine($"Current Pokedex entry count: {Pokedex.Count}");
                Thread.Sleep(50);
                qb.DeleteAll<Pokemon>();
                Console.WriteLine("Pokedex deleted. Reading current Pokedex entries...");
                Pokedex = qb.ReadAll<Pokemon>();
                Console.WriteLine($"Pokedex Count: {Pokedex.Count}");

                Console.WriteLine(lineBreak);

                // Rollback Pokedex
                Console.WriteLine("Re-inserting Pokedex entries...");
                qb.Create(DexCPY);
                Console.WriteLine("Pokedex re-inserted. Printing current Pokedex...");
                Pokedex = qb.ReadAll<Pokemon>();
                foreach (var pokemon in Pokedex) { Console.WriteLine($"{pokemon.Name}   {pokemon.Type1}   {pokemon.Type2}   Gen {pokemon.Generation}"); }
                Console.WriteLine($"Pokedex Count: {Pokedex.Count}");

                Console.WriteLine(lineBreak);

                Console.WriteLine("How about we \'come up\' with a new Gen 4 Normal-Poison pokemon called \'Poryans.\' The stats will be...whatever.");

                Random rand = new Random();
                Pokemon Poryans = new Pokemon();
                Poryans.Name = "Poryans";
                Poryans.DexNumber = 27523;
                Poryans.Generation = 4;
                Poryans.Attack = rand.Next(255);
                Poryans.Defense = rand.Next(255);
                Poryans.SpecialAttack = rand.Next(255);
                Poryans.SpecialDefense = rand.Next(255);
                Poryans.Speed = rand.Next(255);
                Poryans.HP = rand.Next(8);
                Poryans.Total = Poryans.Attack + Poryans.Defense + Poryans.SpecialAttack + Poryans.SpecialDefense + Poryans.Speed + Poryans.HP;
                Poryans.Form = "Python";
                Poryans.Type1 = "Normal";
                Poryans.Type2 = "Poison";

                qb.Create(Poryans);
                Console.WriteLine($"{Poryans.Name}   {Poryans.Type1}   {Poryans.Type2}   Gen {Poryans.Generation}\n" +
                    $"Attack: {Poryans.Attack}   Special Attack: {Poryans.SpecialAttack}   Form: {Poryans.Form}");

                Console.WriteLine(lineBreak);

                // Silly BannedGame Demo : Intro
                Console.WriteLine("If...AND ONLY IF... you are a good noodle, you'll NEVER touch ANY of these games. At all. Ever. In your life.");
                foreach (var game in ParentalControls) { Console.WriteLine(game.Title); }
                Console.WriteLine($"That's a lot of games. That's like... {ParentalControls.Count} games.");
                Console.WriteLine(lineBreak);
                Thread.Sleep(1500);

                // Deleting BanList
                Console.WriteLine("\'Mom said I can do what I want, whenever I want.\'");
                Thread.Sleep(1500);
                qb.DeleteAll<BannedGame>();
                ParentalControls = qb.ReadAll<BannedGame>();
                Console.WriteLine($"Well then... now you can't play {ParentalControls.Count} games!");
                Console.WriteLine(lineBreak);

                // Inserting individual BannedGame
                Thread.Sleep(1500);
                Console.WriteLine("\n\'Hey! I said you can't be on that Borlox! " +
                    "\nThe Inanet is a great place for anything USA, but you stole my credit card and spent way too much money!\'\n");

                // Quick creation of custom BannedGame
                BannedGame insert = new BannedGame();
                insert.Title = "Borlox";
                insert.Series = "Inanet";
                insert.Country = "USA";
                insert.Details = "PUT. THAT. DOWN. frfr -_-";
                qb.Create(insert);
                ParentalControls = qb.ReadAll<BannedGame>();

                Console.WriteLine($"So that makes {ParentalControls.Count} no-go game(s).");
                Console.WriteLine($"Title \t Series \t Country \t Details");
                foreach (var game in ParentalControls) { Console.WriteLine($"{game.Title} \t {game.Series} \t {game.Country} \t {game.Details}"); }

                qb.DeleteAll<BannedGame>();
                qb.Create(BanCPY);
                qb.Create(insert);
            }
            
        }
    }
}