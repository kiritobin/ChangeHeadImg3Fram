using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.DAL;
using WebApplication5.Model;

namespace WebApplication5.BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL userInfoDal = new UserInfoDAL();

        #region 判断用户名是否存在
        public int UserName(UserInfo user)
        {
            int count = userInfoDal.UserName(user);
            return count;
        }
        #endregion

        #region 用户注册
        public bool Insert(UserInfo user)
        {
            int count = userInfoDal.UserName(user);
            if (count > 0)
            {
                return false;
            }
            else
            {
                user.url = @"\Imgs\system\system.jpg";
                userInfoDal.Insert(user);
                return true;
            }
        }
        #endregion

        #region 用户登录
        public UserInfo SelectUser(string userName, string password)
        {
            return userInfoDal.SelectUser(userName, password);
        }
        #endregion

        #region 更新图片
        public void updateImg(UserInfo user)
        {
            userInfoDal.updateImg(user);
        }
        #endregion

        #region 获取路径，删除图片
        public UserInfo delImg(string userName)
        {
            return userInfoDal.delImg(userName);
        }
        #endregion
    }
}