using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public abstract class Window : MonoBehaviour
{
    private CanvasGroup _panel;

    private void Awake()
    {
        _panel = GetComponent<CanvasGroup>();
    }

    public void Close()
    {
        _panel.alpha = 0;
        _panel.interactable = false;
        _panel.blocksRaycasts = false;
    }

    public void Open()
    {
        _panel.alpha = 1;
        _panel.interactable = true;
        _panel.blocksRaycasts = true;
    }
}