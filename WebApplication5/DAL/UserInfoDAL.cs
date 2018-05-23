using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication5.Model;

namespace WebApplication5.DAL
{
    public class UserInfoDAL
    {
        SQLHelper sqlHelp = new SQLHelper();

        #region 判断用户名是否存在
        public int UserName(UserInfo user)
        {
            int i = Convert.ToInt32(sqlHelp.ExecuteScalar("select count(*) from T_UserImg where userName=@userName",
                 new SqlParameter("@userName", user.userName)));
            return i;
        }
        #endregion

        #region 用户注册
        public void Insert(UserInfo user)
        {
            sqlHelp.ExecuteNonQuery(@"INSERT INTO T_UserImg
                       (userName,password,picUrl)                                 
                        VALUES
                       (@UserName,@password,@url)",
                new SqlParameter("@userName", user.userName),
                new SqlParameter("@password", user.password),
                new SqlParameter("@url", user.url));
        }
        #endregion

        #region 用户登录
        public UserInfo SelectUser(string userName, string password)
        {
            UserInfo user = new UserInfo();
            SqlDataReader reader = sqlHelp.ExecuteSqlReader("select * from T_UserImg where userName=@userName and password=@password",
                new SqlParameter("@userName", userName),
                new SqlParameter("@password", password));
            while (reader.Read())
            {
                user.userName = reader.GetString(0);
                user.password = reader.GetString(1);
                user.url = reader.GetString(2);
            }
            reader.Close();
            return user;
        }
        #endregion

        #region 更新图片
        public void updateImg(UserInfo user)
        {
            sqlHelp.ExecuteNonQuery(@"update T_UserImg set picUrl=@url where userName=@userName",
                new SqlParameter("@userName", user.userName),
                new SqlParameter("@url", user.url));
        }
        #endregion

        #region 获取图片路径，删除图片
        public UserInfo delImg(string userName)
        {
            UserInfo user = new UserInfo();
            SqlDataReader reader = sqlHelp.ExecuteSqlReader("select * from T_UserImg where userName=@userName",
                new SqlParameter("@userName", userName));
            while (reader.Read())
            {
                user.userName = reader.GetString(0);
                user.url = reader.GetString(2);
            }
            reader.Close();
            return user;
        }
        #endregion

    }
}