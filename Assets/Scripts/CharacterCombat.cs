using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{

    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    public float attackDelay = .6f;

    public event System.Action OnAttack;

    private float healthRegenTimer = 0.0f;
    private float manaRegenTimer = 0.0f;
    


    CharacterStats myStats;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;

        //Health Regen
        if (myStats.currentHp < myStats.maxHP)
        {
            healthRegenTimer += Time.deltaTime;
            if (healthRegenTimer > 1.0f)
            {
                myStats.currentHp += Mathf.RoundToInt(myStats.healthRegen);
                healthRegenTimer -= 1.0f; //reset the timer
                if (myStats.currentHp > myStats.maxHP)
                {
                    myStats.currentHp = myStats.maxHP;                    
                }
                myStats.UpdatePlayerGUI();
            }
        }                 
        

        //Mana Regen
        if (myStats.currentMana < myStats.maxMana)
        {
            
            manaRegenTimer += Time.deltaTime;
            if (manaRegenTimer > 1.0f)
            {
                myStats.currentMana += Mathf.RoundToInt(myStats.manaRegen);
                manaRegenTimer -= 1.0f;
                if (myStats.currentMana > myStats.maxMana)
                {
                    myStats.currentMana = myStats.maxMana;
                }

                myStats.UpdatePlayerGUI();
            }
        }
        

    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed;
        }

    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}
