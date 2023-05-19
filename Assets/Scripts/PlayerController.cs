using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Ray cameraRay;
    Item target_card;
    public LayerMask layerMask;

    Vector3 targetPos, mouseOffsetPos;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(cameraRay, 100f);
            if (hits.Length>0)
            {
                foreach (RaycastHit hit in hits)
                {
                    Debug.Log("hit on " + hit.collider.gameObject.name + " layer: " + hit.collider.gameObject.layer, hit.collider.gameObject);
                    switch (hit.collider.gameObject.layer)
                    {
                        case 0:
                            targetPos = hit.point;

                            if(target_card)
                                target_card.isUsed = false;
                            break;
                        case 6: // ground
                            targetPos = hit.collider.transform.position;

                            if(target_card)
                                target_card.isUsed = true;
                            break;

                        case 7: //card  
                            if (target_card == null)
                            {
                                mouseOffsetPos = hit.collider.transform.position - GetMouseWorldPos();
                                target_card = hit.collider.gameObject.GetComponent<Item>();
                                target_card.SelectCard();
                            }
                            break;
                        default:
                            if (target_card)
                                target_card.isUsed = false;

                            break;
                    }
                }
            }
            if(target_card)
            {
                target_card.transform.position = targetPos.WithY(target_card.transform.position.y);
            }

        }
        else if(Input.GetMouseButtonUp(0))
        {
            if (target_card)
            {
                if (!target_card.isUsed)
                {
                    //get card back to card's initial place
                    target_card.SetInitialPositionAndRotation();
                }
                else
                {
                    //deployed on ground

                }

                target_card.DeselectCard();
            }
            target_card = null;
        }
    }
    private Vector3 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
