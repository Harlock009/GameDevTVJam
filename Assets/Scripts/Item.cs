using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        string playerTag = collision.gameObject.tag;
        if (playerTag == "Player")
        {
            collision.gameObject.GetComponent<Player>().PickUpItem(itemData);
            Destroy(gameObject);
        }
    }
}
