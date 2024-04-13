using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(0)] private int _startValue = 0;
    [SerializeField, Min(0.1f)] private float _delay = 0.5f;

    private int _currentValue;
    private Coroutine _increaseCoroutine;

    public event Action ValueIncreased;

    public int CurrentValue => _currentValue;

    private void Start()
    {
        _currentValue = _startValue;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_increaseCoroutine == null)
            {
                _increaseCoroutine = StartCoroutine(IncreaseValue());
            }
            else
            {
                StopCoroutine(_increaseCoroutine);
                _increaseCoroutine = null;
            }
        }
    }

    private IEnumerator IncreaseValue()
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            _currentValue++;
            ValueIncreased?.Invoke();
            yield return wait;
        }
    }
}
