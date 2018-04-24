using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* Base class that the player can derive from to include stats. */

public class CharacterStats : MonoBehaviour
{

    [Header("Main UI elements")]
    public Text healthText;
    public Image healthImage;
    public Text manaText;
    public Image manaImage;
    public Text characterName;
    public Text characterLvl;

    [Header("Main  Stats")]
    public string Name;        
    public int maxHP = 100;
    public int currentHp;
    public int healthRegen = 2;
    public int maxMana = 50;
    public int currentMana;
    public int manaRegen = 1;

    [Header("Other Stats")]
    public List<Stat> stats = new List<Stat>();
    public Stat Armor;
    public Stat AttackDamage;
    public Stat AttackSpeed;
    public Stat BockChance;
    public Stat CritChance;
    public Stat Dexterity;
    public Stat Haste;
    public Stat MagicPenatration;
    public Stat Strength;
    public Stat Versatility;
    public Stat Vitality;
    public Stat Wisdom;


    #region oldStuff
    /*
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
    public List<Stat> stats = new List<Stat>();

    [Header("Player Skills Enabled")]
    public List<Skills> PlayerSkills = new List<Skills>();        

    //Delegates for listerers
    public delegate void OnXpChange();
    public event OnXpChange onXpChange;

    public delegate void OnLevelChange();
    public event OnLevelChange onLevelChange;

    */
    #endregion



    private void Awake()
    {
        if (characterName != null)        
            characterName.text = Name;
        
        currentHp = maxHP;
        currentMana = maxMana;
        
        //update the player GUI at the begin. //TODO will be changed if you can save the game and get back in the game. 
        UpdatePlayerGUI();
    }

    private void Update()
    {
        
    }




    //Function that is called when the player takes damage or heals himself.
    public void TakeDamage(int damage)
    {
        // Subtract the armor value
        damage -= Armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        // Damage the character
        currentHp -= damage;
        UpdatePlayerGUI();
        Debug.Log(transform.name + " takes " + damage + " damage.");

        // If health reaches zero
        if (currentHp <= 0)
        {
            currentHp = 0;
            Die();
        }           
    }
    //This will update the player GUI elements
    public void UpdatePlayerGUI()
    {
        if (healthText != null)
        {
            //Set the player Current and Max HP text + Bar Size
            float _curHP = currentHp;
            float _maxHP = maxHP;//making a float .

            healthImage.fillAmount = _curHP / _maxHP;
            healthText.text = maxHP.ToString() + "/" + currentHp;
        }

        //Set the player Current and Max Mana text + Bar Size
        if (manaText != null)
        {
            //Set the player Current and Max HP text + Bar Size
            float _curMana = currentMana;
            float _maxMana = maxMana;

            manaImage.fillAmount = _curMana / _maxMana;
            manaText.text = maxMana.ToString() + "/" + currentMana;
        }

        //characterLvl.text = PlayerLevel.ToString();



    }

    public virtual void Die()
    {
        //Die in some way
        //This method is meant to be overwritten
        Debug.Log("Player Died ");
    }


    /*//Just some temp methods to help test
    public void UpdateLevel(int amount)
    {
        PlayerLevel += amount;            
    }

    public void UpdateXp(int amount)
    {
        PlayerXP += amount;
    }*/
}

