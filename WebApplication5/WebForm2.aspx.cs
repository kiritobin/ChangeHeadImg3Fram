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
    public partial class WebForm2 : System.Web.UI.Page
    {
        UserInfo user = new UserInfo();
        UserInfoBLL userBll = new UserInfoBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
            {
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                Response.Write("登录用户："+Session["userName"].ToString());
                Image1.ImageUrl = Session["picUrl"].ToString();
            }
        }
        protected void btnChange_Click(object sender, EventArgs e)
        {
            string path = "/Imgs/user/"+ Session["userName"].ToString()+"/";
            bool filesValid = false;
            //DateTime now = DateTime.Now;
            string fileName = Path.GetFileNameWithoutExtension(upUserPic.FileName);
            //string fileName = "" + now.Year + now.Month + now.Day + now.Hour + now.Minute + now.Second + now.Millisecond;
            if (upUserPic.HasFile)
            {
                String fileExtension = Path.GetExtension(upUserPic.FileName).ToLower();
                String[] restrictExtension = { ".jpg", ".jpeg", ".png" };
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    double mb = upUserPic.PostedFile.ContentLength / 1024 / 1024.0;
                    if (fileExtension == restrictExtension[i] && mb <= 4)
                    {
                        filesValid = true;
                    }
                }
                if (filesValid == true)
                {
                    try
                    {
                        Image1.ImageUrl = Session["picUrl"].ToString();
                        upUserPic.SaveAs(Server.MapPath(path) + fileName + fileExtension);

                        user = userBll.delImg(Session["userName"].ToString());
                        if (user.url != @"\Imgs\system\system.jpg")
                        {
                            File.Delete(Server.MapPath(user.url));
                        }

                        string imgPath = path + Path.GetFileName(upUserPic.PostedFile.FileName);
                        user.userName = Session["userName"].ToString();
                        user.url = imgPath;
                        userBll.updateImg(user);
                        Image1.ImageUrl = imgPath;

                        labConfirm.Text = "修改成功";
                    }
                    catch
                    {
                        labConfirm.Text = "上传失败";
                    }
                    finally
                    {
                        Image1.Dispose();
                    }
                }
                else
                {
                    labConfirm.Text = "修改失败";
                }
            }
            else
            {
                labConfirm.Text = "格式错误";
                Image1.ImageUrl = Session["picUrl"].ToString();
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session.Remove("userName");
            Session.Abandon();
            Response.Redirect("WebForm1.aspx");
        }
    }
}