using TMPro;
using UnityEngine;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _displayText;

    private void OnEnable()
    {
        _counter.ValueIncreased += UpdateDisplay;
    }

    private void OnDisable()
    {
        _counter.ValueIncreased -= UpdateDisplay;
    }

    private void Start()
    {
        if (_counter == null)
        {
            Debug.Log("—чЄтчик не найден!");
            return;
        }

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (_displayText != null)
            _displayText.text = _counter.CurrentValue.ToString();
    }
}