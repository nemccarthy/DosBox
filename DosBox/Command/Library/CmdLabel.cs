using DosBox.Command.Framework;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    public class CmdLabel : DosCommand
    {
        public CmdLabel(string cmdName, IDrive drive) : base(cmdName, drive)
        {
        }

        public override void Execute(IOutputter outputter)
        {
            if (GetParameters().Count == 1 )
            {
                var newLbl = GetParameters()[0];
                if (GetParameters().Count == 2)
                {
                    newLbl = GetParameters()[1];
                }
                base.Drive.Label = newLbl;

                outputter.PrintLine($"Set new volume label {base.Drive.Label}");
            }
            else
            {
                outputter.PrintLine("invalid usage, label [newLblName]");
            }

        }
    }
}