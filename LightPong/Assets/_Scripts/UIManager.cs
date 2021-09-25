using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instnce;

    public GameObject LodingScreen;

    private PhotonConnectionManager _pc;

    private void Awake()
    {
        instnce = this;
        _pc = FindObjectOfType<PhotonConnectionManager>();
    }

    #region main menu buttons

    public void btn_Start()
    {
        //join in random room
        _pc.btn_start();
    }

    #endregion
}
