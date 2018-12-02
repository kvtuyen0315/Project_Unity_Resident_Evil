using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Respawner : MonoBehaviour
    {
        public void Despawn(GameObject gobj, float inSeconds)
        {
            gobj.SetActive(false);

            GameManager._instance._timer.Add(() =>
            {
                gobj.SetActive(true);

            }, inSeconds);
        }
        

    }
}

