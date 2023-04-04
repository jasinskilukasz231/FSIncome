using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core.Interfaces
{
    public interface IAddData
    {
        //interface for adding animals fields and machines to farm profile
        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        public bool goBack { get; set; }
        public void SaveToFile();

    }
}
