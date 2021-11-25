using LitJson;
using UnityEngine;

public class Usernformation
{
    string username
    {
        set;
        get;
    }
    string password
    {
        set;
        get;
    }
string nickname
    {
        set;
        get;
    }
        
    public Usernformation(string _username, string _password,string _nickname)
    {
        username = _username;
        password = _password;
        nickname = _nickname;
    }
}

public class ObjectBase
{
    public float speed;
    public Vector3 vector;
    public Animator animator;
    public Transform targettransform;
    public bool outmingame=false;
    
}
