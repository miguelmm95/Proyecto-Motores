using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{
    public float speed;
    public int damage;
    public float lifeTime;

    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {  
        //Debug.Log(collision.collider.name);
        
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().getDamage(damage);
            Destroy(gameObject);
        }
    }
}
