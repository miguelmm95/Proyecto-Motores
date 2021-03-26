using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float speed = 5f;

    Vector3 m_Movement;
    Quaternion m_Rotation;
    Rigidbody m_Rigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        Turn();
        //m_Movement.Set(horizontal, 0f, vertical);
        //m_Movement.Normalize();

        //bool horizontalInput = !Mathf.Approximately(horizontal, 0f);
        //bool verticalInput = !Mathf.Approximately(vertical, 0f);
        //bool isWalking = horizontalInput || verticalInput;
    }

    void Move(float h, float v)
    {
        m_Movement.Set(h, 0f, v);

        m_Movement = m_Movement.normalized * speed * Time.fixedDeltaTime;

        m_Rigidbody.MovePosition(transform.position + m_Movement);
    }

    void Turn()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            m_Rotation = Quaternion.LookRotation(playerToMouse);

            m_Rigidbody.MoveRotation(m_Rotation);

        }
    }
}
