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

        //删除对应用户的所有绑定信息
        //尚未完成
        public bool SendDeleteUserInfoToDB(PersonInfo person)
        {
            try
            {
                if (dbContext.USERINFO.Where(x => x.NICKNAME == person.UserNickName && x.REALNAME == person.UserRealName).ToList().Count == 0)
                    return false;
                var user = dbContext.USERINFO.Where(x => x.NICKNAME == person.UserNickName && x.REALNAME == person.UserRealName).ToList().First();
                var count = dbContext.USERINFO.ToList().Count - 1;
                dbContext.USERINFO.Attach(user);
                dbContext.Entry<USERINFO>(user).State = System.Data.Entity.EntityState.Deleted;

                for (int i = 1; i <= count; i++)
                {
                    dbContext.USERINFO.ToList()[i - 1].USERID = i;
                }

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
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}
