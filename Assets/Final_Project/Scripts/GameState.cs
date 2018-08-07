//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;

//public class GameState : NetworkBehaviour {
//    //public ArrayList players = new ArrayList();
//    //public float[] players= new float[4];


//    // public int[] players = new int[] {-1, -1, -1, -1};

//    public SyncListInt players = new SyncListInt();

//    [SyncVar]
//    public int currPlayers;


//    //[SyncVar]
//    public  int maxPlayers = 4;
//    [SyncVar]
//    public int winner;

//    private CustomNetworkDiscovery netScript;
//    public GameObject netGameObj;


//    bool p1set;
//    bool p2set;

//    [SyncVar]
//    public int p1score;
//    [SyncVar]
//    public int p2score;

//	// Use this for initialization
//	void Start () {
//        netScript = netGameObj.GetComponent<CustomNetworkDiscovery>();
//        p1set = netScript.Player1Set();
//        p2set = netScript.Player2Set();
//        //currPlayers = players.Count;

//        p1score = 0;
//        p2score = 0;
//	}
	
//	// Update is called once per frame
//	void Update () {
//        currPlayers = players.Count;
//        if (p1set)
//        {
//            AddPlayer(0);
//           // print("player 1 added");
//          //  print("Count after adding player 1 " + players.Count);
//            p1set = false;

//        }
//        if (p2set)
//        {
//            AddPlayer(0);
//          //  print("player 2 added");
//            foreach (int score in players)
//            {
//          //      print(score);
//            }
//            p2set = false;
//        }
//       // print("currPlayers: " + currPlayers);

//	}

//    //public void AddPlayer(int index, int num) {
//    //    players[index] = num;
//    //    if (index == 0)
//    //        print("Player 1 added to game");
        
//    //    else if (index == 1)
//    //        print("Player 2 added to game");
//    //}

//    public void AddPlayer(int num)
//    {
//        players.Add(num);
//    }

//    public int NumPlayers() 
//    {
//        return currPlayers;

//    } 

//    //public void UpdatePlayer1Score()
//    //{
//    //    players[0]++;
//    //    print("player 1 score" + players[0]);
//    //}

//    //public void UpdatePlayer2Score()
//    //{
//    //    players[1]++;
//    //    print("player 2 score" + players[1]);
//    //}


//    public void UpdateP1Score(){
//        p1score++;
//        print("p1 score: " + p1score);
//    }
//    public void UpdateP2Score()
//    {
//        p2score++;
//        print("p2 score: " + p2score);
//    }

//    //public bool DoneCheckingPlayer1()
//    //{
//    //    if (netScript.Player1Set())
//    //    {
//    //        return false;
//    //    }
//    //    return true;
//    //}
//}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameState : NetworkBehaviour
{
    [SyncVar]
    public int lastPlayerId = 0;

    public SyncListInt players = new SyncListInt();

    public override void OnStartServer()
    {
        base.OnStartServer();
    }

    // this increments lastPlayerId and adds an entry in the scoreboard array
    // this is called from a Command by the player, so it runs as server
    public void AddNewPlayer()
    {
        lastPlayerId++;
        players.Add(0);
        Debug.Log("Added new player: " + lastPlayerId + " now players len = " + players.Count);
    }

}