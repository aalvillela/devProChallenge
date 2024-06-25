using NUnit.Framework;
using LoggerApp;
using NUnit.Framework.Legacy;

namespace Tests
{
    [TestFixture]
    public class LoggerTests
    {
        private static readonly string testFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "application.log");

        [SetUp]
        public void SetUp()
        {
            // Ensure the directory exists
            string directory = Path.GetDirectoryName(testFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Create an empty file if it doesn't exist
            if (!File.Exists(testFilePath))
            {
                File.WriteAllText(testFilePath, "");
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Delete the file if it exists
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Test]
        public void TestLogMessage()
        {
            // Use Logger.LogMessage method from LoggerApp namespace
            Logger.LogMessage("User logged in", "INFO");
            Logger.LogMessage("Failed login attempt", "WARNING");

            // Read the contents of the log file
            string[] logEntries = File.ReadAllLines(testFilePath);

            // Perform assertions
            ClassicAssert.AreEqual(2, logEntries.Length);
            StringAssert.Contains("[INFO] User logged in", logEntries[0]);
            StringAssert.Contains("[WARNING] Failed login attempt", logEntries[1]);
        }
    }
}
