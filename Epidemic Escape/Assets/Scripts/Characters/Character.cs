using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour, IDamagable
{
    public enum Team
    {
        Player,
        Enemy
    }


    public string DisplayName;
    public int CurHp;
    public int MaxHp;

    [SerializeField] protected Team team;

    [Header("Audio")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip hitSFX;


    public event UnityAction onTakeDamage;
    public event UnityAction onHeal;

    public virtual void TakeDamage(int damageToTake)
    {
        Debug.Log("taking damage");
        CurHp -= damageToTake;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();

        if (audioSource == null)
            Debug.Log("audioSource == null");

        hitSFX = Resources.Load<AudioClip>("Hit");

        audioSource.PlayOneShot(hitSFX);



        onTakeDamage?.Invoke();

        if (CurHp <= 0)
            Die();
    }

    public virtual void Die()
    //public void Die()
    {
        
    }

    public Team GetTeam()
    {
        Debug.Log("get team");
        return team;
    }

    public virtual void Heal (int healAmount)
    //public void Heal(int healAmount)
    {
        CurHp += healAmount;

        if (CurHp > MaxHp)
            CurHp = MaxHp;

        onHeal?.Invoke();
    }
}
