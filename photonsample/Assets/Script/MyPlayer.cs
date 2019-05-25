using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class MyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = PhotonNetwork.LocalPlayer.ActorNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
