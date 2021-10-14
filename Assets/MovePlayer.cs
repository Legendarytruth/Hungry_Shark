using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed = 10f;
    public float sprintSpeed = 20f;
    public float turnSmooth = 0.1f;
    float turnVelocity;
    private Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;

        if(dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSmooth);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDir = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized * sprintSpeed * Time.deltaTime;
            }
            else
            {
                moveDir = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized * walkSpeed * Time.deltaTime;
            }

            controller.Move(moveDir);
        }
    }
}
