using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEmojiManager : MonoBehaviour
{
    enum Emojis
    {
        defaultJustEmo,
        defaultSmileEmo,
        defaultVerySmileEmo
    }

    // 각 플레이어의 이모티콘을 관리하는 변수입니다.
    public Dictionary<int, Sprite> playerEmojis = new Dictionary<int, Sprite>();

    #region Default Emoji Fields
    //유니티 에디터에서 각 스프라이트 값이 할당됩니다.
    public Sprite defaultJustEmo;
    public Sprite defaultSmileEmo;
    public Sprite defaultVerySmileEmo;
    #endregion

    public Sprite TestCustomEmo;

    void Start()
    {
        // 기본적으로 제공되는 이모티콘을 딕셔너리 변수에 저장합니다.
        playerEmojis.Add((int)Emojis.defaultJustEmo, defaultJustEmo);
        playerEmojis.Add((int)Emojis.defaultSmileEmo, defaultSmileEmo);
        playerEmojis.Add((int)Emojis.defaultVerySmileEmo, defaultVerySmileEmo);


        Debug.LogFormat("Default Setting Complete");
        foreach(KeyValuePair<int, Sprite> var in playerEmojis)
        {
            Debug.LogFormat(var.Key + var.Value.name);
        }
    }

    public void AddNewCustomEmo(Sprite spr)
    {
        playerEmojis.Add(playerEmojis.Count, spr);


        Debug.LogFormat("New uploaded" , playerEmojis);
        foreach (KeyValuePair<int, Sprite> var in playerEmojis)
        {
            Debug.LogFormat(var.Key + var.Value.name);
        }
    }

    public void TestCustomEmoUpload()
    {
        AddNewCustomEmo(TestCustomEmo);
    }
}
