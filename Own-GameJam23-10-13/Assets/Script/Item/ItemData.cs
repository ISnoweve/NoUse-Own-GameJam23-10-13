using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemData : MonoBehaviour
{
    public EItem ownItemData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(ownItemData);
        GameManager.Instance.ObjectDetect(ownItemData);
        Destroy(gameObject);
    }
}
