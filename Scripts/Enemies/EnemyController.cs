using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent nav;
    private Rigidbody rb;
    private float m_CurrHealth;
    private float shootDistance = 10;

    public WeaponController weapon;
    public float areaDetection = 5;
    public int health;
    public Slider m_Slider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        m_Slider.maxValue = health;
        m_CurrHealth = health;

        SetHealthUI();
    }

    GameObject FindPlayer()
    {
        GameObject m_Player = GameObject.FindGameObjectWithTag("Player");

        return m_Player;
    }

    void Update()
    {
        if(m_CurrHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        GameObject player = FindPlayer();
        float m_Distance = Vector3.Distance(player.transform.position,this.transform.position);

        if (m_Distance <= areaDetection)
        {
            if (nav.remainingDistance <= shootDistance)
            {
                Vector3 direction = (player.transform.position - transform.position);
                Quaternion myDirection = Quaternion.LookRotation(direction.normalized);
                Quaternion rotation = Quaternion.RotateTowards(transform.rotation, myDirection, 2.0f);


                if (Quaternion.Angle(rotation, myDirection) < 15.0f)
                {
                    weapon.isShooting = true;
                }
                else
                {
                    weapon.isShooting = false;
                }

                nav.SetDestination(player.transform.position);
                transform.rotation = rotation;
            }
            else
            {
                weapon.isShooting = false;
            }
        }
        else
        {
            weapon.isShooting = false;
        }

    }


    public void getDamage(int damage)
    {
        m_CurrHealth -= damage;
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        m_Slider.value = m_CurrHealth;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrHealth / health);
    }
}
