using System;
using System.Diagnostics;
using System.Threading;
using System.Management;

namespace nCrypt
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

            if (args.Length != 2)
            {
                Console.WriteLine("  Usage:");
                Console.WriteLine("  nCrypt.exe -e|--encrypt \"text to encrypt\"");
                Console.WriteLine("  nCrypt.exe -d|--decrypt \"text to decrypt\"");
                Console.WriteLine("\n  Make sure to run via PowerShell or Command Prompt / Terminal");

                if (IsLaunchedFromExplorer())
                {
                    Console.Title = "nCrypt Console Manager";
                    Thread.Sleep(5000);
                }

                Environment.Exit(0);
            }

            string option = args[0];
            string inputText = args[1];

            var cipher = new nCipher();

            switch (option)
            {
                case "-e":
                case "--encrypt":
                    string encrypted = cipher.Encrypt(inputText);
                    Console.WriteLine("Encrypted text:");
                    Console.WriteLine(encrypted);
                    break;

                case "-d":
                case "--decrypt":
                    string decrypted = cipher.Decrypt(inputText);
                    Console.WriteLine("Decrypted text:");
                    Console.WriteLine(decrypted);
                    break;

                default:
                    Console.WriteLine("Unknown option: " + option);
                    Console.WriteLine("Use -e|--encrypt or -d|--decrypt");
                    break;
            }
        }

        static bool IsLaunchedFromExplorer()
        {
            try
            {
                Process process = Process.GetCurrentProcess();
                Process parent = GetParentProcess(process.Id);
                if (parent != null)
                {
                    return parent.ProcessName.Equals("explorer", StringComparison.OrdinalIgnoreCase);
                }
            }
            catch
            {
                // Ignore Errors
            }
            return false;
        }

        static Process GetParentProcess(int id)
        {
            try
            {
                var query = new ManagementObjectSearcher(
                    "SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = " + id);
                foreach (ManagementObject item in query.Get())
                {
                    int parentId = Convert.ToInt32(item["ParentProcessId"]);
                    return Process.GetProcessById(parentId);
                }
            }
            catch
            {
                // Ignore Errors
            }
            return null;
        }
    }
}
