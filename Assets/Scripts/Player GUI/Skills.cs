using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Rpg Generator/Player/Create Skill")]
public class Skills : ScriptableObject
{
    public string Description;
    public Sprite Icon;
    public int LevelNeeded;
    public int XpNeeded;

    public List<Stat> AffectedAttributes = new List<Stat>();

    /*//Public method to set the values in the skills UI
    public void SetValues(GameObject SkillDisplayObject, CharacterStats Player)
    {            

        //Error handling - make sure  that a SO is used
        if (SkillDisplayObject)
        {
            SkillDisplay SD = SkillDisplayObject.GetComponent<SkillDisplay>();
            SD.skillName.text = name;
            if (SD.skillDescription)                
                SD.skillDescription.text = Description;

            if (SD.skillIcon)
                SD.skillIcon.sprite = Icon;

            if (SD.skillLevel)
                SD.skillLevel.text = LevelNeeded.ToString();

            if (SD.skillXpNeeded)
                SD.skillXpNeeded.text = XpNeeded.ToString() + "XP";

            if (SD.skillAttributes)
                SD.skillAttributes.text = AffectedAttributes[0].stats.ToString();

            if (SD.skillAttrAmount)
                SD.skillAttrAmount.text = "+" +  AffectedAttributes[0].baseValue.ToString();
        }
    }*/
    
    /*//check if the player is able to get the skill
    public bool CheckSkills(CharacterStats Player)
    {
        //check if  player is the right level
        if (Player.PlayerLevel < LevelNeeded)
            return false;            

        if (Player.PlayerXP < XpNeeded)            
            return false;

        return true;
    }*/

    /*//check if the player already has the skill
    public bool EnableSkill(CharacterStats Player)
    {
        //go trough all the skills the player currently has
        List<Skills>.Enumerator skills = Player.PlayerSkills.GetEnumerator();
        while (skills.MoveNext())
        {
            var CurrSkill = skills.Current;
            if (CurrSkill.name == this.name)
            {
                return true;
            }
        }
        return false;

    }*/

    /*public bool GetSkill(CharacterStats Player)
    {
        int i = 0;
        //List through the Skill's attributes
        List<Stat>.Enumerator attributes = AffectedAttributes.GetEnumerator();
        while (attributes.MoveNext())
        {
            //List through the Player Attributes and match  with Skill atribute
            List<Stat>.Enumerator PlayerAttr = Player.stats.GetEnumerator();
            while (PlayerAttr.MoveNext())
            {
                if (attributes.Current.stats.name.ToString() == PlayerAttr.Current.stats.name.ToString())
                {
                    //update the player attributes
                    PlayerAttr.Current.baseValue += attributes.Current.baseValue;
                    //Mark that an attribute was updated
                    i++;
                }
            }
            if (i > 0)
            {
                //reduce the xp from the player
                Player.PlayerXP -= this.XpNeeded;
                //add to the list of Skills
                Player.PlayerSkills.Add(this);
                return true;
            }
        }
        return false;
    }*/



}

