using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

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
        public UserLogin userlogin;

        public List<UserSingUp> usersingup = new List<UserSingUp>();
        [SerializeField] private bool check;

        [Header("Login UI")] [SerializeField] private GameObject loginPanel;
        [SerializeField] private InputField loginUsernameInputField;
        [SerializeField] private InputField loginPasswordInputField;
        [SerializeField] private Toggle loginSaveAccountToggle;
        [SerializeField] private Text loginLogText;

        [Header("Signup UI")] [SerializeField] private GameObject signupPanel;
        [SerializeField] private InputField signupUsernameInputField;
        [SerializeField] private InputField signupPasswordInputField;
        [SerializeField] private InputField signupNicknameInputField;
        [SerializeField] private Text signupLogText;


        public void OnClickStartButton()
        {
            if (_isLoggedIn)
            {
                // 대충 시작하는 스크립트
                Debug.Log("Lobby로 이동");
                PhotonManager.Instance.ConnectToPhoton();
            }
            else
            {
                Debug.Log("로그인 시도");
                // 로그인 하는 스크립트
                if (_savedUserInfo != null)
                {
                    var isSuccess = Login(_savedUserInfo.Username, _savedUserInfo.Password); // **원래 저장한 값으로 로그인함
                    Debug.Log("자동 로그인");

                    if (isSuccess == 0) // 임시 : 성공했을때
                    {
                        // 대충 시작하는 스크립트
                        _isLoggedIn = true;
                        loginPanel.SetActive(false);
                        PhotonManager.Instance.ConnectToPhoton();
                        Debug.Log("로그인 성공");
                        Debug.Log("환영합니다 oo님");
                    }
                    else
                    {
                        // 대충 에러 메세지 보내는 스크립트
                        // loginLogText.gameObject.SetActive(true);
                        // loginLogText.text = "";  -> switch 사용
                    }
                }
                else
                {
                    InitLoginPanel();
                    loginPanel.SetActive(true);
                    Debug.Log("로그인 UI 킴");
                }
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
            var isSuccess = Login(loginUsernameInputField.text, loginPasswordInputField.text);

            if (isSuccess == 0) // 임시 : 성공했을때
            {
                // 대충 시작하는 스크립트
                _isLoggedIn = true;
                loginPanel.SetActive(false);
                Debug.Log("로그인 성공");
                Debug.Log("환영합니다 oo님");
                PhotonManager.Instance.ConnectToPhoton();

                if (loginSaveAccountToggle.isOn)
                {
                    _savedUserInfo = new UserInfo(loginUsernameInputField.text, loginPasswordInputField.text);
                    Debug.Log("로그인 저장");
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
            var isSuccess = SignUp(signupUsernameInputField.text, signupPasswordInputField.text,
                signupNicknameInputField.text);

            if (isSuccess == 0) // 임시 : 성공했을때
            {
                signupPanel.SetActive(false);

                InitLoginPanel();
                loginPanel.SetActive(true);
                Debug.Log("계정 생성 성공");
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

            InitSignupPanel();
            signupPanel.SetActive(true);
        }

        // 이 함수 대신 다른 로그인 함수로 대체해주세요
        private int Login(string uname, string pw)
        {
            StartCoroutine(CoLogin(uname, pw));
            return check ? 0 : 1;
        }

        private int SignUp(string uname, string pw, string nick)
        {
            StartCoroutine(CoSingUp(uname, pw, nick));
            return check ? 0 : 1;
        }

        const string urs = "http://118.67.143.241:8000";

        private IEnumerator CoLogin(string uname, string pw)
        {

            WWWForm form = new WWWForm();
            form.AddField("username", uname);
            form.AddField("password", pw);


            UnityWebRequest www = UnityWebRequest.Post("" + urs + "/auth", form);
            Debug.Log(www);
            Debug.Log(www.ToString());

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {

                Debug.Log(www.error);
                check = false;
            }
            else
            {
                check = true;

                JObject json = JObject.Parse(www.downloadHandler.text);
                UserInformation.Instance.GetNickname(json["nickname"].ToObject<string>());
                UserInformation.Instance.GetUser(uname);
                UserInformation.Instance.GetPassword(pw);
                UserInformation.Instance.GetGold(json["gold"].ToObject<int>());

                Debug.Log("Form upload complete!");
            }
        }

        string token = null;

        private IEnumerator CoSingUp(string uname, string pw, string nickname)
        {
            usersingup.Add(new UserSingUp(uname, pw, nickname));
            Debug.Log(usersingup[0]);
            Debug.Log(usersingup[0].username);
            Debug.Log(usersingup[0].password);
            Debug.Log(usersingup[0].nickname);
            WWWForm form = new WWWForm();
            form.AddField("username", uname);
            form.AddField("password", pw);
            form.AddField("nickname", nickname);


            JsonData data = JsonMapper.ToJson(usersingup[0]);
            Debug.Log(data.ToJson().GetType());
            UnityWebRequest www = UnityWebRequest.Post("http://118.67.143.241:8000/create", form);
            Debug.Log(UnityWebRequest.Post("http://118.67.143.241:8000/create", form));
            Debug.Log("json" + data.ToJson());
            Debug.Log("string" + data.ToString());
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                check = false;
                Debug.Log(www.error);
            }
            else
            {
                check = true;
                JObject json = JObject.Parse(www.downloadHandler.text);
                UserInformation.Instance.GetNickname(json["nickname"].ToObject<string>());
                UserInformation.Instance.GetUser(uname);
                UserInformation.Instance.GetPassword(pw);
                UserInformation.Instance.GetGold(json["gold"].ToObject<int>());
                Debug.Log("Form upload complete!");
            }

            StopAllCoroutines();
        }
    }
}