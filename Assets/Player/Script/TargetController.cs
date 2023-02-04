using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Transform target;
    private Vector3 direction;
    public float hideDist;
    // Update is called once per frame
    void Update()
    {
        direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        if (direction.magnitude < hideDist)
        {
            SetIndicatorActive(false);
        }
        else
        {
            SetIndicatorActive(true);
        }
    }

    private void SetIndicatorActive(bool isActive)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }
}
