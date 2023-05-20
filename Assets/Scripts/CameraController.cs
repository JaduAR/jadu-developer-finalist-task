// ----------------------
// Onur EREREN - May 2023
// ----------------------

// Jadu UI Technical Task Camera Controller
// Moves camera between points with the ease option selected (EaseInOutSine is default).

using System.Collections;
using UnityEngine;
using EaseLibrary;

namespace TechTask
{
    public class CameraController : MonoBehaviour
    {
        #region REFERENCES

        [SerializeField] 
        private Transform[] _cameraPositions;

        private Transform _cameraTransform;
        
        #endregion

        #region VARIABLES

        [SerializeField] 
        private EaseType _cameraEase;

        [SerializeField] 
        private float _cameraMoveDuration;
        
        #endregion
        
        #region MONOBEHAVIOUR

        private void Start()
        {
            _cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                MoveCamera(0);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                MoveCamera(1);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                MoveCamera(2);
            }
        }
        
        #endregion
        
        #region METHODS

        public void MoveCamera(int positionIndex)
        {
            MoveCamera(positionIndex, _cameraEase);
        }

        public void MoveCamera(int positionIndex, EaseType easeType)
        {
            StartCoroutine(EaseCameraMovement(positionIndex, easeType));
        }
        
        #endregion
        
        #region COROUTINES

        private IEnumerator EaseCameraMovement(int positionIndex, EaseType easeType)
        {
            Vector3 startPosition = _cameraTransform.position;
            Quaternion startRotation = _cameraTransform.rotation;

            Vector3 endPosition = _cameraPositions[positionIndex].position;
            Quaternion endRotation = _cameraPositions[positionIndex].rotation;

            float timer = 0f;

            while (timer < _cameraMoveDuration)
            {
                timer += Time.deltaTime;
                float rawLerp = timer / _cameraMoveDuration;
                float clampedLerp = Mathf.Clamp(rawLerp, 0f, 1f);
                float easedLerp = KinematicEase.Evaluate(easeType, clampedLerp);

                _cameraTransform.position = Vector3.Lerp(startPosition, endPosition, easedLerp);
                _cameraTransform.rotation = Quaternion.Lerp(startRotation, endRotation, easedLerp);
                
                
                yield return null;
            }
            


        }
        
        #endregion
    }
}