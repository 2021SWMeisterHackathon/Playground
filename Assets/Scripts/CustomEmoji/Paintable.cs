using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public GameObject brush;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, 15f);

            if(hit)
            {
                Debug.Log(hit.transform.gameObject.name);
                Debug.Log(hit.transform.gameObject.tag);

                if (hit.transform.gameObject.tag == "PaintCanvas")
                {
                    Vector2 pos = hit.point;

                    Debug.Log(pos);

                    Instantiate(brush, pos, Quaternion.identity);
                }
            }

            //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Debug.Log(pos);
            //Instantiate(brush, pos, Quaternion.identity);

        }

        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward*100, Color.red);
    }
}
