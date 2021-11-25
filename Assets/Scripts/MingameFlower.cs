using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MingameFlower : MonoBehaviour
{
    public List<Player> playerlist = new List<Player>();
    public ObjectBase mOb;
    public GameObject image;
    public int counts=0;
    public bool gmaestart = false;
    public void AttackMode()
    {
      for(int i = 0; i < playerlist.Count; i++)
        {
            if (playerlist[i].mOb.vector!= Vector3.zero)
            {
                playerlist[i].mOb.outmingame = true;
                counts++;
                playerlist[i].mOb.animator.SetBool("Hit", true);
            }
        }
    }

    public void EndGame()
    {
        for (int i = 0; i < playerlist.Count; i++)
        {
            if (playerlist[i].mOb.outmingame ==true)
            {
                playerlist[i].mOb.outmingame = false;
                playerlist[i].mOb.animator.SetBool("Hit", false);
            }
        }
        playerlist.Clear();
        counts = 0;
        mOb.animator.SetBool("Start", false);
    }
    public void CheckPlayer()
    {
        
        for (int i = 0; i < FindObjectsOfType<Player>().Length; i++)
        {
            playerlist.Add(FindObjectsOfType<Player>()[i]);
        }
    }
    public void AttackAni()
    {
        if(mOb.animator.GetBool("Attack"))
        {
            //AudioManager.Instance.PlaySFX(0);
        }
        mOb.animator.SetBool("Attack", (mOb.animator.GetBool("Attack")?false:true));
        

    }
    public void ImageOn()
    {
        image.SetActive(image.activeSelf==true ? false : true);
    }
    public void StartGame()
    {
        score = 10000;
        CheckPlayer();
        mOb.animator.SetBool("Start", true);
        gmaestart = true;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        CheckPlayer();
        mOb = new ObjectBase();
        mOb.animator = GetComponent<Animator>();
        image.SetActive(false);
        
    }
    private void Update()
    {
        if (gmaestart)
        {
            CheckingPlayer();
        }
    }
    void CheckingPlayer()
    {
        if (playerlist.Count <= counts)
        {
            EndGame();
        }
    }

    IEnumerator EndMiniGame( int score)
    {

        WWWForm form = new WWWForm();
        form.AddField("game_name", "¹«±ÃÈ­");
        form.AddField("score", score);
        score -= 3000;


        UnityWebRequest www = UnityWebRequest.Post("http://118.67.143.241:8080/game/end", form);
        Debug.Log(www);
        Debug.Log(www.ToString());

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {

            Debug.Log(www.error);
           
        }
        else
        {
            

            JObject json = JObject.Parse(www.downloadHandler.text);
            UserInformation.Instance.GetNickname(json["nickname"].ToObject<string>());
            UserInformation.Instance.GetGold(json["gold"].ToObject<int>());

            Debug.Log("Form upload complete!");
        }
        

    }
   
    public int score=10000;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(EndMiniGame(score));
            counts++;
        }
    }
    // Update is called once per frame
    
}
