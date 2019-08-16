using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public string WEB_URL = "";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RestClient.Instance.Get(WEB_URL,GetPlayers));
    }

    void GetPlayers(PlayerList playerList)
    {
        foreach(Player p in playerList.players)
        {
            Debug.Log("Player ID: " + p.Id);
            Debug.Log("Player Username: " + p.Username);
            Debug.Log("Player skeleton: " + p.skeleton);
        }
    }
}
