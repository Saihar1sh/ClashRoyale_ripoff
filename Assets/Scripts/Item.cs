using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Item : MonoBehaviour, IDragHandler
{
    public SpriteRenderer displaySR;
    public Sprite spriteToBeDisplayed;

    public bool isUsed = false;

    public GameObject modelPrefab;
    public Vector3 initialPos {  get; private set; } = Vector3.zero;
    public Quaternion initialRot {  get; private set; }


    private SortingGroup sortingGroup;
    private int initSortingLayer;

    private void Awake()
    {
        sortingGroup = GetComponent<SortingGroup>();
        initSortingLayer = sortingGroup.sortingOrder;
    }
    public void SelectCard()
    {
        sortingGroup.sortingOrder += 1;
    }
    public void DeselectCard()
    {
        sortingGroup.sortingOrder = initSortingLayer;
    }

    public void SetInitialPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        initialPos = position;
        initialRot = rotation;

        transform.position = position;
        transform.rotation = rotation;

    }
    public void SetInitialPositionAndRotation()
    {
        transform.position = initialPos;
        transform.rotation = initialRot;
    }

    void DeployModel()
    {
        modelPrefab.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("on drag");
        transform.position +=(Vector3) eventData.delta;
        //throw new System.NotImplementedException();
    }


}
