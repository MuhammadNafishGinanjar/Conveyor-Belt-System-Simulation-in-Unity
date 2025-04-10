using UnityEngine;

public class DeleteZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ConveyorBelt conveyorBelt = FindObjectOfType<ConveyorBelt>();

        if (conveyorBelt != null && conveyorBelt.onBelt.Contains(other.gameObject))
        {
            // Hapus dari list conveyor
            conveyorBelt.onBelt.Remove(other.gameObject);
        }

        // Hancurkan objek setelah dihapus dari list
        Destroy(other.gameObject);
    }
}
