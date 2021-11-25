using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiController : MonoBehaviour
{
    float second;
    void Start()
    {
        second = 0;
        transform.Translate(Vector2.up * 0.5f);
    }


    void Update()
    {
        second += Time.deltaTime;
        transform.Translate(Vector2.up * Time.deltaTime);

        if (second >= 3.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
