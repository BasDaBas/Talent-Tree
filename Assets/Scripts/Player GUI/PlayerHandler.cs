using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStats
{
    public class PlayerHandler : MonoBehaviour
    {

        public PlayerStats Player;

        [SerializeField]
        private Canvas[] m_canvas;
        private bool m_SeeCanvas;       

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("tab"))
            {
                if (m_canvas[0])
                {
                    m_SeeCanvas = !m_SeeCanvas;
                    m_canvas[0].gameObject.SetActive(m_SeeCanvas);
                }
            }

            if (Input.GetKeyDown("c"))
            {
                if (m_canvas[1])
                {
                    m_SeeCanvas = !m_SeeCanvas;
                    m_canvas[1].gameObject.SetActive(m_SeeCanvas);
                }
            }
        }
    }
}
