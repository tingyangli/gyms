using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class PersonModel
    {
        /// <summary>
        /// Id号，自增
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        public string Password2 { get; set; }
        /// <summary>
        /// 性别，0-男，1-女
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// 邮箱，用于验证密码，找回密码
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 头像，认为注册的时候没有头像
        /// </summary>
        public byte[] Avatar { get; set; }
        /// <summary>
        /// 身份，1-管理员，0-普通用户
        /// </summary>
        public int Identity { get; set; }
        /// <summary>
        /// 附加
        /// </summary>
        public string GenderName { get; set; }
        /// <summary>
        /// 附加
        /// </summary>
        public string IdentityName { get; set; }

    }

}
