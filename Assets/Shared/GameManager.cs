using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class GameManager
    {
        #region Variable.
        // .
        public event System.Action<Player> _onLocalPlayerJoined;

        // Game Object.
        private GameObject _gameObject;

        // Static GameManager.
        private static GameManager m_Instance;
        public static GameManager _instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new GameManager();
                    m_Instance._gameObject = new GameObject("_gameManager");
                    m_Instance._gameObject.AddComponent<InputController>();
                    m_Instance._gameObject.AddComponent<Timer>();
                    m_Instance._gameObject.AddComponent<Respawner>();
                }
                return m_Instance;
            }
        }

        // .
        private InputController m_InputController;
        public InputController _inputController
        {
            get
            {
                if (m_InputController == null)
                {
                    m_InputController = _gameObject.GetComponent<InputController>();
                }
                return m_InputController;
            }
        }

        // .
        private Timer m_Timer;
        public Timer _timer
        {
            get
            {
                if (m_Timer == null)
                {
                    m_Timer = _gameObject.GetComponent<Timer>();
                }
                return m_Timer;
            }
        }

        // .
        private Respawner m_Respawner;
        public Respawner _respawner
        {
            get
            {
                if (m_Respawner == null)
                {
                    m_Respawner = _gameObject.GetComponent<Respawner>();
                }
                return m_Respawner;
            }
        }

        // .
        private Player m_LocalPlayer;
        public Player _localPlayer
        {
            get
            {
                return m_LocalPlayer;
            }
            set
            {
                m_LocalPlayer = value;
                if (_onLocalPlayerJoined != null)
                {
                    _onLocalPlayerJoined(m_LocalPlayer);
                }
            }
        }
        #endregion

    }
}

