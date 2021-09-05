using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] GameObject enemyProjectilePrefab;
    [SerializeField] GameObject bodyPartProjectile;

    private bool canShoot;
    private float shotCooldownTime = 0.30f;

    public static Enemy Instance { get; private set; }
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        player = PlayerController.Instance;
        uiController = UIController.Instance;

        speed = 6;
        damping = 2;
        maxProximity = 15;

        canShoot = true;

    }

    // Update is called once per frame
    void Update()
    {
        AimAtPlayer();
        ChasePlayer();
        Shoot();
    }

    void Shoot()
    {
        if (distance <= 20 && canShoot)
        {
            Instantiate(enemyProjectilePrefab, transform.position, transform.rotation);
            canShoot = false;
            StartCoroutine(shotCooldown());
        }
    }

    IEnumerator shotCooldown()
    {
        yield return new WaitForSeconds(shotCooldownTime);
        canShoot = true;
    }

    public override void Die()
    {
        SelfDestruction();
        base.Die();
    }
    public void SelfDestruction()
    {
        Instantiate(bodyPartProjectile, transform.position, transform.rotation = Quaternion.Euler(0, 0, 0));
        Instantiate(bodyPartProjectile, transform.position, transform.rotation = Quaternion.Euler(0, 180, 0));
        Instantiate(bodyPartProjectile, transform.position, transform.rotation = Quaternion.Euler(0, 90, 0));
        Instantiate(bodyPartProjectile, transform.position, transform.rotation = Quaternion.Euler(0, -90, 0));
    }

}
