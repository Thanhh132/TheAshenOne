using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject interactMessageObj;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowInteractMessage(string message)
    {
        interactMessageObj.SetActive(true);
    }

    public void HideInteractMessage()
    {
        interactMessageObj.SetActive(false);
    }
}