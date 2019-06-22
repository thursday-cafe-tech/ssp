using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class MyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public TurnManager turnManager;
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = PhotonNetwork.LocalPlayer.ActorNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("PlayerCount: " + PhotonNetwork.CurrentRoom.PlayerCount);
        // Debug.Log("CurrntRoom: " + PhotonNetwork.CurrentRoom);
        // Debug.Log("PlayerListLength: " + PhotonNetwork.PlayerList.Length);
        // foreach (Player p in PhotonNetwork.PlayerList){
        //     Debug.Log("Player: " + p);
        //     Debug.Log("ActorNumber: " + p.ActorNumber);
        // }
        int playerTurn = this.turnManager.Turn%2==1?1:2;
        if(playerTurn==PhotonNetwork.LocalPlayer.ActorNumber) {
            this.gameObject.GetComponent<Text>().text = "今は"+ PhotonNetwork.LocalPlayer.ActorNumber + "のターン";
        } else {
            this.gameObject.GetComponent<Text>().text = "";
        }
    }
}
