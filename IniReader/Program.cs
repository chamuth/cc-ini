using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninponix;

class Program
{
    static void Main(string[] args)
    {
        var path = @"C:\Users\Chamuth\Desktop\sample.ini";
        var iniReader = new INI(path);

        iniReader.Add("Name", "Chamuth Chamandana");
        iniReader.Add("Age", "15");

        //OR
        iniReader.Configurations.Add("School", "Pinnawala National School");

        iniReader.Save();


        //CHANGING DATA
        iniReader.Configurations["Name"] = "Chamuth Chamandana Thilakarathne";

        iniReader.Save();

    }
}
