using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerStats
{
    public class PlayerStats : MonoBehaviour
    {

        [Header("Main Player UI elements")]
        public Text healthText;
        public Image healthImage;
        public Text manaText;
        public Image manaImage;
        public Text characterName;
        public Text characterLvl;

        [Header("Main Player Stats")]
        public string PlayerName;        
        public int PlayerMaxHp = 100;
        private int PlayerCurrentHp;
        public int PlayerMaxMana = 50;
        private int PlayerCurrentMana;


        [SerializeField]
        private int m_PlayerXP = 0;
        public int PlayerXP
        {
            get { return m_PlayerXP; }
            set
            {
                m_PlayerXP = value;

                if (onXpChange != null)
                    onXpChange();
            }
        }
        //set listener for player level
        [SerializeField]
        private int m_PlayerLevel = 1;
        public int PlayerLevel
        {
            get { return m_PlayerLevel; }
            set
            {
                m_PlayerLevel = value;

                if (onLevelChange != null)
                    onLevelChange();
            }
        }

        [Header(" Player Attributes")]
        public List<PlayerAttributes> attributes = new List<PlayerAttributes>();

        [Header("Player Skills Enabled")]
        public List<Skills> PlayerSkills = new List<Skills>();        

        //Delegates for listerers
        public delegate void OnXpChange();
        public event OnXpChange onXpChange;

        public delegate void OnLevelChange();
        public event OnLevelChange onLevelChange;

        private void Start()
        {
            PlayerCurrentHp = PlayerMaxHp;
            PlayerCurrentMana = PlayerMaxMana;
            characterName.text = PlayerName;
            //update the player GUI at the begin. //TODO will be changed if you can save the game and get back in the game. 
            UpdatePlayerGUI();
        }


        //Just some temp methods to help test
        public void UpdateLevel(int amount)
        {
            PlayerLevel += amount;
            
        }

        public void UpdateXp(int amount)
        {
            PlayerXP += amount;
        }
        //Function that is called when the player takes damage or heals himself.
        public void TakeDamage(int amount)
        {
            PlayerCurrentHp -= amount;
            UpdatePlayerGUI();
        }
        //This will update the player GUI elements
        public void UpdatePlayerGUI()
        {
            //Set the player Current and Max HP text + Bar Size
            healthText.text = PlayerCurrentHp.ToString();
            healthImage.fillAmount = PlayerCurrentHp / PlayerMaxHp;
            healthText.text = PlayerMaxHp.ToString() + "/" + PlayerCurrentHp;
            //Set the player Current and Max Mana text + Bar Size
            manaText.text = PlayerCurrentMana.ToString();
            manaImage.fillAmount = PlayerCurrentMana / PlayerMaxMana;
            manaText.text = PlayerMaxMana.ToString() + "/" + PlayerCurrentMana;

            characterLvl.text = PlayerLevel.ToString();



        }
    }
}
