using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro.Examples;

public class InstanceSimulation : MonoBehaviour
{
    public GameObject simulationObjectPrefeb;
    public GameObject cameraTaget;
    public CameraController CameraController;
    // Start is called before the first frame update
    void Start()
    {
        var simCreated = Instantiate(simulationObjectPrefeb, this.transform);
        cameraTaget = simCreated.transform.GetChild(0).GetChild(0).gameObject;
        CameraController = Camera.main.GetComponent<CameraController>();
        CameraController.CameraTarget = cameraTaget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
