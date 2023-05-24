using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
	[SerializeField] GameObject mainMenu;
	[SerializeField] GameObject customizationMenu;
	[SerializeField] Animator customizationMenuAnim;

	private void Start()
	{
		customizationMenuAnim = GetComponentInChildren<Animator>();
	}

	public void SwapPanels(bool isOpening)
	{
		if (isOpening)
		{
			mainMenu.SetActive(false);
			customizationMenu.SetActive(true);
			customizationMenuAnim.SetBool("isOpen", true);
		}
		else
		{
			StartCoroutine(ClosePanel());
			customizationMenuAnim.SetBool("isOpen", false);
		}
	}

	IEnumerator ClosePanel()
	{
		yield return new WaitForSeconds(2f);
		mainMenu.SetActive(true);
		customizationMenu.SetActive(false);

	}


}
