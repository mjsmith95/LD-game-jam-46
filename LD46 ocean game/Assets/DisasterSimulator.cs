using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterSimulator : MonoBehaviour
{
    public List<Material> coralMaterial;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < coralMaterial.Capacity; i++)
        {
            coralMaterial[i].color = new Vector4(1, 1, 1,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
