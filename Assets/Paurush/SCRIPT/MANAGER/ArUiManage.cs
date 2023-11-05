using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArUiManage : MonoBehaviour
{
    [SerializeField] Button  objectPlacedAr;
    [SerializeField] Button  quiteApp;
    [SerializeField] EnableDisableComponent enableDisableComponent;
    [SerializeField] EnableDisableCollider enableDisableCollider;
    [SerializeField] MaterialMange materialMange;

    private void Start()
    {
        objectPlacedAr.onClick.AddListener(() => { StartSimulationProcess(); });
        quiteApp?.onClick.AddListener(() => { ClosingApp(); });
        enableDisableComponent = FindObjectOfType<EnableDisableComponent>();
        materialMange = FindObjectOfType<MaterialMange>();
    }


    public void MaterialAssignprocess(CabinatePartCatagory cabinatePartCatagory, int indexid)
    {
        materialMange.ChangeTextureColorMaterial(cabinatePartCatagory, indexid);
    }

    void StartSimulationProcess()
    {
        if (enableDisableComponent != null)
        {
            enableDisableComponent.EnableDiableCom();
        }

        if (enableDisableCollider != null)
        {
            enableDisableCollider.ToggleEnableDisableCollider();
        }
        // disable th
    }

    void ClosingApp()
    {
        Application.Quit();
    }
}
