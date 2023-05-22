using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TechTask;

namespace TechTask {

	public class HairStyleButton : MonoBehaviour
	{
		#region REFERENCES

		UIController _uiController;


		[SerializeField]
		private GameObject _activeBg;

		[SerializeField]
		private Image _styleImage;

		[SerializeField]
		private TMP_Text _buttonName;

		#endregion

		#region VARIABLES

		private const float DeselectTextAlpha = 0.3f;

		private int _index;
		private string _styleName;

		private Color _activeTextColor;
		private Color _inactiveTextColor;	

		#endregion

		#region METHODS

		public void SetupButton(UIController uiController, int index, Sprite styleSprite, string styleName)
		{
			_uiController = uiController;

            _activeTextColor = _buttonName.color;
            _inactiveTextColor = new Color(_activeTextColor.r, _activeTextColor.g, _activeTextColor.b, DeselectTextAlpha);

            _index = index;
			_styleName = styleName;
			_styleImage.sprite = styleSprite;
			_buttonName.text = _styleName;
		}

		public void Activate()
		{
			_activeBg.SetActive(true);
			_buttonName.fontStyle = FontStyles.Bold;
			_buttonName.color = _activeTextColor;

			_uiController.HairButtonClicked(_index);
		}

		public void Deactivate()
		{
			_activeBg.SetActive(false);
            _buttonName.fontStyle = FontStyles.Normal;
            _buttonName.color = _inactiveTextColor;
        }

		#endregion
	}

}