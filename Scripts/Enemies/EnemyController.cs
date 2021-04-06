using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;

    public int health;
    public float currHealth;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        currHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void getDamage(int damage)
    {
        currHealth -= damage;
    }
}
