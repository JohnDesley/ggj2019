using UnityEngine;
using System.Collections;

public enum Currency { scraps, money }

public class CurrencyController : MonoBehaviour
{
    public Currency currency = Currency.money;
    public int amount = 1;

    private bool isInteractable = false;

    public GameObject interactPop;

    private GameObject player;
    private PlayerInventory playerInventory;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
        setInteractable(false);
    }

    private void Update()
    {
        if (isInteractable && Input.GetKeyUp(KeyCode.E) && playerInventory != null)
        {
            playerInventory.setCurrency(currency, amount);
        }
    }

    private void setInteractable(bool interactable)
    {
        isInteractable = interactable;
        interactPop.GetComponent<Renderer>().enabled = interactable;
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