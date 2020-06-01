using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour
{
    public float threshold = 0.05f;
    public bool debugMode = true;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    List<OVRBone> fingerBones;
    private Gesture previousGesture;

    

    // Start is called before the first frame update
    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();

        CreateDirrectory();
        ReadData();
        
        Saver.instance.text.text += "Path " + Application.persistentDataPath;
    }

    // Update is called once per frame
    void Update()
    {
        if (debugMode && Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }

        Gesture currectGesture = Recognize();
        bool hasRecognized = !currectGesture.Equals(new Gesture());

        if(hasRecognized && !currectGesture.Equals(previousGesture))
        {
            Debug.Log("New gesture found" + currectGesture.name);
            previousGesture = currectGesture;
            currectGesture.onRecognized.Invoke();
        }
    }


    public void Save()
    {
        Debug.Log("Save");
        Gesture g = new Gesture();
        g.name = "Gesture" + System.Guid.NewGuid().GetHashCode();
        List<Vector3> data = new List<Vector3>();

        foreach (OVRBone bone in fingerBones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerDatas = data;
        gestures.Add(g);
        SaveGesture();
    }

    public Gesture Recognize()
    {
        Gesture currectGesture = new Gesture();
        float currentMin = Mathf.Infinity;

        foreach (Gesture gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;

            for (int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currectData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currectData, gesture.fingerDatas[i]);
                if(distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance += distance;
            }

            if(!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currectGesture = gesture;
            }
        }

        return currectGesture;
    }

    List<Gesture> GetGestureList()
    {
        if (gestures.Count == 0)
            return new List<Gesture>();
        else
            return gestures;
    }

    void SaveGesture()
    {
        for (int i = 0; i < gestures.Count; i++)
        {
            string path = Application.persistentDataPath + "/test/" + gestures[i].name + ".json";
            string jsonString = JsonUtility.ToJson(gestures[i]);
            File.WriteAllText(path, jsonString);
        }



        //// Read a file  
        //string readText = File.ReadAllText(path);
        //List<Gesture> gesturesJson = JsonUtility.FromJson<List<Gesture>>(readText);

        //Debug.Log(path);
    }

    void ReadData()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath + "/test");
        
        Debug.Log("Read data" + files.Length);

        for (int i = 0; i < files.Length; i++)
        {
            string readText = File.ReadAllText(files[i]);
            Gesture tempGesture = JsonUtility.FromJson<Gesture>(readText);
            gestures.Add(tempGesture);
        }
    }

    void CreateDirrectory()
    {
        try
        {
            string path = Application.persistentDataPath + "/test";
            // Determine whether the directory exists.
            if (Directory.Exists(path))
            {
                Debug.Log("That path exists already.");
                return;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Debug.Log("The directory was created successfully");
            
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
        finally { }
    }

}
