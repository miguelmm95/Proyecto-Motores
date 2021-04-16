using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float speed = 5f;

    public WeaponController weapon;

    Vector3 m_Movement;
    Animator m_Animator;
    Quaternion m_Rotation;
    Rigidbody m_Rigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        floorMask = LayerMask.GetMask("Floor");

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.isShooting = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            weapon.isShooting = false;
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        Turn();

        
    }

    void Move(float h, float v)
    {
        m_Movement.Set(h, 0f, v);

        m_Movement = m_Movement.normalized * speed * Time.fixedDeltaTime;

        bool horizontalInput = !Mathf.Approximately(h, 0f);
        bool verticalInput = !Mathf.Approximately(v, 0f);
        bool isWalking = horizontalInput || verticalInput;
        m_Animator.SetBool("isWalking", isWalking);

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
