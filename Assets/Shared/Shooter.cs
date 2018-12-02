using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Shooter : MonoBehaviour
    {
        #region Variable.
        // float.
        [SerializeField] private float _rateOfFire;
        [SerializeField] private float _nextFireAllowed;

        // bool.
        public bool _canFire;

        // Particle System.
        private ParticleSystem _muzzleFireParticleSystem;

        // Transform.
        [SerializeField] private Transform _hand;
        [SerializeField] private Transform _muzzle;
        [SerializeField] private Transform _startBullet;
        [SerializeField] private Transform _aimTarget;

        // Class.
        [SerializeField] private Projectitle _projectitle;

        public WeaponReloader _reloader;

        [SerializeField] private AudioController _audioReload;
        [SerializeField] private AudioController _audioFire;
        [SerializeField] private AudioController _audioEmtyAmmo;

        #endregion

        #region Equip.
        public void Equip()
        {
            transform.SetParent(_hand);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        #endregion

        #region Awake.
        private void Awake()
        {
            _muzzle = transform.Find("Model/Muzzle");
            _startBullet = transform.Find("Model/StartBullet");
            _reloader = GetComponent<WeaponReloader>();
            _muzzleFireParticleSystem = _muzzle.GetComponent<ParticleSystem>();
        }
        #endregion

        #region Fire Effect.
        private void FireEffect()
        {
            if (_muzzleFireParticleSystem == null)
            {
                return;
            }

            _muzzleFireParticleSystem.Play();
        }
        #endregion

        #region Reload.
        public void Reload()
        {
            if (_reloader == null)
            {
                return;
            }
            _reloader.Reload();
            _audioReload.Play();
        }
        #endregion

        #region Fire.
        public virtual void Fire()
        {
            _canFire = false;

            if (Time.time < _nextFireAllowed)
            {
                return;
            }

            if (_reloader != null)
            {
                if (_reloader._isReloading)
                {
                    return;
                }

                if (_reloader._roundsRemainingInClip == 0)
                {
                    _audioEmtyAmmo.Play();
                    return;
                }

                _reloader.TakeFromClip(1);
            }
            
            _nextFireAllowed = Time.time + _rateOfFire;

            _startBullet.LookAt(_aimTarget); // For Crosshair.

            // Effect.
            FireEffect();

            // Clone bullet.
            Instantiate(_projectitle, _startBullet.position, _startBullet.rotation);
            // Audio sound fire.
            _audioFire.Play();
            _canFire = true;

        }
        #endregion
    }
}