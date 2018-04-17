using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour {

    [SerializeField] Sprite image;
    [SerializeField] string toolTip;
    [SerializeField] string description;

    public Sprite Image
    {
        get { return image; }
        set { image = value; }
    }

    public string ToolTip
    {
        get { return toolTip; }
        set {toolTip = value; }            
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
