using UnityEngine;
using UnityEngine.UI;

public class ColorSelect : MonoBehaviour
{
	public ColorObj[] colorButtons;
	int current;
	int prev;
	private void Start()
	{
		for (int i = 0; i < colorButtons.Length; i++)
		{
			int index = i;
			colorButtons[i].GetComponent<Button>().onClick.AddListener(() =>
			{
				PlayAnimation(index);
			});
		}
	}

	private void PlayAnimation(int buttonIndex)
	{
		if (gameObject.tag == "Color")
		{

			if (prev != -1)
			{
				colorButtons[prev].anim.SetBool("isSelected", false);
				colorButtons[prev].GetComponent<Animator>().SetBool("isSelected", false);
			}

			colorButtons[buttonIndex].anim.SetBool("isSelected", true);
			colorButtons[buttonIndex].GetComponent<Animator>().SetBool("isSelected", true);
			//SetColor();
			prev = current;
			current = buttonIndex;
		}
	}

	private void SetColor()
	{
		Debug.Log("SetColor");
	}
}
