using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpellCreator : EditorWindow {

    [MenuItem("Spell Maker/Spell Wizard")]
    static void Init()
    {
        SpellCreator spellWindow = (SpellCreator)CreateInstance(typeof(SpellCreator));
        spellWindow.Show();
    }

    Spell tempSpell = null;
    SpellManager spellManager = null;

    private void OnGUI()
    {
        if (spellManager = null)
        {
            spellManager = GameObject.Find("SpellManager").GetComponent<SpellManager>();
        }
        if (tempSpell)
        {
            tempSpell.spellName = EditorGUILayout.TextField("Spell Name", tempSpell.spellName);
            tempSpell.spellPrefab = (GameObject)EditorGUILayout.ObjectField("Spell Prefab", tempSpell.spellPrefab, typeof(GameObject),false);
            tempSpell.SpellCollisionParticle = (GameObject)EditorGUILayout.ObjectField("Spell Collision Effect", tempSpell.SpellCollisionParticle ,typeof(GameObject), false);
            tempSpell.spellIcon = (Texture2D)EditorGUILayout.ObjectField("Spell Icon", tempSpell.spellIcon, typeof(Texture2D), false);
            tempSpell.spellManaCost = EditorGUILayout.IntField("Mana Cost", tempSpell.spellManaCost);
            tempSpell.spellMinDamage = EditorGUILayout.IntField("Min Damage", tempSpell.spellMinDamage);
            tempSpell.spellMaxDamage = EditorGUILayout.IntField("Max Damage", tempSpell.spellMaxDamage);
            tempSpell.projectileSpeed = EditorGUILayout.IntField("Projectile Speed", tempSpell.projectileSpeed);
            tempSpell.spellCooldown = EditorGUILayout.IntField("Spell Cooldown", tempSpell.spellCooldown);
            tempSpell.spellCastSpeed = EditorGUILayout.FloatField("Cast Speed", tempSpell.spellCastSpeed);
        }

        EditorGUILayout.Space();
        if (tempSpell == null)
        {
            if (GUILayout.Button("Create Spell"))
            {
                tempSpell = CreateInstance<Spell>();
            }
        }
        else
        {
            if (GUILayout.Button("Create Scriptable Object"))
            {
                AssetDatabase.CreateAsset(tempSpell, "Assets/Spells/" + tempSpell.spellName + ".asset");
                AssetDatabase.SaveAssets();
                spellManager.spellList.Add(tempSpell);  
                Selection.activeObject = tempSpell;

                tempSpell = null;
            }

            if (GUILayout.Button("Reset"))
            {
                Reset();
            }
        }
    }

    void Reset()
    {
        if (tempSpell)
        {
            tempSpell.spellName = "";
            tempSpell.spellIcon = null;
            tempSpell.spellManaCost = 0;
            tempSpell.spellMinDamage = 0;
            tempSpell.spellMaxDamage = 0;
            tempSpell.spellPrefab = null;
            tempSpell.SpellCollisionParticle = null;
            tempSpell.spellCooldown = 0;
            tempSpell.spellCastSpeed = 0;
        }
    }
}
