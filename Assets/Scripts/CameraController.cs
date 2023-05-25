using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple camera script to transition between two positions.
/// </summary>
public class CameraController : MonoBehaviour
{
    public Transform ZoomedOutPosition;
    public Transform ZoomedInPosition; 
    [Header("Properties")]
    [SerializeField] private AnimationCurve _transitionCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    [SerializeField] private float _transitionDuration = 1f;
    
    private Coroutine _transitionCoroutine;

    public void ZoomIn()
    {
        if(_transitionCoroutine != null) StopCoroutine(_transitionCoroutine);
        StartCoroutine(Transition(ZoomedInPosition.position, ZoomedInPosition.rotation));
    }
    
    public void ZoomOut()
    {
        if(_transitionCoroutine != null) StopCoroutine(_transitionCoroutine);
        _transitionCoroutine = StartCoroutine(Transition(ZoomedOutPosition.position, ZoomedOutPosition.rotation));
    }

    private IEnumerator Transition(Vector3 newPosition, Quaternion newRotation)
    {
        var startPos = transform.position;
        var startRot = transform.rotation;
        var elapsedTime = 0f;
        while (elapsedTime < _transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            var t = _transitionCurve.Evaluate(elapsedTime / _transitionDuration);
            transform.position = Vector3.Lerp(startPos, newPosition, t);
            transform.rotation = Quaternion.Lerp(startRot, newRotation, t);
            yield return new WaitForEndOfFrame();
        }
    }
}

