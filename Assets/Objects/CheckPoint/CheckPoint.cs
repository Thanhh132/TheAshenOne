using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public string interactMessage = "Bấm E để tương tác";

    private PlayerInputHandle playerInput;
    private Transform playerTransform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInput = other.GetComponent<PlayerInputHandle>();
            playerTransform = other.transform;
            playerInput.SetNearCheckpoint(true);
            playerInput.CurrentCheckpoint = this.transform;
            UIManager.Instance.ShowInteractMessage(interactMessage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInput = null;
            playerTransform = null;
            var input = other.GetComponent<PlayerInputHandle>();
            input.SetNearCheckpoint(false);
            input.CurrentCheckpoint = null;
            UIManager.Instance.HideInteractMessage();
        }
    }

    private void Update()
    {
        if (playerInput != null && Input.GetKeyDown(KeyCode.E))
        {
            // Đặt checkpoint cho player
            playerInput.CurrentCheckpoint = this.transform;

            // Hồi đầy máu nếu player còn sống
            var stats = playerTransform.GetComponentInChildren<Stats>();
            if (stats != null && stats.currentHealth > 0)
            {
                stats.RestoreFullHealth();
            }

            // Hồi đầy máu cho tất cả enemy
            var allStats = FindObjectsOfType<Stats>();
            foreach (var s in allStats)
            {
                // Bỏ qua player
                if (s != stats)
                {
                    s.RestoreFullHealth();
                }
            }

            // Có thể thêm hiệu ứng hoặc âm thanh tại đây nếu muốn
        }
    }
}