using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEquipItem : EquipItem
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private AudioClip shootSFX;
    private float lastAttackTime;

    public override void OnUse()
    {
        RangedWeaponItemData i = item as RangedWeaponItemData;

        if (Time.time - lastAttackTime < i.FireRate)
            return;

        //return if we don't have a projectile in our inventory

        lastAttackTime = Time.time;

        //spawn the projectile
        //remove the projectile from inventory
        //play the sound effect
    }
}
