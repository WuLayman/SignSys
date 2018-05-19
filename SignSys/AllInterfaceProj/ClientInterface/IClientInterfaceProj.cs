using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInterfaceProj.ClientInterface
{
    public interface IClientInterfaceProj
    {
        /// <summary>
        /// 开启服务
        /// </summary>
        void Star();

        /// <summary>
        /// 关闭服务
        /// </summary>
        void Leave();

        /// <summary>
        /// 断线
        /// </summary>
        event Action ClientDisconnection;

        /// <summary>
        /// 重连
        /// </summary>
        event Action ClientReconnection;
    }
}
