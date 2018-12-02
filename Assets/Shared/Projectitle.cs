using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectitle : MonoBehaviour
    {
        #region Variable.
        // float.
        [SerializeField] private float _speed;
        [SerializeField] private float _timeToLive;
        [SerializeField] private float _damge;
        //[SerializeField] private float _damgePlus;
        [SerializeField] private float _distance;

        // Raycast Hit.
        private RaycastHit _hit;


        // Class.
        private Destructable _destructable;

        #endregion

        #region Start.
        private void Start()
        {
            Destroy(gameObject, _timeToLive);
        }
        #endregion

        #region Update.
        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);

            if (Physics.Raycast(transform.position, transform.forward, out _hit, _distance))
            {
                CheckDestructable(_hit.transform);
            }
        }
        #endregion

        #region On Collision Enter.
        //private void OnCollisionEnter(Collision other)
        //{
        //    _destructable = other.transform.GetComponent<Destructable>();
        //    if (_destructable == null)
        //    {
        //        return;
        //    }

        //    Debug.Log("Hit");

        //    // Take damage.
        //    _destructable.TakeDamage(_damge);

        //    // Distroy.
        //    Destroy(gameObject);
        //}
        #endregion

        #region On Trigger Enter.
        //private void OnTriggerEnter(Collider other)
        //{
        //    _destructable = other.transform.GetComponent<Destructable>();
        //    if (_destructable == null)
        //    {
        //        return;
        //    }

        //    Debug.Log("Hit");

        //    // Take damage.
        //    _destructable.TakeDamage(_damge);
        //    Destroy(gameObject);
        //}
        #endregion

        #region Check Destructable.
        private void CheckDestructable(Transform other)
        {
            _destructable = other.transform.GetComponent<Destructable>();
            if (_destructable == null)
            {
                return;
            }

            // Take damage.
            _destructable.TakeDamage(_damge);
            Destroy(gameObject);
        }
        #endregion
    }
}

