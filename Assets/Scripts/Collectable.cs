using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Just add the stats as a depencency injection
    // https://youtu.be/b0dVJx-ys2E?si=i5gn3jyyOzV9LQ2k
    public CollectableStats stats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && stats.type == CollectableStats.itemType.Currency)
        {
            PlayerManager.instance.statsMan.updateCurrency(stats.itemValue);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && stats.type == CollectableStats.itemType.Item)
        {
            if(stats.name == "HEALTHPOT") {
                PlayerManager.instance.statsMan.stats.numberOfHealthPotions++;
            }
            if(stats.name == "STEPPOT") {
                PlayerManager.instance.statsMan.stats.numberOfStepPotions++;
            }
            Destroy(gameObject);
        }
    }
}
