using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

[System.Serializable]
public class RequestConArgumentos : UnityEvent<ListaCarros> { }

public class RequestManager : MonoBehaviour
{
    [SerializeField]
    private RequestConArgumentos _requestConArgumentos;

    [SerializeField]
    private string _url = "http://127.0.0.1:5000/";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HacerRequest());
    }

    public IEnumerator HacerRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get(_url);

        yield return www.SendWebRequest();

        string jsonSource = null;

        //revisar si no hubo broncas
        if (www.result != UnityWebRequest.Result.Success)
        {
            print("ERROR EN REQUEST!");
        }
        else
        {
            jsonSource = www.downloadHandler.text;
        }

        // print(jsonSource);
        yield return new WaitForSeconds(1);

        ListaCarros dummy2 = JsonUtility.FromJson<ListaCarros>(jsonSource);

        // print(JsonUtility.ToJson(dummy2));
        _requestConArgumentos?.Invoke(dummy2);

        /*
{"steps":[{"carros":[{"id":0,"x":-6.0,"z":0.0},{"id":0,"x":-4.5,"z":1.0},{"id":0,"x":-3.0,"z":2.0},{"id":0,"x":-1.5,"z":3.0},{"id":0,"x":0.0,"z":4.0},{"id":0,"x":1.5,"z":5.0},{"id":0,"x":3.0,"z":6.0},{"id":0,"x":4.5,"z":7.0},{"id":0,"x":6.0,"z":8.0},{"id":0,"x":7.5,"z":9.0}],"semaforos":[{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0}]},{"carros":[{"id":0,"x":-6.0,"z":0.0},{"id":0,"x":-4.5,"z":1.0},{"id":0,"x":-3.0,"z":2.0},{"id":0,"x":-1.5,"z":3.0},{"id":0,"x":0.0,"z":4.0},{"id":0,"x":1.5,"z":5.0},{"id":0,"x":3.0,"z":6.0},{"id":0,"x":4.5,"z":7.0},{"id":0,"x":6.0,"z":8.0},{"id":0,"x":7.5,"z":9.0}],"semaforos":[{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0}]},{"carros":[{"id":0,"x":-6.0,"z":0.0},{"id":0,"x":-4.5,"z":1.0},{"id":0,"x":-3.0,"z":2.0},{"id":0,"x":-1.5,"z":3.0},{"id":0,"x":0.0,"z":4.0},{"id":0,"x":1.5,"z":5.0},{"id":0,"x":3.0,"z":6.0},{"id":0,"x":4.5,"z":7.0},{"id":0,"x":6.0,"z":8.0},{"id":0,"x":7.5,"z":9.0}],"semaforos":[{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0}]},{"carros":[{"id":0,"x":-6.0,"z":0.0},{"id":0,"x":-4.5,"z":1.0},{"id":0,"x":-3.0,"z":2.0},{"id":0,"x":-1.5,"z":3.0},{"id":0,"x":0.0,"z":4.0},{"id":0,"x":1.5,"z":5.0},{"id":0,"x":3.0,"z":6.0},{"id":0,"x":4.5,"z":7.0},{"id":0,"x":6.0,"z":8.0},{"id":0,"x":7.5,"z":9.0}],"semaforos":[{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0}]},{"carros":[{"id":0,"x":-6.0,"z":0.0},{"id":0,"x":-4.5,"z":1.0},{"id":0,"x":-3.0,"z":2.0},{"id":0,"x":-1.5,"z":3.0},{"id":0,"x":0.0,"z":4.0},{"id":0,"x":1.5,"z":5.0},{"id":0,"x":3.0,"z":6.0},{"id":0,"x":4.5,"z":7.0},{"id":0,"x":6.0,"z":8.0},{"id":0,"x":7.5,"z":9.0}],"semaforos":[{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0}]},{"carros":[{"id":0,"x":-6.0,"z":0.0},{"id":0,"x":-4.5,"z":1.0},{"id":0,"x":-3.0,"z":2.0},{"id":0,"x":-1.5,"z":3.0},{"id":0,"x":0.0,"z":4.0},{"id":0,"x":1.5,"z":5.0},{"id":0,"x":3.0,"z":6.0},{"id":0,"x":4.5,"z":7.0},{"id":0,"x":6.0,"z":8.0},{"id":0,"x":7.5,"z":9.0}],"semaforos":[{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0}]},{"carros":[{"id":0,"x":-6.0,"z":0.0},{"id":0,"x":-4.5,"z":1.0},{"id":0,"x":-3.0,"z":2.0},{"id":0,"x":-1.5,"z":3.0},{"id":0,"x":0.0,"z":4.0},{"id":0,"x":1.5,"z":5.0},{"id":0,"x":3.0,"z":6.0},{"id":0,"x":4.5,"z":7.0},{"id":0,"x":6.0,"z":8.0},{"id":0,"x":7.5,"z":9.0}],"semaforos":[{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0}]},{"carros":[{"id":0,"x":-6.0,"z":0.0},{"id":0,"x":-4.5,"z":1.0},{"id":0,"x":-3.0,"z":2.0},{"id":0,"x":-1.5,"z":3.0},{"id":0,"x":0.0,"z":4.0},{"id":0,"x":1.5,"z":5.0},{"id":0,"x":3.0,"z":6.0},{"id":0,"x":4.5,"z":7.0},{"id":0,"x":6.0,"z":8.0},{"id":0,"x":7.5,"z":9.0}],"semaforos":[{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0}]},{"carros":[{"id":0,"x":-6.0,"z":0.0},{"id":0,"x":-4.5,"z":1.0},{"id":0,"x":-3.0,"z":2.0},{"id":0,"x":-1.5,"z":3.0},{"id":0,"x":0.0,"z":4.0},{"id":0,"x":1.5,"z":5.0},{"id":0,"x":3.0,"z":6.0},{"id":0,"x":4.5,"z":7.0},{"id":0,"x":6.0,"z":8.0},{"id":0,"x":7.5,"z":9.0}],"semaforos":[{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0}]},{"carros":[{"id":0,"x":-6.0,"z":0.0},{"id":0,"x":-4.5,"z":1.0},{"id":0,"x":-3.0,"z":2.0},{"id":0,"x":-1.5,"z":3.0},{"id":0,"x":0.0,"z":4.0},{"id":0,"x":1.5,"z":5.0},{"id":0,"x":3.0,"z":6.0},{"id":0,"x":4.5,"z":7.0},{"id":0,"x":6.0,"z":8.0},{"id":0,"x":7.5,"z":9.0}],"semaforos":[{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0},{"id":0,"color":0}]}]}

    */
    }
}
