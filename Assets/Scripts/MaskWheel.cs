using UnityEngine;

public class MaskWheel : MonoBehaviour
{
    Vector3 mousePos;

    public int selectedWheelSlot;

    [SerializeField] Sprite slotSelect1;
    [SerializeField] Sprite slotSelect2;
    [SerializeField] Sprite slotSelect3;

    void Update()
    {
        mousePos = Input.mousePosition;

        Debug.Log(mousePos);

        if (mousePos.x < Screen.width/2 && mousePos.y > Screen.height/2)
        {
            selectedWheelSlot = 1;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = slotSelect1;
        }
        else if (mousePos.x > Screen.width/2 && mousePos.y > Screen.height/2)
        {
            selectedWheelSlot = 2;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = slotSelect2;
        }
        else
        {
            selectedWheelSlot = 3;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = slotSelect3;
        }
    }
}
