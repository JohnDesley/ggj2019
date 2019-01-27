using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobOffice : MonoBehaviour
{
    private GameObject player;
    private PlayerInventory playerInventory;
    private PlayerSkills playerSkills;

    private bool isInteractable = false;
    private bool hasDoneJob = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
        playerSkills = player.GetComponent<PlayerSkills>();
        setInteractable(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInteractable && Input.GetKeyUp(KeyCode.E) && playerInventory != null && !hasDoneJob)
        {
            playerInventory.setCurrency(Currency.money, (int)Mathf.Max(5, Mathf.Ceil(playerSkills.knowledge / 2) + 5));
            hasDoneJob = true;
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
