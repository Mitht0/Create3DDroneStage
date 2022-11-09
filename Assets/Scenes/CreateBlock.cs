using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{

    Vector2 displayCenter;

    // ブロックを設置する位置を一応リアルタイムで格納
    private Vector3 pos;

    [SerializeField]
    private GameObject blockPrefab;
    public GameObject BlockView;

    // Use this for initialization
    void Start()
    {
        // ↓ 画面中央の平面座標を取得する
        displayCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        // ↓ 「カメラからのレイ」を画面中央の平面座標から飛ばす
        Ray ray = Camera.main.ScreenPointToRay(displayCenter);
        // ↓ 当たったオブジェクト情報を格納する変数
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 3, false);

        // ↓ Physics.Raycast() でレイを飛ばす
        if (Physics.Raycast(ray, out hit))
        {
            // ↓ 生成位置の変数の値を「ブロックの向き + ブロックの位置」
            pos = hit.normal + hit.collider.transform.position;
            pos = new Vector3(Mathf.Floor(hit.point.x) + 0.5f, Mathf.Floor(hit.point.y) + 0.5f, Mathf.Floor(hit.point.z) + 0.5f);
            //作成するブロックの位置を視覚化
            BlockView.transform.position = pos;

            // ↓ 右クリック
            if (Input.GetMouseButtonDown(1))
            {
                if (!hit.collider.CompareTag("Block"))
                {
                    // 生成位置の変数の座標にブロックを生成
                    Instantiate(blockPrefab, pos, Quaternion.identity);
                }
            }

            // ↓ 左クリック
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.CompareTag("Block"))
                {
                    // ↓ レイが当たっているオブジェクトを削除
                    Destroy(hit.collider.gameObject);
                }
            }

            
        }
    }

}