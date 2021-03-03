using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputEffect : MonoBehaviour,ISelectHandler,IDeselectHandler
{
    public Graphic icon;
    public Color selectColor = Color.white;
    public Color deslectColor = Color.white;
    public Image backImage;

    public Sprite selectSprite;
    public Sprite deselectSprite;

    public void OnDeselect(BaseEventData eventData)
    {
        icon.color = deslectColor;
        backImage.sprite = deselectSprite;
    }

    public void OnSelect(BaseEventData eventData)
    {
        icon.color = selectColor;
        backImage.sprite = selectSprite;
    }

    // Use this for initialization
    void Start () {
        icon.color = deslectColor;
        backImage.sprite = deselectSprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
