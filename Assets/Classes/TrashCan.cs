using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private Currency currency = Currency.scraps;

    private bool isInteractable = false;

    private bool isEmpty = false;

    private GameObject player;
    private PlayerInventory playerInventory;

    public Sprite emptySprite;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
        setInteractable(false);
    }

    private void Update()
    {
        if (isInteractable && Input.GetKeyUp(KeyCode.E) && playerInventory != null && !isEmpty)
        {
            playerInventory.setCurrency(currency, Random.Range(10, 50));
            this.GetComponent<SpriteRenderer>().sprite = emptySprite;
            isEmpty = true;
        }
    }

    private void setInteractable(bool interactable)
    {
        isInteractable = interactable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        setInteractable(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        setInteractable(false);
    }
}
