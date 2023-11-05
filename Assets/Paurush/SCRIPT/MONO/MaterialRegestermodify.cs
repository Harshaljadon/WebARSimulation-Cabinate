using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialRegestermodify : MonoBehaviour
{
    [SerializeField]
    int[] materialIndexSlected;
    public CabinatePartCatagory cabinatePartCatagory;
    public List<Material> materials;
    MaterialMange materialMange;
    public Renderer myRender;
    // Start is called before the first frame update
    void Start()
    {
        materialMange = FindAnyObjectByType<MaterialMange>();
        myRender = GetComponent<Renderer>();
        ForwardModyMaterial();


    }

    void ForwardModyMaterial()
    {
        var size = materialIndexSlected.Length;
        for (int i = 0; i < size; i++)
        {
            materials.Add(myRender.materials[materialIndexSlected[i]]);
        }

        materialMange.RefernceMaterialAdd(cabinatePartCatagory, materials, this);
    }

    public void AssignModifymaterial(List<Material> modifyedMaterials)
    {
        materials = modifyedMaterials;
        var size = materialIndexSlected.Length;
        for (int i = 0; i < size; i++)
        {
            myRender.materials[materialIndexSlected[i]] = materials[i];
        }
    }
}
