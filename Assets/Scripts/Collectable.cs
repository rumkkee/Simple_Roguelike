using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Just add the stats as a depencency injection
    // https://youtu.be/b0dVJx-ys2E?si=i5gn3jyyOzV9LQ2k
    public CollectableStats stats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Object collected: {stats.name} typeof: {stats.type} value: {stats.itemValue}");
            Destroy(gameObject);
        }
    }
}
