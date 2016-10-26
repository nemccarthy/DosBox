using DosBox.Command.Library;
using DosBoxTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DosBoxTest.Command.Library
{
    [TestClass]
    public class CmdVolTest : CmdTest
    {
        [TestInitialize]
        public void setUp()
        {
            base.SetUpBase();

            // Add all commands which are necessary to execute this unit test
            // Important: Other commands are not available unless added here.
            commandInvoker.AddCommand(new CmdDir("dir", drive));
        }

        [TestMethod]
        public void CmdVol_WithoutParameter()
        {
            drive.ChangeCurrentDirectory(rootDir);
            ExecuteCommand("vol");
            TestHelper.AssertContains("Volume Serial Number is 1E16-3FE3", testOutput);
            TestHelper.AssertContains("Volume in drive C is Hello World", testOutput);
        }

        [TestMethod]
        public void CmdVol_WithBadParameter()
        {
            drive.ChangeCurrentDirectory(rootDir);
            ExecuteCommand("vol a:");
            TestHelper.AssertContains("The system cannot find the drive specified.", testOutput);
        }
    }


}