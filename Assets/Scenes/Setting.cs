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
        //Panel�̃I���I�t
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
        // GameObject�^�̔z��cubes�ɁA"Item"�^�O�̂����I�u�W�F�N�g�����ׂĊi�[
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Item");

        // GameObject�^�̕ϐ�cube�ɁAcubes�̒��g�����ԂɎ��o���B
        // foreach�͔z��̗v�f�̐��������[�v���܂��B
        foreach (GameObject cube in cubes)
        {
            // ����
            Destroy(cube);
        }
    }

}
