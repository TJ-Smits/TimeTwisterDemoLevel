using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Transform prefabLocation;

    public GameObject doorPrefab;

    private GameObject prefabInstance;

    // Start is called before the first frame update
    void Start()
    {
        prefabInstance = Instantiate(doorPrefab, prefabLocation.position, prefabLocation.rotation);
        prefabLocation.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") || other.CompareTag("Player"))
        {
            Destroy(prefabInstance);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        prefabInstance = Instantiate(doorPrefab, prefabLocation.position, prefabLocation.rotation);
    }
}
