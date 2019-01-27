using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    private GameObject player;
    private PlayerSkills playerSkills;

    private bool isInteractable = false;
    private bool hasGottenKnowledge = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerSkills = player.GetComponent<PlayerSkills>();
        setInteractable(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInteractable && Input.GetKeyUp(KeyCode.E) && playerSkills != null && !hasGottenKnowledge)
        {
            playerSkills.setKnowledge(Random.Range(1, 4));
            hasGottenKnowledge = true;
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