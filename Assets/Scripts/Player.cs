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
        mOb.animator = GetComponent<Animator>();
        mOb.speed = 10.0f;
    }

    public void Move()
    {
        mOb.vector = Vector3.zero;
        
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                mOb.vector = (Input.GetAxisRaw("Horizontal") > 0) ? Vector3.right : Vector3.left;
                this.transform.localScale = (Input.GetAxisRaw("Horizontal") > 0) ? new Vector3(1, this.transform.localScale.y, this.transform.localScale.z) : new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);




            }
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                mOb.vector = (Input.GetAxisRaw("Vertical") > 0) ? Vector3.up : Vector3.down;


            }
        mOb.animator.SetBool("Move",((Input.GetAxisRaw("Horizontal") != 0)|| (Input.GetAxisRaw("Vertical") != 0))? true:false);
        
        
        transform.position += mOb.vector * mOb.speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
    }

}
