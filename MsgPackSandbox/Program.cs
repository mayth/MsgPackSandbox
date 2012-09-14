using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsgPack;

namespace MsgPackSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            MessagePackObject unpackedRoot;
            Node root;
            using (var stream = System.IO.File.OpenRead(args[0]))
            {
                unpackedRoot = Unpacking.UnpackObject(stream);
                root = Node.Parse(unpackedRoot);
            }
            Console.WriteLine("ok!");

            Console.ReadKey();
        }
    }
}
