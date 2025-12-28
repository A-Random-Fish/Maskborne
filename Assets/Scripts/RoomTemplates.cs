using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] downRooms;
    public GameObject[] upRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    bool spawnedBoss;
    [SerializeField] List<GameObject> boss;
    GameObject bossObject;

    GameObject bossText;

    bool bossTextEnabled;

    void Awake()
    {
        bossText = GameObject.Find("BossDeadText");
        bossText.SetActive(false);
    }

    void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count-1)
                {
                    bossObject = Instantiate(boss[Random.Range(0, boss.Count)], rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

        if (spawnedBoss == true && bossObject == null && !bossTextEnabled)
        {
            bossTextEnabled = true;
            bossText.SetActive(true);
        }
    }
}
