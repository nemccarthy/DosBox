using System;
using DosBox.Command.Framework;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    public class CmdExit : DosCommand
    {
        public CmdExit(string cmdName, IDrive drive) : base(cmdName, drive)
        {
        }

        public override void Execute(IOutputter outputter)
        {
            Environment.Exit(0);
        }
    }
}