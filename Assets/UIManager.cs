using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject selectedButton;
    public CameraMovement camMove;
    public Transform beginPos;
    public Transform hairPos;
    public Transform skinPos;
    public Transform skinPosInd;
    public Transform hairPosInd;
    public GameObject UIPanel;
    public GameObject indicator;

    private Vector2 velocity = Vector2.zero;
    private float smoothTime = 1f;
    // Update is called once per frame
    void Update()
    {
        switch (camMove.pos)
        {
            case 1:
                moveUI(beginPos);
                break;
            case 2:
                moveUI(skinPos);
               
                break;
            case 3:
                moveUI(hairPos);
                break;
        }
    }

    //Moves Ui panel up slowly to predetrmind positions
    void moveUI(Transform pos)
    {
      UIPanel.transform.position = Vector2.SmoothDamp(UIPanel.transform.position, pos.position, ref velocity, smoothTime);
    }

    //Moves the selector indicator to under the current selected menu
    public void indicatorMove(Transform newPos)
    {
        indicator.transform.position = newPos.position;
    }
    public void shrinkButton(GameObject newButton)
    {
        if(selectedButton != null)
        selectedButton.transform.localScale = new Vector3(1f,1f,1f);

        newButton.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        selectedButton = newButton;
        
    }

}
