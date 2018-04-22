using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastSpell : MonoBehaviour {

    public Transform magicSpawn;
    Spell spell;
    public List<Spell> spellList = new List<Spell>();
    public float[] coolDownTimer;
    public Image[] fillImage;

	// Use this for initialization
	void Start () {
        spell = (Spell)Resources.Load("Spells/" + gameObject.name, typeof(Spell));
        List<Spell> spellDataBase = GameObject.Find("SpellManager").GetComponent<SpellManager>().spellList;

        for (int i = 0; i < spellDataBase.Count; i++)
        {
            spellList.Add(spellDataBase[i]);
        }
	}

    private void Update()
    {
        CheckCooldown();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (coolDownTimer[0] <= 0f && spellList[0].spellManaCost < GetComponentInParent<PlayerStats>().currentMana)
            {
                GetComponent<PlayerStats>().currentMana -= spellList[0].spellManaCost;
                GetComponent<PlayerStats>().UpdatePlayerGUI();
                CastMagic(spellList[0]);
                coolDownTimer[0] += spellList[0].spellCooldown;
                fillImage[0].fillAmount = 1.0f;
                if (spell != null)
                    CastMagic(spell);                
            }            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (coolDownTimer[1] <= 0f && spellList[1].spellManaCost < GetComponentInParent<PlayerStats>().currentMana)
            {
                GetComponent<PlayerStats>().currentMana -= spellList[1].spellManaCost;
                GetComponent<PlayerStats>().UpdatePlayerGUI();

                CastMagic(spellList[1]);
                coolDownTimer[1] += spellList[0].spellCooldown;
                fillImage[1].fillAmount = 1.0f;
                if (spell != null)
                    CastMagic(spell);
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (coolDownTimer[2] <= 0f && spellList[2].spellManaCost < GetComponentInParent<PlayerStats>().currentMana)
            {
                GetComponent<PlayerStats>().currentMana -= spellList[2].spellManaCost;
                GetComponent<PlayerStats>().UpdatePlayerGUI();

                CastMagic(spellList[2]);
                coolDownTimer[2] += spellList[2].spellCooldown;
                fillImage[2].fillAmount = 1.0f;
                if (spell != null)
                    CastMagic(spell);
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (coolDownTimer[3] <= 0f && spellList[3].spellManaCost < GetComponentInParent<PlayerStats>().currentMana)
            {
                GetComponent<PlayerStats>().currentMana -= spellList[3].spellManaCost;
                GetComponent<PlayerStats>().UpdatePlayerGUI();

                CastMagic(spellList[3]);
                coolDownTimer[3] += spellList[3].spellCooldown;
                fillImage[3].fillAmount = 1.0f;
                if (spell != null)
                    CastMagic(spell);
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (coolDownTimer[4] <= 0f && spellList[4].spellManaCost < GetComponentInParent<PlayerStats>().currentMana)
            {
                GetComponent<PlayerStats>().currentMana -= spellList[4].spellManaCost;
                GetComponent<PlayerStats>().UpdatePlayerGUI();

                CastMagic(spellList[4]);
                coolDownTimer[4] += spellList[4].spellCooldown;
                fillImage[4].fillAmount = 1.0f;
                if (spell != null)
                    CastMagic(spell);
            }

        }
    }

    void CastMagic(Spell spell)
    {
        if (spell.spellPrefab == null)
        {
            Debug.LogWarning("Spell prefab is null! Must assign as spell prefab!");
            return;
        }
        else
        {
            GameObject spellObject = Instantiate(spell.spellPrefab, magicSpawn.position, magicSpawn.rotation);
            spellObject.AddComponent<Rigidbody>();
            spellObject.GetComponent<Rigidbody>().useGravity = false;
            spellObject.GetComponent<Rigidbody>().velocity = spellObject.transform.forward * spell.projectileSpeed;
            spellObject.name = spell.spellName;
            spellObject.transform.parent = GameObject.Find("SpellManager").transform;

            Destroy(spellObject, 2f);

        }
        
    }

    void CheckCooldown()
    {
        if (coolDownTimer != null)
        {
            for (int i = 0; i < coolDownTimer.Length; i++)
            {
                if (coolDownTimer[i] > 0)
                {
                    coolDownTimer[i] -= Time.deltaTime;
                }
                if (coolDownTimer[i] < 0)
                {
                    coolDownTimer[i] = 0;

                }

                fillImage[i].fillAmount -= 1.0f / spellList[0].spellCooldown * Time.deltaTime;
            }
        }
        
    }
}
