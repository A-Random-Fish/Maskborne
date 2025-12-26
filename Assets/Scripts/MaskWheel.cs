using UnityEngine;

public class MaskWheel : MonoBehaviour
{
    [SerializeField] Inventory inv;
    [SerializeField] PlayerController pc;

    Vector3 mousePos;

    public int selectedWheelSlot;

    [SerializeField] Sprite slotSelect1;
    [SerializeField] Sprite slotSelect2;
    [SerializeField] Sprite slotSelect3;

    void Update()
    {
        mousePos = Input.mousePosition;

        if (mousePos.x < Screen.width/2 && mousePos.y > Screen.height/2)
        {
            selectedWheelSlot = 0;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = slotSelect1;
        }
        else if (mousePos.x > Screen.width/2 && mousePos.y > Screen.height/2)
        {
            selectedWheelSlot = 1;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = slotSelect2;
        }
        else
        {
            selectedWheelSlot = 2;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = slotSelect3;
        }

        pc.maskEquipped = inv.masks[selectedWheelSlot];
    }
}
