using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public bool isShooting;

    public BulletControler bullet;
    public float bulletSpeed;
    public int bulletDamage;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    void Update()
    {
        if (isShooting)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletControler newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletControler;
                newBullet.speed = bulletSpeed;
                newBullet.damage = bulletDamage;
            }
        }
        else
        {
            shotCounter = 0;
        }
    }
}
