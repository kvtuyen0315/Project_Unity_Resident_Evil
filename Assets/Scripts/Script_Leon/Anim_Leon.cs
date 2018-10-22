using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Anim_Leon : MonoBehaviour
    {
        // Float for Walk & Run.
        [Range(0.0f, 1.0f)]
        public float Vertical;
        private float weight;

        // Pistol Aims
        public bool _isPistolAims;

        // Animation.
        private Animator anim;

        // Use this for initialization
        void Start()
        {
            // Set Animation.
            anim = GetComponent<Animator>();

            // Set Pistol Aims.
            _isPistolAims = false;

            anim.SetInteger("Both_Hand", 3);
        }

        // Update is called once per frame
        void Update()
        {
            // Set change float Animation.
            anim.SetFloat("vertical", Vertical);
            
            if (_isPistolAims == true)
            {
                weight += 0.05f;
                if (weight >= 1.0f)
                {
                    weight = 1.0f;
                }
            }
            else
            {
                weight -= 0.05f;
                if (weight <= 0.0f)
                {
                    weight = 0.0f;
                }
            }
            anim.SetLayerWeight(3, weight);

            // Set change bool Animation.
            anim.SetBool("Is_Pistol_Aims", _isPistolAims);
        }

        
    }

}

