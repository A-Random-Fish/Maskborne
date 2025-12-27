using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WolfSummon : MonoBehaviour
{
    public GameObject[] allObjectsWithTag;

    GameObject nearestObject;

    [SerializeField] float moveSpeed;

    void Start()
    {
        allObjectsWithTag = GameObject.FindGameObjectsWithTag("monster");
    }

    void Update()
    {
        nearestObject = allObjectsWithTag[0];
        float distanceToNearest = Vector2.Distance(transform.position, nearestObject.transform.position);
        
        for (int i = 1; i < allObjectsWithTag.Length; i++)
        {
            float distanceToCurrent = Vector2.Distance(transform.position, allObjectsWithTag[i].transform.position);

            if (distanceToCurrent < distanceToNearest)
            {
                nearestObject = allObjectsWithTag[i];
                distanceToNearest = distanceToCurrent;
            }

            if (allObjectsWithTag[i] == null)
            {
                Destroy(this.gameObject);
            }
        }

        if (distanceToNearest > 30f)
        {
            Destroy(this.gameObject);
        }

        if (nearestObject == null)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, nearestObject.transform.position, moveSpeed);
    }
}
