using UnityEngine;
using UnityEngine.UI;


public sealed class UICounter : MonoBehaviour
{
    private Text _counter;

    private void OnEnable()
    {
        _counter = GetComponent<Text>();
    }

    private void OnDisable()
    {
        _counter = null;
    }

    public void ShowCounter(int count)
    {
        _counter.text = $"{count}";
    }
}