using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;
    public GameObject playerPrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists,destroying object!");
            Destroy(this);
        }
    }

    private void Start() {
        QualitySettings.vSyncCount =0;
        Application.targetFrameRate=Constants.TICKS_PER_SEC;
        Server.Start(6,42069);
    }

    private void OnApplicationQuit() {
        Server.Stop();
    }
    public Player InstatniatePlayer(){
        return Instantiate(playerPrefab,new Vector3(0,0.5f,0),Quaternion.identity).GetComponent<Player>();
    }
}
