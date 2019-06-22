using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Login : MonoBehaviourPunCallbacks
{

    private bool isConnectedToMaster = false;
    // Start is called before the first frame update
    void Start()
    {
        string playerName="ishiyama";
        PhotonNetwork.LocalPlayer.NickName = playerName;
        Debug.Log("おしている");
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void OnLoginButtonClicked() {
        string playerName="ishiyama";
        PhotonNetwork.LocalPlayer.NickName = playerName;
        Debug.Log("おしている");
        PhotonNetwork.ConnectUsingSettings();          
    }

    public void OnCreateRoomButtonClicked() {
        if(this.isConnectedToMaster) {
            PhotonNetwork.CreateRoom("5000");
        }
    }

    public void OnJoinRoomButtonClicked() {
        if(this.isConnectedToMaster) {
            PhotonNetwork.JoinRoom("5000");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("つながっている");
        // PhotonNetwork.JoinRoom("5000");
        // PhotonNetwork.CreateRoom("5000");
        this.isConnectedToMaster = true;
        
        //PhotonNetwork.JoinRandomRoom();
        //this.SetActivePanel(SelectionPanel.name)
    }
    
    public override void OnJoinedRoom()
    {
        PhotonNetwork.CurrentRoom.IsOpen = true;
        PhotonNetwork.CurrentRoom.IsVisible = true;
        Debug.Log("ジョインルームしている");
        //PhotonNetwork.LoadLevel("DemoAsteroids-GameScene");
        PhotonNetwork.LoadLevel("SSP-48");
        

        // SetActivePanel(InsideRoomPanel.name);

        // if (playerListEntries == null)
        // {
        //     playerListEntries = new Dictionary<int, GameObject>();
        // }

        // foreach (Player p in PhotonNetwork.PlayerList)
        // {
        //     GameObject entry = Instantiate(PlayerListEntryPrefab);
        //     entry.transform.SetParent(InsideRoomPanel.transform);
        //     entry.transform.localScale = Vector3.one;
        //     entry.GetComponent<PlayerListEntry>().Initialize(p.ActorNumber, p.NickName);

        //     object isPlayerReady;
        //     if (p.CustomProperties.TryGetValue(AsteroidsGame.PLAYER_READY, out isPlayerReady))
        //     {
        //         entry.GetComponent<PlayerListEntry>().SetPlayerReady((bool) isPlayerReady);
        //     }

        //     playerListEntries.Add(p.ActorNumber, entry);
        // }

        // StartGameButton.gameObject.SetActive(CheckPlayersReady());

        // Hashtable props = new Hashtable
        // {
        //     {AsteroidsGame.PLAYER_LOADED_LEVEL, false}
        // };
        // PhotonNetwork.LocalPlayer.SetCustomProperties(props);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("failed");
        string roomName = "Room " + Random.Range(1000, 10000);

        RoomOptions options = new RoomOptions {MaxPlayers = 8};

        PhotonNetwork.CreateRoom(roomName, options, null);
    }
}

