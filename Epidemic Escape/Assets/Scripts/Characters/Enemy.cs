using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    protected State curState;

    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float chaseDistance;
    //[SerializeField] private float attackDistance;

    protected GameObject target;

    protected float lastAttackTime;
    protected float targetDistance;
    protected int attackMode;

    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        target = FindObjectOfType<Player>().gameObject;
    }

    protected virtual void Update()
    {
        targetDistance = Vector2.Distance(transform.position, target.transform.position);

        spriteRenderer.flipX = GetTargetDirection().x < 0;

        switch (curState)
        {
            case State.Idle: IdleUpdate(); break;
            case State.Chase: ChaseUpdate(); break;
            case State.Attack: AttackUpdate(); break;
        }
    }

    void ChangeState (State newState)
    {
        Debug.Log("ChangeState");
        curState = newState;
        Debug.Log(curState);
    }

    void IdleUpdate ()
    {
        if (targetDistance <= chaseDistance)
            ChangeState(State.Chase);
    }

    void ChaseUpdate ()
    {
        if (InAttackRange())
            ChangeState(State.Attack);
        else if (targetDistance > chaseDistance)
            ChangeState(State.Idle);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    protected virtual void AttackUpdate ()
    {
        Debug.Log("running attackupdate");
        if (targetDistance > chaseDistance)
            ChangeState(State.Idle);
        else if (!InAttackRange())
            ChangeState(State.Chase);

        if(CanAttack())
        {
            Debug.Log("can attack enemy");
            lastAttackTime = Time.time;
            AttackTarget();
        }
    }

    protected virtual void AttackTarget ()
    {

    }

    protected virtual bool CanAttack ()
    {
        return false;
    }

    protected virtual bool InAttackRange ()
    {
        Debug.Log("can attack enemy but false");
        //return targetDistance <= attackDistance;
        return false;
    }

    protected Vector2 GetTargetDirection ()
    {
        return (target.transform.position - transform.position).normalized;
    }

    public override void Die ()
    {
        DropItems();
        Destroy(gameObject);
    }

    protected void DropItems ()
    {

    }
}
