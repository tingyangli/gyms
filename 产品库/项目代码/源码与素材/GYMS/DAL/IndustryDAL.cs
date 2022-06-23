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
    public class IndustryDAL
    {
        string conString = "DSN=GYMS;UID=root;PWD=123456"; //ODBC的数据源名
        OdbcConnection con = null;
        /// <summary>
        /// 返回主页面的几张推荐图
        /// </summary>
        /// <param name="industryModels"></param>
        /// <returns></returns>
        public bool Select(out List<IndustryModel> industryModels)
        {
            industryModels = new List<IndustryModel>();
            bool success;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "SELECT Name,Picture FROM gyms.info limit 1,3"; //SQL命令
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
                string Name = (string)reader[0];
                byte[] Picture = (byte[])reader[1];
                IndustryModel industryModel = new IndustryModel();
                industryModel.Name = Name;
                industryModel.Picture = Picture;
                industryModels.Add(industryModel);
            }
            con.Close();
            return success;
        }
        /// <summary>
        /// 返回所有的工业遗产数据
        /// </summary>
        /// <param name="industryModels"></param>
        /// <returns></returns>
        public bool SelectAll(out List<IndustryModel> industryModels)
        {
            industryModels = new List<IndustryModel>();
            bool success;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "SELECT * FROM gyms.info"; //SQL命令
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
                string Name = (string)reader[0];
                string Address = (string)reader[1];
                string Department = (string)reader[2];
                string Distribution_characteristics = (string)reader[3];
                string Position_characteristics = (string)reader[4];
                string Terrain_features = (string)reader[5];
                string Geospatial_relationships = (string)reader[6];
                string Age = (string)reader[7];
                string Era = (string)reader[8];
                string Footprint = (string)reader[9];
                string Status_quo = (string)reader[10];
                string Protective_measures = (string)reader[11];
                string Current_use = (string)reader[12];
                byte[] Picture=null;
                if (reader[13] != System.DBNull.Value)
                {
                    Picture = (byte[])reader[13];
                }
                IndustryModel industryModel = new IndustryModel();
                industryModel.Name = Name;
                industryModel.Address = Address;
                industryModel.Department = Department;
                industryModel.Distribution_characteristics = Distribution_characteristics;
                industryModel.Position_characteristics = Position_characteristics;
                industryModel.Terrain_features = Terrain_features;
                industryModel.Geospatial_relationships = Geospatial_relationships;
                industryModel.Age = Age;
                industryModel.Era = Era;
                industryModel.Footprint = Footprint;
                industryModel.Status_quo = Status_quo;
                industryModel.Protective_measures = Protective_measures;
                industryModel.Current_use = Current_use;
                industryModel.Picture = Picture;
                industryModels.Add(industryModel);
            }
            con.Close();
            return success;
        }
        /// <summary>
        /// 查找所有工业遗产名称
        /// </summary>
        /// <param name="industryModelsName"></param>
        /// <returns></returns>
        public bool SelectAllName(out List<string> industryModelsName)
        {
            industryModelsName = new List<string>();
            bool success;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "SELECT Name FROM gyms.info"; //SQL命令
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
                string Name = (string)reader[0];
                industryModelsName.Add(Name);
            }
            con.Close();
            return success;
        }
        /// <summary>
        /// 查看某个具体的工业遗产
        /// </summary>
        /// <param name="name"></param>
        /// <param name="industryModelBLL"></param>
        /// <returns></returns>
        public bool SelectDetail(string name,out IndustryModel industryModelBLL)
        {
            industryModelBLL = null;
            bool success;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "SELECT * FROM gyms.info where Name=?"; //SQL命令
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter NAME = new OdbcParameter("?", name);
            com.Parameters.Add(NAME);
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
                string Name = (string)reader[0];
                string Address = (string)reader[1];
                string Department = (string)reader[2];
                string Distribution_characteristics = (string)reader[3];
                string Position_characteristics = (string)reader[4];
                string Terrain_features = (string)reader[5];
                string Geospatial_relationships = (string)reader[6];
                string Age = (string)reader[7];
                string Era = (string)reader[8];
                string Footprint = (string)reader[9];
                string Status_quo = (string)reader[10];
                string Protective_measures = (string)reader[11];
                string Current_use = (string)reader[12];
                byte[] Picture = (byte[])reader[13];
                IndustryModel industryModel = new IndustryModel();
                industryModel.Name = Name;
                industryModel.Address = Address;
                industryModel.Department = Department;
                industryModel.Distribution_characteristics = Distribution_characteristics;
                industryModel.Position_characteristics = Position_characteristics;
                industryModel.Terrain_features = Terrain_features;
                industryModel.Geospatial_relationships = Geospatial_relationships;
                industryModel.Age = Age;
                industryModel.Era = Era;
                industryModel.Footprint = Footprint;
                industryModel.Status_quo = Status_quo;
                industryModel.Protective_measures = Protective_measures;
                industryModel.Current_use = Current_use;
                industryModel.Picture = Picture;
                industryModelBLL = industryModel;
            }
            con.Close();
            return success;
        }
        /// <summary>
        /// 查看工业遗产名是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsExist(IndustryModel model)
        {
            bool i;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "Select Name From info Where Name =?"; //SQL命令
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Name = new OdbcParameter("?", model.Name);
            com.Parameters.Add(Name);
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
        /// 添加工业遗产信息
        /// </summary>
        /// <param name="personmodel"></param>
        /// <returns></returns>
        public int Insert(IndustryModel model)
        {
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "INSERT INTO info(Name," +
                "Address," +
                "Department," +
                "Distribution_characteristics," +
                "Position_characteristics," +
                "Terrain_features," +
                "Geospatial_relationships," +
                "Age," +
                "Era," +
                "Footprint," +
                "Status_quo," +
                "Protective_measures," +
                "Current_use,Picture) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Name = new OdbcParameter("?", model.Name);
            OdbcParameter Address = new OdbcParameter("?", model.Address);
            OdbcParameter Department = new OdbcParameter("?", model.Department);
            OdbcParameter Distribution_characteristics = new OdbcParameter("?", model.Distribution_characteristics);
            OdbcParameter Position_characteristics = new OdbcParameter("?", model.Position_characteristics);
            OdbcParameter Terrain_features = new OdbcParameter("?", model.Terrain_features);
            OdbcParameter Geospatial_relationships = new OdbcParameter("?", model.Geospatial_relationships);
            OdbcParameter Age = new OdbcParameter("?", model.Age);
            OdbcParameter Era = new OdbcParameter("?", model.Era);
            OdbcParameter Footprint = new OdbcParameter("?", model.Footprint);
            OdbcParameter Status_quo = new OdbcParameter("?", model.Status_quo);
            OdbcParameter Protective_measures = new OdbcParameter("?", model.Protective_measures);
            OdbcParameter Current_use = new OdbcParameter("?", model.Current_use);
            /*            OdbcParameter Picture = new OdbcParameter("?", model.Picture);*/
            OdbcParameter Picture = new OdbcParameter("@Picture",
                (model.Picture == null) ? DBNull.Value : (object)model.Picture);
            com.Parameters.Add(Name);
            com.Parameters.Add(Address);
            com.Parameters.Add(Department);
            com.Parameters.Add(Distribution_characteristics);
            com.Parameters.Add(Position_characteristics);
            com.Parameters.Add(Terrain_features);
            com.Parameters.Add(Geospatial_relationships);
            com.Parameters.Add(Age);
            com.Parameters.Add(Era);
            com.Parameters.Add(Footprint);
            com.Parameters.Add(Status_quo);
            com.Parameters.Add(Protective_measures);
            com.Parameters.Add(Current_use);
            com.Parameters.Add(Picture);
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Revise(IndustryModel model)
        {
            int i=0;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "Update info set " +
                "Address=?," +
                "Department=?," +
                "Distribution_characteristics=?," +
                "Position_characteristics=?," +
                "Terrain_features=?," +
                "Geospatial_relationships=?," +
                "Age=?," +
                "Era=?," +
                "Footprint=?," +
                "Status_quo=?," +
                "Protective_measures=?," +
                "Current_use=?," +
                "Picture=? where Name=?";
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Address = new OdbcParameter("?", model.Address);
            OdbcParameter Department = new OdbcParameter("?", model.Department);
            OdbcParameter Distribution_characteristics = new OdbcParameter("?", model.Distribution_characteristics);
            OdbcParameter Position_characteristics = new OdbcParameter("?", model.Position_characteristics);
            OdbcParameter Terrain_features = new OdbcParameter("?", model.Terrain_features);
            OdbcParameter Geospatial_relationships = new OdbcParameter("?", model.Geospatial_relationships);
            OdbcParameter Age = new OdbcParameter("?", model.Age);
            OdbcParameter Era = new OdbcParameter("?", model.Era);
            OdbcParameter Footprint = new OdbcParameter("?", model.Footprint);
            OdbcParameter Status_quo = new OdbcParameter("?", model.Status_quo);
            OdbcParameter Protective_measures = new OdbcParameter("?", model.Protective_measures);
            OdbcParameter Current_use = new OdbcParameter("?", model.Current_use);
            /*            OdbcParameter Picture = new OdbcParameter("?", model.Picture);*/
            OdbcParameter Picture = new OdbcParameter("@Picture",
                (model.Picture == null) ? DBNull.Value : (object)model.Picture);
            OdbcParameter Name = new OdbcParameter("?", model.Name);
            com.Parameters.Add(Address);
            com.Parameters.Add(Department);
            com.Parameters.Add(Distribution_characteristics);
            com.Parameters.Add(Position_characteristics);
            com.Parameters.Add(Terrain_features);
            com.Parameters.Add(Geospatial_relationships);
            com.Parameters.Add(Age);
            com.Parameters.Add(Era);
            com.Parameters.Add(Footprint);
            com.Parameters.Add(Status_quo);
            com.Parameters.Add(Protective_measures);
            com.Parameters.Add(Current_use);
            com.Parameters.Add(Picture);
            com.Parameters.Add(Name);
            i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Delete(IndustryModel model)
        {
            int i;
            con = new OdbcConnection(conString);
            con.Open();
            string commandText = "Delete from info where Name=?";
            OdbcCommand com = new OdbcCommand(commandText, con);
            OdbcParameter Name = new OdbcParameter("?", model.Name);
            com.Parameters.Add(Name);
            i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
