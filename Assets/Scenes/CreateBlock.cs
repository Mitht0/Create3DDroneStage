using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateBlock : MonoBehaviour
{
    //Line�̊p�x��ۑ�
    public float angleX=0;
    public float angleY=0;

    Vector2 displayCenter;

    // �u���b�N��ݒu����ʒu���ꉞ���A���^�C���Ŋi�[
    private Vector3 pos;
    // �� ���������I�u�W�F�N�g�����i�[����ϐ�
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

    //Dropdown���i�[����ϐ�
    [SerializeField] 
    private TMP_Dropdown dropdown;

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

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 3, false);

        // �� Physics.Raycast() �Ń��C���΂�
        if (Physics.Raycast(ray, out hit))
        {
            // �� �����ʒu�̕ϐ��̒l���u�u���b�N�̌��� + �u���b�N�̈ʒu�v
            pos = hit.normal + hit.collider.transform.position;
            pos = new Vector3(Mathf.Floor(hit.point.x) + 0.5f, Mathf.Floor(hit.point.y) + 0.5f, Mathf.Floor(hit.point.z) + 0.5f);
            //�쐬����u���b�N�̈ʒu�����o��
            BlockView.transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Create();
        }

    }

    //����
    public void Create()
    {
         if (!hit.collider.CompareTag("Item"))
         {
             if (Prefab == MPadPrefab)
             {
                 // �����ʒu�̕ϐ��̍��W�Ƀu���b�N�𐶐�
                 Instantiate(Prefab, new Vector3(Mathf.Floor(hit.point.x) + 0.5f, Mathf.Floor(hit.point.y) + 0.0f, Mathf.Floor(hit.point.z) + 0.5f), Quaternion.identity);
             }
             else if (Prefab == LinePrefab)
             {
                 // �����ʒu�̕ϐ��̍��W�Ƀu���b�N�𐶐�
                 GameObject clone = Instantiate(Prefab, new Vector3(Mathf.Floor(hit.point.x) + 0.5f, Mathf.Floor(hit.point.y) + 0.5f, Mathf.Floor(hit.point.z) + 0.5f), Quaternion.identity);
                 clone.transform.Rotate(angleX, angleY, 0, Space.World);
             }
             else
             {
                 // �����ʒu�̕ϐ��̍��W�Ƀu���b�N�𐶐�
                 Instantiate(Prefab, pos, Quaternion.identity);
             }
         }
    }

    //�������̕ύX
    public void ChangeMaterial()
    {
        //Dropdown��Value��0�̂Ƃ��iBlock���I������Ă���Ƃ��j
        if (dropdown.value == 0)
        {
            Prefab = blockPrefab;
        }
        //Dropdown��Value��1�̂Ƃ��iRing���I������Ă���Ƃ��j
        else if (dropdown.value == 1)
        {
            Prefab = ringPrefab;
        }
        //Dropdown��Value��2�̂Ƃ��iMPad���I������Ă���Ƃ��j
        else if (dropdown.value == 2)
        {
            Prefab = MPadPrefab;
        }
        //Dropdown��Value��3�̂Ƃ��iLine���I������Ă���Ƃ��j
        else if (dropdown.value == 3)
        {
            Prefab = LinePrefab;
        }
    }


}