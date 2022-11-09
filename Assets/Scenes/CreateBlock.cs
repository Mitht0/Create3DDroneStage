using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{

    Vector2 displayCenter;

    // �u���b�N��ݒu����ʒu���ꉞ���A���^�C���Ŋi�[
    private Vector3 pos;

    private GameObject Prefab;
    [SerializeField]
    private GameObject blockPrefab;
    [SerializeField]
    private GameObject ringPrefab;
    [SerializeField]
    private GameObject MPadPrefab;
    public GameObject BlockView;

    // Use this for initialization
    void Start()
    {
        // �� ��ʒ����̕��ʍ��W���擾����
        displayCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Prefab = blockPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        // �� �u�J��������̃��C�v����ʒ����̕��ʍ��W�����΂�
        Ray ray = Camera.main.ScreenPointToRay(displayCenter);
        // �� ���������I�u�W�F�N�g�����i�[����ϐ�
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 3, false);

        // �� Physics.Raycast() �Ń��C���΂�
        if (Physics.Raycast(ray, out hit))
        {
            // �� �����ʒu�̕ϐ��̒l���u�u���b�N�̌��� + �u���b�N�̈ʒu�v
            pos = hit.normal + hit.collider.transform.position;
            pos = new Vector3(Mathf.Floor(hit.point.x) + 0.5f, Mathf.Floor(hit.point.y) + 0.5f, Mathf.Floor(hit.point.z) + 0.5f);
            //�쐬����u���b�N�̈ʒu�����o��
            BlockView.transform.position = pos;

            // �� �E�N���b�N
            if (Input.GetMouseButtonDown(1))
            {
                if (!hit.collider.CompareTag("Item"))
                {
                    if (Prefab==MPadPrefab) 
                    {
                        // �����ʒu�̕ϐ��̍��W�Ƀu���b�N�𐶐�
                        Instantiate(Prefab, new Vector3(Mathf.Floor(hit.point.x) + 0.5f, Mathf.Floor(hit.point.y) + 0.0f, Mathf.Floor(hit.point.z) + 0.5f), Quaternion.identity);
                    }
                    else
                    {
                        // �����ʒu�̕ϐ��̍��W�Ƀu���b�N�𐶐�
                        Instantiate(Prefab, pos, Quaternion.identity);
                    }
                }
            }

            // �� ���N���b�N
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    // �� ���C���������Ă���I�u�W�F�N�g���폜
                    Destroy(hit.collider.gameObject);
                }
            }

            
        }
    }

    public void ChangeBlock()
    {
        Prefab = blockPrefab;
    }

    public void ChangeRing()
    {
        Prefab = ringPrefab;
    }
    public void ChangeMPad()
    {
        Prefab = MPadPrefab;
    }
}