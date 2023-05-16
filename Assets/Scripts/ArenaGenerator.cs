using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaGenerator : MonoBehaviour
{
    public Vector2 tileSpacing;

    [SerializeField]
    GameObject tilePrefab;

    [SerializeField]
    Transform tilesParent;

    Vector2 index;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                if ((i is 14 or 15) && !(j is 2 or 15))
                    continue;

                index.Set(i, j);
                Vector3 spawnPos = index.Multiply(Vector2.one + tileSpacing).ConvertV2ToV3_XZ_plane();
                GameObject _gameObject = Instantiate(tilePrefab, spawnPos, Quaternion.identity,tilesParent);
                _gameObject.name = index.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
