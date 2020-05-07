using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The interactable class. Classes that inherit this will be interacted with.
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    public bool isInRange;
    public abstract void Interact(Player player);
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        string playerTag = collision.gameObject.tag;
        if (playerTag == "Player")
        {
            isInRange = true;
        }
    }
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        string playerTag = collision.gameObject.tag;
        if (playerTag == "Player")
        {
            isInRange = false;
        }
    }
}
