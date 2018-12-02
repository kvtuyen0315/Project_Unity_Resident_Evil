using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class SpawnPoint : MonoBehaviour
    {
        #region Variable.

        #endregion

        #region On Draw Gizmos.
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero + Vector3.up * 0.5f, Vector3.one);
        }
        #endregion
    }
}

