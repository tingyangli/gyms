using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Security.Cryptography; //数据加密的命名空间
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PersonDAL
    {
        string conString = "DSN=GYMS;UID=root;PWD=ting6312828"; //ODBC的数据源名
        OdbcConnection con = null;
        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetMD5(string password)
        {
            byte[] result = Encoding.Default.GetBytes(password);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            password = BitConverter.ToString(output).Replace("-", "");  //tbMd5pass为输出加密文本的文本框
            return password;
        }
        /// <summary>
        /// 确定账号是否存在
        /// </summary>
        /// <param name="personmodel"></param>
        /// <returns></returns>
        public bool IsExist(PersonModel personmodel)
        {
            bool i;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "Select Name From person Where Name =? and Id !=?"; //SQL命令
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Name = new OdbcParameter("?", personmodel.Name);
            OdbcParameter Id = new OdbcParameter("?", personmodel.Id);
            com.Parameters.Add(Name);
            com.Parameters.Add(Id);
            if (com.ExecuteScalar() == null)
            {
                i = false;
            }
            else
            {
                i = true;
            }
            con.Close();
            return i;
        }
        /// <summary>
        /// 验证邮箱是否存在
        /// </summary>
        /// <param name="personmodel"></param>
        /// <returns></returns>
        public bool IsExistEmail(PersonModel personmodel)
        {
            bool i;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "Select Email From person Where Email =? and Id !=?"; //SQL命令
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Email = new OdbcParameter("?", personmodel.Email);
            OdbcParameter Id = new OdbcParameter("?", personmodel.Id);
            com.Parameters.Add(Email);
            com.Parameters.Add(Id);
            if (com.ExecuteScalar() == null)
            {
                i = false;
            }
            else
            {
                i = true;
            }
            con.Close();
            return i;
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="personModel"></param>
        /// <returns></returns>
        [Obsolete]
        public int Insert(PersonModel personmodel)
        {
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "INSERT INTO person(Name,Password,Gender,Email,Identity) VALUES (?,?,?,?,?)";
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Name = new OdbcParameter("?", personmodel.Name);
            OdbcParameter Password = new OdbcParameter("?", personmodel.Password);
            string gender;
            if (personmodel.Gender == 0)
            {
                gender = "男";
            }
            else
            {
                gender = "女";
            }
            OdbcParameter Gender = new OdbcParameter("?",gender);
            OdbcParameter Email = new OdbcParameter("?", personmodel.Email);
            OdbcParameter Identity = new OdbcParameter("?", personmodel.Identity);
            com.Parameters.Add(Name);
            com.Parameters.Add(Password);
            com.Parameters.Add(Gender);
            com.Parameters.Add(Email);
            com.Parameters.Add(Identity);
            int i= com.ExecuteNonQuery();
            con.Close();
            return i;
        }
        /// <summary>
        /// 查询用户名和密码是否存在
        /// </summary>
        /// <param name="personmodel"></param>
        /// <returns></returns>
        public bool Select(PersonModel personmodel,out PersonModel personModelBLL)
        {
            bool Exist = false;
            personModelBLL = new PersonModel();
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "Select * From person Where Name =? and Password=?"; //SQL命令
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Name = new OdbcParameter("?", personmodel.Name);
            OdbcParameter Password = new OdbcParameter("?", personmodel.Password);  
            com.Parameters.Add(Name);
            com.Parameters.Add(Password);
            if (com.ExecuteScalar() == null)
            {
                Exist = false;
            }
            else
            {
                Exist = true;
            }
            OdbcDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                personModelBLL.Id=(int)reader[0];
                personModelBLL.Name = (string)reader[1];
                personModelBLL.Password = (string)reader[2];
                if ((string)reader[3] == "男")
                {
                    personModelBLL.Gender = 0;
                }
                else
                {
                    personModelBLL.Gender = 1;
                }
                personModelBLL.Email = (string)reader[4];
                if (reader[5] != System.DBNull.Value)
                {
                    personModelBLL.Avatar = (byte[])reader[5];
                }
                personModelBLL.Identity = (int)reader[6];

            }
            con.Close();
            return Exist;
        }
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="personmodel"></param>
        /// <returns></returns>
        public int UpdatePwd(PersonModel personmodel)
        {
            int i=0;
            PersonModel person = personmodel;
            bool same=SelectUpdate(person);
            if (same)
            {
                i = i + 1;
            }
            con = new OdbcConnection(conString);
            con.Open();
            string commandText1 = "Update person set Password=? where Email=?";
            OdbcCommand com = new OdbcCommand(commandText1, con);
            OdbcParameter Password = new OdbcParameter("?", personmodel.Password);
            OdbcParameter Email = new OdbcParameter("?", personmodel.Email);
            com.Parameters.Add(Password);
            com.Parameters.Add(Email);
            i = i+(com.ExecuteNonQuery());
            con.Close();
            return i;
        }
        /// <summary>
        /// 更新时数据若与之前相同需要进行处理
        /// </summary>
        /// <param name="personmodel"></param>
        /// <returns></returns>
        public bool SelectUpdate(PersonModel personmodel)
        {
            bool same = false;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "Select Password From person Where Email =?"; //SQL命令
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Email = new OdbcParameter("?", personmodel.Email);
            com.Parameters.Add(Email);
            OdbcDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                if ((string)reader[0] == personmodel.Password)
                {
                    same = true;
                }
            }
            con.Close();
            return same;
        }
        /// <summary>
        /// 用户信息更改，认为没有更改就不会保存！
        /// </summary>
        /// <param name="personmodel"></param>
        /// <returns></returns>
        public int Revise(PersonModel personmodel)
        {
            int i;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "Update person set Name=?,Gender=?,Email=?,Avatar=?,Identity=? where Id=?";
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Name = new OdbcParameter("?", personmodel.Name);
            string gender;
            if (personmodel.Gender == 0)
            {
                gender = "男";
            }
            else
            {
                gender = "女";
            }
            OdbcParameter Gender = new OdbcParameter("?", gender);
            OdbcParameter Email = new OdbcParameter("?", personmodel.Email);
            OdbcParameter Avatar = new OdbcParameter("?", personmodel.Avatar);
            OdbcParameter Identity = new OdbcParameter("?", personmodel.Identity);
            OdbcParameter Id = new OdbcParameter("?", personmodel.Id);
            com.Parameters.Add(Name);
            com.Parameters.Add(Gender);
            com.Parameters.Add(Email);
            com.Parameters.Add(Avatar);
            com.Parameters.Add(Identity);
            com.Parameters.Add(Id);
            i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }


        /// <summary>
        /// 管理员修改信息
        /// </summary>
        /// <param name="personmodel"></param>
        /// <returns></returns>
        public int ReviseByM(PersonModel personmodel)
        {
            int i;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "Update person set Name=?,Gender=?,Email=?,Identity=? where Id=?";
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Name = new OdbcParameter("?", personmodel.Name);
            string gender;
            if (personmodel.Gender == 0)
            {
                gender = "男";
            }
            else
            {
                gender = "女";
            }
            OdbcParameter Gender = new OdbcParameter("?", gender);
            OdbcParameter Email = new OdbcParameter("?", personmodel.Email);
            OdbcParameter Identity = new OdbcParameter("?", personmodel.Identity);
            OdbcParameter Id = new OdbcParameter("?", personmodel.Id);
            com.Parameters.Add(Name);
            com.Parameters.Add(Gender);
            com.Parameters.Add(Email);
            com.Parameters.Add(Identity);
            com.Parameters.Add(Id);
            i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
        /// <summary>
        /// 查找所有人员全部信息
        /// </summary>
        /// <param name="personModels"></param>
        /// <returns></returns>
        public bool SelectAll(out List<PersonModel> personModels)
        {
            personModels = new List<PersonModel>();
            bool success;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "SELECT * FROM gyms.person"; //SQL命令
            OdbcCommand com = new OdbcCommand(commandText, con);
            if (com.ExecuteScalar() == null)
            {
                success = false;
            }
            else
            {
                success = true;
            }
            OdbcDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                PersonModel personModel = new PersonModel();
                personModel.Id = (int)reader[0];
                personModel.Name = (string)reader[1];
                if ((string)reader[3] == "男")
                {
                    personModel.Gender = 0;
                }
                else
                {
                    personModel.Gender = 1;
                }
                personModel.Email = (string)reader[4];
                personModel.Identity = (int)reader[6];
                personModels.Add(personModel);
            }
            con.Close();
            return success;
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="personmodel"></param>
        /// <returns></returns>
        public int Delete(PersonModel personmodel)
        {
            int i;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "Delete from person where Id=?";
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Id = new OdbcParameter("?", personmodel.Id);
            com.Parameters.Add(Id);
            i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
