using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Item[] itemCards;
    //public RectTransform[] sprite_rects;

    public Image[] toCopy;

    public Canvas canvas;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;// WaitForSeconds(0.1f);
        for (int i = 0; i < itemCards.Length; i++)
        {
            itemCards[i].SetInitialPositionAndRotation(toCopy[i].transform.position, Quaternion.Euler(canvas.transform.rotation.eulerAngles));
        //yield return new WaitForSeconds(0.1f);
            itemCards[i].displaySR.size =  toCopy[i].rectTransform.sizeDelta;
            //itemCards[i].transform.rotation = Quaternion.Euler( canvas.transform.rotation.eulerAngles);
            //sprite_rects[i] = toCopy[i].rectTransform;
            //Debug.Log(toCopy[i].rectTransform.sizeDelta + " " + sprite_rects[i].sizeDelta);
            //transforms[i].localScale = toCopy[i].localScale;
        } 
    }
    [ContextMenu("DisplayGameobjectsByLayer")]
    public void DisplayGameobjectsByLayer()
    {
        GameObject parent = new("parent");
        GameObject[] layerObjs = new GameObject[8];
        for (int i = 0; i < 8; i++)
        {
            GameObject gameObject = new GameObject("Layer " + i);
            gameObject.transform.SetParent(parent.transform);
            layerObjs[i] = gameObject;
        }
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();
        foreach (var item in gameObjects)
        {
            Debug.Log(item.layer);
            item.transform.SetParent(layerObjs[item.layer].transform);
        }
    }

    // Update is called once per frame
/*    void Update()
    {
    }
*/}
