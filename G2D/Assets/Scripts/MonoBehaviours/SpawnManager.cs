using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject corazonPrefab; // Prefab del corazón
    public GameObject oroPrefab; // Prefab del oro
    public float spawnInterval = 3f; // Intervalo de tiempo entre cada spawn
    public float spawnRadius = 5f; // Radio alrededor del SpawnManager para colocar los objetos

    private void Start()
    {
        // Comienza a llamar al método SpawnObject() cada spawnInterval segundos
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }


    private void SpawnObject()
    {
        // Genera una posición aleatoria dentro del spawnRadius
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0f; // Asegura que la posición esté en el plano XY

        // Elije aleatoriamente entre el corazón y el oro
        GameObject prefabToSpawn = Random.value < 0.5f ? corazonPrefab : oroPrefab;


        // Instancia el prefab en la posición generada
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}




