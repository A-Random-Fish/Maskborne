using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public bool showInventory;

    public List<GameObject> slots;
    public List<GameObject> wheelSlots;
    public List<string> masks;

    void Update()
    {
        for (int i = 0; i < slots.Count; i++)
            ChangeMaskDisplayed(slots, i, masks[i]);

        for (int i = 0; i < wheelSlots.Count; i++)
            ChangeMaskDisplayed(wheelSlots, i, masks[i]);

        if (!showInventory)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            }
        }
        else
        {
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    void ChangeMaskDisplayed(List<GameObject> slotList, int SlotID, string Mask)
    {
        slotList[SlotID].GetComponent<SpriteRenderer>().sprite = Resources.Load(Mask, typeof (Sprite)) as Sprite;
    }

    public void InventoryDisplay(bool displayType)
    {
        showInventory = displayType;
    }

}
