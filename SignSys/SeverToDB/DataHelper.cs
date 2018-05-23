using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeverToDB
{
    public class DataHelper
    {
        private Entities1 entities = EntityHelper.GetEntities();
        public static string ErrorMsg = null;

        public bool SendNewPersonInfoToDB(PersonInfo personInfo)
        {
            if (entities.USERINFO.Where(x => x.NICKNAME == personInfo.UserNickName).ToList().Count == 1)
            {
                ErrorMsg = "该用户名已存在，换一个吧~~~";
                return false;
            }
            USERINFO userInfo = new USERINFO()
            {
                NICKNAME = personInfo.UserNickName,
                REALNAME = personInfo.UserRealName,
                PASSWORD = personInfo.PassWord,
                MACADDRESS = personInfo.MacAddress,
                USERID = Guid.NewGuid().ToString()
            };
            entities.USERINFO.Add(userInfo);

            try
            {
                var num = entities.SaveChanges();
                if (num == 1)
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                ErrorMsg = ex.Message;
            }

            return false;
        }
    }
}
