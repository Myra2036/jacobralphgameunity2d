using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float smoothing = 0.03f;
    // *******THE TARGET MUST BE THE PLAYER
    public Transform target;

    public Vector2 minPos;
    public Vector2 maxPos;

    // ********MIN X AND Y ZOOM = -500, MAX X AND Y ZOOM = 500
    public float minZoom = 5f;
    public float maxZoom = 10f;

    public float zoomSpeed = 1f;

    private void FixedUpdate()
    {
        // Camera tracking player
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }

        // Camera zoom in/out
        float scrollWheel = Input.mouseScrollDelta.y;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scrollWheel * zoomSpeed, minZoom, maxZoom);
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
