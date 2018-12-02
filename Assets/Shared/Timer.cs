using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Timer : MonoBehaviour
    {
        #region Class Time Event.
        private class TimeEvent
        {
            public float _timeToExecute;
            public CallBack _method;
        }
        #endregion

        #region Variable.
        private List<TimeEvent> _events;

        public delegate void CallBack();
        #endregion

        #region Awake.
        private void Awake()
        {
            _events = new List<TimeEvent>();
        }
        #endregion

        #region Add.
        public void Add(CallBack method, float inSeconds)
        {
            _events.Add(new TimeEvent
            {
                _method = method,
                _timeToExecute = Time.time + inSeconds
            });
        }
        #endregion

        #region Update.
        private void Update()
        {
            if (_events.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _events.Count; i++)
            {
                TimeEvent timeEvent = _events[i];
                if (timeEvent._timeToExecute <= Time.time)
                {
                    timeEvent._method();
                    _events.Remove(timeEvent);
                }
            }
        }
        #endregion
    }
}

