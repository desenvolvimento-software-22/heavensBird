using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public Transform dropPoint;
    public GameObject item;

    public void Drop()
    {
        Instantiate(item, dropPoint.position, Quaternion.identity);
    }
}
