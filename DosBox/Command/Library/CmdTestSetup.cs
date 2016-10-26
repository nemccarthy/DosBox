using DosBox.Command.Framework;
using DosBox.Filesystem;
using DosBox.Interfaces;

namespace DosBox.Command.Library
{
    public class CmdTestSetup : DosCommand
    {
        public CmdTestSetup(string cmdName, IDrive drive) : base(cmdName, drive)
        {
        }

        public override void Execute(IOutputter outputter)
        {
            //creates some test dirs

            Drive.CurrentDirectory.Add(new File("File1InRoot", "an entry"));
            Drive.CurrentDirectory.Add(new File("File2InRoot", "a long entry in a file"));

            var subDir1 = new Directory("subDir1");
            Drive.CurrentDirectory.Add(subDir1);

            subDir1.Add(new File("File1InDir1", ""));
            subDir1.Add(new File("File2InDir1", ""));

            var subDir2 = new Directory("subDir2");
            Drive.CurrentDirectory.Add(subDir2);

            subDir2.Add(new Directory("subSubDir3"));
        }
    }
}