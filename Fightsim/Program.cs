// int i = 100;
// string name = "Mia";
// while (i > 0 && name == "Mia")
// {
//     Console.WriteLine();
//     i--;
// }
// Console.ReadLine();
// // int i = Random.Shared.Next(0, 21);
// // Console.WriteLine(i);

int player1hp = 100;
int player2hp = 100;
Console.WriteLine("---Welcome to my game---");
Console.WriteLine("Please enter the name of the first fighter:");
string name1 = Console.ReadLine();
Console.WriteLine("Now please enter the name of the second fighter:");
string name2 = Console.ReadLine();
Console.WriteLine($"Fighters chosen {name1} vs {name2}!");
Console.WriteLine("Press Enter to continue...");
Console.ReadLine();
while (player1hp > 0 && player2hp > 0)
{
  Console.WriteLine("    --New Round!--");
  Console.WriteLine($"{name1} has {player1hp} HP and {name2} has {player2hp} HP");
  Console.WriteLine("--------------------------------");
  if (Random.Shared.NextDouble() <= 0.7)
  {
    int player1damage = Random.Shared.Next(20);
    player2hp -= player1damage;
    Console.WriteLine($"{name1} does {player1damage} damage to {name2}!");
    Console.WriteLine($"{name2} has {player2hp} remaining!");
  }
  else
  {
    Console.WriteLine($"{name1} missed!");
  }
  if (player2hp <= 0) break;
  Console.WriteLine("--------------------------------");
  if (Random.Shared.NextDouble() <= 0.6)
  {
    int player2damage = Random.Shared.Next(25);
    player1hp -= player2damage;
    Console.WriteLine($"{name2} does {player2damage} damage to {name1}!");
    Console.WriteLine($"{name1} has {player1hp} remaining!");
    Console.WriteLine("--------------------------------");
    Console.ReadLine();
  }
   else
    {
        Console.WriteLine($"{name2} missed!");
    }
}
if (player1hp == 0 && player2hp == 0)
{
  Console.WriteLine("Tie!");
}

else if (player1hp <= 0)
{
  Console.WriteLine($"{name2} won!!");
}
else if (player2hp <= 0)
{
  Console.WriteLine($"{name1} won!!");
}
Console.WriteLine("Press Enter to end game..");
Console.ReadLine();

