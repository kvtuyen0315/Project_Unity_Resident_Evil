using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Laser2 : MonoBehaviour
    {
        #region Variable
        // float.
        public float _distanceiaDoRaio;

        // bool.
        private bool _activeLaser;

        // Line Renderer.
        private LineRenderer _lrLaser;
        public Transform muzzle;
        private RaycastHit _hit;

        // Class.
        private InputController m_PlayerInput;
        public InputController _playerInput
        {
            get
            {
                if (m_PlayerInput == null)
                {
                    m_PlayerInput = GameManager._instance._inputController;
                }
                return m_PlayerInput;
            }
        }

        #endregion

        #region Start.
        private void Start()
        {
            _lrLaser = GetComponent<LineRenderer>();
        }
        #endregion

        #region Is On Active.
        private void IsOnActive()
        {
            if (_playerInput._fire2)
            {
                if (_activeLaser == true)
                {
                    _lrLaser.enabled = true;
                    _activeLaser = false;
                }
            }
            else
            {
                _lrLaser.enabled = false;
                _activeLaser = true;
            }
        }
        #endregion

        #region Update.
        private void Update()
        {
            if (Physics.Raycast(transform.position, transform.forward, out _hit, _distanceiaDoRaio))
            {
                //_lrLaser.SetPosition(1, transform.InverseTransformPoint(new Vector3(0.09f, 0.47f, _hit.point.z)));
                //_lrLaser.SetPosition(1, transform.InverseTransformPoint(new Vector3(0.0f, 0.0f, _hit.point.z)));
                //_lrLaser.SetPosition(1, new Vector3(0.09f, 0.47f, _hit.distance));
                _lrLaser.SetPosition(1, new Vector3(0.0f, 0.0f, _hit.distance));
            }
            else
            {
                _lrLaser.SetPosition(1, new Vector3(0.0f, 0.0f, _distanceiaDoRaio));
            }

            IsOnActive();
        }
        #endregion
    }
}

