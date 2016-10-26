using System;
using DosBox.Command.Framework;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    public class CmdVol : DosCommand
    {
        public CmdVol(string cmdName, IDrive drive)
            : base(cmdName, drive)
        {
        }

        public override void Execute(IOutputter outputter)
        {
            if (GetParameters().Count == 0 || (GetParameters().Count == 1 && GetParameters()[0] == "C:"))
            {
                outputter.PrintLine($"Volume in drive C is Hello World");
                outputter.PrintLine($"Volume Serial Number is 1E16-3FE3");
            }
            else
            {
                outputter.PrintLine("The system cannot find the drive specified.");
            }
        }
    }
}