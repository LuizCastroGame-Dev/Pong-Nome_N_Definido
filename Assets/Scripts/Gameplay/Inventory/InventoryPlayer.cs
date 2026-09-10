using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPlayer : MonoBehaviour
{
    public Image[] slots;
    public Sprite emptySlotSprite;

    public void refreshUI(List<GameObject> inventory)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.Count)
            {
                SpriteRenderer sr = inventory[i].GetComponent<SpriteRenderer>();
                if(sr != null)
                {
                    slots[i].sprite = sr.sprite;
                }
            }
            else
            {
                slots[i].sprite = emptySlotSprite;
            }
        }
    }
}
