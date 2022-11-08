using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{

    Vector2 displayCenter;

    // �u���b�N��ݒu����ʒu���ꉞ���A���^�C���Ŋi�[
    private Vector3 pos;

    [SerializeField]
    private GameObject blockPrefab;

    // Use this for initialization
    void Start()
    {
        // �� ��ʒ����̕��ʍ��W���擾����
        displayCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // �� �u�J��������̃��C�v����ʒ����̕��ʍ��W�����΂�
        Ray ray = Camera.main.ScreenPointToRay(displayCenter);
        // �� ���������I�u�W�F�N�g�����i�[����ϐ�
        RaycastHit hit;

        // �� Physics.Raycast() �Ń��C���΂�
        if (Physics.Raycast(ray, out hit))
        {
            // �� �����ʒu�̕ϐ��̒l���u�u���b�N�̌��� + �u���b�N�̈ʒu�v
            pos = hit.normal + hit.collider.transform.position;

            // �� �E�N���b�N
            if (Input.GetMouseButtonDown(1))
            {
                // �����ʒu�̕ϐ��̍��W�Ƀu���b�N�𐶐�
                Instantiate(blockPrefab, pos, Quaternion.identity);
            }

            // �� ���N���b�N
            if (Input.GetMouseButtonDown(0))
            {
                // �� ���C���������Ă���I�u�W�F�N�g���폜
                Destroy(hit.collider.gameObject);
            }
        }
    }
}