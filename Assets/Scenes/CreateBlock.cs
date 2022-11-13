using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateBlock : MonoBehaviour
{
    //Lineの角度を保存
    public float angleX=0;
    public float angleY=0;

    Vector2 displayCenter;

    // ブロックを設置する位置を一応リアルタイムで格納
    private Vector3 pos;
    // ↓ 当たったオブジェクト情報を格納する変数
    public RaycastHit hit;

    private GameObject Prefab;
    [SerializeField]
    private GameObject blockPrefab;
    [SerializeField]
    private GameObject ringPrefab;
    [SerializeField]
    private GameObject MPadPrefab;
    [SerializeField]
    private GameObject LinePrefab;

    public GameObject BlockView;

    //Dropdownを格納する変数
    [SerializeField] 
    private TMP_Dropdown dropdown;

    // Use this for initialization
    void Start()
    {
        // ↓ 画面中央の平面座標を取得する
        displayCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Prefab = blockPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        // ↓ 「カメラからのレイ」を画面中央の平面座標から飛ばす
        Ray ray = Camera.main.ScreenPointToRay(displayCenter);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 3, false);

        // ↓ Physics.Raycast() でレイを飛ばす
        if (Physics.Raycast(ray, out hit))
        {
            // ↓ 生成位置の変数の値を「ブロックの向き + ブロックの位置」
            pos = hit.normal + hit.collider.transform.position;
            pos = new Vector3(Mathf.Floor(hit.point.x) + 0.5f, Mathf.Floor(hit.point.y) + 0.5f, Mathf.Floor(hit.point.z) + 0.5f);
            //作成するブロックの位置を視覚化
            BlockView.transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Create();
        }

    }

    //生成
    public void Create()
    {
         if (!hit.collider.CompareTag("Item"))
         {
             if (Prefab == MPadPrefab)
             {
                 // 生成位置の変数の座標にブロックを生成
                 Instantiate(Prefab, new Vector3(Mathf.Floor(hit.point.x) + 0.5f, Mathf.Floor(hit.point.y) + 0.0f, Mathf.Floor(hit.point.z) + 0.5f), Quaternion.identity);
             }
             else if (Prefab == LinePrefab)
             {
                 // 生成位置の変数の座標にブロックを生成
                 GameObject clone = Instantiate(Prefab, new Vector3(Mathf.Floor(hit.point.x) + 0.5f, Mathf.Floor(hit.point.y) + 0.5f, Mathf.Floor(hit.point.z) + 0.5f), Quaternion.identity);
                 clone.transform.Rotate(angleX, angleY, 0, Space.World);
             }
             else
             {
                 // 生成位置の変数の座標にブロックを生成
                 Instantiate(Prefab, pos, Quaternion.identity);
             }
         }
    }

    //生成物の変更
    public void ChangeMaterial()
    {
        //DropdownのValueが0のとき（Blockが選択されているとき）
        if (dropdown.value == 0)
        {
            Prefab = blockPrefab;
        }
        //DropdownのValueが1のとき（Ringが選択されているとき）
        else if (dropdown.value == 1)
        {
            Prefab = ringPrefab;
        }
        //DropdownのValueが2のとき（MPadが選択されているとき）
        else if (dropdown.value == 2)
        {
            Prefab = MPadPrefab;
        }
        //DropdownのValueが3のとき（Lineが選択されているとき）
        else if (dropdown.value == 3)
        {
            Prefab = LinePrefab;
        }
    }


}