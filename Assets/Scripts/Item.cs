using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IDragHandler
{
    public SpriteRenderer displaySR;
    public Sprite spriteToBeDisplayed;

    public GameObject modelPrefab;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("on drag");
        transform.position +=(Vector3) eventData.delta;
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
