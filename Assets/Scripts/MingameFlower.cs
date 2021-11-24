using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MingameFlower : MonoBehaviour
{
    public List<Player> playerlist = new List<Player>();
    public ObjectBase mOb;
    public void AttackMode()
    {
      for(int i = 0; i < playerlist.Count; i++)
        {
            if (playerlist[i].mOb.vector!= Vector3.zero)
            {
                playerlist[i].mOb.outmingame = true;
            }
        }
    }
    public void CheckPlayer()
    {
        
        for (int i = 0; i < FindObjectsOfType<Player>().Length; i++)
        {
            playerlist.Add(FindObjectsOfType<Player>()[i]);
        }
    }
    public void AttackAni()
    {
        mOb.animator.SetBool("Attack", (mOb.animator.GetBool("Attack")?false:true));
    }
    // Start is called before the first frame update
    void Start()
    {
        CheckPlayer();
        mOb = new ObjectBase();
        mOb.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
