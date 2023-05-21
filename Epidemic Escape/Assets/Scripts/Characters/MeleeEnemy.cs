using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private int damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;

    

    protected override void AttackTarget()
    {

        Debug.Log("attacking target");
        IDamagable damagable = target.GetComponent<IDamagable>();

        if(damagable != null)
            damagable.TakeDamage(damage);
    }

    protected override bool CanAttack()
    {
        Debug.Log("CanAttack");
        return Time.time - lastAttackTime > attackRate;
    }

    protected override bool InAttackRange()
    {

        return targetDistance <= attackRange;
        
    }
}
