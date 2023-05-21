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

        if (!bottomPanel.IsHidden()) {
            target = tabTargets[bottomPanel.GetTab()];
        }

        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * transitionSpeed * 1.25f);
        //transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * transitionSpeed * 1.25f);

        Vector3 lookDelta = lookAtXZ.position - transform.position;
        lookDelta.y = 0;
        Quaternion look = Quaternion.LookRotation(lookDelta);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, look.eulerAngles.y, transform.rotation.eulerAngles.z);

        //transform.LookAt(new Vector3(lookAtXZ.position.x, transform.position.y, lookAtXZ.position.z));
    }

}
