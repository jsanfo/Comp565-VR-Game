using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class networkManager : MonoBehaviourPunCallbacks
{
    public static networkManager Instance;

    private void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    public void LeaveRoomAndLoadHomeScreen(){
        PhotonNetwork.LeaveRoom();
    }

    #region Photon Callback Methods

    public override void OnPlayerEnteredRoom(Player newPlayer){
        Debug.Log(newPlayer.NickName + " joined " + "Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnLeftRoom(){
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause){
        PhotonNetwork.LoadLevel(2);
    }
    
    #endregion
}
