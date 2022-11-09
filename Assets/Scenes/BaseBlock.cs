using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    public GameObject prefab;
    public int quantity=10;
    private float xPos;
    private float zPos;

    void Start()
    {
        xPos = quantity / 2 * -1+0.5f;
        zPos = quantity / 2 * -1+0.5f;
        for (int i = quantity/2*-1; i < quantity/2; i++)
        {
            for (int j = quantity/2*-1; j < quantity/2; j++)
            {
                zPos += 1.0f;
                Instantiate(prefab, new Vector3(xPos, -0.5f, zPos), Quaternion.identity);

            }
            zPos = quantity / 2 * -1;
            xPos += 1.0f;
        }
    }
}
