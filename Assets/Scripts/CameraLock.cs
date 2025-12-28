using UnityEngine;
using System.Collections.Generic;

public class CameraLock : MonoBehaviour
{
    [SerializeField] Transform camPos;

    [SerializeField] List<GameObject> enemies;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            Camera.main.transform.position = new Vector3(camPos.position.x, camPos.position.y, -10f);
            
            if (enemies.Count != 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    EnemyDetection ed = enemies[i].GetComponent<EnemyDetection>();
                    ed.playerInRoom = true;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            if (enemies.Count != 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    EnemyDetection ed = enemies[i].GetComponent<EnemyDetection>();
                    ed.playerInRoom = false;
                }
            }
        }
    }
}
