using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BLL
{
    public class IndustryBLL
    {
        /// <summary>
        /// 主页面所显示的个例
        /// </summary>
        /// <param name="industryModelsUI"></param>
        /// <returns></returns>
        public bool Select(out List<IndustryModel> industryModelsUI)
        {
            industryModelsUI = null;
            bool success=false;
            if(new IndustryDAL().Select(out List<IndustryModel> industryModels) == true)
            {
                industryModelsUI = industryModels;
                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }
        /// <summary>
        /// 输出所有的行业信息
        /// </summary>
        /// <param name="industryModelsUI"></param>
        /// <returns></returns>
        public bool SelectAll(out List<IndustryModel> industryModelsUI)
        {
            industryModelsUI = null;
            bool success = false;
            if (new IndustryDAL().SelectAll(out List<IndustryModel> industryModels) == true)
            {
                industryModelsUI = industryModels;
                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }
        /// <summary>
        /// 输出所有工业遗产名称
        /// </summary>
        /// <param name="industryModelsUI"></param>
        /// <returns></returns>
        public bool SelectAllName(out List<string> industryModelsUIName)
        {
            industryModelsUIName = null;
            bool success = false;
            if (new IndustryDAL().SelectAllName(out List<string> industryModelsName) == true)
            {
                industryModelsUIName = industryModelsName;
                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }
        /// <summary>
        /// 根据名称获取指定的工业遗产的具体信息
        /// </summary>
        /// <param name="industryModelUI"></param>
        /// <returns></returns>
        public bool SelectDetail(string name,out IndustryModel industryModelUI)
        {
            industryModelUI = null;
            bool success = false;
            if (new IndustryDAL().SelectDetail(name,out IndustryModel industryModelBLL) == true)
            {
                industryModelUI = industryModelBLL;
                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }

        /// <summary>
        /// 插入工业遗产信息
        /// </summary>
        /// <param name="industryModel"></param>
        /// <param name="messageStr"></param>
        /// <returns></returns>
        public bool Insert(IndustryModel industryModel,out string messageStr)
        {
            bool success = false;
            messageStr = "";
            if (industryModel.Name != "")
            {
                if(new IndustryDAL().IsExist(industryModel) == false)
                {
                    int count = new IndustryDAL().Insert(industryModel);
                    if (count > 0)
                    {
                        messageStr = "添加成功";
                    }
                    else
                    {
                        messageStr = "添加失败";
                    }
                }
                else
                {
                    messageStr = "该工业遗产已被添加";
                }
            }
            else
            {
                messageStr = "请输入工业遗产名称";
            }
            return success;
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="industryModel"></param>
        /// <param name="messageStr"></param>
        /// <returns></returns>
        public bool Revise(IndustryModel industryModel, out string messageStr)
        {
            bool success = false;
            messageStr = "";
            if (industryModel.Name != null)
            {
                int count = new IndustryDAL().Revise(industryModel);
                if (count > 0)
                {
                    messageStr = "修改成功";
                }
                else
                {
                    messageStr = "修改失败";
                }
            }
            return success;
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="industryModel"></param>
        /// <param name="messageStr"></param>
        /// <returns></returns>
        public bool Delete(IndustryModel industryModel, out string messageStr)
        {
            bool success = false;
            messageStr = "";
            if (industryModel.Name != null)
            {
                if (new IndustryDAL().Delete(industryModel) != 0)
                {
                    messageStr = "删除成功";
                }
                else
                {
                    messageStr = "删除失败";
                }
            }
            else
            {
                messageStr = "未选中信息！";
            }
            return success;
        }
    }
}
