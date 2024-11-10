using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] GameObject ChestClosed;
    [SerializeField] GameObject ChestOpened;
    [SerializeField] bool isOpened;

    public override void Interact(Character character)
    {
        if (isOpened == false)
        {
            isOpened = true;

            ChestClosed.SetActive(false);
            ChestOpened.SetActive(true);
        }
    }
}
