using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

class Program
{
    static void Main()
    {

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine("=========================================================");
        Console.WriteLine("     AUTO PING LOGGER - #UTIL27");
        Console.WriteLine("=========================================================");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("     SIMPHONY NETWORK ISSUE UTILITY");
        Console.WriteLine("=========================================================");
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=========================================================");
        Console.WriteLine("# DEVELOPER :- GOHULAN SOMANATHAN");
        Console.WriteLine("=========================================================");
        Console.WriteLine("# COMPANY   :-CUBEMAK LABS");
        Console.WriteLine("=========================================================");
        Console.WriteLine("# APP VER   :- 1.0.0 RELE 2023 NOVEMBER 06");
        Console.WriteLine("=========================================================");
        Console.WriteLine("");

        string ipAddress = "XXX.XXX.XXX.XXX";
        string logDirectory = "c:/pingresults";
        string logFileName = $"pingresults_{ipAddress}.sg";
        string logFilePath = Path.Combine(logDirectory, logFileName);

        // Create the log directory if it doesn't exist
        Directory.CreateDirectory(logDirectory);

        using (StreamWriter logFile = File.AppendText(logFilePath))
        {
            logFile.WriteLine($"Ping log for {ipAddress}");
        }

        // Continuously ping the IP address and log the responses
        while (true)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string response = PingHost(ipAddress);

            using (StreamWriter logFile = File.AppendText(logFilePath))
            {
                logFile.WriteLine($"{timestamp}: {response}");
            }

            Thread.Sleep(1000); // Wait for 5 seconds before the next ping (adjust as needed)
        }
    }

    static string PingHost(string ipAddress)
    {
        try
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(ipAddress);

            if (reply.Status == IPStatus.Success)
            {
                return $"Ping successful - Round trip time: {reply.RoundtripTime} ms";
            }
            else
            {
                return $"Ping failed - {reply.Status}";
            }
        }
        catch (Exception ex)
        {
            return $"Ping error: {ex.Message}";
        }
    }
}
