using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkDiscovery : NetworkDiscovery
{
    private bool _receivedBradcast = false;

    float playernum;
    bool playNumSet;

    bool player1set;
    bool player2set;
    bool player3set;
    bool player4set;

    private void Start()
    {
        Initialize();
        //TODO
        // access Game State Script
    }

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        if (!_receivedBradcast)
        {
            _receivedBradcast = true;
            base.OnReceivedBroadcast(fromAddress, data);
            Debug.Log("FromAddress: " + fromAddress + "  Data: " + data);
            string[] addressSplit = fromAddress.Split(':');
            string[] dataSplit = data.Split(':');
            NetworkManager.singleton.networkAddress = addressSplit[addressSplit.Length - 1];
            NetworkManager.singleton.networkPort = int.Parse(dataSplit[dataSplit.Length - 1]);
            NetworkManager.singleton.StartClient();
        }
    }

    public void StartListeningBroadcast()
    {
        StartAsClient();
        //playernum = (int)Random.Range(1f, 3.9f);
        // accessing the game state script, check if rand num exists


        if (player1set && player2set && player3set)
        {
            SetPlayerNumber(3);
            player4set = true;
        }
        else if (player2set)
        {
            SetPlayerNumber(2);
            player3set = true;
        }
        else if (player1set)
        {
            SetPlayerNumber(1);
            player2set = true;
        }
        playNumSet = true;

    }

    public void StartAsHost()
    {
        NetworkManager.singleton.StartHost();
        StartAsServer();
        SetPlayerNumber(0);
        player1set = true;
        playNumSet = true;
    }

    public bool PlayerNumIsSet()
    {
        return playNumSet;
    }
    public void SetPlayerNumber(float num)
    {
        playernum = num;
    }
    public float GetPLayerNumber()
    {
        return playernum;
    }
}
