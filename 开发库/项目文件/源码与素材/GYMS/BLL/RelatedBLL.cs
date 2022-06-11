using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BLL
{
    public class RelatedBLL
    {
        /// <summary>
        /// 查找列表所有信息
        /// </summary>
        /// <returns></returns>
        public bool SelectAll(out List<RelatedModel> relatedModelsUI)
        {
            relatedModelsUI = null;
            bool success = false;
            if (new RelatedDAL().SelectAll(out List<RelatedModel> relatedModels) == true)
            {
                relatedModelsUI = relatedModels;
                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }
        /// <summary>
        /// 插入信息
        /// </summary>
        /// <param name="relatedModel"></param>
        /// <param name="messageStr"></param>
        /// <returns></returns>
        public bool Insert(RelatedModel relatedModel,out string messageStr)
        {
            bool success = false;
            messageStr = "";
            if (relatedModel.person_name == "")
            {
                messageStr = "用户名不能为空";
            }
            else if (relatedModel.info_name == "")
            {
                messageStr = "话题不能为空";
            }
            else if(relatedModel.message=="")
            {
                messageStr = "内容不能为空";
            }
            else
            {
                int count = new RelatedDAL().Insert(relatedModel);
                if (count > 0)
                {
                    messageStr = "发布成功";
                }
                else
                {
                    messageStr = "发布失败";
                }
            }
            return success;
        }
    }
}
