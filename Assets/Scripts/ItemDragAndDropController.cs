using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject itemIcon;

    RectTransform iconTransform;
    Image itemIconImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        if (itemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;
        }
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

        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            itemIcon.SetActive(false);
            itemIconImage.sprite = null;
        }
        else
        {
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.Icon;
        }
    }
}
