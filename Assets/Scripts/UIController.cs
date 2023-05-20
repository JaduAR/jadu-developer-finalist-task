// ----------------------
// Onur EREREN - May 2023
// ----------------------

// Jadu UI Technical Task UI Controller
// Controls UI actions


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EaseLibrary;

namespace TechTask
{

    public class UIController : MonoBehaviour
    {
        #region REFERENCES

        [SerializeField] 
        private Transform _header;
        
        [SerializeField]
        private Transform[] _headerPositions;


        #endregion

        #region VARIABLES

        [SerializeField]
        private float _menuChangeDuration;

        [SerializeField]
        private EaseType _easeType;        
        
        #endregion
        
        
        #region METHODS

        public void MoveHeader(int positionIndex)
        {
            StartCoroutine(MoveUIElement(_header, _headerPositions[positionIndex].position, _menuChangeDuration, _easeType));
        }
        
        
        #endregion

        #region COROUTINES

        private IEnumerator MoveUIElement(Transform element, Vector3 targetPosition, float moveDuration, EaseType easeType)
        {
            Vector3 startPosition = element.position;
            Vector3 endPosition = targetPosition;

            float timer = 0f;

            while (timer < _menuChangeDuration)
            {
                timer += Time.deltaTime;
                float lerp = timer / _menuChangeDuration;
                float clampedLerp = Mathf.Clamp(lerp, 0f, 1f);
                float easedLerp = KinematicEase.Evaluate(easeType, clampedLerp);

                element.position = Vector3.Lerp(startPosition, endPosition, easedLerp);
                
                yield return null;
            }
            
            

        }
        
        #endregion

    }
}