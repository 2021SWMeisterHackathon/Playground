using System;
using UnityEngine;

public class UserInformation : Singleton<UserInformation>
{
    [SerializeField]
    private static string username
    {
        set;
        get;
    }

    [SerializeField]
    private static string password
    {
        set;
        get;
    }

    [SerializeField]
    private static string nickname;
   

    public void GetUser(string _username)
    {
        username = _username;
    }
    public void GetPassword(string _password)
    {
        password = _password;
    }
    public void GetNickname(string _nickname)
    {
        nickname = _nickname;
    }
}
