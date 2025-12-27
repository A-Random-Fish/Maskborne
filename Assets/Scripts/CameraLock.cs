using UnityEngine;

public class CameraLock : MonoBehaviour
{
    [SerializeField] Transform camPos;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            Camera.main.transform.position = new Vector3(camPos.position.x, camPos.position.y, -10f);
        }
    }
}
