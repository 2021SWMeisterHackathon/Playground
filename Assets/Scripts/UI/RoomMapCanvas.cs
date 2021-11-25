using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RoomMapCanvas : MonoBehaviour
    {
        private bool _isEmoticonPanelEnable = false;
        [SerializeField] private GameObject customEmoticonPanel;

        [SerializeField] private GameObject emoticonItemPrefab;
        [SerializeField] private Transform emoticonInstantParent;

        private static readonly KeyCode[] KeyCodes =
        {
            KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4,
            KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9
        };
        
        private void Update()
        {
            if (!Input.anyKeyDown) return;
            
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                _isEmoticonPanelEnable = !_isEmoticonPanelEnable;
                customEmoticonPanel.SetActive(_isEmoticonPanelEnable);
            }
            else
            {
                for (int i = 1; i < KeyCodes.Length; i++)
                {
                    if (Input.GetKeyDown(KeyCodes[i]))
                    {
                        TempSendEmoticon(i);
                    }
                }
            }
        }

        public void OnClickExitButton()
        {
            // 씬 나가기(포톤)
        }

        private void OnClickCustomEmoticon()
        {
            // 커스텀 이모티콘 보내는 메서드
        }

        private void OnEnable()
        {
            var emoticonLength = 10;  // 이모티콘 관리자에 접근
            for (int i = 0; i < emoticonLength; i++)
            {
                var emoticon = Instantiate(emoticonItemPrefab, emoticonInstantParent);
                emoticon.GetComponent<Button>().onClick.AddListener(() => { OnClickCustomEmoticon();});
            }
        }

        // 이모티콘 보내는 메서드(임시. 나중에 연동할때 이 함수만 바꿔주시면 됩니다)
        private void TempSendEmoticon(int index)
        {
            
        }
    }
}
