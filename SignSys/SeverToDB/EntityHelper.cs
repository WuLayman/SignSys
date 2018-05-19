using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeverToDB
{
    public static class EntityHelper
    {
        static Entities1 Entities = new Entities1();
        public static Entities1 GetEntities()
        {
            return Entities;
        }
    }
}
