using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorBelt : MonoBehaviour
{
    public float speed; // Kecepatan Conveyor
    public Vector3 direction; // Arah pergerakan
    public List<GameObject> onBelt; // List objek di atas belt

    private float originalSpeed; // Menyimpan kecepatan asli
    private bool isRunning; // Status conveyor berjalan atau berhenti

    public Slider speedSlider; // Slider UI untuk atur kecepatan

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = speed; // Simpan kecepatan asli
        isRunning = true; // Conveyor berjalan saat game dimulai

        if (speedSlider != null)
        {
            speedSlider.value = speed; // Set slider ke kecepatan awal
            speedSlider.onValueChanged.AddListener(UpdateSpeed); // Tambahkan listener
        }
    }

    // Update Conveyor
    void Update()
    {
        for (int i = 0; i < onBelt.Count; i++)
        {
            onBelt[i].GetComponent<Rigidbody>().linearVelocity = speed * direction;
        }
    }

    // Ketika objek masuk ke conveyor
    private void OnCollisionEnter(Collision collision)
    {
        onBelt.Add(collision.gameObject);
    }

    // Ketika objek keluar dari conveyor
    private void OnCollisionExit(Collision collision)
    {
        onBelt.Remove(collision.gameObject);
    }

    // Fungsi untuk Start dan Stop dengan 1 Button
    public void ToggleConveyor()
    {
        if (isRunning)
        {
            speed = 0; // Stop conveyor
        }
        else
        {
            speed = originalSpeed; // Start conveyor
        }

        isRunning = !isRunning; // Ubah status
    }

    // Fungsi untuk mengatur kecepatan conveyor dari slider
    public void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed;
        originalSpeed = newSpeed; // Update kecepatan asli juga
    }
}
