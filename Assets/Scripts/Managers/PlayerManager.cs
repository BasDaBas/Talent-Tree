using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    #region Singleton
    public static PlayerManager instance;    

    // Use this for initialization
    void Awake () {
        instance = this;
	}

    #endregion

    public GameObject player;

    public void KillPlayer()
    {
        Debug.Log(this + " died");
        //DO something
    }

}
