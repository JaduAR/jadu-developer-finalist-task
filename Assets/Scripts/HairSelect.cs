using UnityEngine;
using UnityEngine.UI;
public class HairSelect : MonoBehaviour
{
	public HairObj[] hairButtons;
	int current;
	int prev;
	private void Start()
	{
		for (int i = 0; i < hairButtons.Length; i++)
		{
			int index = i;
			hairButtons[i].GetComponent<Button>().onClick.AddListener(() =>
			{
				PlayAnimation(index);
			});
		}
	}

	private void PlayAnimation(int buttonIndex)
	{
		hairButtons[current].anim.SetBool("isSelected", false);
		hairButtons[current].GetComponent<Animator>().SetBool("isSelected", false);

		hairButtons[buttonIndex].anim.SetBool("isSelected", true);
		hairButtons[buttonIndex].GetComponent<Animator>().SetBool("isSelected", true);
		//SetHair();
		prev = current;
		current = buttonIndex;
	}

	private void SetHair()
	{
		Debug.Log("SetColor");
	}
}
