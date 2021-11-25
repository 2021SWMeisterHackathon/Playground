using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiManager : MonoBehaviour
{
    enum Emojis
    {
        defaultJustEmo, defaultSmileEmo, defaultVerySmileEmo
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
        DontDestroyOnLoad(gameObject);

        #region 기본 9가지 이모티콘 넣기
        // 기본적으로 제공되는 이모티콘을 딕셔너리 변수에 저장합니다.
        playerEmojis.Add((int)Emojis.defaultJustEmo, defaultJustEmo);
        playerEmojis.Add((int)Emojis.defaultSmileEmo, defaultSmileEmo);
        playerEmojis.Add((int)Emojis.defaultVerySmileEmo, defaultVerySmileEmo);
        //playerEmojis.Add((int)Emojis.defaultVerySmileEmo, defaultVerySmileEmo);
        //playerEmojis.Add((int)Emojis.defaultVerySmileEmo, defaultVerySmileEmo); // 5                                                                                                                                                                                                                                                                                                                                                                                  playerEmojis.Add((int)Emojis.defaultVerySmileEmo, defaultVerySmileEmo);
        //playerEmojis.Add((int)Emojis.defaultVerySmileEmo, defaultVerySmileEmo);
        //playerEmojis.Add((int)Emojis.defaultVerySmileEmo, defaultVerySmileEmo);
        //playerEmojis.Add((int)Emojis.defaultVerySmileEmo, defaultVerySmileEmo); // 9
        #endregion
    }

    public void AddNewCustomEmo(Sprite spr)
    {
        playerEmojis.Add(playerEmojis.Count, spr);
    }

    public void TestCustomEmoUpload()
    {
        AddNewCustomEmo(TestCustomEmo);
    }
}