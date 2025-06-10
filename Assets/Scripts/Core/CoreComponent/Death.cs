using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;

    protected ParticleManager ParticleManager { get => particleManager ??= core.GetCoreComponent<ParticleManager>(); }
    private ParticleManager particleManager;

    protected Stats Stats { get => stats ??= core.GetCoreComponent<Stats>(); }
    private Stats stats;

    private void OnEnable()
    {
        Stats stats = core.GetCoreComponent<Stats>();
        if (stats != null)
            stats.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        Stats stats = core.GetCoreComponent<Stats>();
        if (stats != null)
            stats.OnHealthZero -= Die;
    }

    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }

        var player = core.transform.parent.GetComponent<Player>();
        if (player != null)
        {
            // Dịch chuyển về checkpoint gần nhất
            player.transform.position = player.LastCheckpointPosition;

            // Hồi đầy máu
            var stats = player.GetComponentInChildren<Stats>();
            if (stats != null)
            {
                stats.RestoreFullHealth();
            }

            // Active lại player
            player.gameObject.SetActive(true);

            // Unactive player để trigger lại OnEnable/OnDisable nếu cần
            // Nếu muốn delay, dùng Coroutine
            core.transform.parent.gameObject.SetActive(false);
            core.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            // Nếu không phải player (ví dụ quái), chỉ set inactive hoặc destroy
            core.transform.parent.gameObject.SetActive(false);
            // Hoặc: GameObject.Destroy(core.transform.parent.gameObject);
        }
    }
}
