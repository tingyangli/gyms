using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
using System.Text.RegularExpressions;

namespace BLL
{
    public class PersonBLL
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="personModel"></param>
        /// <param name="messageStr"></param>
        /// <returns></returns>
        public bool Insert(PersonModel personModel,out string messageStr)
        {
            bool success = false;
            messageStr = "";
            if (personModel.Name=="")
            {
                messageStr = "用户名不能为空！";
            }
            else if (personModel.Password.Length < 6)
            {
                messageStr = "密码长度应大于6！";
            }
            else if (personModel.Password.Length > 15)
            {
                messageStr = "密码长度应不大于15!";
            }
            else if (personModel.Password2 != personModel.Password)
            {
                messageStr = "密码两次输入不一致！";
            }
            else if (personModel.Email == "")
            {
                messageStr = "邮箱不能为空！";
            }
            else if (IsEmail(personModel.Email)==false)
            {
                messageStr = "邮箱格式不正确！";
            }
            else
            {
                //信息正确，转入DAL层
                if (new PersonDAL().IsExist(personModel) == false)
                {
                    if(new PersonDAL().IsExistEmail(personModel) == false)
                    {
                        int count = new PersonDAL().Insert(personModel);
                        if (count > 0)
                        {
                            messageStr = "注册成功！";
                            success = true;
                        }
                        else
                        {
                            messageStr = "注册失败！";
                        }
                    }
                    else
                    {
                        messageStr = "邮箱已被注册！";
                    }
                }
                else
                {
                    messageStr = "用户已存在！";
                }
            }
            return success;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="personModel"></param>
        /// <param name="messageStr"></param>
        /// <returns></returns>
        public bool Select(PersonModel personModel, out string messageStr,out PersonModel personModelUI)
        {
            messageStr = "";
            personModelUI = new PersonModel();
            bool success = false;
            if (new PersonDAL().IsExist(personModel) == true)
            {
                //以用户名和密码进行查询
                if (new PersonDAL().Select(personModel,out PersonModel personModelBLL)==true)
                {
                    messageStr = "登录成功！";
                    success = true;
                    personModelUI = personModelBLL;
                }
                else
                {
                    messageStr = "密码错误！";

                }
            }
            else
            {
                messageStr = "用户不存在！";
            }
            return success;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="personModel"></param>
        /// <param name="messageStr"></param>
        /// <returns></returns>
        public bool UpdatePwd(PersonModel personModel, out string messageStr)
        {
            messageStr = "";
            bool success = false;
            if (new PersonDAL().IsExistEmail(personModel) == false)
            {
                messageStr = "邮箱不存在，请先注册!";
            }
            if (personModel.Password2 != personModel.Password)
            {
                messageStr = "两次密码输入不一致！";
            }
            else if(personModel.Password.Length < 6)
            {
                messageStr = "密码长度应大于6！";
            }
            else if (personModel.Password.Length > 15)
            {
                messageStr = "密码长度应不超过15";
            }
            else
            {
                //密码格式正确，转入DAL层进行修改
                int count = new PersonDAL().UpdatePwd(personModel);
                if (count>0)
                {
                    messageStr = "密码修改成功！";
                    success = true;
                }
                else
                {
                    messageStr = "密码修改失败！";
                }
            }
            return success;
        }
        /// <summary>
        /// 判断邮箱格式是否正确
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public bool IsEmail(string inputData)
        {
            Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="personModel"></param>
        /// <param name="messageStr"></param>
        /// <returns></returns>
        public bool Revise(PersonModel personModel, out string messageStr)
        {
            bool success = false;
            messageStr = "";
            if (personModel.Name == "")
            {
                messageStr = "用户名不能为空！";
            }
            else if (personModel.Email == "")
            {
                messageStr = "邮箱不能为空！";
            }
            else if (IsEmail(personModel.Email) == false)
            {
                messageStr = "邮箱格式不正确！";
            }
            else
            {
                //信息正确，转入DAL层
                if (new PersonDAL().IsExist(personModel) == false)
                {
                    if (new PersonDAL().IsExistEmail(personModel) == false)
                    {
                        //根据ID号进行修改
                        int count = new PersonDAL().Revise(personModel);
                        if (count > 0)
                        {
                            messageStr = "保存成功！";
                            success = true;
                        }
                        else
                        {
                            messageStr = "保存失败！";
                        }
                    }
                    else
                    {
                        messageStr = "邮箱已被注册！";
                    }
                }
                else
                {
                    messageStr = "用户已存在！";
                }
            }
            return success;
        }
        /// <summary>
        /// 管理员修改信息
        /// </summary>
        /// <param name="personModel"></param>
        /// <param name="messageStr"></param>
        /// <returns></returns>
        public bool ReviseByM(PersonModel personModel, out string messageStr)
        {
            bool success = false;
            messageStr = "";
            if (personModel.Name == "")
            {
                messageStr = "用户名不能为空！";
            }
            else if (personModel.Email == "")
            {
                messageStr = "邮箱不能为空！";
            }
            else if (IsEmail(personModel.Email) == false)
            {
                messageStr = "邮箱格式不正确！";
            }
            else if (personModel.Password.Length < 6)
            {
                messageStr = "密码长度应大于6！";
            }
            else if (personModel.Password.Length > 15)
            {
                messageStr = "密码长度应不超过15";
            }
            else
            {
                //信息正确，转入DAL层
                if (new PersonDAL().IsExist(personModel) == false)
                {
                    if (new PersonDAL().IsExistEmail(personModel) == false)
                    {
                        //根据ID号进行修改
                        int count = new PersonDAL().ReviseByM(personModel);
                        if (count > 0)
                        {
                            messageStr = "保存成功！";
                            success = true;
                        }
                        else
                        {
                            messageStr = "保存失败！";
                        }
                    }
                    else
                    {
                        messageStr = "邮箱已被注册！";
                    }
                }
                else
                {
                    messageStr = "用户已存在！";
                }
            }
            return success;
        }

        /// <summary>
        /// 查找列表所有信息
        /// </summary>
        /// <returns></returns>
        public bool SelectAll(out List<PersonModel> personModelsUI)
        {
            personModelsUI = null;
            bool success = false;
            if (new PersonDAL().SelectAll(out List<PersonModel> personModels) == true)
            {
                personModelsUI = personModels;
                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="personModel"></param>
        /// <param name="messageStr"></param>
        /// <returns></returns>
        public bool Delete(PersonModel personModel, out string messageStr)
        {
            bool success = false;
            messageStr = "";
            if (personModel.Id != 0)
            {
                if(new PersonDAL().Delete(personModel)!=0)
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
                messageStr = "未选中用户信息！";
            }
            return success;
        }
        public bool isExistEmail(PersonModel personModel)
        {
            return new PersonDAL().IsExistEmail(personModel);
        }
    }
    
}
