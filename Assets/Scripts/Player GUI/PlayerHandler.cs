using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHandler : MonoBehaviour
{

    //public CharacterStats Player;

    public GameObject skillUI;	    // The entire UI   

    // Update is called once per frame
    void Update()
    {       

        if (Input.GetKeyDown(KeyCode.K))
        {
            skillUI.SetActive(!skillUI.activeSelf);
        }
    }
}

