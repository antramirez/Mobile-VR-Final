using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkDiscovery : NetworkDiscovery {
    private bool _receivedBradcast = false;

    int playernum;


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
            string[] addressSplit  = fromAddress.Split(':');
            string[] dataSplit = data.Split(':');
            NetworkManager.singleton.networkAddress = addressSplit[addressSplit.Length - 1];
            NetworkManager.singleton.networkPort = int.Parse(dataSplit[dataSplit.Length - 1]);
            NetworkManager.singleton.StartClient();
        }
    }

    public void StartListeningBroadcast() {
        StartAsClient();
        playernum = Random.Range(0,4);
        // accessing the game state script, check if rand num exists
        print(playernum);

    }

    public void StartAsHost () {
        NetworkManager.singleton.StartHost();
        StartAsServer();
        playernum = 0;
    }

}
