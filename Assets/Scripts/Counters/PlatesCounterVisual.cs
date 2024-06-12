using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;

    private List<GameObject> plateVasualGameObjectList;

    private void Awake()
    {
        plateVasualGameObjectList = new List<GameObject>();
    }

    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounterOnOnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounterOnOnPlateRemoved;
    }

    private void PlatesCounterOnOnPlateRemoved(object sender, EventArgs e)
    {
        GameObject plateGameObject = plateVasualGameObjectList[plateVasualGameObjectList.Count - 1];
        plateVasualGameObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }

    private void PlatesCounterOnOnPlateSpawned(object sender, EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopPoint);

        float plateOffsetY = .1f;
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * plateVasualGameObjectList.Count, 0);
        
        plateVasualGameObjectList.Add(plateVisualTransform.gameObject);
    }
}
