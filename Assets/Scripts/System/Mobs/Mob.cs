using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {

    [SerializeField] string mobName;
    [SerializeField] int curHealth;
    [SerializeField] int maxHealth;
    [SerializeField] int level;
    [SerializeField] string mobTag = "Enemy";

    [SerializeField] GameObject prefab;

    [SerializeField] Icon icon;
    [SerializeField] List<Buff> buffs;
    [SerializeField] MobTypes mobType;
    [SerializeField] MobRanks mobRank;

    //loot table entry;

    public string Name
    {
        get { return mobName; }
        set { mobName = value; }            
    }

    private void Awake()
    {
        gameObject.tag = mobTag;
    }

    public int CurrentHealth
    {
        get { return curHealth; }
        set
        {
            if (value < 0)
                curHealth = 0;
            else if (value > maxHealth)
                curHealth = maxHealth;
            else
                curHealth = value;
        }   
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set
        {
            if (value < 1)
                maxHealth = 1;
            else
                maxHealth = value;                
        }
    }

    public int Level
    {
        get { return level; }
        set
        {
            if (value < 0)
                level = 0;
            else
                level = value;
        }
    }

    public void LevelUp()
    {
        level++;
    }

    public Icon Thumbnail
    {
        get { return icon; }
        set { icon = value; }
    }

    public MobTypes MobType
    {
        get { return mobType; }
        set { mobType = value; }
    }

    public MobRanks MobRank
    {
        get { return mobRank; }
        set { mobRank = value; }
    }

    public List<Buff> Buffs
    {
        get { return buffs; }
        set { buffs = value; }
    }

    public void AddBuff(Buff b)
    {
        buffs.Add(b);
    }


    //Array of Buffs
}
