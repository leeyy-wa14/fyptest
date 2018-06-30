using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_test
{
    class Process
    {
        public bool Start(String dir) { 
        var folder = new Folder();
            return folder.isEmpty(dir);
        }


    }
}
