using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderSwitch : MonoBehaviour {

    public Image handle;
    public Sprite onHandleSprite;
    public Sprite offHandleSprite;

    public Text onText;
    public Text offText;
    public bool isOn;
    public SliderSwitchEvent onValueChanged;
    public void Awake()
    {
        Slider slider = GetComponent<Slider>();
        if (slider == null)
        {
            Destroy(this);
            return;
        }
        //slider.onValueChanged.AddListener((float value) => { });
        //slider.onValueChanged.AddListener(value => { });
        slider.onValueChanged.AddListener(SliderValueChanged);

        slider.onValueChanged.Invoke(slider.value);
    }
    void SliderValueChanged(float value)
    {
        if (value <= 0)
        {
            if (isOn)
            {
                isOn = false;
                if (onValueChanged != null)
                {
                    onValueChanged.Invoke(isOn);
                }
            }
            handle.sprite = offHandleSprite;
            onText.gameObject.SetActive(false);
            offText.gameObject.SetActive(true);
        }
        else
        {
            if (!isOn)
            {
                isOn = true;

                if (onValueChanged != null)
                {
                    onValueChanged.Invoke(isOn);
                }
            }

            handle.sprite = onHandleSprite;
            onText.gameObject.SetActive(true);
            offText.gameObject.SetActive(false);
        }
    }
    [System.Serializable]
    public class SliderSwitchEvent : UnityEvent<bool>
    {

    }
}
