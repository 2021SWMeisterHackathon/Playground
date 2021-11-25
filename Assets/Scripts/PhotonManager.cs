using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : PunCallbacksSingleton<PhotonManager>
{

    public void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void JoinRoomMap()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public void LeaveRoomMap()
    {
        PhotonNetwork.LeaveRoom();
    }
    
    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManagerEx.Instance.LoadScene(SceneType.Lobby);
        // Do Something
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel((int) SceneType.RoomMap);
        // Do Something
    }

    public override void OnCreateRoomFailed(short returnCode, string message) => Debug.LogError("방만들기실패");
    public override void OnJoinRoomFailed(short returnCode, string message) => Debug.LogError("방참가실패");
    public override void OnJoinRandomFailed(short returnCode, string message) => Debug.LogError("방랜덤참가실패");

    public override void OnLeftRoom()
    {
        SceneManagerEx.Instance.LoadScene(SceneType.Lobby);
        // Do Something
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("연결끊김");
        // Do Something
    }

}
