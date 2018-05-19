using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure
{
    public class PusSubEvents
    {
        /// <summary>
        /// 退出登录事件
        /// </summary>
        public class LogoutEvent : PubSubEvent
        {

        }

        /// <summary>
        /// ModifyPassword已加载事件
        /// </summary>
        public class ModifyPasswordLoadedEvent:PubSubEvent
        {

        }

        /// <summary>
        /// 更改TitleRegion中TextBlock事件
        /// </summary>
        public class TitleChangedEvent : PubSubEvent<string>
        {

        }

        public class UserNameChangedEvent:PubSubEvent<string>
        {

        }
    }
}
