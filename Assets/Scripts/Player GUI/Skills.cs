using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStats
{
    [CreateAssetMenu(menuName = "Rpg Generator/Player/Create Skill")]
    public class Skills : ScriptableObject
    {
        public string Description;
        public Sprite Icon;
        public int LevelNeeded;
        public int XpNeeded;

        public List<PlayerAttributes> AffectedAttributes = new List<PlayerAttributes>();

        //Public method to set the values in the skills UI
        public void SetValues(GameObject SkillDisplayObject, PlayerStats Player)
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
                    SD.skillAttributes.text = AffectedAttributes[0].attribute.ToString();

                if (SD.skillAttrAmount)
                    SD.skillAttrAmount.text = "+" +  AffectedAttributes[0].amount.ToString();
            }
        }
        //check if the player is able to get the skill
        public bool CheckSkills(PlayerStats Player)
        {
            //check if  player is the right level
            if (Player.PlayerLevel < LevelNeeded)
                return false;            

            if (Player.PlayerXP < XpNeeded)            
                return false;

            return true;
        }

        //check if the player already has the skill
        public bool EnableSkill(PlayerStats Player)
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

        }

        public bool GetSkill(PlayerStats Player)
        {
            int i = 0;
            //List through the Skill's attributes
            List<PlayerAttributes>.Enumerator attributes = AffectedAttributes.GetEnumerator();
            while (attributes.MoveNext())
            {
                //List through the Player Attributes and match  with Skill atribute
                List<PlayerAttributes>.Enumerator PlayerAttr = Player.attributes.GetEnumerator();
                while (PlayerAttr.MoveNext())
                {
                    if (attributes.Current.attribute.name.ToString() == PlayerAttr.Current.attribute.name.ToString())
                    {
                        //update the player attributes
                        PlayerAttr.Current.amount += attributes.Current.amount;
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
        }



    }
}
