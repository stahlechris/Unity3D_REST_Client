using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stahle.Utility;
using UnityEngine.Networking;

public class RestClient : Singleton<RestClient>
{

    //enable way to send info back via an Action
    public IEnumerator Get(string url,System.Action<PlayerList> callback)
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
                    Debug.Log(jsonResult);


                    //TODO deserialize the JsonResult...rn it can't deserialize it back
                    //stupid fucking computer
                    //PlayerList playerList = JsonUtility.FromJson<PlayerList>(jsonResult);


                    //execute a callback w/ a playerlist
                    //callback(playerList);
                }
            }
        }
    }
}
