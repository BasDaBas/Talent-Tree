using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerStats
{

    public class AttributesDisplay : MonoBehaviour
    {
        // Get the Scriptable object for Skill
        public Attributes attributes;
        //Get the UI Components;
        public Text attributeText;
        public Text attributeAmount;


        [SerializeField]
        private PlayerStats Player;

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
            List<PlayerAttributes>.Enumerator PlayerAttr = Player.attributes.GetEnumerator();
            while (PlayerAttr.MoveNext())
            {
                if (attributes.name == PlayerAttr.Current.attribute.name.ToString())
                {
                    attributeAmount.text = PlayerAttr.Current.amount.ToString();
                }
            }
        }
    }
}
