using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerStats
{
    public class SkillDisplay : MonoBehaviour
    {
        // Get the Scriptable object for Skill
        public Skills skill;
        //Get the UI Components
        public Text skillName;
        public Text skillDescription;
        public Image skillIcon;
        public Text skillLevel;
        public Text skillXpNeeded;
        public Text skillAttributes;
        public Text skillAttrAmount;

        [SerializeField]
        private PlayerStats m_PlayerHandler;
        // Use this for initialization
        void Start()
        {
            m_PlayerHandler = this.GetComponentInParent<PlayerHandler>().Player;
            //Listener for the xp change
            m_PlayerHandler.onXpChange += ReactToChange;
            //Listener for the level change
            m_PlayerHandler.onLevelChange += ReactToChange;

            if (skill)            
                skill.SetValues(this.gameObject, m_PlayerHandler);

            EnableSkills();
            
        }

        
        public void EnableSkills()
        {
            //if the player has the skill already  then show it's enabled
            if (m_PlayerHandler && skill && skill.EnableSkill(m_PlayerHandler))
            {
                TurnOnSkillIcon();
            }
            //if the player has the skill already, then show it as enabled
            else if (m_PlayerHandler && skill && skill.CheckSkills(m_PlayerHandler))
            {
                this.GetComponent<Button>().interactable = true;
                this.transform.Find("IconParent").Find("Disabled").gameObject.SetActive(false);
            }
            else
            {
                TurnOffSkillIcon();
            }
        }

        private void OnEnable()
        {
            EnableSkills();
        }

        //Method to be used when you click the skill Icon
        public void GetSkill()
        {
            if (skill.GetSkill(m_PlayerHandler))
            {
                TurnOnSkillIcon();
            }
        }

        //Turn on Skill Icon -  stop it from being clickable  and disable  the UI elements that make it change the color
        private void TurnOnSkillIcon()
        {
            this.GetComponent<Button>().interactable = false;
            this.transform.Find("IconParent").Find("Available").gameObject.SetActive(false);
            this.transform.Find("IconParent").Find("Disabled").gameObject.SetActive(false);
        }

        //Turn off Skill Icon -  stop it from being clickable  and enable  the UI elements  that make it change the color
        private void TurnOffSkillIcon()
        {
            this.GetComponent<Button>().interactable = false;
            this.transform.Find("IconParent").Find("Available").gameObject.SetActive(true);
            this.transform.Find("IconParent").Find("Disabled").gameObject.SetActive(true);
        }

        //event when listener is woken
        void ReactToChange()
        {
            EnableSkills();
        }
    }
}
