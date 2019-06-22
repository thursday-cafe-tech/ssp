using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class MyPlayer : Photon.Pun.MonoBehaviourPun
{
    // Start is called before the first frame update
    public TurnManager turnManager;

    public PhotonView photonView;

    private bool judge = true;

    public string hand ="";
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = PhotonNetwork.LocalPlayer.ActorNumber.ToString();
        this.photonView = this.gameObject.GetComponent<PhotonView>();
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

        if(this.turnManager.Turn == 7 && this.judge) {
            photonView.RPC("winLose", RpcTarget.All, this.hand);
            this.judge = false;
        }
    }

    [PunRPC]
    void winLose(string othersHand) {
        if(this.hand == "rock" && othersHand == "paper") {
            Debug.Log("負け");
            this.gameObject.GetComponent<Text>().text = "まけ";
        }
        if(this.hand == "scissor" && othersHand == "rock") {
            Debug.Log("負け");
            this.gameObject.GetComponent<Text>().text = "まけ";
        }
        if(this.hand == "paper" && othersHand == "scissor") {
            Debug.Log("負け");
            this.gameObject.GetComponent<Text>().text = "まけ";
        }
        if(this.hand == "rock" && othersHand == "scissor") {
            Debug.Log("勝ち");
            this.gameObject.GetComponent<Text>().text = "かち";
        }
        if(this.hand == "scissor" && othersHand == "paper") {
            Debug.Log("勝ち");
            this.gameObject.GetComponent<Text>().text = "かち";
        }
        if(this.hand == "paper" && othersHand == "rock") {
            Debug.Log("勝ち");
            this.gameObject.GetComponent<Text>().text = "かち";
        }
    }

    public void Rock() {
        this.hand = "rock";
    }

    public void Scissor() {
        this.hand = "scissor";
    }

    public void Paper() {
        this.hand = "paper";
    }
}
