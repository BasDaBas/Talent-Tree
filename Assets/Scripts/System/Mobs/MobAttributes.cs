using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttributes : MonoBehaviour {

    [SerializeField] string AttributeName;
    [SerializeField] int currentValue;
    [SerializeField] int baseValue;

    [SerializeField] Icon icon;
    [SerializeField] AttributeType attributeType;

    public string Name
    {
        get { return AttributeName; }
        set { AttributeName = value; }
    }

    public int BaseValue
    {
        get { return baseValue; }
        set { baseValue = value; }
    }

    public void BaseAttributesIncrease(int amount)
    {
        baseValue += amount;
    }

    public int CurrentAttributeValue
    {
        get { return currentValue; }
        set { currentValue = value; }
    }

    public void AddToCurrentValue(int amount)
    {
        currentValue += amount;
    }

    public Icon Thumbnail
    {
        get { return icon; }
        set { icon = value; }
    }

    public AttributeType Type
    {
        get { return attributeType; }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
