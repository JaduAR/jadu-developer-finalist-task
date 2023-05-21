using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    BottomPanel bottomPanel;

    [SerializeField]
    Transform lookAtXZ;

    [SerializeField]
    Transform overviewTarget;

    [SerializeField]
    Transform[] tabTargets;

    [SerializeField]
    float transitionSpeed = 1.0f;

    private void Start() {
        if (tabTargets.Length != bottomPanel.NumTabs()) {
            Debug.LogError("Incorrect tabTargets length, using dummies");
            tabTargets = new Transform[bottomPanel.NumTabs()];
        }
    }

    private void Update() {
        Transform target = overviewTarget;
        float speedMult = 1.0f;

        if (!bottomPanel.IsHidden()) {
            target = tabTargets[bottomPanel.GetTab()];
            speedMult = 1.5f;
        }

        // move towards target
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * transitionSpeed * speedMult);

        // look towards `lookAtXZ` but only affect Y rotation
        Vector3 lookDelta = lookAtXZ.position - transform.position;
        Quaternion look = Quaternion.LookRotation(lookDelta);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, look.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

}
