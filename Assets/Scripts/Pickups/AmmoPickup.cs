using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class AmmoPickup : PickUpItem
    {
        #region Variable.
        // enum.
        [SerializeField] private WeaponType _weaponType;

        // int.
        [SerializeField] private int _amount;

        // float
        [SerializeField] private float _respawnTime;

        // Class.
        [SerializeField] private AudioController _audioPickupItems;
        #endregion

        #region On Pick Up.
        public override void OnPickUp(Transform item)
        {
            Debug.Log("F");

            Container playerInventory = item.GetComponentInChildren<Container>();

            playerInventory.Put(_weaponType.ToString(), _amount);

            item.GetComponent<Player>()._playerShooter._activeWeapon._reloader.HandleOnAmmoChanged();

            _audioPickupItems.Play();
            GameManager._instance._respawner.Despawn(gameObject, _respawnTime);
        }
        #endregion
    }
}

