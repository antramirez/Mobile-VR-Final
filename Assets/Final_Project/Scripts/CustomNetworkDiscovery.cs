using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkDiscovery : NetworkDiscovery {
    private bool _receivedBradcast = false;
    float playernum;
    bool playNumSet;
    public float playerNumber;
    public bool player1set;
    public bool player2set;

	private void Start()
	{
        Initialize();
	}

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        if (!_receivedBradcast)
        {
            _receivedBradcast = true;
            base.OnReceivedBroadcast(fromAddress, data);
            Debug.Log("FromAddress: " + fromAddress + "  Data: " + data);
            string[] addressSplit  = fromAddress.Split(':');
            string[] dataSplit = data.Split(':');
            NetworkManager.singleton.networkAddress = addressSplit[addressSplit.Length - 1];
            NetworkManager.singleton.networkPort = int.Parse(dataSplit[dataSplit.Length - 1]);
            NetworkManager.singleton.StartClient();
        }
    }

    public void StartListeningBroadcast() 
    {
        StartAsClient();
        player2set = true;
    }

    public void StartAsHost () 
    {
        NetworkManager.singleton.StartHost();
        StartAsServer();
        player1set = true;
    }

    public bool Player1Set()
    {
        return player1set;
    }
    public bool Player2Set()
    {
        return player2set;
    }
}