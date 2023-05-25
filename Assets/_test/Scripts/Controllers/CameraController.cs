using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private Camera _camera;

    private void Awake() {
        if (!_camera) {
            _camera = Camera.main;
        }
    }

    public IEnumerator MoveCamera(ScreenSO screen) {
        Vector3 p0 = _camera.transform.position;
        Quaternion q0 = _camera.transform.rotation;
        float c = 0;
        while (c < screen.lerpTotalTime) {

            _camera.transform.position = Vector3.Lerp(p0, screen.cameraPosition, screen.transitionCurve.Evaluate(c / screen.lerpTotalTime));
            _camera.transform.rotation = Quaternion.Lerp(q0, screen.cameraRotation, screen.rotationCurve.Evaluate(c / screen.lerpTotalTime));

            c += Time.deltaTime;
            yield return null;
        }

        _camera.transform.position = screen.cameraPosition;
        _camera.transform.rotation = screen.cameraRotation;

    }
}
