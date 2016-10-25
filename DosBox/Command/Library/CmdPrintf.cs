using System.Linq;
using DosBox.Command.Framework;
using DosBox.Filesystem;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    public class CmdPrintf : DosCommand
    {
        public CmdPrintf(string cmdName, IDrive drive) : base(cmdName, drive)
        {
        }

        public override void Execute(IOutputter outputter)
        {
            string fileName = GetParameters()[0];

            var dirToPrint = Drive.CurrentDirectory;
            var file = dirToPrint.Content.OfType<Filesystem.File>().Single(f => f.Name == fileName);
            var content = file.FileContent;

            outputter.PrintLine($"-- Content of {file.Name} --");
            outputter.PrintLine(content);
        }
    }
}