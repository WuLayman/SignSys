using AllInterfaceProj.ServerInterface;
using PublicBaseClassProj;
using SeverToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImplementInterface

{
    public class SendDataHelper : ISendDataToDB
    {
        public bool SendChangePersonInfoToDB(PersonInfo personInfo)
        {
            try
            {
                Entities1 dbContext = EntityHelper.GetEntities();
                var userInfo = dbContext.USERINFO.Where(x => x.NICKNAME == personInfo.UserNickName).ToList().First();
                userInfo.PASSWORD = personInfo.PassWord;
                userInfo.MACADDRESS = personInfo.MacAddress;
                var num = dbContext.SaveChanges();
                if (num == 1)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public bool SendPictureInfoToDB(PictureInfo picture)
        {
            try
            {
                Entities1 dbContext = new Entities1();
                if (dbContext.PICTUREINFO.Where(x => x.NICKNAME == picture.UserNickName).ToList().Count == 1)
                {
                    var userPic = dbContext.PICTUREINFO.Where(x => x.NICKNAME == picture.UserNickName).ToList().First();
                    if (picture.TtAndEP == TimetableAndExpPic.实验表)
                    {
                        userPic.EXPERIMENT = picture.Picture;
                    }
                    if (picture.TtAndEP == TimetableAndExpPic.课程表)
                    {
                        userPic.COURSE = picture.Picture;
                    }

                    var num = dbContext.SaveChanges();
                    if (num == 1)
                        return true;
                }
                else
                {
                    PICTUREINFO pic = new PICTUREINFO()
                    {
                        NICKNAME = picture.UserNickName,
                        PICTUREID = Guid.NewGuid().ToString()
                    };
                    if (picture.TtAndEP == TimetableAndExpPic.实验表)
                    {
                        pic.EXPERIMENT = picture.Picture;
                    }
                    if (picture.TtAndEP == TimetableAndExpPic.课程表)
                    {
                        pic.COURSE = picture.Picture;
                    }
                    dbContext.PICTUREINFO.Add(pic);
                    var num = dbContext.SaveChanges();
                    if (num == 1)
                        return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public bool SendSignInfoToDB(PersonSignInfo personSign)
        {
            try
            {
                Entities1 dbContext = new Entities1();
                var count = dbContext.SIGNINFO.ToList().Count;
                SIGNINFO signInfo = new SIGNINFO()
                {
                    SIGNINFOID = Guid.NewGuid().ToString(),
                    NICKNAME = personSign.UserNickName,
                    SIGNTIME = personSign.SignTime,
                };
                if (personSign.IsSign == true)
                {
                    signInfo.ISSIGN = "YES";
                }
                if (personSign.IsSign == false)
                {
                    signInfo.ISSIGN = "No";
                }
                dbContext.SIGNINFO.Add(signInfo);
                var num = dbContext.SaveChanges();
                if (num == 1)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public bool SendStateInfoDB(string userNickName, PersonStateInfo state, string message)
        {
            try
            {
                Entities1 dbContext = new Entities1();
                var count = dbContext.LEAVEWORDINFO.ToList().Count;
                var leaveMsg = new LEAVEWORDINFO()
                {
                    WORDID = Guid.NewGuid().ToString(),
                    NICKNAME = userNickName,
                    MESSAGE = message,
                    LEAVETIME = DateTime.Now
                };
                if (state == PersonStateInfo.上课)
                {
                    leaveMsg.LEAVESTATE = "上课";
                }
                if (state == PersonStateInfo.请假)
                {
                    leaveMsg.LEAVESTATE = "请假";
                }
                dbContext.LEAVEWORDINFO.Add(leaveMsg);
                var num = dbContext.SaveChanges();
                if (num == 1)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}
