using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using Photon;

public class TurnManager : MonoBehaviourPun, IPunTurnManagerCallbacks
{
    private PunTurnManager punTurnManager;
    public Text TurnText;
    // Start is called before the first frame update

    public int Turn
    {
        get { return this.punTurnManager.Turn; }
    }
    void Awake()
    {
        this.punTurnManager = this.gameObject.AddComponent<PunTurnManager>();
        this.punTurnManager.TurnManagerListener = this;
        this.punTurnManager.TurnDuration = 5.0f;//ターンは5秒にする
        if (PhotonNetwork.IsMasterClient)
        {
            this.punTurnManager.BeginTurn();//turnmanagerに新しいターンを始めさせる
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.TurnText != null)
        {
            this.TurnText.text = this.punTurnManager.Turn.ToString();//何ターン目かを表示してくれる
        }
    }

    public void OnPlayerFinished(Player player,
    int turn,
    object move
    )
    {
        Debug.Log("OnPlayerFinished");
    }

    public void OnTurnTimeEnds(int turn)
    {
        Debug.Log("OnTurnTimeEnds");
        if (PhotonNetwork.IsMasterClient)
        {
            this.punTurnManager.BeginTurn();//turnmanagerに新しいターンを始めさせる
        }
    }

    public void OnPlayerMove(Player player,
    int turn,
    object move
    )
    {
        Debug.Log("OnPlayerMove");
    }

    public void OnTurnBegins(int turn)
    {
        Debug.Log("OnTurnBegins");
    }

    public void OnTurnCompleted(int turn)
    {
        Debug.Log("OnTurnCompleted");
    }
}
