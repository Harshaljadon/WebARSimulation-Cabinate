using UnityEngine;

public class ScaleWithCameraDistance : MonoBehaviour
{
    public Transform cameraTransform;
    public float scalingRate = 0.1f;
    public float minScaleFactor = 0.5f;
    public float maxScaleFactor = 2.0f;

    float initialDistance, currentDistance;

    public bool scaleFix;
    Vector3 orignalLocalScale;

    private void OnEnable()
    {
        cameraTransform = Camera.main.transform;
        initialDistance = Vector3.Distance(cameraTransform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        //previousDis = initialDistance;
    }

    private void Start()
    {
        orignalLocalScale = this.transform.localScale;
        // Calculate the initial distance between the player and the game object
        //cameraTransform = Camera.main.transform;
        //initialDistance = Vector3.Distance(cameraTransform.position, new Vector3(0, transform.position.y, transform.position.z));
        //Invoke(nameof(SelfDisable), .5f);
    }


    void SelfDisable()
    {
        this.enabled = false;
    }

    public void DraggingSizeUpdate_OnMouseDown()
    {
        if (!scaleFix)
        {
            currentDistance = Vector3.Distance(cameraTransform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z));
            // Calculate the scaling factor based on the change in distance
            float distanceChange = currentDistance - initialDistance;
            float scalingFactor = 1.0f + scalingRate * distanceChange;

            // Ensure the scaling factor stays within desired bounds
            scalingFactor = Mathf.Clamp(scalingFactor, minScaleFactor, maxScaleFactor);

            // Apply the scaling factor to the game object's transform
            transform.localScale = Vector3.one * scalingFactor;
        }
    }

    public void DraggingSizeUpdate_OnMouseUp()
    {
        this.transform.localScale = orignalLocalScale;
    }

    private void Update()
    {

        //if (Input.touchCount == 2)
        //{
        //    //initialDistance = Vector3.Distance(cameraTransform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z));

        //    return;
        //}
        // Calculate the current distance between the player and the game object
        if (scaleFix)
        {
            currentDistance = Vector3.Distance(cameraTransform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z));

            // Calculate the scaling factor based on the change in distance
            float distanceChange = currentDistance - initialDistance;
            float scalingFactor = 1.0f + scalingRate * distanceChange;

            // Ensure the scaling factor stays within desired bounds
            scalingFactor = Mathf.Clamp(scalingFactor, minScaleFactor, maxScaleFactor);

            // Apply the scaling factor to the game object's transform
            transform.localScale = Vector3.one * scalingFactor;
        }
        //else
        //{
        //    initialDistance = Vector3.Distance(cameraTransform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z));

        //}

    }
}
