using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
	public GameObject hairContent;
	public GameObject skinContent;

	Animator animator;

	private void Start()
	{
		animator= GetComponent<Animator>();
	}

	public void OpenSkinPanel()
	{
		StopAllCoroutines();
		animator.SetBool("isToHair", false);
		StartCoroutine(TransitionToSkin());
	}
	public void OpenHairPanel()
	{
		StopAllCoroutines();
		animator.SetBool("isToHair", true);
		StartCoroutine(TransitionToHair());
	}

	IEnumerator TransitionToSkin()
	{
		yield return new WaitForSeconds(.8f);
		hairContent.SetActive(false);
		skinContent.SetActive(true);
	}
	IEnumerator TransitionToHair()
	{
		yield return new WaitForSeconds(.8f);
		skinContent.SetActive(false);
		hairContent.SetActive(true);
	}
}
