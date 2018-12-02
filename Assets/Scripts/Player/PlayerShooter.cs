using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class PlayerShooter : WeaponController
    {
        #region Update.
        private void Update()
        {
            if (GameManager._instance._inputController._mouseWheelDown)
            {
                SwitchWeapon(-1);
            }

            if (GameManager._instance._inputController._mouseWheelUp)
            {
                SwitchWeapon(1);
            }

            if (!_canFire)
            {
                return;
            }

            if (GameManager._instance._inputController._fire2 == true &&
                GameManager._instance._inputController._fire1 == true)
            {
                _activeWeapon.Fire();
            }
        }
        #endregion
    }
}

