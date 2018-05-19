using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  AllInterfaceProj.ServerInterface
{
    /// <summary>
    /// 管理员类
    /// </summary>
    public class Manager
    {
        private string managerNickName;
        private string password;
        /// <summary>
        /// 用户名（昵称）
        /// </summary>
        public string ManagerNickName { get => managerNickName; set => managerNickName = value; }     
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get => password; set => password = value; }
    }
}
