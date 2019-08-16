using UnityEngine;

public class Game : MonoBehaviour
{
    public string WEB_URL = "";
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(RestClient.Instance.Get(WEB_URL,GetPlayers));
        StartCoroutine(RestClient.Instance.Get(WEB_URL));
    }

    void GetPlayers(PlayerList playerList)
    {
        foreach(Player p in playerList.players)
        {
            Debug.Log("Player ID: " + p.Id);
            Debug.Log("Player Username: " + p.Username);
            Debug.Log("Player skeleton: " + p.skeleton);
            //todo go into skeleton and output joints by casting into (Joint)
        }
    }
}
