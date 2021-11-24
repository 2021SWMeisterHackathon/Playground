using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] private BGMType BgmType;
    private void Start()
    {
        AudioManager.Instance.PlayBGM(BgmType);
        
        return;
        
        switch (SceneManagerEx.Instance.CurrentSceneType)
        {
            default:
                break;
        }
    }
}
