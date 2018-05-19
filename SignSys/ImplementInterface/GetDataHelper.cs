using AllInterfaceProj.ServerInterface;
using PublicBaseClassProj;
using SeverToDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImplementInterface
{
    public class GetDataHelper : IGetData
    {
        //已通过测试
        /// <summary>
        /// 用于客户端获取所有签到信息
        /// </summary>
        /// <param name="personInfo"></param>
        /// <returns></returns>
        public ObservableCollection<PersonSignInfo> ReceiveAllSignInfoFromServer(PersonInfo personInfo)
        {
            try
            {
                var personSignInfo = new ObservableCollection<PersonSignInfo>();
                Entities1 dbContext = new Entities1();
                var allSignInfo = dbContext.SIGNINFO.Where(x => x.NICKNAME == personInfo.UserNickName).ToList();
                foreach (var item in allSignInfo)
                {
                    var person = new PersonSignInfo()
                    {
                        UserNickName = item.NICKNAME,
                        IsSign = true,
                        SignTime = item.SIGNTIME
                    };
                    personSignInfo.Add(person);
                }
                return personSignInfo;
            }
            catch
            {

            }
            return null;
        }

        //已通过测试
        /// <summary>
        /// 用于客户端获取已存于数据库的MAC地址
        /// 用于登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string ReceiveMacAddress(string userName)
        {
            try
            {
                Entities1 dbContext = new Entities1();
                var macAddress = dbContext.USERINFO.Where(x => x.NICKNAME == userName).ToList().First().MACADDRESS;
                return macAddress;
            }
            catch
            {

            }
            return null;
        }

        //已通过测试
        /// <summary>
        /// 用于客户端获取课程表或实验表图片
        /// </summary>
        /// <param name="userNickName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public PictureInfo ReceivePictureFromServer(string userNickName, TimetableAndExpPic type)
        {
            try
            {
                var pictureInfo = new PictureInfo();
                Entities1 dbContext = new Entities1();
                var picture = dbContext.PICTUREINFO.Where(x => x.NICKNAME == userNickName).ToList().First();
                if (type == TimetableAndExpPic.实验表)
                {
                    pictureInfo.TtAndEP = TimetableAndExpPic.实验表;
                    pictureInfo.UserNickName = picture.NICKNAME;
                    pictureInfo.Picture = picture.EXPERIMENT;
                }
                else
                {
                    pictureInfo.TtAndEP = TimetableAndExpPic.课程表;
                    pictureInfo.UserNickName = picture.NICKNAME;
                    pictureInfo.Picture = picture.COURSE;
                }
                return pictureInfo;
            }
            catch
            {

            }
            return null;
        }


        //已通过测试
        /// <summary>
        /// 用于客户端查询今日是否已签到
        /// </summary>
        /// <param name="personInfo"></param>
        /// <returns></returns>
        public bool ReceiveSignInfoFromServer(PersonInfo personInfo)
        {
            try
            {
                Entities1 dbContext = new Entities1();
                var signInfo = dbContext.SIGNINFO.Where(x => x.NICKNAME == personInfo.UserNickName).ToList();
                if (signInfo == null || signInfo.Count == 0)
                {
                    return false;
                }
                var data = signInfo.OrderByDescending(x => x.SIGNTIME).First();
                var date = (DateTime)data.SIGNTIME;
                var newDate = date.ToString("yyyyMMdd");
                if (newDate != DateTime.Today.ToString("yyyyMMdd"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //已通过测试
        /// <summary>
        /// 用于用户登录
        /// </summary>
        /// <param name="personInfo"></param>
        /// <returns></returns>
        public bool SendPerosnInfoToServer(PersonInfo personInfo)
        {
            try
            {
                Entities1 dbContext = new Entities1();
                var userInfo = dbContext.USERINFO.ToList().Where(x => x.NICKNAME == personInfo.UserNickName && x.PASSWORD == personInfo.PassWord).ToList();
                if (userInfo.Count == 0)
                {
                    return false;
                }
                if (userInfo.Count == 1)
                {
                    if (userInfo.First().MACADDRESS == null || userInfo.First().MACADDRESS == "")
                    {
                        return true;
                    }
                    else if (userInfo.First().MACADDRESS == personInfo.MacAddress)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
