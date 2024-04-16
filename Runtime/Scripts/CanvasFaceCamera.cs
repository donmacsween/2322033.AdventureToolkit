// Author  : Don MacSween.
// Purpose : A helper script that ensures world space canvases face the camera
using UnityEngine;

namespace ADVTK
{
    public class CanvasFaceCamera : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private void Awake()
        {
            if (_camera == null) { _camera = Camera.main; }
        }
        void Update()
        {
            // Used in update to allow for camera switching after Awake
            if (_camera != null)
            {
                transform.LookAt(_camera.transform);
            }
            else
            {
                _camera = Camera.main;
            }
        }
    }
}
