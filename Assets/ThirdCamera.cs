using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    public Transform playerPos;
    
    public float smooth = 0.5f;
    private Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - playerPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = playerPos.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smooth);
    }
}
