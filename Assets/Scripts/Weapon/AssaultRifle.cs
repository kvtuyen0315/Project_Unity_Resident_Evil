using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class AssaultRifle : Shooter
    {
        #region Variable.
        // Class.
        [SerializeField] private WeaponReloader _weaponReloader;
        #endregion

        #region Override.
        public override void Fire()
        {
            base.Fire();

            if (_canFire)
            {
                // We fire the gun.
            }
        }
        #endregion

        #region Update.
        private void Update()
        {
            if (GameManager._instance._inputController._reload &&
                _weaponReloader._shotsFiredInClip > 0)
            {
                if (_weaponReloader._isReloading == true)
                {
                    return;
                }
                Reload();
            }
        }
        #endregion

    }
}

