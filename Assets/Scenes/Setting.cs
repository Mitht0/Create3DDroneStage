using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Setting : MonoBehaviour
{
    public GameObject Panel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Active();
        }
    }

    public void Active()
    {
        //Panelのオンオフ
        if (Panel.activeSelf == false)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
    }

    public void AllDestroy()
    {
        // GameObject型の配列cubesに、"Item"タグのついたオブジェクトをすべて格納
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Item");

        // GameObject型の変数cubeに、cubesの中身を順番に取り出す。
        // foreachは配列の要素の数だけループします。
        foreach (GameObject cube in cubes)
        {
            // 消す
            Destroy(cube);
        }
    }

}
