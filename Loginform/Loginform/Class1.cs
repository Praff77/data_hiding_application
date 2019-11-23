using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace header
{
    class Pro
    {
        public static void Lock(string nname, string Address)
        {
            string command;
            command = "ren " + Address + " " + nname + "";
            System.Diagnostics.Process.Start("CMD.exe", command);
            command = "Attrib +h +s " + Address + "";
            System.Diagnostics.Process.Start("CMD.exe", command);

        }
        public static void Unlock(string Address, string rname)
        {
            string command;
            command = "Attrib -h -s " + Address + "";
            System.Diagnostics.Process.Start("CMD.exe", command);
            command = "ren " + Address + " " + rname + "";
            System.Diagnostics.Process.Start("CMD.exe", command);

        }

    }
}