using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    private Character.Team team;
    private Rigidbody2D rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        rig.velocity = transform.up * speed;
    }

    public void SetTeam (Character.Team t)
    {
        team = t;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if(damagable != null && damagable.GetTeam() != team)
        {
            damagable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
