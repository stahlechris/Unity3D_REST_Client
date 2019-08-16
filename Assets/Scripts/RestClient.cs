using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stahle.Utility;
using UnityEngine.Networking;
using Newtonsoft.Json;
public class RestClient : Singleton<RestClient>
{
    //public IEnumerator Get(string url,System.Action<PlayerList> callback)
    public IEnumerator Get(string url)
    {
        using(UnityWebRequest www = UnityWebRequest.Get(url))
        {
            www.certificateHandler = new BypassCertificate();
            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if(www.isDone)
                {

                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(jsonResult); //this works

                    //PlayerList playerList = JsonUtility.FromJson<PlayerList>(jsonResult); //this doesn't
                    //PlayerList playerList = JsonConvert.DeserializeObject<PlayerList>(jsonResult);

                    List<Player> players = JsonConvert.DeserializeObject<List<Player>>(jsonResult);

                    //comment out this foreach loop when testing with the 2 arg Get()
                    foreach (Player p in players)
                    {
                        Debug.Log("Player ID: " + p.Id);
                        Debug.Log("Player Username: " + p.Username);
                        foreach(Microsoft.Azure.Kinect.Sensor.BodyTracking.Joint j in p.skeleton.Joints)
                        {
                            Debug.Log(j);
                        }
                    }
                    //execute a callback w/ a playerlist to print the players in console
                    //callback(playerList);
                }
            }
        }
    }

    //todo add server side validation
    public IEnumerator Delete(string url,int id)
    {
        string urlWithParam = string.Format("{0}{1}",url,id);

        using (UnityWebRequest www = UnityWebRequest.Delete(urlWithParam))
        {
            www.certificateHandler = new BypassCertificate();
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    Debug.Log(string.Format("Deleted player with ID: {0}", id));
                }
            }
        }
    }

    //!UNDER CONSTRUCTION!
    //public IEnumerator Post(string url, Player newPlayer)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Delete(url))
    //    {
    //        www.certificateHandler = new BypassCertificate();
    //        yield return www.SendWebRequest();

    //        if (www.isNetworkError || www.isHttpError)
    //        {
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            if (www.isDone)
    //            {
    //                Debug.Log(string.Format("Deleted player with ID: {0}", id));
    //            }
    //        }
    //    }
    //}
}
