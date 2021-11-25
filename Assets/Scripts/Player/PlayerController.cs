using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float x, y;
    public float speed;

    public GameObject DefaultEmojiPanel;
    public GameObject CustomEmojiPanel;

    public GameObject EmojiPrefab;

    private GameObject var; //Instantiate() 된 인스턴스를 컨트롤하기 위함
    private Sprite spriteVar; //임시 변수

    void Start()
    {
        DefaultEmojiPanel.SetActive(false);

        speed = 0.09f;
    }


    void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * speed;
        y = Input.GetAxisRaw("Vertical") * speed;

        transform.Translate(new Vector2(x, y));

        #region 이모티콘 입력 관련
        //기본 이모티콘 메뉴 열기
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenDefaultEmojiPanel();
        }
        //자작 이모티콘 메뉴 열기
        else if (Input.GetKeyDown(KeyCode.Alpha0))
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

    public void OpenDefaultEmojiPanel()
    {
        Debug.Log("OpenDefaultEmojiPanel()");
        DefaultEmojiPanel.SetActive(!DefaultEmojiPanel.active);
    }

    public void OpenCustomEmojiPanel()
    {
        Debug.Log("OpenCustomPanel");
        CustomEmojiPanel.SetActive(!CustomEmojiPanel.active);
    }

    public void InputEmoji(int index)
    {
        GameObject.Find("EmojiManager").GetComponent<EmojiManager>().playerEmojis.TryGetValue(index - 1, out spriteVar);

        switch (index)
        {
            case 1:
                InstantiateEmoji(spriteVar);
                break;
            case 2:
                InstantiateEmoji(spriteVar);
                break;
            case 3:
                InstantiateEmoji(spriteVar);
                break;
        }

        DefaultEmojiPanel.SetActive(false);
    }

    public void InstantiateEmoji(Sprite spr)
    {
        var = Instantiate(EmojiPrefab);

        var.transform.position = this.transform.position;
        var.GetComponent<SpriteRenderer>().sprite = spr;
    }
}
