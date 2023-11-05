using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMange : MonoBehaviour
{
    public CabineteMaterialCatogory[] cabineteMaterialCatogory;
    public AssignTeXture_Color[] assignTeXture_Colors;

    int lengthMaterial,lengthTextureAssign;

    bool dataAdded;

    private void Start()
    {
        lengthMaterial = cabineteMaterialCatogory.Length;
        lengthTextureAssign = assignTeXture_Colors.Length;

    }


    /// <summary>
    /// Ui button trigger 
    /// </summary>
    /// <param name="cabinatePartCatagory"></param>
    /// <param name="id_texture_color"></param>
    public void ChangeTextureColorMaterial(CabinatePartCatagory cabinatePartCatagory, int id_texture_color)
    {
        if (!dataAdded)
        {
            return;
        }
        for (int i = 0; i < lengthTextureAssign; i++)
        {
            if (assignTeXture_Colors[i].m_CabinatePartCatagory == cabinatePartCatagory)
            {
                if (assignTeXture_Colors[i].textureHolder.Length != 0)
                {
                    for (int j = 0; j < lengthMaterial; j++)
                    {
                        if (cabineteMaterialCatogory[j].m_CabinatePartCatagory == cabinatePartCatagory)
                        {
                            int individualLength = cabineteMaterialCatogory[j].m_CabinatePartMaterial.Count;
                            for (int k = 0; k < individualLength; k++)
                            {
                                cabineteMaterialCatogory[j].m_CabinatePartMaterial[k].mainTexture = assignTeXture_Colors[i].textureHolder[id_texture_color];
                                //cabineteMaterialCatogory[j].cabinatepartRenberRef.
                            }

                            cabineteMaterialCatogory[j].m_MaterialRegestermodify.AssignModifymaterial(cabineteMaterialCatogory[j].m_CabinatePartMaterial);

                        }
                    }
                }
                if (assignTeXture_Colors[i].colorHolder.Length != 0)
                {
                    for (int j = 0; j < lengthMaterial; j++)
                    {
                        if (cabineteMaterialCatogory[j].m_CabinatePartCatagory == cabinatePartCatagory)
                        {
                            int individualLength = cabineteMaterialCatogory[j].m_CabinatePartMaterial.Count;
                            for (int k = 0; k < individualLength; k++)
                            {
                                cabineteMaterialCatogory[j].m_CabinatePartMaterial[k].color = assignTeXture_Colors[i].colorHolder[id_texture_color];
                                //cabineteMaterialCatogory[j].cabinatepartRenberRef.
                            }

                            cabineteMaterialCatogory[j].m_MaterialRegestermodify.AssignModifymaterial(cabineteMaterialCatogory[j].m_CabinatePartMaterial);

                        }
                    }
                }
            }
        }
    }




    /// <summary>
    /// add those material which match to enum, eg body material add to list of body material
    /// </summary>
    /// <param name="cabinatePartCatagory">enum to compare catagory</param>
    /// <param name="materials">passed material</param>
    public void RefernceMaterialAdd(CabinatePartCatagory cabinatePartCatagory, List<Material> materials, MaterialRegestermodify materialRegestermodify) //Renderer renderer
    {
        dataAdded = true;
        for (int i = 0; i < lengthMaterial; i++)
        {
            if (cabineteMaterialCatogory[i].m_CabinatePartCatagory == cabinatePartCatagory)
            {
                foreach (var itemMaterial in materials)
                {
                    cabineteMaterialCatogory[i].m_CabinatePartMaterial.Add(itemMaterial);
                }
                //cabineteMaterialCatogory[i].cabinatepartRenberRef = renderer;
                cabineteMaterialCatogory[i].m_MaterialRegestermodify = materialRegestermodify;
                break;
            }
        }

    }

}

[System.Serializable]
public enum CabinatePartCatagory
{
    Top,Body,Drawer

}

[System.Serializable]
public struct CabineteMaterialCatogory
{
    public CabinatePartCatagory m_CabinatePartCatagory;
    public List<Material> m_CabinatePartMaterial;
    public MaterialRegestermodify m_MaterialRegestermodify;
    //public Renderer cabinatepartRenberRef;
}

[System.Serializable]
public struct AssignTeXture_Color
{
    public CabinatePartCatagory m_CabinatePartCatagory;
    public Texture[] textureHolder;
    public Color[] colorHolder;
}