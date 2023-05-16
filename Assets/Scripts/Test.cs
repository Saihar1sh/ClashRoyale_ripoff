using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Transform[] spriteTranforms;
    //public RectTransform[] sprite_rects;

    public Image[] toCopy;

    public Canvas canvas;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < spriteTranforms.Length; i++)
        {
            spriteTranforms[i].transform.position = toCopy[i].transform.position;
            spriteTranforms[i].transform.rotation = Quaternion.Euler( canvas.transform.rotation.eulerAngles);
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
