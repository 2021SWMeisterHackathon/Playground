using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float x, y;
    public float speed;

    public GameObject EmojiInputPanel;
    public GameObject CustomEmojiInputPanel;

    #region EmojiPrefabFields
    public GameObject JustEmoji;
    public GameObject SmileEmoji;
    public GameObject VerySmileEmoji;
    #endregion

    private GameObject var; //Instantiate된 인스턴스를 컨트롤하기 위함

    void Start()
    {
        EmojiInputPanel.SetActive(false);

        speed = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * speed;
        y = Input.GetAxisRaw("Vertical") * speed;

        transform.Translate(new Vector2(x, y));

        #region 이모티콘 입력 관련
        //기본 이모티콘 메뉴
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenEmojiPanel();
        }
        //자작 이모티콘 작성 메뉴
        else if (Input.GetKeyDown(KeyCode.R))
        {
            OpenCustomEmojiPanel();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            InputEmoji(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            InputEmoji(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            InputEmoji(3);
        }
        #endregion
    }

    public void OpenEmojiPanel()
    {
        Debug.Log("OpenEmojiPanel()");
        EmojiInputPanel.SetActive(true);
    }

    public void OpenCustomEmojiPanel()
    {
        Debug.Log("OpenCustomEmojiPanel");
        CustomEmojiInputPanel.SetActive(true);
}

    public void InputEmoji(int index)
    {
        Debug.Log("UseEmoji");

        switch(index)
        {
            case 1:
                InstantiateEmoji(JustEmoji); break;
            case 2:
                InstantiateEmoji(SmileEmoji); break;
            case 3:
                InstantiateEmoji(VerySmileEmoji); break;
        }

        EmojiInputPanel.SetActive(false);
    }

    public void InstantiateEmoji(GameObject EmojiPrefab)
    {
        var = Instantiate(EmojiPrefab);

        var.transform.position = this.transform.position;
    }
}
