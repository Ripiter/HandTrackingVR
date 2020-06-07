using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameObject[] spawnObjArray;
    //public GameObject spawnObj;

    GameObject spawnedObj = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnObject(GameObject _spawnObj)
    {
        //GameObject spawnObj = spawnObjArray[Random.Range(0, spawnObjArray.Length)];

        if (_spawnObj == spawnedObj)
            Destroy(spawnedObj);


        spawnedObj = Instantiate(_spawnObj, transform.position, Quaternion.identity, transform);
        Saver.instance.textMessage.text += "\n Spawned";
    }

    public void DestroyObject()
    {
        if (spawnedObj != null)
            Destroy(spawnedObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
