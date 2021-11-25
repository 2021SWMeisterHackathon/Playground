using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LobbyCanvas : MonoBehaviour
    {
        [Header("Custom Panel")]
        [SerializeField] private GameObject skinItemPrefab;
        [SerializeField] private Transform skinInstantParent;
        [SerializeField] private GameObject emoticonItemPrefab;
        [SerializeField] private Transform emoticonInstantParent;

        [Header("Shop Panel")] 
        [SerializeField] private Image selectedItemImage;
        [SerializeField] private Text logText;
        
        private Canvas _lobbyCanvas;
        private int _currentSelectedItem = -1;

        // 룸 참가
        public void OnClickJoinRoomMapButton()
        {
            // (포톤)
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
                var index = i;
                skin.GetComponent<Button>().onClick.AddListener(() => { OnClickSkinButton(index); });
            }

            var emoticonLength = 10; // 이모티콘 관리자에 접근해서 얻은 이모티콘 수
            for (int i = 0; i < emoticonLength; i++)
            {
                var emoticon = Instantiate(emoticonItemPrefab, emoticonInstantParent);
                var index = i;
                emoticon.GetComponent<Button>().onClick.AddListener(() => { OnClickEmoticonButton(index); });
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
        
        public void OnClickItemButtonInShop(int index)
        {
            _currentSelectedItem = index;
            selectedItemImage.sprite = null /* 아이템 버튼에 들어가는 이미지 */;
        }

        public void OnClickBuyButton()
        {
            logText.text = "";

            if (_currentSelectedItem < 0)
            {
                logText.text = "아이템을 선택해주세요!";
            }
            else if (TempBuyItem(_currentSelectedItem))
            {
                // 아이템 적용
                logText.text = "아이템 구매에 성공했습니다!";
            }
            else
            {
                logText.text = "아이템 구매에 실패했습니다!";
            }
        }

        private bool TempBuyItem(int itemIndex)
        {
            return true;  // 성공 실패 여부
        }
    }
}