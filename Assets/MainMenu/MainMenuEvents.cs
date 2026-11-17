using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    [SerializeField] private string _startLevelName;
    private UIDocument _document;
    private VisualElement _rootMenu;
    private VisualElement _settingsMenu;
    private VisualElement _creditsMenu;

    private Button _button;
    private Button _settingsButton;
    private Button _creditsButton;
    private Button _settingsBackButton;
    private Button _creditsBackButton;
    private AudioSource _audioSource;

    private List<Button> _menuButtons = new List<Button>();

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _document = GetComponent<UIDocument>();

        _rootMenu = _document.rootVisualElement.Q("RootMenu");
        _settingsMenu = _document.rootVisualElement.Q("SettingsMenu");
        _creditsMenu = _document.rootVisualElement.Q("CreditsMenu");

        _button = _document.rootVisualElement.Q("StartButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnStartClick);
        // settings button
        _settingsButton = _document.rootVisualElement.Q("SettingsButton") as Button;
        _settingsButton.RegisterCallback<ClickEvent>(OnSettingsButtonClick);
        // settings back button
        _settingsBackButton = _document.rootVisualElement.Q("SettingsBackButton") as Button;
        _settingsBackButton.RegisterCallback<ClickEvent>(OnSettingsBackButtonClick);
        // credits button
        _creditsButton = _document.rootVisualElement.Q("CreditsButton") as Button;
        _creditsButton.RegisterCallback<ClickEvent>(OnCreditsButtonClick);
        // credits back button
        _creditsBackButton = _document.rootVisualElement.Q("CreditsBackButton") as Button;
        _creditsBackButton.RegisterCallback<ClickEvent>(OnCreditsBackButtonClick);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnDisable()
    {
        _settingsButton.UnregisterCallback<ClickEvent>(OnSettingsButtonClick);
        _settingsBackButton.UnregisterCallback<ClickEvent>(OnSettingsBackButtonClick);
        _creditsButton.UnregisterCallback<ClickEvent>(OnCreditsButtonClick);
        _creditsBackButton.UnregisterCallback<ClickEvent>(OnCreditsBackButtonClick);
        _button.UnregisterCallback<ClickEvent>(OnStartClick);

        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnStartClick(ClickEvent evt)
    {
        Debug.Log("Start Game.");
        SceneManager.LoadScene(_startLevelName);
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        _audioSource.Play();
    }

    private void OnSettingsButtonClick(ClickEvent evt)
    {
        Debug.Log("Settings Button Click");
        // dsiable root menu, enable settings menu
        _rootMenu.style.display = DisplayStyle.None;
        _settingsMenu.style.display = DisplayStyle.Flex;
    }

    private void OnSettingsBackButtonClick(ClickEvent evt)
    {
        Debug.Log("Settings Button Click");
        // dsiable root menu, enable settings menu
        _rootMenu.style.display = DisplayStyle.Flex;
        _settingsMenu.style.display = DisplayStyle.None;
    }

    private void OnCreditsButtonClick(ClickEvent evt)
    {
        Debug.Log("Settings Button Click");
        // dsiable root menu, enable settings menu
        _rootMenu.style.display = DisplayStyle.None;
        _creditsMenu.style.display = DisplayStyle.Flex;
    }
    private void OnCreditsBackButtonClick(ClickEvent evt)
    {
        Debug.Log("Settings Button Click");
        // dsiable root menu, enable settings menu
        _rootMenu.style.display = DisplayStyle.Flex;
        _creditsMenu.style.display = DisplayStyle.None;
    }
}
