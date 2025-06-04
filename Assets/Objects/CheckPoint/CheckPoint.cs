using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public string interactMessage = "Bấm E để tương tác";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var input = other.GetComponent<PlayerInputHandle>();
            input.SetNearCheckpoint(true);
            input.CurrentCheckpoint = this.transform;
            UIManager.Instance.ShowInteractMessage("Bấm E để tương tác");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var input = other.GetComponent<PlayerInputHandle>();
            input.SetNearCheckpoint(false);
            input.CurrentCheckpoint = null;
            UIManager.Instance.HideInteractMessage();
        }
    }
}