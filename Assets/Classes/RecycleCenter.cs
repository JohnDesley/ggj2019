using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleCenter : MonoBehaviour
{
    private GameObject player;
    private PlayerInventory playerInventory;

    private bool isInteractable = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
        setInteractable(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInteractable && Input.GetKeyUp(KeyCode.E) && playerInventory != null)
        {
            if (playerInventory.scraps / 10 > 1)
            {
                int amountOfMoney = playerInventory.scraps / 10;
                int scrapsLeft = playerInventory.scraps % 10;

                playerInventory.setCurrency(Currency.scraps, -(playerInventory.scraps - scrapsLeft));
                playerInventory.setCurrency(Currency.money, amountOfMoney);
            }
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
