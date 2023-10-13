using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject stageOneSpawner;
    public GameObject stageTwoSpawner;
    public GameObject stageThreeSpawner;
    public GameObject stageSecretSpawner;
    public GameObject stumpSecretBackSpawner;

    public TextMeshProUGUI secretTextBox;
    public TextMeshProUGUI gameEnd;
    

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        secretTextBox.enabled = false;
        gameEnd.enabled = false;
        stumpSecretBackSpawner.SetActive(false);
        ResetPlayerPostion();
    }

    private void ResetPlayerPostion()
    {
        Transform playerPosition = PlayerMovement.Instance.Own.transform;
        Transform spawnOnePosition = stageOneSpawner.transform;

        playerPosition.position = spawnOnePosition.position;
    }

    public void ObjectDetect(EItem Item)
    {
        PlayerMovement.Instance.ResetVelocity();
        Transform playerPosition = PlayerMovement.Instance.Own.transform;
        
        if (Item == EItem.Cg)
        {
            gameEnd.enabled = true;
        }
        else if (Item == EItem.Dtwo)
        {
            Transform spawnTwoPostion = stageTwoSpawner.transform;
            playerPosition.position = spawnTwoPostion.position;
        }
        else if(Item == EItem.Oumua)
        {
            Transform spawnThreePostion = stageThreeSpawner.transform;
            playerPosition.position = spawnThreePostion.position;
        }
        else if(Item == EItem.Haga)
        {
            Transform spawnScretPostion = stageSecretSpawner.transform;
            playerPosition.position = spawnScretPostion.position;
            
            SecretAction();
            
            stumpSecretBackSpawner.SetActive(true);
        }

        if (Item == EItem.Nemo || Item == EItem.Lubee)
        {
            Transform spawnBackPosition = stumpSecretBackSpawner.transform;
            playerPosition.position = spawnBackPosition.position;

            secretTextBox.enabled = false;
        }
    }

    private void SecretAction()
    {
        secretTextBox.enabled = true;
    }
}
