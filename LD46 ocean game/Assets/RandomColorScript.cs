using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorScript : MonoBehaviour
{
    public MeshRenderer[] renderers;
    public float constraintLow;
    public float constraintHigh;
    // Start is called before the first frame update
    void Start()
    {

        //material = new Material(sampleMaterial);
        //Color32 randColor = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        //entityMaterial.color = randColor;
        Color newColor = Random.ColorHSV(constraintLow,constraintHigh,1,1,1,1);
        ApplyColor(newColor,0);
    }

    void ApplyColor(Color color, int targetMaterialInxex)
    {
        Material generatedMaterial = new Material(Shader.Find("Standard"));
        generatedMaterial.SetColor("_Color", color);
        for(int i = 0; i < renderers.Length ; i++){
            renderers[i].material = generatedMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
