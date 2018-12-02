using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class PlayerHealth : Destructable
    {
        #region Variable.
        // int.
        private int _spawnIndex;

        // Class.
        [SerializeField] private SpawnPoint[] _spawnPoint;


        #endregion

        #region Spawn At New Spawn Point.
        private void SpawnAtNewSpawnPoint()
        {
            _spawnIndex = Random.Range(0, _spawnPoint.Length);
            transform.position = _spawnPoint[_spawnIndex].transform.position;
            transform.rotation = _spawnPoint[_spawnIndex].transform.rotation;

        }
        #endregion

        #region Die.
        public override void Die()
        {
            base.Die();

            SpawnAtNewSpawnPoint();
        }
        #endregion

        #region Test Die.
        [ContextMenu("Test Die!")] private void TestDie()
        {
            Die();
        }
        #endregion
    }
}

