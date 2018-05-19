using AllInterfaceProj.ServerInterface;
using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeverToDB
{
    public class RecvDataFromDBHelper : IReceiveInfoFromDB
    {
        Entities1 dbContext = EntityHelper.GetEntities();
          
        public bool JudgeIfManagerExist(Manager manager)
        {
            try
            {
                var data = dbContext.MANAGERS.Where(x => x.MANAGERNAME == manager.ManagerNickName.ToUpper() && x.PASSWORD == manager.Password.ToUpper()).ToList();
                if (data.Count != 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public List<PersonSignInfo> ReceiveAllSignInfo()
        {
            try
            {
                List<PersonSignInfo> signInfos = new List<PersonSignInfo>();
                var allDatas = dbContext.SIGNINFO.ToList();
                foreach (var SignInfo in allDatas)
                {
                    var signInfo = new PersonSignInfo()
                    {
                        UserNickName = SignInfo.NICKNAME
                    };
                    if (SignInfo.ISSIGN == "YES" || SignInfo.ISSIGN == "yes")
                    {
                        signInfo.IsSign = true;
                    }
                    else
                    {
                        signInfo.IsSign = false;
                    }
                    signInfo.SignTime = SignInfo.SIGNTIME;
                    signInfos.Add(signInfo);
                }
                return signInfos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public List<LeaveMessage> ReceiveLeaveMsg()
        {
            try
            {
                var dataLists = new List<LeaveMessage>();
                var data = dbContext.LEAVEWORDINFO.ToList();
                foreach (var item in data)
                {
                    LeaveMessage leaveMessage = new LeaveMessage()
                    {
                        LeaveState = item.LEAVESTATE,
                        LeaveTime = (DateTime)item.LEAVETIME,
                        Message = item.MESSAGE
                    };
                    leaveMessage.RealName = dbContext.USERINFO.Where(x => x.NICKNAME == item.NICKNAME).ToList().First().REALNAME;
                    dataLists.Add(leaveMessage);
                }
                return dataLists;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public List<string> ReceiveRealName(List<string> nickName)
        {
            try
            {
                var realNames = new List<string>();
                var users = dbContext.USERINFO.ToList();
                foreach (var item in nickName)
                {
                    realNames.Add(users.Where(x => x.NICKNAME == item).ToList().First().REALNAME);
                }
                return realNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public List<PersonSignInfo> ReceiveTodaySignInfo()
        {
            try
            {
                List<PersonSignInfo> signInfos = new List<PersonSignInfo>();
                var datas = dbContext.SIGNINFO.ToList();
                foreach (var item in datas)
                {
                    var time = (DateTime)item.SIGNTIME;
                    if (time.ToString("yyyyMMdd") == DateTime.Today.ToString("yyyyMMdd"))
                    {
                        var signInfo = new PersonSignInfo()
                        {
                            UserNickName = item.NICKNAME,
                            SignTime = item.SIGNTIME
                        };
                        if (item.ISSIGN == "YES" || item.ISSIGN == "yes")
                        {
                            signInfo.IsSign = true;
                        }
                        else
                        {
                            signInfo.IsSign = false;
                        }
                        signInfos.Add(signInfo);
                    }
                }
                return signInfos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public List<PictureInfo> ReveicePicture(string userRealName, string type)
        {
            try
            {
                List<PictureInfo> pictures = new List<PictureInfo>();
                var usersInfo = dbContext.USERINFO.Where(x => x.REALNAME == userRealName).ToList();
                if (usersInfo.Count == 0)
                {
                    return null;
                }
                foreach (var item in usersInfo)
                {
                    var data = dbContext.PICTUREINFO.Where(x => x.NICKNAME == item.NICKNAME).ToList().First();
                    PictureInfo picture = new PictureInfo();
                    picture.UserNickName = item.NICKNAME;
                    if (type == "course")
                    {
                        picture.TtAndEP = TimetableAndExpPic.课程表;
                        picture.Picture = data.COURSE;
                    }
                    if (type == "experiment")
                    {
                        picture.TtAndEP = TimetableAndExpPic.实验表;
                        picture.Picture = data.EXPERIMENT;
                    }
                    pictures.Add(picture);
                }
                return pictures;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public List<PersonInfo> ReveiveAllUserInfo()
        {
            try
            {
                List<PersonInfo> users = new List<PersonInfo>();
                var usersInfo = dbContext.USERINFO.ToList();
                foreach (var user in usersInfo)
                {
                    var person = new PersonInfo()
                    {
                        UserNickName = user.NICKNAME,
                        UserRealName = user.REALNAME,
                        PassWord = user.PASSWORD,
                        MacAddress = user.MACADDRESS
                    };
                    users.Add(person);
                }
                return users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}
