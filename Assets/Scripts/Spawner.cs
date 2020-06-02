using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameObject[] spawnObjArray;
    public GameObject spawnObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnObject()
    {
        //GameObject spawnObj = spawnObjArray[Random.Range(0, spawnObjArray.Length)];

        GameObject topSecret = Instantiate(spawnObj, transform.position, Quaternion.identity, transform);
        Saver.instance.textMessage.text += "\n Spawned";
        if(topSecret.GetComponentInChildren<ParticleSystem>() != null)
        {
            ParticleSystem[] secretChildren = topSecret.GetComponentsInChildren<ParticleSystem>();

            for (int i = 0; i < secretChildren.Length; i++)
            {
                if(secretChildren[i].isPlaying == false)
                {
                    secretChildren[i].Play();
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
