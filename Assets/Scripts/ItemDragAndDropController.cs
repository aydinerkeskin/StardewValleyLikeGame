using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;

    private void Start()
    {
        itemSlot = new ItemSlot();
    }

    public void OnClick(ItemSlot newItemSlot)
    {
        if (itemSlot.item == null)
        {
            itemSlot.Copy(newItemSlot);
            newItemSlot.Clear();
        }
        else
        {
            Item item = newItemSlot.item;
            int count = newItemSlot.count;

            newItemSlot.Copy(itemSlot);

            itemSlot.Set(item, count);
        }
    }
}
