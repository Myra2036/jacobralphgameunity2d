using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothing;
    public Transform target;

    public Vector2 minPos;
    public Vector2 maxPos;

    private void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
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
