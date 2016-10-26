using DosBox.Command.Library;
using DosBox.Filesystem;
using DosBox.Interfaces;
using DosBox.Invoker;
using DosBoxTest.Command.Framework;
using DosBoxTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DosBoxTest.Command.Library
{
    [TestClass]
    public class CmdTestSetupTest
    {

        protected CommandInvoker commandInvoker;
        protected IDrive drive;

        protected int numbersOfDirectoriesBeforeTest;
        protected int numbersOfFilesBeforeTest;
        protected Directory rootDir;
        protected TestOutput testOutput = new TestOutput();

        public virtual void SetUpBase()
        {
            drive = new Drive("C");
            rootDir = drive.RootDirectory;

            commandInvoker = new CommandInvoker();
            testOutput = new TestOutput();
        }

        [TestInitialize]
        public void setUp()
        {
            SetUpBase();

            // Add all commands which are necessary to execute this unit test
            // Important: Other commands are not available unless added here.
            commandInvoker.AddCommand(new CmdTestSetup("testsetup", drive));
        }

        [TestMethod]
        public void CmdTestSetup_TestStruct()
        {
            ExecuteCommand("testsetup");
            numbersOfDirectoriesBeforeTest = drive.RootDirectory.GetNumberOfDirectories();
            numbersOfFilesBeforeTest = drive.RootDirectory.GetNumberOfFiles();
            Assert.AreEqual(numbersOfFilesBeforeTest, 4);
            Assert.AreEqual(numbersOfDirectoriesBeforeTest, 4);
        }

        protected void ExecuteCommand(string commandLine)
        {
            if (commandInvoker == null)
                commandInvoker = new CommandInvoker();
            commandInvoker.ExecuteCommand(commandLine, testOutput);
        }
    }
}