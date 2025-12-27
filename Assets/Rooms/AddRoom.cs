using UnityEngine;

public class AddRoom : MonoBehaviour
{
    RoomTemplates templates;
    
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }
}
