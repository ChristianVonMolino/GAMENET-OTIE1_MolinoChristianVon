using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject playerPrefab;

    public static GameManager instance;

    void Start()
    {
        if(PhotonNetwork.IsConnected) 
        {
            if(playerPrefab != null)
            {
                int xrandomPoint = Random.Range(-10, 10);
                int zrandomPoint = Random.Range(-10, 10);
                Debug.Log("Hello");
                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(xrandomPoint, 0, zrandomPoint), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " Has Joined The Room!!");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " Has Joined The Room!" + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Room has now " + PhotonNetwork.CurrentRoom.PlayerCount + "/20 players");
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("GameLauncherScene");
    }
    public void LeaveRoom()

    {
        PhotonNetwork.LeaveRoom();
    }
}
