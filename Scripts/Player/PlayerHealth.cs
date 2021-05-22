using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float m_CurrHealth;

    public float health;
    public Slider m_Slider;
    public Image m_FillImage;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;

    void Start()
    {
        m_Slider.maxValue = health;
        m_CurrHealth = health;

        SetHealthUI();

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
