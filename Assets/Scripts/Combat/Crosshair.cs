using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Crosshair : MonoBehaviour
    {
        #region Variable.
        // int.
        [SerializeField] private int _size;

        // Vector3.
        private Vector3 _screenPosition;

        // Texture 2D.
        [SerializeField] private Texture2D _image;

        #endregion

        #region On GUI.
        private void OnGUI()
        {
            _screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            _screenPosition.y = Screen.height - _screenPosition.y;
            GUI.DrawTexture(new Rect(_screenPosition.x - _size / 2, _screenPosition.y - _size / 2, _size, _size), _image);
        }
        #endregion
    }
}

