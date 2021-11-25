using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paintable : MonoBehaviour
{
    public GameObject brush;

    Ray ray;
    Vector3 MousePosition;
    RaycastHit2D hit;

    Vector2 pos;

    public RenderTexture RTexture;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(MousePosition, transform.forward, 15f);

            if(hit)
            {
                Debug.Log(hit.transform.gameObject.name);
                Debug.Log(hit.transform.gameObject.tag);

                if (hit.transform.gameObject.tag == "PaintCanvas")
                {
                    pos = hit.point;

                    Debug.Log(pos);

                    Instantiate(brush, pos, Quaternion.identity);
                }
            }
        }
    }

    public void Save()
    {
        StartCoroutine(CoSave());
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private IEnumerator CoSave()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture.active = RTexture;

        var texture2D = new Texture2D(RTexture.width, RTexture.height);
        texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
        texture2D.Apply();

        var data = texture2D.EncodeToPNG();

        File.WriteAllBytes(Application.dataPath + "/CustomEmojis/a.png", data);


    }

    //임시로 다음 씬을 구현
    public void GoToGameScene()
    {
        SceneManager.LoadScene("DeunSolSampleScene");
    }
}
