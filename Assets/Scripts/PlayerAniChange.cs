using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniChange : MonoBehaviour
{
    private int avatarnumber;
    // Start is called before the first frame update
    public void ClickChange(int clicknumber)
    {
        avatarnumber = clicknumber;
    }
    public void ChangeAvatar(Player player)
    {
        Debug.Log(avatarnumber);
       
       
        player.mOb.animator.runtimeAnimatorController= Resources.Load("Ani/Avatar" + avatarnumber) as RuntimeAnimatorController;

        Debug.Log(Resources.Load("Ani/Avatar" + avatarnumber));
    }
}
