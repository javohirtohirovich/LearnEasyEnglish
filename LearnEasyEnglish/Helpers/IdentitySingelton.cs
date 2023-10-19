using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Helpers
{
    public class IdentitySingelton
    {
        public int UserId { get; set; }
        public long updateId { get; set; }

        private static IdentitySingelton _instance;
        private static IdentitySingelton _updateid;
        private IdentitySingelton()
        {

        }
        public static void SaveId(int id)
        {
            if (_instance == null)
            {
                _instance = new IdentitySingelton();
                _instance.UserId = id;
            }
        }
        public static IdentitySingelton currentId()
        {
            return _instance;
        }
        public static void SaveUpdateId(long id)
        {
            _updateid = new IdentitySingelton();
            _updateid.updateId = id;
        }
        public static IdentitySingelton UpdateId()
        {
            return _updateid;
        }
    }
}
