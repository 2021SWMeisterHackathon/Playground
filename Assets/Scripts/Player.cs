using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public ObjectBase mOb;
  
    // Start is called before the first frame update
    void Start()
    {
        mOb = new ObjectBase();
        mOb.animator = GetComponent<Animator>();
      
        mOb.speed = 10.0f;
    }

    public void Move()
    {
        if (mOb.outmingame ==true)
        {
            return;
        }
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
   
    private void FixedUpdate()
    {
        try
        {
            Move();
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Potal1" || (collision.gameObject.tag == "MainPotal"))
        {
            mOb.targettransform = collision.gameObject.GetComponent<Transform>();
            if (collision.gameObject.tag == "Potal1")
            {
                FindObjectOfType<MingameFlower>().StartGame();
            }
            transform.position = mOb.targettransform.position;
        }
        if (collision.gameObject.tag == "Goalin")
        {
            mOb.animator.SetBool("Win", true);
        }
    }
    
    public void WinEnd()
    {
        mOb.animator.SetBool("Win", false);
    }

}
