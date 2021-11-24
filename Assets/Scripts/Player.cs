using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private ObjectBase mOb;
    // Start is called before the first frame update
    void Start()
    {
        mOb = new ObjectBase();
        mOb.speed = 10.0f;
    }

    public void Move()
    {
        mOb.vector = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            mOb.vector = (Input.GetAxisRaw("Horizontal") > 0) ? Vector3.right : Vector3.left;
            
          

           
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            mOb.vector = (Input.GetAxisRaw("Vertical") > 0) ? Vector3.up : Vector3.down;

            
        }
        Debug.Log(transform.position);
        transform.position += mOb.vector * mOb.speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        Move(); 
    }

}
