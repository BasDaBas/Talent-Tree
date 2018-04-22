using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class AttributesDisplay : MonoBehaviour
{
    // Get the Scriptable object for Skill
    public Attributes attributes;
    //Get the UI Components;
    public Text attributeText;
    public Text attributeAmount;


    [SerializeField]
    private CharacterStats Player;

    // Use this for initialization
    void Start()
    {
        Player = this.GetComponentInParent<PlayerHandler>().Player;

        attributeText.text = attributes.name;

        UpdateAttributes();
    }

    private void OnEnable()
    {
        Player = this.GetComponentInParent<PlayerHandler>().Player;
        UpdateAttributes();
    }

    public void UpdateAttributes()
    {
        //List through the Player Attributes and match  with Skill atribute
        List<Stat>.Enumerator PlayerAttr = Player.stats.GetEnumerator();
        while (PlayerAttr.MoveNext())
        {
            if (attributes.name == PlayerAttr.Current.stats.name.ToString())
            {
                attributeAmount.text = PlayerAttr.Current.baseValue.ToString();
            }
        }
    }
}*/

