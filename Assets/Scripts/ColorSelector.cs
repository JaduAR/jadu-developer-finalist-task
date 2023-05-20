using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : Selector
{
   [SerializeField] private Image buttonImage;
   [SerializeField] private float _shrinkSize;

   public void SetColor(Color skinColor)
   {
      buttonImage.color = skinColor;
   }
   
   public override void SetOwner(Tab owner)
   {
      base.owner = owner;
   }

   //This is called when the button is clicked. Hooked in by Unity Event.
   public override void Select()
   {
      transform.localScale = Vector3.one * 0.25f;
      owner.SetActiveItem(this);
   }

   public override void Deselect()
   {
      transform.localScale = Vector3.one;
   }
}
