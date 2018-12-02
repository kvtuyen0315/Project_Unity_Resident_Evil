using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class WeaponReloader : MonoBehaviour
    {
        #region Variable.
        // int.
        [SerializeField] private int _maxAmmo; 
        [SerializeField] private int _clipSize;
        [SerializeField] private int m_ShotsFiredInClip;
        public int _shotsFiredInClip
        {
            get
            {
                return m_ShotsFiredInClip;
            }
        }

        public int _roundsRemainingInClip
        {
            get
            {
                return _clipSize - m_ShotsFiredInClip;
            }
        }

        public int _roundsRemainingInVentory
        {
            get
            {
                return _inventory.GetAmountRemaining(_containerItemId);
            }
        }

        // float.
        [SerializeField] private float _reloadTime;

        // bool.
        private bool m_IsReloading;
        public bool _isReloading
        {
            get
            {
                return m_IsReloading;
            }
        }

        private bool _reload = true;

        // enum.
        [SerializeField] private WeaponType m_WeaponType;
        public WeaponType _weaponType
        {
            get
            {
                return m_WeaponType;
            }
        }

        // Class.
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private Container _inventory;

        // System.
        private System.Guid _containerItemId;

        public event System.Action _onAmmoChanged; 

        #endregion

        #region Awake.
        private void Awake()
        {
            _inventory._onContainerReady += () =>
            {
                _containerItemId = _inventory.Add(_weaponType.ToString(), _maxAmmo);
            };
        }
        #endregion

        #region Reload.
        public void Reload()
        {
            if (m_IsReloading)
            {
                return;
            }

            m_IsReloading = true;

            _playerAnimation._getAnimator.SetBool("Reload", _reload);

            GameManager._instance._timer.Add(() =>
            {
                ExecuteReload(_inventory.TakeFromContainer(_containerItemId, _clipSize - _roundsRemainingInClip));
            }, _reloadTime);

            
        }
        #endregion

        #region Execute Reload.
        private void ExecuteReload(int amount)
        {
            m_IsReloading = false;
            m_ShotsFiredInClip -= amount;

            _playerAnimation._getAnimator.SetBool("Reload", !_reload);

            HandleOnAmmoChanged();
        }
        #endregion

        #region Take from clip.
        public void TakeFromClip(int ammo)
        {
            m_ShotsFiredInClip += ammo;

            HandleOnAmmoChanged();
        }
        #endregion

        #region Handle On Ammo Changed.
        public void HandleOnAmmoChanged()
        {
            if (_onAmmoChanged != null)
            {
                _onAmmoChanged();
            }
        }
        #endregion
    }
}

