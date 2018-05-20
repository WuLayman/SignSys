using I_communication_component.MyWcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_communication_component
{
    public class CallBack : IServiceCallback
    {   
        public void ShowMessage(string msg)
        {
            Console.WriteLine("服务器正在工作中；" + msg);


        }
    }
}
