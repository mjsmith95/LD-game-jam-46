
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    private RectTransform graphContainer;

    public Sprite circleSprite;
    public List<GameObject> plotList;
    public List<int> valueList;
    public Color color;


    private void Start()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        valueList = new List<int>() { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0} ;
        
        

        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 100f;
        float xSize = 20f;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPositiion = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            CreateCircle(new Vector2(xPositiion, yPosition));
        }
        ShowGraph();
    }


    private void CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.GetComponent<Image>().color = color;
        plotList.Add(gameObject);
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(8, 8);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    private void ShowGraph()
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 100f;
        float xSize = 12f;
        for(int i = 0; i < valueList.Count; i++)
        {
            float xPositiion = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            RectTransform rectTransform = plotList[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(xPositiion, yPosition);
        }
    }

    public void addData(int newData)
    {
        valueList.Add(newData);
        valueList.RemoveAt(0);
        ShowGraph();
    }

}
