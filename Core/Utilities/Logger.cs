using System;
using System.IO;
using Serilog;
using Serilog.Debugging;

namespace AutomationFramework.Core.Utilities
{
    public static class Logger
    {
        private static bool _isInitialized = false;
        private static string _logDirectory;

        /// <summary>
        /// Initializes the logger with a specific scenario name and type (UI or API).
        /// </summary>
        /// <param name="scenarioName">The name of the scenario being run.</param>
        /// <param name="logType">The type of scenario: "UI" or "API".</param>
        public static void Initialize(string scenarioName, string logType)
        {
            if (!_isInitialized)
            {
                // Generate a timestamp for the log folder (only once per test run)
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                // Create a new log folder inside the Logs directory with a timestamp for the entire test run
                var baseLogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Logs");
                _logDirectory = Path.Combine(baseLogDirectory, $"TestRun_{timestamp}");

                if (!Directory.Exists(_logDirectory))
                {
                    Directory.CreateDirectory(_logDirectory);
                }

                _isInitialized = true; // Set the flag to prevent re-creation
            }

            // Determine the appropriate log filename based on the scenario type (UI or API)
            var logSuffix = logType.Equals("UI", StringComparison.OrdinalIgnoreCase) ? "_UiLog.txt" : "_ApiLog.txt";

            // Create a scenario-specific log file name inside the test run folder
            var logFilePath = Path.Combine(_logDirectory, $"{scenarioName.Replace(" ", "_")}{logSuffix}");

            // Enable Serilog SelfLog to track internal logging errors (Optional)
            SelfLog.Enable(msg =>
            {
                Console.Error.WriteLine(msg);
                File.AppendAllText(Path.Combine(_logDirectory, "SerilogSelfLog.txt"), msg + Environment.NewLine);
            });

            // Initialize Serilog logger for this specific scenario
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Level:u3}: {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(logFilePath,
                    rollingInterval: RollingInterval.Infinite,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Level:u3}: {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Information($"Logger initialized for scenario: {scenarioName} of type: {logType}");
        }

        /// <summary>
        /// Closes the logger and flushes any remaining log information.
        /// </summary>
        public static void CloseLogger()
        {
            Log.Information("Flushing and closing the logger.");
            Log.Information("===================================================");
            Log.CloseAndFlush();
        }
    }
}
