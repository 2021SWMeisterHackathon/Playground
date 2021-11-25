using System;
using UnityEngine;
using LitJson;

public class UserSingUp
{
    public string username
    {
        set;
        get;
    }
    public string password
    {
        set;
        get;
    }
    public string nickname
    {
        set;
        get;
    }
    public UserSingUp(string _username,string _password,string _nickname)
    {
        username = _username;
        password = _password;
        nickname = _nickname;
    }
}
public class UserLogin
{
    private  string username
    {
        set;
        get;
    }
    private  string password
    {
        set;
        get;
    }
    public UserLogin(string _username, string _password)
    {
        username = _username;
        password = _password;
        
    }
}
public  class UserInformation : Singleton<UserInformation>
{
    [SerializeField]
    private string username;
   
    [SerializeField]
    private string password;
   
    [SerializeField]
    private string nickname;

    [SerializeField]
    private int gold;
    

   

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
    public void GetGold(int _gold)
    {
        gold = _gold;
    }
    public void AddGold(int _gold)
    {
        gold += _gold;
    }
}
