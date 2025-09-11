using System;
using TMPro;
using UnityEngine;

public class FillTextOnKeyDown : MonoBehaviour
{
    [Header("Text to be filled")]
    [SerializeField] private GameObject[] _textToFill;

    [Header("String to fill with")]
    [SerializeField] private string[] _inputText;

    private TextMeshProUGUI _TMPToFill;
    private int _totalInputsCounter = 0;
    private int _currentTMPCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _TMPToFill = _textToFill[_currentTMPCounter].GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (_currentTMPCounter >= _textToFill.Length || _currentTMPCounter > _inputText.Length)
            {
                return;
            }

            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (_totalInputsCounter >= _inputText[_currentTMPCounter].Length)
                {
                    _totalInputsCounter = 0;
                    if (_currentTMPCounter >= _textToFill.Length)
                    {
                        _currentTMPCounter = 0;
                    }
                    else
                    {
                        _currentTMPCounter++;
                    }
                    _TMPToFill = _textToFill[_currentTMPCounter].GetComponent<TextMeshProUGUI>();
                    return;
                }

                _TMPToFill.text += (_inputText[_currentTMPCounter])[_totalInputsCounter];
                _totalInputsCounter++;
            }
        }
        catch
        {
            return;
        }
    }

    void OnDisable()
    {
        _totalInputsCounter = 0;
        _currentTMPCounter = 0;
        _TMPToFill = _textToFill[_currentTMPCounter].GetComponent<TextMeshProUGUI>();
        _textToFill[0].GetComponent<TextMeshProUGUI>().text = "";
        _textToFill[1].GetComponent<TextMeshProUGUI>().text = "";

    }

}
