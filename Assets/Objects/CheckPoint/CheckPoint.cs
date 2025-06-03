using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public string interactMessage = "Bấm E để tương tác";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowInteractMessage(interactMessage);
            other.GetComponent<PlayerInputHandle>().SetNearCheckpoint(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.HideInteractMessage();
            other.GetComponent<PlayerInputHandle>().SetNearCheckpoint(false);
        }
    }
}