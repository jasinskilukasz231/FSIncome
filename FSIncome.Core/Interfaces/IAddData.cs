using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core.Interfaces
{
    public interface IAddData
    {
        //interface for adding animals fields and machines to farm profile
        public bool goBack { get; set; }
        public List<string> dataList { get; set; }  
        public void SaveToFile(List<string> dataList);

    }
}
