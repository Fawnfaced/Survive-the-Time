using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    [HideInInspector]
    public float speed;
    public GameObject DeathEffect;
    private Rigidbody2D myBody;
    public int Health = 100;
    //public GameObject DeathEffect;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }


        
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag)
        ()
    }*/

    void Die()
    {
        EnemyCounter.scoreValue += 1;
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Awake()
    {
        myBody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity=new Vector2(speed, myBody.velocity.y);
    }
}
