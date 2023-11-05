using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialUiCall : MonoBehaviour
{
    [SerializeField] ArUiManage arUiManage;
    [SerializeField] int indexidPass;
    public CabinatePartCatagory cabinatePartCatagory;

    Button button;

    // Start is called before the first frame update
    void Start()
    {
        arUiManage = FindObjectOfType<ArUiManage>();
        button = this.GetComponent<Button>();
        button?.onClick.AddListener(() => { MaterialChangesProcess(); });
    }

    void MaterialChangesProcess()
    {
        arUiManage.MaterialAssignprocess(cabinatePartCatagory, indexidPass);
    }

}
