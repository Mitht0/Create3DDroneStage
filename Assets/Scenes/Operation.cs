using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour
{
    //触れているオブジェクトを取得
    private GameObject Object;
    //回転変数の取得のためのスクリプト
    public CreateBlock CreateBlockScript;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            Destroy();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            RotateX();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            RotateY();
        }
    }

    public void Destroy()
    {
        Destroy(Object);
    }
    
    public void RotateX()
    {
        CreateBlockScript.angleX += 90.0f;
        if(CreateBlockScript.angleX >= 360) CreateBlockScript.angleX = 0.0f;
        Object.transform.Rotate(90, 0 , 0, Space.World);
    }
    public void RotateY()
    {
        CreateBlockScript.angleY += 90.0f;
        if (CreateBlockScript.angleX >= 360) CreateBlockScript.angleX = 0.0f;
        Object.transform.Rotate(0, 90, 0, Space.World);
    }

    void OnTriggerEnter(Collider collision)
    {
        Object = collision.transform.root.gameObject;
        //Debug.Log(collision.gameObject.name);
    }

}
