using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(fileName = "Moving Settings", menuName = "Data/MovingSettings")]
    public class MovingSettings : ScriptableObject
    {
        #region Variable.
        // float.
        // Leon.
        public float _leonWalkSpeed;
        public float _leonRunSpeed;
        public float _leonRotationSpeed;
        public float _leonTurn180Speed;
        public float _leonMiniumMoveTreshold;

        // Zombie normal.
        public float _zWalkSpeed;
        public float _zRunSpeed;

        #endregion

    }
}

