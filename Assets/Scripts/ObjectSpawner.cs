using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Objek yang akan di-spawn
    public Transform spawnPoint; // Posisi spawn (opsional)
    public float spawnDelay = 1f; // Jeda waktu antar spawn

    private int objectID = 0; // ID unik untuk setiap objek
    private bool canSpawn = true; // Untuk mengontrol delay

    public void SpawnObject()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnWithDelay());
        }
    }

    IEnumerator SpawnWithDelay()
    {
        canSpawn = false;

        // Tentukan posisi spawn (jika spawnPoint null, spawn di posisi spawner)
        Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;

        // Spawn object baru
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        // Pilih warna random (hijau atau merah)
        Color randomColor = Random.Range(0, 2) == 0 ? Color.green : Color.red;

        // Ubah warna objek
        newObject.GetComponent<Renderer>().material.color = randomColor;

        // Tentukan nama objek dengan ID dan warna
        string colorName = randomColor == Color.green ? "Hijau" : "Merah";
        newObject.name = "Object_" + objectID + " (" + colorName + ")";

        // Tambahkan ID
        objectID++;

        // Tunggu selama jeda waktu
        yield return new WaitForSeconds(spawnDelay);

        // Izinkan spawn lagi
        canSpawn = true;
    }
}
