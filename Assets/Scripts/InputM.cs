using System.Collections.Generic;
using UnityEngine;

public class InputM : MonoBehaviour
{
    public List<Usernformation> userjsonlist = new List<Usernformation>();
    private string inputusername;
    private string inputpassword;
    private string inputnickname;
    public void InputNickname(string _nickname)
    {
        inputusername = _nickname;
    }
   
}
