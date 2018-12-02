using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class PickUpItem : MonoBehaviour
    {
        #region Variale.
        //// Class.
        //[SerializeField] private AudioController _audioPickupItems;
        #endregion

        #region On Trigger Enter.
        //private void OnTriggerEnter(Collider collider)
        //{
        //    if (collider.tag != "Player")
        //    {
        //        return;
        //    }

        //    if (GameManager._instance._inputController._pickupItems)
        //    {
        //        _audioPickupItems.Play();
        //        PickUp(collider.transform);
        //    }
            
        //}
        #endregion

        #region On Trigger Stay.
        private void OnTriggerStay(Collider collider)
        {
            if (collider.tag != "Player")
            {
                return;
            }

            
            if (GameManager._instance._inputController._pickupItems)
            {
                PickUp(collider.transform);
            }
        }
        #endregion

        #region On Pick Up.
        public virtual void OnPickUp(Transform item)
        {
            // Nothing for now.
        }
        #endregion

        #region Pick Up.
        private void PickUp(Transform item)
        {
            OnPickUp(item);
        }
        #endregion
    }
}

