using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class PageCycler : MonoBehaviour
{

    [Header("Pages")]
    [SerializeField] private GameObject[] _pages;
    [SerializeField] private int _currentPageIndex;
    [Header("Input")]
    [SerializeField] private InputActionAsset controls;
    private InputActionMap _inputActionMap;
    public InputAction click;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputActionMap = controls.FindActionMap("UI");
        click = _inputActionMap.FindAction("Click");
        click.performed += OnClickAction;

        _currentPageIndex = 0;
        
    }

    void OnDestroy()
    {
        click.performed -= OnClickAction;
    }

    void CycleIndex()
    {
        if (_currentPageIndex < _pages.Length - 1) //the index may not be larger then the length of the pages array
        {
            _currentPageIndex++;
        }
        else
        {
            _currentPageIndex = 0;
        }
    }

    // set all pages as inactive, then activate the current one.
    void UpdatePage()
    {
        for (int pageIndex = 0; pageIndex < _pages.Length; pageIndex++)
        {
            // if the page index is equal to the current active page's index, make that page active
            // make all other pages inactive.
            _pages[pageIndex].SetActive(pageIndex == _currentPageIndex);
        }
    }

    //event occurs when mouse click, etc. occurs
    private void OnClickAction(InputAction.CallbackContext obj)
    {
        CycleIndex();
        UpdatePage();
    }
}
