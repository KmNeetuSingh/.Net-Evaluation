using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class SmartHomeSystem
{
    private List<string> connectedDevices;

    public SmartHomeSystem()
    {
        connectedDevices = new List<string>();
    }

    public void AddDevice(string device)
    {
        connectedDevices.Add(device);
        Console.WriteLine($"{device} added to the system.");
    }

    public void RemoveDevice(string device)
    {
        if (connectedDevices.Remove(device))
        {
            Console.WriteLine($"{device} removed from the system.");
        }
        else
        {
            Console.WriteLine($"{device} not found in the system.");
        }
    }

    public void TurnOnOffDevices(bool turnOn)
    {
        string status = turnOn ? "ON" : "OFF";
        foreach (var device in connectedDevices)
        {
            Console.WriteLine($"{device} is now {status}.");
        }
    }
}

public class TaskScheduler
{
    private PriorityQueue<string, int> taskQueue;

    public TaskScheduler()
    {
        taskQueue = new PriorityQueue<string, int>();
    }

    public void AddTask(string task, int priority)
    {
        taskQueue.Enqueue(task, priority);
        Console.WriteLine($"Task added: {task} with priority {priority}");
    }

    public void ExecuteTasks()
    {
        Console.WriteLine("Executing tasks in order of priority:");
        while (taskQueue.Count > 0)
        {
            string task = taskQueue.Dequeue();
            Console.WriteLine($"Executing: {task}");
        }
    }
}

public class BlockchainTransaction
{
    public string TransactionId { get; private set; }
    public string Sender { get; private set; }
    public string Receiver { get; private set; }
    public decimal Amount { get; private set; }

    public BlockchainTransaction(string sender, string receiver, decimal amount)
    {
        Sender = sender;
        Receiver = receiver;
        Amount = amount;
        TransactionId = GenerateTransactionId();
    }

    private string GenerateTransactionId()
    {
        string transactionData = $"{Sender}-{Receiver}-{Amount}";
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(transactionData));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    public bool ValidateTransaction()
    {
        string expectedTransactionId = GenerateTransactionId();
        return expectedTransactionId == TransactionId;
    }
}

public class MusicPlaylist
{
    private class Node
    {
        public string Song { get; set; } = string.Empty;
        public Node Next { get; set; } = null;
        public Node Prev { get; set; } = null;
    }

    private Node head;
    private Node tail;

    public MusicPlaylist()
    {
        head = null;
        tail = null;
    }

    public void AddSong(string song)
    {
        Node newNode = new Node { Song = song };
        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
        Console.WriteLine($"Song added: {song}");
    }

    public void RemoveSong(string song)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Song == song)
            {
                if (current.Prev != null) current.Prev.Next = current.Next;
                if (current.Next != null) current.Next.Prev = current.Prev;
                if (current == head) head = current.Next;
                if (current == tail) tail = current.Prev;

                Console.WriteLine($"Song removed: {song}");
                return;
            }
            current = current.Next;
        }
        Console.WriteLine($"Song not found: {song}");
    }

    public void PlaySongs()
    {
        Console.WriteLine("Playing songs:");
        Node current = head;
        while (current != null)
        {
            Console.WriteLine($"Playing: {current.Song}");
            current = current.Next;
        }
    }
}

public class Stock
{
    public string Symbol { get; set; }
    public int Quantity { get; set; }
    public double PricePerShare { get; set; }

    public Stock(string symbol, int quantity, double pricePerShare)
    {
        Symbol = symbol;
        Quantity = quantity;
        PricePerShare = pricePerShare;
    }

    public double GetStockValue()
    {
        return Quantity * PricePerShare;
    }
}

public class StockPortfolio
{
    private List<Stock> stocks;

    public StockPortfolio()
    {
        stocks = new List<Stock>();
    }

    // Add a stock to the portfolio
    public void AddStock(string symbol, int quantity, double pricePerShare)
    {
        Stock stock = new Stock(symbol, quantity, pricePerShare);
        stocks.Add(stock);
        Console.WriteLine($"Added {quantity} shares of {symbol} at {pricePerShare} each.");
    }

    // Remove a stock from the portfolio by its symbol
    public void RemoveStock(string symbol)
    {
        var stock = stocks.Find(s => s.Symbol == symbol);
        if (stock != null)
        {
            stocks.Remove(stock);
            Console.WriteLine($"Removed {stock.Quantity} shares of {symbol}.");
        }
        else
        {
            Console.WriteLine($"Stock with symbol {symbol} not found in portfolio.");
        }
    }

    // Calculate the total value of the portfolio
    public double CalculateTotalPortfolioValue()
    {
        double totalValue = 0;
        foreach (var stock in stocks)
        {
            totalValue += stock.GetStockValue();
        }
        return totalValue;
    }

    // Display all stocks in the portfolio
    public void DisplayPortfolio()
    {
        Console.WriteLine("\nPortfolio Overview:");
        foreach (var stock in stocks)
        {
            Console.WriteLine($"Symbol: {stock.Symbol}, Quantity: {stock.Quantity}, Price per Share: {stock.PricePerShare}, Total Value: {stock.GetStockValue()}");
        }
    }
}

// class Program
// {
//     static void Main()
//     {
//         // StockPortfolio Test
//         Console.WriteLine("StockPortfolio Test:");
//         StockPortfolio portfolio = new StockPortfolio();
//         portfolio.AddStock("AAPL", 10, 150.0);
//         portfolio.AddStock("GOOG", 5, 2800.0);
//         portfolio.AddStock("TSLA", 3, 700.0);

//         // Display the current portfolio
//         portfolio.DisplayPortfolio();

//         // Calculate the total portfolio value
//         double totalValue = portfolio.CalculateTotalPortfolioValue();
//         Console.WriteLine($"\nTotal Portfolio Value: {totalValue}");

//         // Remove a stock from the portfolio
//         portfolio.RemoveStock("GOOG");

//         // Display the updated portfolio
//         portfolio.DisplayPortfolio();

//         // Calculate the updated total portfolio value
//         totalValue = portfolio.CalculateTotalPortfolioValue();
//         Console.WriteLine($"\nUpdated Total Portfolio Value: {totalValue}");

//         // SmartHomeSystem Test
//         Console.WriteLine("\nSmartHomeSystem Test:");
//         SmartHomeSystem homeSystem = new SmartHomeSystem();
//         homeSystem.AddDevice("Light");
//         homeSystem.AddDevice("Fan");
//         homeSystem.RemoveDevice("Air Conditioner");
//         homeSystem.TurnOnOffDevices(true);

//         // TaskScheduler Test
//         Console.WriteLine("\nTaskScheduler Test:");
//         TaskScheduler scheduler = new TaskScheduler();
//         scheduler.AddTask("Task 1", 2);
//         scheduler.AddTask("Task 2", 1);
//         scheduler.ExecuteTasks();

//         // BlockchainTransaction Test
//         Console.WriteLine("\nBlockchainTransaction Test:");
//         BlockchainTransaction transaction = new BlockchainTransaction("Alice", "Bob", 100);
//         Console.WriteLine($"Transaction ID: {transaction.TransactionId}");
//         Console.WriteLine($"Is transaction valid? {transaction.ValidateTransaction()}");

//         // MusicPlaylist Test
//         Console.WriteLine("\nMusicPlaylist Test:");
//         MusicPlaylist playlist = new MusicPlaylist();
//         playlist.AddSong("Song 1");
//         playlist.AddSong("Song 2");
//         playlist.RemoveSong("Song 1");
//         playlist.PlaySongs();
//     }
// }
