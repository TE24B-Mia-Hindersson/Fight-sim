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


using System.Formats.Asn1;

string name1 = "";
string name2 = "";
bool playagain = true;
//Bool är en variabel som kan vara antigen true eller false 
// Används för att starta om spelet
while (playagain)
{
  name1 = "";
  name2 = "";
  //nollställer namnen for new gamess
  Console.WriteLine("--------------------------------");
  Console.WriteLine("    ---Welcome to my game---");
  Console.WriteLine("--------------------------------");
  Console.ReadLine();
  Console.Clear();

  Console.WriteLine("Please enter the name of the first fighter (min 3 characters and max 12):");
  name1 = Console.ReadLine();
  while (string.IsNullOrWhiteSpace(name1) || name1.Length < 3 || name1.Length > 12)
  {
    Console.WriteLine("Name entered is too short or too long. Please try again!");
    name1 = Console.ReadLine();
  }
  Console.WriteLine("--------------------------------");
  string[] randname = { "bert", "bosse", "leon", "bengt", "mia" }; 
  //randomiserar mellan de olika namnen
  //[] basically låter mig skapa en samling (som list) som senare plockas ur
  Console.WriteLine("Would you like to choose the name of your second fighter?");
  string input = Console.ReadLine().ToLower();
  //denna string ger dig möjligheten att svara antigen nej -- du får random name. ja -- du får skriva eget
  if (input == "no")
  {
    name2 = randname[Random.Shared.Next(randname.Length)];
    Console.WriteLine($"Random name chosen: {name2}");
  }
  else
  {
    Console.WriteLine("Now please enter the name of the second fighter (min 3 characters and max 12):");
    name2 = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(name2) || name2.Length < 3 || name2.Length > 12)
    {
      Console.WriteLine("Name entered is too short or too long. Please try again!");
      name2 = Console.ReadLine();
    }
  }
  Console.WriteLine("--------------------------------");
  Console.WriteLine($"Fighters chosen {name1} vs {name2}!");
  Console.WriteLine("Press Enter to continue...");
  Console.ReadLine();
  Console.Clear();


  int player1hp = 100;
  int player2hp = 100;
  int maxrounds = 7;
  int currround = 1;
  while (player1hp > 0 && player2hp > 0 && currround <= maxrounds)
  //main loop där spelet körs tills en av dem dör (eller båda) eller om maxrundor nås
  {
    Console.Clear();
    if (currround == maxrounds)
    {
      Console.WriteLine("!!! LAST ROUND !!!");
    }
    Console.WriteLine($"    --Round {currround} !--");
    Console.WriteLine($"{name1} has {player1hp} HP and {name2} has {player2hp} HP");
    Console.WriteLine("--------------------------------");
    Console.ReadLine();
    Console.Clear();
    Console.WriteLine($"Choose your attack for {name1}:");
    Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine("Attack 1 (safe choice): 80% hit chance, 10-20 damage");
    Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine("Attack 2 (risky choice): 40% hit chance, 20-30 damage");
    Console.WriteLine("-------------------------------------------------------");
    string choice = Console.ReadLine();
    Console.Clear();
    double hitchancep1;
    //double är som int fast för decimaltal
    int mindamp1, maxdamp1;
    if (choice == "1")
    {
      hitchancep1 = 0.8;
      mindamp1 = 10;
      maxdamp1 = 20;
      Console.WriteLine("--------------------------------");
      Console.WriteLine($"{name1} chose the safe attack!");
    }
    else if (choice == "2")
    {
      hitchancep1 = 0.4;
      mindamp1 = 20;
      maxdamp1 = 30;
      Console.WriteLine("--------------------------------");
      Console.WriteLine($"{name1} chose the risky attack!");
    }
    else
    //om spelaren för nån anledning inte svarar??
    {
      Console.WriteLine("--------------------------------------------");
      Console.WriteLine("Invalid response :(. Ill go with the safe option for you!");
      hitchancep1 = 0.8;
      mindamp1 = 10;
      maxdamp1 = 20;
    }
    if (Random.Shared.NextDouble() <= hitchancep1)
    //checkar om spelarens slag landar/alternativt inte gör de
    {
      int player1damage = Random.Shared.Next(mindamp1, maxdamp1 + 1);
      player2hp -= player1damage;
      Console.WriteLine("--------------------------------");
      Console.WriteLine($"{name1} hit and dealt {player1damage} damage!");
    }
    else
    {
      Console.WriteLine("--------------------------------");
      Console.WriteLine($"{name1} missed!");
      Console.WriteLine("-_-");
    }
    if (player2hp <= 0) break;
    //om player 2 bara dör :P


    double hitchancep2;
    int mindamp2, maxdamp2;
    if (Random.Shared.Next(2) == 0)
    //andra fightern (inte du som bestämmer) slumpar vilken attack som väljs
    {
      hitchancep2 = 0.8;
      mindamp2 = 10;
      maxdamp2 = 20;
      Console.WriteLine("--------------------------------");
      Console.WriteLine($"{name2} chose the safe attack!");
    }
    else
    {
      hitchancep2 = 0.4;
      mindamp2 = 20;
      maxdamp2 = 30;
      Console.WriteLine("--------------------------------");
      Console.WriteLine($"{name2} chose the risky attack!");
    }
    if (Random.Shared.NextDouble() <= hitchancep2)
    {
      int player2damage = Random.Shared.Next(mindamp2, maxdamp2 + 1);
      player1hp -= player2damage;
      Console.WriteLine("--------------------------------");
      Console.WriteLine($"{name2} hit and dealt {player2damage} damage!");
    }
    else
    {
      Console.WriteLine("--------------------------------");
      Console.WriteLine($"{name2} missed!");
      Console.WriteLine("-_-");
    }
    if (player1hp <= 0) break;

    Console.WriteLine("--------------------------------");
    Console.ReadLine();
    Console.Clear();

    currround++;
    //läger till en runda 
  }
  Console.WriteLine("=========RESULTS==========");
  if (player1hp <= 0 && player2hp <= 0)
  {
    Console.WriteLine("--------------------------------");
    Console.WriteLine("            Tie!");
    Console.WriteLine("--------------------------------");
    Console.ReadLine();
    Console.Clear();
  }

  else if (player1hp <= 0)
  {
    Console.WriteLine("--------------------------------");
    Console.WriteLine($"       {name2} won!!");
    Console.WriteLine("--------------------------------");
    Console.ReadLine();
    Console.Clear();
  }
  else if (player2hp <= 0)
  {
    Console.WriteLine("--------------------------------");
    Console.WriteLine($"       {name1} won!!");
    Console.WriteLine("--------------------------------");
    Console.ReadLine();
    Console.Clear();
  }
  else
  {
    if (player1hp > player2hp)
    {
      Console.WriteLine("--------------------------------");
      Console.WriteLine($"{name1} won due to hp!");
      Console.WriteLine("--------------------------------");
      Console.ReadLine();
      Console.Clear();
    }
    else if (player2hp > player1hp)
    {
      Console.WriteLine("--------------------------------");
      Console.WriteLine($"{name2} won due to hp!");
      Console.WriteLine("--------------------------------");
      Console.ReadLine();
      Console.Clear();
    }
    else
    {
      Console.WriteLine("--------------------------------");
      Console.WriteLine("             tie!");
      Console.WriteLine("--------------------------------");
      Console.ReadLine();
      Console.Clear();
    }
  }


  Console.WriteLine("--------------------------------");
  Console.WriteLine("Would you like to play again?");
  string answer = Console.ReadLine().ToLower();
  if (answer == "yes")
  {
    Console.WriteLine("Press enter to restart!");
    Console.ReadLine();
    Console.Clear();
    playagain = true;
  }

  else if (answer == "no")
  {
    Console.Clear();
    playagain = false;
    Console.ReadLine();
    Console.Clear();
  }
  else
  {
    Console.Clear();
    Console.WriteLine("Invalid input. The game will now end :(");
    playagain = false;
    Console.ReadLine();
    Console.Clear();
  }
}
Console.WriteLine("Thank you for playing!");
Console.ReadLine();
