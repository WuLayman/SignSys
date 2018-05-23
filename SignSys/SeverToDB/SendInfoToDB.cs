using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeverToDB
{
    public class SendInfoToDB
    {
        Entities1 dbContext = EntityHelper.GetEntities();
        public static string ErrorMsg = null;
        
        public bool SendDeleteUserInfoToDB(PersonInfo person)
        {
            try
            {
                if (dbContext.USERINFO.Where(x => x.NICKNAME == person.UserNickName && x.REALNAME == person.UserRealName).ToList().Count == 0)
                {
                    ErrorMsg = "要删除的用户不存在，请检查用户信息！";
                    return false;
                }
                var user = dbContext.USERINFO.Where(x => x.NICKNAME == person.UserNickName && x.REALNAME == person.UserRealName).ToList().First();
                dbContext.USERINFO.Attach(user);
                dbContext.Entry<USERINFO>(user).State = System.Data.Entity.EntityState.Deleted;
                var b = dbContext.SaveChanges();
                if (b != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
            }
            return false;
        }
    }
}
