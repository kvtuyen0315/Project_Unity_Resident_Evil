using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour
    {
        #region Variable.
        // Line Renderer.
        [SerializeField] private LineRenderer _line;

        // Ray cast Hit.
        private RaycastHit _hit;
        #endregion

        #region Start.
        private void Start()
        {
            _line = GetComponent<LineRenderer>();
        }
        #endregion

        #region Update.
        private void Update()
        {

            if (Physics.Raycast(transform.position, transform.forward, out _hit))
            {
                if (_hit.collider)
                {
                    _line.SetPosition(1, new Vector3(0.0f, 0.0f, _hit.distance));
                }
                else
                {
                    _line.SetPosition(1, new Vector3(0.0f, 0.0f, 100.0f));
                }
            }
        }
        #endregion
    }
}

