using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    private float m_CurrHealth;

    public int health;
    public Slider m_Slider;
    public Image m_FillImage;
    public Color m_FullHEalthColor = Color.green;
    public Color m_ZeroHealthColor = Color.magenta;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        m_Slider.maxValue = health;
        m_CurrHealth = health;

        SetHealthUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_CurrHealth <= 0)
        {
            Destroy(gameObject);
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
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHEalthColor, m_CurrHealth / health);
    }
}
