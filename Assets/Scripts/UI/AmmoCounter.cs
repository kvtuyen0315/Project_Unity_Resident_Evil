using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SA
{
    public class AmmoCounter : MonoBehaviour
    {
        #region Variable.
        // int.
        private int _amountInInventory;
        private int _amountInClip;

        // Text.
        [SerializeField] private Text _text;

        // Class.
        private PlayerShooter  _playerShooter;
        private WeaponReloader _reloader;
        #endregion

        #region Awake.
        private void Awake()
        {
            GameManager._instance._onLocalPlayerJoined += HandleOnlocalPlayerJoined;
        }
        #endregion

        #region Handle On local Player Joined.
        private void HandleOnlocalPlayerJoined(Player player)
        {
            _playerShooter = player._playerShooter;
            _playerShooter._onWeaponSwitch += HandleOnWeaponSwitch;

        }
        #endregion

        #region Handle On Weapon Switch.
        private void HandleOnWeaponSwitch(Shooter activeWeapon)
        {
            _reloader = activeWeapon._reloader;
            _reloader._onAmmoChanged += HandleOnAmmoChanged;
            HandleOnAmmoChanged();
        }
        #endregion

        #region Handle On Ammo Changed.
        private void HandleOnAmmoChanged()
        {
            _amountInInventory  = _reloader._roundsRemainingInVentory;
            _amountInClip       = _reloader._roundsRemainingInClip;
            _text.text = string.Format("{0}/{1}", _amountInClip, _amountInInventory);
        }
        #endregion
    }
}

