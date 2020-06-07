using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonFrog : MonoBehaviour
{
    public GameObject frogPrefab;
    public bool CanSpawnFrog = true;
    public GameObject frogSummonParticles;

    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor" && CanSpawnFrog)
        {
            Vector3 spawnPos = transform.position;
            spawnPos.y += 20f;

            Instantiate(frogSummonParticles, transform.position, Quaternion.identity);
            Instantiate(frogPrefab, spawnPos, Quaternion.identity);
            CanSpawnFrog = false;
        }
    }
    

}
