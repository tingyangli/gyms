using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMS
{
    public class Common
    {
        public static List<String> GenderList
        {
            get
            {
                string[] s = { "男", "女" };
                List<string> genderList = new List<string>();
                for (int i = 0; i < s.Length; i++)
                {
                    genderList.Add(s[i]);
                }
                return genderList;
            }
        }
        public static List<String> IdentityList
        {
            get
            {
                string[] s = { "普通用户", "管理员" };
                List<string> genderList = new List<string>();
                for (int i = 0; i < s.Length; i++)
                {
                    genderList.Add(s[i]);
                }
                return genderList;
            }
        }
    }
}
