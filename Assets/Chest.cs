using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool isActivated = false;
    public Sprite openSprite;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    public float lootDropDelay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            PartcleManager.instance.makePartcleFX(PartcleManager.PartcleType.Treasure, _collider.bounds.center);
            _spriteRenderer.sprite = openSprite;
            StartCoroutine(SpawnLoot());
        }
    }

    private IEnumerator SpawnLoot()
    {
        // Randomize the number of loot items to drop
        int lootCount = Random.Range(10, 40);

        for (int i = 0; i < lootCount; i++)
        {
            // Instantiate the loot item at the chest's position
            LootManager.instance.InstantiateLoot(_collider.bounds.center);
            
            // Wait for a specified delay before dropping the next item
            yield return new WaitForSeconds(lootDropDelay);
        }
    }
}
