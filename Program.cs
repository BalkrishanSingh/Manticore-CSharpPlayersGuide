
int minDistance = 0, maxDistance = 100;
int maxManticoreHealth = 10, maxCityHealth = 15;
int manticoreHealth = maxManticoreHealth, cityHealth = maxCityHealth;
int manticoreLocation = GetManticoreLocation();
int round = 1;

while (true)
{
    Console.WriteLine("-----------------------------------------------------------");
    DisplayRound();
    if (manticoreHealth == 0)
    {
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        break;
    }

    cityHealth--;
    if (cityHealth == 0)
    {
        Console.WriteLine("The City of Consolas has been destroyed! You should have tried harder...");
        break;
    }
    round++;
}

 void DisplayRound()
{
    
    
    RoundColor();//change color according to type of cannon damage
    DisplayStatus();
    
    int cannonDamage = CalculateCannonDamage();
    Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");
    
    
    int cannonTargetRange = InputNumberInRange("Enter desired cannon target range: ", minDistance, maxDistance);//should cannon have a min or max distance?
    Console.WriteLine(ManticoreHitStatus(manticoreLocation,cannonTargetRange));
    
    manticoreHealth = NewManticoreHealth(manticoreHealth,manticoreLocation,cannonDamage,cannonTargetRange);
    
    Console.ForegroundColor = ConsoleColor.Gray;//turns back color to gray for next round
    
}



static string ManticoreHitStatus(int manticoreLocation, int cannonTargetRange)
{
     if (manticoreLocation > cannonTargetRange) return "That round FELL SHORT of the target.";
    else if (manticoreLocation < cannonTargetRange) return "That round OVERSHOT the the target.";
    else return "That round was a DIRECT HIT!";

}

 static int NewManticoreHealth(int manticoreHealth,int manticoreLocation,int cannonDamage, int cannonTargetRange)
{
    if (manticoreLocation == cannonTargetRange) return manticoreHealth - cannonDamage;
    else return manticoreHealth;
}



void RoundColor()
{
    if (round % 3 == 0 && round % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    
    else if (round % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }
    else if (round % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        
    }
    
    
}
 int CalculateCannonDamage()
{
    int cannonDamage = 1;
    
   if (round % 3 == 0 && round % 5 == 0)
    {
        cannonDamage = 10; // fire-electric cannon damage
    }

    else if (round % 3 == 0)
    {
        cannonDamage = 3;//fire blast cannon damage
        
    }
    else if (round % 5 == 0)
    {
        cannonDamage = 5;//electric blast cannon damage   
    }
    return cannonDamage;
}


 void DisplayStatus()
{
    Console.WriteLine(
        $"STATUS: Round: {round} City: {cityHealth}/{maxCityHealth} Manticore: {manticoreHealth}/{maxManticoreHealth}");
}


 int GetManticoreLocation()
{
    int location;
    
    int choice = InputNumberInRange("Enter 1 for Single-player and 2 for Multiplayer :",1,2);
    if (choice == 2){
         location = InputNumberInRange("Player 1, how far away from the city do you want to station the Manticore? ",minDistance,maxDistance);
         Console.Clear();

    }
    else
    {
        Random rnd = new Random();
         location = rnd.Next(minDistance, maxDistance);
    }


    return location;
}


int InputNumberInRange(string text, int min, int max)
{
    while (true)
    {
        Console.Write(text);
        int number = Convert.ToInt32(Console.ReadLine());
        if (number >= min && number <= max)
        {
            return number;
        }
        else
        {
            Console.WriteLine($"Please enter a number between {min} and {max}.");
        }
    }
}