using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Text _valueText;

    protected void ChangeValue(int value)
    {
        _valueText.text = value.ToString();
    }

    protected void ChangeValue(float value)
    {
        _valueText.text = value.ToString();
    }
}
