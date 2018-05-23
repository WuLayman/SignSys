using SeverToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFSocket.CommunicateManager;

namespace MainProj
{
    public static class PersonIPEndPointCollection
    {
        public static List<PersonIPEndPoint> GetUsersMsg(List<Person> people)
        {
            List<PersonIPEndPoint> personIPEndPoints = new List<PersonIPEndPoint>();
            var dbContext = EntityHelper.GetEntities();

            try
            {
                foreach (var item in people)
                {
                    PersonIPEndPoint personIPEndPoint = new PersonIPEndPoint();
                    var person = dbContext.USERINFO.Where(x => x.NICKNAME == item.PersonInfo.UserNickName).ToList().First();
                    personIPEndPoint.UserRealName = person.REALNAME;
                    personIPEndPoint.UserIP = item.IP;
                    personIPEndPoint.UserPoint = item.Port;
                    personIPEndPoints.Add(personIPEndPoint);
                }
                return personIPEndPoints;
            }
            catch
            {
                return null;
            }

        }
    }
}
