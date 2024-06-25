using System;
using LoggerApp; // Ensure correct namespace import

namespace devProChallenge
{
    class Program
    {
        static void Tests(string[] args)
        {
            Logger.LogMessage("User logged in", "INFO");
            Logger.LogMessage("Failed login attempt", "WARNING");

            // Additional program logic
        }
    }
}
