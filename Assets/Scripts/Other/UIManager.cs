using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = Convert.ToString(slider.value);
    }
}
