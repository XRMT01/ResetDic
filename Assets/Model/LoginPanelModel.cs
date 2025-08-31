
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class AuthRequest
{
    public string username;
    public string password;
    public string platform = "web"; // 可选参数
}
[System.Serializable]
public class AuthResponse
{
    public string message;
    public string token;
    public UserInfo user;
}
[System.Serializable]
public class UserInfo
{
    public int id;
    public string uid;
    public string username;
    public string platform;
    public int score;
}