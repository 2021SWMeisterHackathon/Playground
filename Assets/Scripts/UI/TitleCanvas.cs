using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TitleCanvas : MonoBehaviour
    {
        private class UserInfo
        {
            public string Username;
            public string Password;
            
            public UserInfo(string username, string password)
            {
                Username = username;
                Password = password;
            }
        }

        private bool _isLoggedIn = false;
        private UserInfo _savedUserInfo = null;

        [Header("Login UI")]
        [SerializeField] private GameObject loginPanel;
        [SerializeField] private InputField loginUsernameInputField;
        [SerializeField] private InputField loginPasswordInputField;
        [SerializeField] private Toggle loginSaveAccountToggle;
        [SerializeField] private Text loginLogText;
        
        [Header("Signup UI")]
        [SerializeField] private GameObject signupPanel;
        [SerializeField] private InputField signupUsernameInputField;
        [SerializeField] private InputField signupPasswordInputField;
        [SerializeField] private InputField signupNicknameInputField;
        [SerializeField] private Text signupLogText;
        
        
        public void OnClickStartButton()
        {
            if (_isLoggedIn)
            {
                // 대충 시작하는 스크립트
            }
            else
            {
                // 로그인 하는 스크립트
                if (_savedUserInfo != null)
                {
                    TempLogin(_savedUserInfo.Username,_savedUserInfo.Password);  // **원래 저장한 값으로 로그인함
                }
                else
                {
                    InitLoginPanel();
                    loginPanel.SetActive(true);
                }
                
                // **로그인하고 나서 뜨는 ui
            }
        }
        
        private void InitLoginPanel()
        {
            loginUsernameInputField.text = "";
            loginPasswordInputField.text = "";
            loginSaveAccountToggle.isOn = false;
            loginLogText.gameObject.SetActive(false);
        }
        
        private void InitSignupPanel()
        {
            signupUsernameInputField.text = "";
            signupPasswordInputField.text = "";
            signupNicknameInputField.text = "";
            signupLogText.gameObject.SetActive(false);
        }

        public void OnClickLoginButton()
        {
            var isSuccess = TempLogin(loginUsernameInputField.text, loginPasswordInputField.text);
            
            if (isSuccess == 0)  // 임시 : 성공했을때
            {
                // 대충 시작하는 스크립트
                if (loginSaveAccountToggle.isOn)
                {
                    _savedUserInfo = new UserInfo(loginUsernameInputField.text, loginPasswordInputField.text);
                }
            }
            else
            {
                // 대충 에러 메세지 보내는 스크립트
                // loginLogText.gameObject.SetActive(true);
                // loginLogText.text = "";  -> switch 사용
            }
        }

        public void OnClickSignupButton()
        {
            var isSuccess = TempSignUp(signupUsernameInputField.text, signupPasswordInputField.text,
                signupNicknameInputField.text);
            
            if (isSuccess == 0)  // 임시 : 성공했을때
            {
                signupPanel.SetActive(false);
                
                InitLoginPanel();
                loginPanel.SetActive(true);
            }
            else
            {
                // 대충 에러 메세지 보내는 스크립트
                // signupLogText.gameObject.SetActive(true);
                // signupLogText.text = "";  -> switch 사용
            }
        }

        public void OnClickSignupPanelButton()
        {
            loginPanel.SetActive(false);
                
            InitLoginPanel();
            signupPanel.SetActive(true);
        }

        // 이 함수 대신 다른 로그인 함수로 대체해주세요
        private int TempLogin(string uname, string pw)
        {
            return 0;  // 로그인 response (다른 자료형이어도 됩니다.)
        }

        private int TempSignUp(string uname, string pw, string nick)
        {
            return 0;
        }
    }
}