using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemManager Instance;
    [Space(10)]
    public List<GameObject> StageOne;
    [Space(10)]
    public List<GameObject> StageTwo;
    [Space(10)]
    public List<GameObject> StageThree;

    private void Awake()
    {
        Instance = this;
    }
}
