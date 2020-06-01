using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnObject()
    {
        Instantiate(spawnObj, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
