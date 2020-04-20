using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSlider : MonoBehaviour
{
    public bool isActice;
    public GameObject uiSlider;

    private void Awake()
    {
        uiSlider.SetActive(false);
    }

    public void ChangeState()
    {
        uiSlider.SetActive(!isActice);
        isActice = !isActice;
    }
}
