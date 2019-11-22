using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFader : MonoBehaviour
{
    [SerializeField] private float _charWaitTime;

    private TMP_Text _text;
    private Coroutine _fadeTextCoroutine;

    private string _fadingText;
    private WaitForSeconds _nextCharWaitTime;
    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.alpha = 0.0f;
        _nextCharWaitTime = new WaitForSeconds(_charWaitTime);
        _fadingText = _text.text;
    }

    private void Update()
    {
        if (_text.maxVisibleCharacters == _text.text.Length)
        {
            StopCoroutine(_fadeTextCoroutine);
        }
    }

    public void StartFade()
    {
        _text.alpha = 1f;
        _fadeTextCoroutine  = StartCoroutine(FadeAlpha());
    }

    private IEnumerator FadeAlpha()
    {
        Debug.Log("Fade");
        for (int i = 0; i < _text.text.Length; i++)
        {
            _text.maxVisibleCharacters = i + 1;
            
            yield return _nextCharWaitTime;
        }
    }
}
