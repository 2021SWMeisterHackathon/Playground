using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LobbyCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject skinItemPrefab;
        [SerializeField] private Transform skinInstantParent;
        
        [SerializeField] private GameObject emoticonItemPrefab;
        [SerializeField] private Transform emoticonInstantParent;

        private int currentSkinIndex;
        private Canvas _lobbyCanvas;

        // 룸 참가
        public void OnClickJoinRoomMapButton()
        {
            PhotonManager.Instance.JoinRoomMap();
        }

        // 창작 이모티콘 만들기
        public void OnClickEmoticonCreateButton()
        {
            _lobbyCanvas.enabled = false;
            // 캔버스 초기화
        }

        public void OnClickSaveCreateButton()
        {
            // 캔버스 저장
            _lobbyCanvas.enabled = true;
        }

        private void Start()
        {
            _lobbyCanvas = GetComponent<Canvas>();
            
            var skinLength = 3;
            for (int i = 0; i < skinLength; i++)
            {
                var skin = Instantiate(skinItemPrefab, skinInstantParent);
                skin.GetComponent<Button>().onClick.AddListener(() => { });
            }

            var emoticonLength = 10;  // 이모티콘 관리자에 접근
            for (int i = 0; i < emoticonLength; i++)
            {
                var emoticon = Instantiate(emoticonItemPrefab, emoticonInstantParent);
                emoticon.GetComponent<Button>().onClick.AddListener(() => { });
            }
        }

        private void OnClickSkinButton(int index)
        {
            // 대충 아바타에 스킨 적용
            // 우측 아바타에 적용된 스킨 표시
        }

        private void OnClickEmoticonButton(int index)
        {
            // 대충 이모티콘 관리 팝업 (확인, 또는 삭제)
        }
    }
}