
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

[Serializable]
struct Item
{
    public int ItemNumber;
    public string Description;
    public double Amount;
}

class FileStructXMLMain
{
    static void Main()
    {
        
        Item[] items = new Item[5];

        items[0].ItemNumber = 1;
        items[0].Description = "apple";
        items[0].Amount = .25;

        items[1].ItemNumber = 3;
        items[1].Description = "cherries";
        items[1].Amount = .15;

        items[2].ItemNumber = 8;
        items[2].Description = "pears";
        items[2].Amount = .10;

        items[3].ItemNumber = 5;
        items[3].Description = "peaches";
        items[3].Amount = .12;

        items[4].ItemNumber = 6;
        items[4].Description = "pineapple";
        items[4].Amount = 1.25;
        
        FileStream stream = File.Create(@"c:\test.xml");
        
        SoapFormatter formatter = new SoapFormatter();
       
        formatter.Serialize(stream, items);

        stream.Close();

        stream = File.Open(@"c:\test.xml", FileMode.Open);

        formatter = new SoapFormatter();

        items = null;

        items = (Item[])formatter.Deserialize(stream);

        foreach (Item item in items)
        {
            Console.WriteLine(item.Description);
        }

        stream.Close();

        Console.ReadLine();
    }
}
