using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public LayerMask enemyLayerMask;
    private Collider2D _objectCollider;

    public void Start()
    {
        _objectCollider = GetComponent<Collider2D>();
    }
    public bool checkAttack(int dmg, Vector2 direction, bool isAttacked)
    {
        float rayDistance = 1.0f;
        Vector2 rayOrigin = _objectCollider.bounds.center;
        // Raycast in the given direction (the direction the player wants to move)
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction, rayDistance, enemyLayerMask);

        if (hit.collider == null)
        {
            return false;
        }

        if (!hit.collider.CompareTag("Enemy"))
        {
            return false;
        }
        Debug.Log("Enemy hit: " + hit.transform.gameObject);
        // GameObject enemyObj = hit.transform.
        EnemyEntity tmp = hit.transform.gameObject.GetComponent<EnemyEntity>();
        if (tmp == null)
        {
            return true;
        }
        if(!isAttacked) tmp.takeDamage(dmg);
        return true;
    }

    public void action()
    {
        Debug.Log("Action done!");

    }

    public void switchPotions()
    {
        Debug.Log("Switching Potions");
        PlayerManager.instance.statsMan.potUI.ToggleActivePotionUI();
    }

    public void usePotion()
    {
        Debug.Log("Use potions");
        PlayerManager.instance.statsMan.updatePotion();
    }
}
