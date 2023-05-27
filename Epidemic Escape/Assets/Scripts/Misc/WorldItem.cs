using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField] private float spawnForce;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip pickupSFX;

    private ItemData itemToGive;

    private void Start()
    {
        Rigidbody2D rig = GetComponent<Rigidbody2D>();

        rig.AddForce(Random.insideUnitCircle * spawnForce, ForceMode2D.Impulse);
    }

    public void SetItem (ItemData item)
    {
        itemToGive = item;
        spriteRenderer.sprite = item.Icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Inventory.Instance.AddItem(itemToGive);
            //play sound effect
            AudioManager.Instance.PlayPlayerSound(pickupSFX);
            Destroy(gameObject);
        }
    }
}
