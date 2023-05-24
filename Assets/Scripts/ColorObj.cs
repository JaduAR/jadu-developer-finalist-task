using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObj : MonoBehaviour
{
	public Animator anim;
	[SerializeField] public bool isSelected = false;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}
}
