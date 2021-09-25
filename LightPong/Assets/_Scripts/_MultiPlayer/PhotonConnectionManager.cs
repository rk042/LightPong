using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PhotonConnectionManager : MonoBehaviourPunCallbacks
{
    private static PhotonConnectionManager instance;

    [SerializeField] private string _GameVersion;
    [SerializeField] private int _MaxPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("instance null");
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("instance not null");
        }

        //game version
        PhotonNetwork.GameVersion = _GameVersion;
        
        //set player name
        PhotonNetwork.NickName = $"Pong " + Random.Range(0, 11);
       
        //connect to photon using settings
        PhotonNetwork.ConnectUsingSettings();
    }

    public void btn_start()
    {
        JoinRandomRoom();

        //show loding screen
        UIManager.instnce.LodingScreen.SetActive(true);
    }

    /// <summary>
    /// create room menualy
    /// </summary>
    private void CreateRoom()
    {
        //create room menualy
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)_MaxPlayer;        

        PhotonNetwork.CreateRoom($"Light {Random.Range(1, 11)} Pong",roomOptions);
    }

    private void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    [PunRPC]
    private void RPC_JoinGame()
    {
        //load gameplay scene
        SceneManager.LoadScene(2);
    }

    #region callbacks 

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");

        //join lobby
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogError(message);

        //create room
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("on joined room "+PhotonNetwork.CurrentRoom.Name);
        
        if (PhotonNetwork.CurrentRoom.PlayerCount==2)
        {
            //close loding screen
            UIManager.instnce.LodingScreen.SetActive(false);

            //call join gameplay rpc
            photonView.RPC("RPC_JoinGame", RpcTarget.All);
        }
        else
        {
            //wait for player
            Debug.Log("wait for player "+PhotonNetwork.CurrentRoom.PlayerCount);
        }
        
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Debug.Log("room list " + roomList[i].Name);
        }
    }

    #endregion
}
