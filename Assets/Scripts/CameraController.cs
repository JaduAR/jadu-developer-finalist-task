using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	[Header("Transforms")]
	[SerializeField] Transform endpos;
	[SerializeField] Transform startpos;
	[Header("Position")]
	[SerializeField] float duration = 2f;
	[Header("Rotation")]
	float time;
	private bool isMovingForward = false;
	private bool isMovingBackward = false;
	private bool isWaiting = true;

	CanvasController canvasController;
	GameObject canvas;


	private void Start()
	{
		startpos.position = transform.position;
		canvas = GameObject.Find("Canvas");
		canvasController = canvas.GetComponent<CanvasController>();
	}

	public void OpenCharacterPanel()
	{
		isMovingForward = true;
		isMovingBackward = false;
		isWaiting = false;
		canvasController.SwapPanels(true);
	}

	public void CloseCharacterPanel()
	{
		isMovingForward = false;
		isMovingBackward = true;
		isWaiting = false;
		canvasController.SwapPanels(false);
	}

	private void Update()
	{
		if (!isWaiting)
		{
			if (isMovingForward)
			{
				MoveCamera(startpos, endpos);
			}
			else if (isMovingBackward)
			{
				MoveCamera(endpos, startpos);
			}
		}
	}

	private void MoveCamera(Transform start, Transform end)
	{
		time += Time.deltaTime;
		float progress = time / duration;

		transform.position = Vector3.Lerp(start.position, end.position, progress);
		transform.rotation = Quaternion.Lerp(start.rotation, end.rotation, progress);
	}
}
