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
            outputter.PrintLine(base.Drive.DriveName);
        }
    }
}