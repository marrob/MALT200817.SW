using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MALT200817.Checklist
{
    public class Check_00_NetFramework : ICheckItem, INotifyPropertyChanged
    {

        string _dut = "Microsoft .NET Framework 4.7.2 Targeting Pack";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Description 
        {
            get 
            {
                return "Az " + _dut + " meglétének ellenőrzése...";
            }
        }



        string _result;
        public string Result 
        {
            get { return _result; }
            set 
            {
                if (_result != value)
                {
                    _result = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result))); 
                }    
            }
        }



        public ResultStatusType Status { get; set; }


        public void Process()
        {
            if (Tools.IsApplicationInstalled(_dut))
            {
                Status = ResultStatusType.Ok;
                Result = "A(z) " + _dut + " OK.";
            }
            else
            {
                Status = ResultStatusType.Failed;
                Result = "A(z) " + _dut + " Nincs telepitve vagy nem megfelelő verzió. Error.";
            }   
        }

        public void Dispose()
        {
            Result = string.Empty ;
            Status = ResultStatusType.Unknown;
        }
    }
}
