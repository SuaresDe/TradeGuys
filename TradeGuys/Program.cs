class Guy
{
    public string Name;
    public int Cash;

    public void WriteMyInfo()
    {
        Console.WriteLine(Name + " has " + Cash + " bucks.");
    }

    public int GiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " says: " + amount + " isn't a valid amount.");
            return 0;
        }
        if (amount > Cash)
        {
            Console.WriteLine(Name + " says: " + "I don't have enough to give you " + amount);
            return 0;
        }
        Cash -= amount;
        return amount;
    }

    public void ReceiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take.");
        }
        else
        {
            Cash += amount;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Guy joe = new Guy() { Cash = 50, Name = "Joe" };
        Guy bob = new Guy() { Cash = 100, Name = "Bob" };

        while (true)
        {
            joe.WriteMyInfo();
            bob.WriteMyInfo();
            Console.Write("Enter an amount: ");
            string howMuch = Console.ReadLine();
            if (howMuch == "") return;
            if (int.TryParse(howMuch, out int amount))
            {
                Console.Write("Who should give the cash: ");
                string whichGuy = Console.ReadLine();
                if (whichGuy == "joe")
                {
                    int cashGiven = joe.GiveCash(amount);
                    bob.ReceiveCash(cashGiven);
                }
                else if (whichGuy == "bob")
                {
                    int cashGiven = bob.GiveCash(amount);
                    joe.ReceiveCash(cashGiven);
                }
                else
                {
                    Console.WriteLine("Please enter 'joe' or 'bob'");
                }

            }
            else
            {
                Console.WriteLine("Please enter an amount (or blank line to exit.)");
            }
        }
    }
}
