<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication5.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        function showImg(file) {
            var prevDiv = document.getElementById("Image1");
            var aa = document.getElementById("upUserPic").value.toLowerCase().split('.');
            if (aa[aa.length - 1] == 'png' || aa[aa.length - 1] == 'jpg' || aa[aa.length - 1] == 'jpeg') {
                if (file.files && file.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (evt) {
                        prevDiv.src = evt.target.result;
                    }
                    reader.readAsDataURL(file.files[0]);
                }
                return true;
            }
            else {
                alert('对不起，你选择的图片格式不对\n图片格式应为*.jpg、*.png、*.jpeg');
                document.getElementById('upUserPic').value = "";
                prevDiv.src = "";
                return false;
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="Image1" runat="server" Width="50px" /><br />
        <asp:FileUpload ID="upUserPic" runat="server" onchange="showImg(this)" /><br />
        <asp:Label ID="labConfirm" runat="server"></asp:Label>
        <p>
            <asp:Button ID="btnChange" runat="server" Text="确认修改" OnClick="btnChange_Click" />
            <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="退出登录" />
        </p>
    </form>
</body>
</html>
