using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        #region Variable.
        // Audio.
        [SerializeField] private AudioClip[] _audioClip;
        private AudioClip _clip;
        private AudioSource _audioSource;

        // int.
        private int _clipIndex;

        // float.
        [SerializeField] private float _delayBetweenClipsWalk;
        [SerializeField] private float _delayBetweenClipsRun;
        [SerializeField] private float _delayBetweenClipsReload;
        [SerializeField] private float _delayBetweenClipsEmtyAmmo;

        private float _delayBetweenClips;

        // bool.
        private bool _canPlay = true;

        // Class.
        private InputController m_PlayerInput;
        private InputController _playerInput
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
            _audioSource = GetComponent<AudioSource>();
        }
        #endregion

        #region Play.
        public void Play()
        {
            if (!_canPlay)
            {
                return;
            }

            if (_playerInput._isRuning)
            {
                _delayBetweenClips = _delayBetweenClipsRun;
            }
            else if (!_playerInput._isRuning)
            {
                _delayBetweenClips = _delayBetweenClipsWalk;
            }
            else if (_playerInput._reload)
            {
                _delayBetweenClips = _delayBetweenClipsReload;
            }

            GameManager._instance._timer.Add(() =>
            {
                _canPlay = true;
            }, _delayBetweenClips);

            _canPlay = false;

            _clipIndex = Random.Range(0, _audioClip.Length);
            _clip = _audioClip[_clipIndex];
            _audioSource.PlayOneShot(_clip);

        }
        #endregion
    }
}

