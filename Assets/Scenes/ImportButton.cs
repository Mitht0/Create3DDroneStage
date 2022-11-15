using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.IO;
using System;
using UnityEngine.UI;

public class ImportButton : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void FileImporterCaptureClick();

    [DllImport("__Internal")]
    private static extern void FileExporterCaptureClick();

    //�R�s�[
    [DllImport("__Internal")]
    private static extern void CopyWebGL(string str);

    //Material
    private GameObject Prefab;
    [SerializeField]
    private GameObject blockPrefab;
    [SerializeField]
    private GameObject ringPrefab;
    [SerializeField]
    private GameObject MPadPrefab;
    [SerializeField]
    private GameObject LinePrefab;

    //�f�[�^�z��
    [System.Serializable]
    public class SaveData
    {
        public SaveObject[] maindata;
    }
    //�I�u�W�F�N�g�̃f�[�^
    [System.Serializable]
    public class SaveObject
    {
        public Vector3 position;
        public Vector3 eulerAngles;
        public string Prefab;
    }

    public void OnButtonPointerDown()
    {
        FileImporterCaptureClick();
    }

    public void FileSelected(string url)
    {
        StartCoroutine(LoadJson(url));
    }

    public Text a;
    private IEnumerator LoadJson(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        Debug.Log(www.bytes);
        ImportJSON(www.bytes);
    }

    public void ImportJSON(Byte[] bytes)
    {
        //���ׂẴI�u�W�F�N�g������
        // GameObject�^�̔z��cubes�ɁA"Item"�^�O�̂����I�u�W�F�N�g�����ׂĊi�[
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Item");

        // GameObject�^�̕ϐ�cube�ɁAcubes�̒��g�����ԂɎ��o���B
        // foreach�͔z��̗v�f�̐��������[�v���܂��B
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }

  
        string datastr = "";
        datastr = System.Text.Encoding.ASCII.GetString(bytes);
        SaveData data = JsonUtility.FromJson<SaveData>(datastr);

        foreach (SaveObject savedata in data.maindata)
        {
            Debug.Log(savedata.position);
            Debug.Log(savedata.eulerAngles);
            Debug.Log(savedata.Prefab);

            if (savedata.Prefab == "Block(Clone)") Prefab = blockPrefab;
            else if (savedata.Prefab == "Ring(Clone)") Prefab = ringPrefab;
            else if (savedata.Prefab == "MPad(Clone)") Prefab = MPadPrefab;
            else if (savedata.Prefab == "LinePivot(Clone)") Prefab = LinePrefab;
            // �����ʒu�̕ϐ��̍��W�Ƀu���b�N�𐶐�
            Vector3 pos = savedata.position;
            GameObject clone = Instantiate(Prefab, pos, Quaternion.identity);
            clone.transform.Rotate(savedata.eulerAngles.x, savedata.eulerAngles.y, savedata.eulerAngles.z, Space.World);

        }
    }

    public void ExportJSON()
    {
        // GameObject�^�̔z��cubes�ɁA"Item"�^�O�̂����I�u�W�F�N�g�����ׂĊi�[
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Item");
 
        int i = 0;
        SaveData data = new SaveData();
        data.maindata = new SaveObject[cubes.Length];
        //�f�[�^�i�[
        foreach (GameObject cube in cubes)
        {
            data.maindata[i] = new SaveObject();
            data.maindata[i].position = cube.transform.position;
            data.maindata[i].eulerAngles = cube.transform.eulerAngles;
            data.maindata[i].Prefab = cube.name;
            i++;
        }
        //JSON��������
        string jsonstr = JsonUtility.ToJson(data);
        Debug.Log(jsonstr);
        CopyWebGL(jsonstr);
        a.text = "Copy!!";
    }

    /*DebugWebGL�Ńt�H���_�I�����A�t�@�C���o��(������)
    public void OnButtonPointerDownEx()
    {
        
        FileExporterCaptureClick();
    }

    public void FileSelectedEx(string url)
    {
        StartCoroutine(OutJson(url));
    }

    private IEnumerator OutJson(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        Debug.Log(url);
        ExportJSON(url);
    }
    */


    public void DebugExportJSON()
    {
        // GameObject�^�̔z��cubes�ɁA"Item"�^�O�̂����I�u�W�F�N�g�����ׂĊi�[
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Item");

        StreamWriter writer;
        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);

        int i = 0;
        SaveData data = new SaveData();
        data.maindata = new SaveObject[cubes.Length];
        //�f�[�^�i�[
        foreach (GameObject cube in cubes)
        {
            data.maindata[i] = new SaveObject();
            data.maindata[i].position = cube.transform.position;
            data.maindata[i].eulerAngles = cube.transform.eulerAngles;
            data.maindata[i].Prefab = cube.name;
            i++;
        }
        //JSON��������
        string jsonstr = JsonUtility.ToJson(data);
        Debug.Log(jsonstr);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();


        // GameObject�^�̕ϐ�cube�ɁAcubes�̒��g�����ԂɎ��o���B
        // foreach�͔z��̗v�f�̐��������[�v���܂��B
        /*
        foreach (GameObject cube in cubes)
        {
            SaveObject data = new SaveObject(); 
            data.position = cube.transform.position;
            data.eulerAngles = cube.transform.eulerAngles;
            data.Prefab = cube;

            string jsonstr = JsonUtility.ToJson(data);
            Debug.Log(jsonstr);
            writer.Write(jsonstr);
        }
        writer.Flush();
        writer.Close();
        */
    }

    public void DebugImportJSON()
    {
        //���ׂẴI�u�W�F�N�g������
        // GameObject�^�̔z��cubes�ɁA"Item"�^�O�̂����I�u�W�F�N�g�����ׂĊi�[
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Item");

        // GameObject�^�̕ϐ�cube�ɁAcubes�̒��g�����ԂɎ��o���B
        // foreach�͔z��̗v�f�̐��������[�v���܂��B
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }

        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();
        SaveData data = JsonUtility.FromJson<SaveData>(datastr);

        foreach (SaveObject savedata in data.maindata)
        {
            Debug.Log(savedata.position);
            Debug.Log(savedata.eulerAngles);
            Debug.Log(savedata.Prefab);

            if (savedata.Prefab == "Block(Clone)") Prefab = blockPrefab;
            else if (savedata.Prefab == "Ring(Clone)") Prefab = ringPrefab;
            else if (savedata.Prefab == "MPad(Clone)") Prefab = MPadPrefab;
            else if (savedata.Prefab == "LinePivot(Clone)") Prefab = LinePrefab;
            // �����ʒu�̕ϐ��̍��W�Ƀu���b�N�𐶐�
            Vector3 pos = savedata.position;
            GameObject clone = Instantiate(Prefab, pos, Quaternion.identity);
            clone.transform.Rotate(savedata.eulerAngles.x, savedata.eulerAngles.y, savedata.eulerAngles.z, Space.World);

        }
    }

}