using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    public List<GameObject> plotList;
    public int plotMax;

    private void Awake()
    {
        plotList = new List<GameObject>(plotMax);
        for (int i = 0; i < plotList.Capacity; i++)
        {
           // plotList[i] = Instantiate<GameObject>(new GameObject("plot", typeof(Image));
        }
    }


    private void updateGraph(int newValue)
    {
        
    }


    private void Update()
    {
        
    }
}
