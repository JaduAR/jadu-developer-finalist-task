using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct States {
    public int state;
    public Vector3 position;
    public Quaternion rotation;
    public float speed;
}

public class ScreenTransition : MonoBehaviour {
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject colorPanel;

    [SerializeField] private List<States> states;

    private int lastState = 0;
    public void TransitionTo(int state) {
        if (state == lastState) return;
        if (state == 1) {
            colorPanel.SetActive(true);
        } else if (state == 0) {
            colorPanel.SetActive(false);
        }
        lastState = state;
        StartCoroutine(TransitionProcess(states[state]));
    }

    private IEnumerator TransitionProcess(States state) {
        while (Vector3.Distance(camera.transform.position, state.position) >= 0.2f) {
            camera.transform.position = Vector3.Lerp(camera.transform.position, state.position, state.speed * Time.deltaTime);
            camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, state.rotation, state.speed * Time.deltaTime);
            yield return null;
        }

        camera.transform.position = state.position;
        camera.transform.rotation = state.rotation;
    }


    private void Update() {
        if (lastState != 0) return;
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.CompareTag("Player")) {
                    TransitionTo(1);
                }
            }
        }
        
    }

    
}
