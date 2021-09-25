using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class Players
{
    public Player _player;
    public int _score;
}

public class GamePlayManager : MonoBehaviour
{    
    [SerializeField] private List<Players> _playersList = new List<Players>();
    [SerializeField] private List<GameObject> _playerPadelList = new List<GameObject>();

    private Boll _Boll;

    private void Awake()
    {
        _Boll = FindObjectOfType<Boll>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //get photon player list to local player list
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            Players players = new Players();
            players._score = 0;
            players._player = PhotonNetwork.PlayerList[i];

            _playersList.Add(players);
        }

        ////set boll position
        //_Boll.transform.position = _playerPadelList[0].transform.GetChild(0).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
