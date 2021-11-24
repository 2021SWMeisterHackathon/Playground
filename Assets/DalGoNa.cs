using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalGoNa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Coll");

        if(other.tag == "Player")
        {
            MiniGame_Start(other.gameObject);
        }
    }

    public void MiniGame_Start(GameObject player)
    {
        Debug.Log("DalGoNa Start");

        
    }
}
