using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected UIController uiController;
    protected int scoreToAdd = 10;
    protected PlayerController player;
    protected float speed = 15;
    protected float damping = 10;
    protected float distance;
    protected float maxProximity = 0;
    // Start is called before the first frame update
    void Awake()
    {
        player = PlayerController.Instance;
        uiController = UIController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        AimAtPlayer();
        ChasePlayer();
    }
    protected void AimAtPlayer()
    {
        if(player != null)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * damping);
        }
    }
    protected void ChasePlayer()
    {
        if(player != null)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);
            if(distance > maxProximity)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            Debug.Log("Enemy got hit!");
            Destroy(other.gameObject);
            Die();
            uiController.UpdateScore(scoreToAdd);
        }
    }
}

