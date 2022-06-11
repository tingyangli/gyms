using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public class RelatedDAL
    {
        string conString = "DSN=GYMS;UID=root;PWD=ting6312828"; //ODBC的数据源名
        OdbcConnection con = null;
        /// <summary>
        /// 查找全部信息
        /// </summary>
        /// <param name="personModels"></param>
        /// <returns></returns>
        public bool SelectAll(out List<RelatedModel>relatedModels)
        {
            relatedModels = new List<RelatedModel>();
            bool success;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "SELECT * FROM gyms.related"; //SQL命令
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
                RelatedModel relatedModel = new RelatedModel();
                relatedModel.id = (int)reader[0];
                relatedModel.person_id= (int)reader[1];
                relatedModel.info_name= (string)reader[2];
                relatedModel.message = (string)reader[3];
                relatedModel.person_name = SelectName(relatedModel.person_id);
                relatedModels.Add(relatedModel);
            }
            con.Close();
            return success;
        }
        /// <summary>
        /// 查找人员对应的Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelectName(int id)
        {
            string name = "";
            bool success;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "SELECT person.Name FROM gyms.related,gyms.person where person.Id=?"; //SQL命令
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Id = new OdbcParameter("?", id);
            com.Parameters.Add(Id);
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
                name = (string)reader[0];
            }
            con.Close();
            return name;
        }
        /// <summary>
        /// 插入信息
        /// </summary>
        /// <param name="relatedModel"></param>
        /// <returns></returns>
        public int Insert(RelatedModel relatedModel)
        {
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "INSERT INTO related(person_id,info_name,message) VALUES (?,?,?)";
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter person_id = new OdbcParameter("?", relatedModel.person_id);
            OdbcParameter info_name = new OdbcParameter("?", relatedModel.info_name);
            OdbcParameter message = new OdbcParameter("?", relatedModel.message);
            com.Parameters.Add(person_id);
            com.Parameters.Add(info_name);
            com.Parameters.Add(message);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
