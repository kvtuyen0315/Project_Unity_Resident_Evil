using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class WeaponController : MonoBehaviour
    {
        #region Variable.
        // bool.
        //private bool _isFiring = true;
        [HideInInspector] public bool _canFire;

        // float.
        [SerializeField] private float _weaponSwitchTime;

        // int.
        private int _currentWeaponIndex;

        // Class.
        private Shooter[] _weapon;
        private Shooter m_ActiveWeapon;
        public Shooter _activeWeapon
        {
            get
            {
                return m_ActiveWeapon;
            }
        }

        // Tranform.
        private Transform _weaponHolster;

        // System Action.
        public event System.Action<Shooter> _onWeaponSwitch;

        #endregion

        #region Awake.
        private void Awake()
        {
            _canFire = true;

            _weaponHolster = transform.Find("Weapons");
            _weapon = _weaponHolster.GetComponentsInChildren<Shooter>();

            if (_weapon.Length > 0)
            {
                Equip(0);
            }
        }
        #endregion

        #region Deactivate Weapons.
        private void DeactivateWeapons()
        {
            for (int i = 0; i < _weapon.Length; i++)
            {
                _weapon[i].gameObject.SetActive(false);
                _weapon[i].transform.SetParent(_weaponHolster);
            }
        }
        #endregion

        #region Switch Weapon.
        internal void SwitchWeapon(int direction)
        {
            _canFire = false;

            _currentWeaponIndex += direction;
            if (_currentWeaponIndex > _weapon.Length - 1)
            {
                _currentWeaponIndex = 0;
            }

            if (_currentWeaponIndex < 0)
            {
                _currentWeaponIndex = _weapon.Length - 1;
            }

            GameManager._instance._timer.Add(() =>
            {
                Equip(_currentWeaponIndex);
            }, _weaponSwitchTime);

        }
        #endregion

        #region Equip.
        internal void Equip(int index)
        {
            DeactivateWeapons();
            _canFire = true;
            m_ActiveWeapon = _weapon[index];
            m_ActiveWeapon.Equip();
            _weapon[index].gameObject.SetActive(true);

            if (_onWeaponSwitch != null)
            {
                _onWeaponSwitch(_activeWeapon);
            }
        }
        #endregion
    }
}

