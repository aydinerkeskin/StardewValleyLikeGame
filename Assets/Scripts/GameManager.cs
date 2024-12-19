﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject Player;

    public ItemContainer inventoryContainer;

    public ItemDragAndDropController dragAndDropController;
}
