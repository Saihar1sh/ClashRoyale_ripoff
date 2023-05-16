using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Ray cameraRay;
    Transform target;
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
            //Debug.Log("mouse click ");
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
                            break;
                        case 6:
                            break;
                        case 7:
                            if (target == null)
                                mouseOffsetPos = hit.collider.transform.position - GetMouseWorldPos();
                            target = hit.collider.transform.parent;
                            break;
                        default:
                            break;
                    }
                }
/*                Debug.Log("hit on "+hitInfo.collider.gameObject.name+" layer: "+ hitInfo.collider.gameObject.layer);
                if(hitInfo.collider.gameObject.layer == 7)
                {


                    //Vector3 mousePos = Camera.main.ScreenToWorldPoint()
                }
                if (hitInfo.collider.gameObject.layer != 6)
                    return;
*/            }
            if(target)
            {
                //Vector3 targetPos = (Camera.main.ScreenToWorldPoint( Input.mousePosition));

                target.position = targetPos.WithY(target.position.y);
            }

        }
        else if(Input.GetMouseButtonUp(0))
        {
            target = null;
        }
    }
    private Vector3 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
