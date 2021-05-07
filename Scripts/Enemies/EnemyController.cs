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
    
    public float areaDetection = 10f;
    public int health;
    public Slider m_Slider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    public PlayerMovement m_Player;


    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        m_Slider.maxValue = health;
        m_CurrHealth = health;
        m_Player = GameObject.FindObjectOfType<PlayerMovement>();

        SetHealthUI();
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
        float m_Distance = Vector3.Distance(m_Player.transform.position,this.transform.position);

        if (m_Distance < areaDetection)
        {
            Debug.Log("Voy a por el jugador");
        }
    }

    void GoToPlayer()
    {
        
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
