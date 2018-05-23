using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication5.BLL;
using WebApplication5.Model;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        UserInfo user = new UserInfo();
        UserInfoBLL userBll = new UserInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            user.userName = txtUserName.Text.Trim();
            user.password = txtPassword.Text.Trim();
            if (user.userName == "")
            {
                Response.Write("请输入用户名!");
                return;
            }
            if (user.password == "")
            {
                Response.Write("请输入密码!");
                return;
            }
            int count = userBll.UserName(user);
            if (count > 0)
            {
                Response.Write("用户名已存在");
                return;
            }
            if (userBll.Insert(user))
            {
                Response.Write("注册成功");
                Directory.CreateDirectory(Server.MapPath("/Imgs/user/"+user.userName));
            }
            else
            {
                Response.Write("注册失败!");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (userName == "")
            {
                Response.Write("请输入用户名!");
                return;
            }
            if (userName == "")
            {
                Response.Write("请输入密码!");
                return;
            }
            UserInfo user = userBll.SelectUser(userName, password);
            if (userName == user.userName)
            {
                //Response.Write("登录成功");
                Session["picUrl"] = user.url;
                Session["userName"] = user.userName;
                Session.Timeout = 1;
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                Response.Write("用户名密码错误");
            }
        }
    }
}