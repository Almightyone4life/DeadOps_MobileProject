using UnityEngine;
using UnityEngine.UIElements;

public class GameHUDController : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    //[SerializeField] private PlayerCharacter _playerCharacter;
    //[SerializeField] private Health _playerHealth;
    private UIDocument _document;
    private VisualElement _loseMenuVisualTree;
    private VisualElement _winMenuVisualTree;

    private Button _loseRetryButton;
    private Button _winRetryButton;

    private VisualElement _playerHUDVisualTree;
    private VisualElement _expBarFill;
    private VisualElement _healthBarFill;

    private Label _elapsedTimeLabel;
    private Label _lvlLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Start()
    {
        // hide lose menu
        DisableAllDisplay();
        _playerHUDVisualTree.style.display = DisplayStyle.Flex;
        //SetExpBarPercent(30, 100);
        //SetHealthBarPercent(100, 100);
    }

    private void DisableAllDisplay()
    {
        _loseMenuVisualTree.style.display = DisplayStyle.None;
        _winMenuVisualTree.style.display = DisplayStyle.None;
    }
    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        // get menu sub objects
        _loseMenuVisualTree = _document.rootVisualElement.Q("LoseMenuVisualTree");
        _winMenuVisualTree = _document.rootVisualElement.Q("WinMenuVisualTree");
        _playerHUDVisualTree = _document.rootVisualElement.Q("PlayerHUDVisualTree");
        // only search the playerHUDvisual tree
        _expBarFill = _playerHUDVisualTree.Q("ExpBarFill");
        _healthBarFill = _playerHUDVisualTree.Q("HealthBarFill");
        // get labels in playerHUDvisual tree
        _elapsedTimeLabel = _playerHUDVisualTree.Q("ElapsedTimeLabel") as Label;
        _lvlLabel = _playerHUDVisualTree.Q("LvlLabel") as Label;
        // get button sub objects
        _loseRetryButton = _loseMenuVisualTree.Q("RetryButton") as Button;
        _winRetryButton = _winMenuVisualTree.Q("RetryButton") as Button;
    }

    private void OnEnable()
    {
        _loseRetryButton.RegisterCallback<ClickEvent>(OnLoseRetryButtonClicked);
        _winRetryButton.RegisterCallback<ClickEvent>(OnWinRetryButtonClicked);

        //_gameController.OnLose.AddListener(DisplayLoseMenu);
        //_gameController.OnWin.AddListener(DisplayWinMenu);
        //_playerCharacter.OnEXPGained += SetExpBarPercent;
        //_playerHealth.OnHealthChanged += SetHealthBarPercent;
    }

    private void OnDisable()
    {      
        _loseRetryButton.UnregisterCallback<ClickEvent>(OnLoseRetryButtonClicked);
        _winRetryButton.UnregisterCallback<ClickEvent>(OnWinRetryButtonClicked);

        //_gameController.OnLose.RemoveListener(DisplayLoseMenu);
        //_gameController.OnWin.RemoveListener(DisplayWinMenu);
        //_playerCharacter.OnEXPGained -= SetExpBarPercent;
        //_playerHealth.OnHealthChanged -= SetHealthBarPercent;
    }

    void Update()
    {

        UpdateLevelLabel();
    }

    

    private void UpdateLevelLabel()
    {
        //_lvlLabel.text = _playerCharacter.LVL.ToString();
    }

    public void DisplayLoseMenu()
    {
        _loseMenuVisualTree.style.display = DisplayStyle.Flex;
        _playerHUDVisualTree.style.display = DisplayStyle.None;
    }

    public void DisplayWinMenu()
    {
        _winMenuVisualTree.style.display = DisplayStyle.Flex;
        _playerHUDVisualTree.style.display = DisplayStyle.None;
    }

    private void OnLoseRetryButtonClicked(ClickEvent evt)
    {
        Debug.Log("Retry");
        _loseMenuVisualTree.style.display = DisplayStyle.None;
        // _gameController.ReloadLevel();
    }

    private void OnWinRetryButtonClicked(ClickEvent evt)
    {
        Debug.Log("Play Again");
        _winMenuVisualTree.style.display = DisplayStyle.None;
        // _gameController.ReloadLevel();
    }

    private void SetExpBarPercent(float currentLevelEXP, float expForLevelUp)
    {
        // formula: 1/max * current is 0-1 value. *100 to convert to %
        float percentage = ((1 / expForLevelUp) * currentLevelEXP) * 100;
        Debug.Log("Percentage: " + percentage);
        // set width as %
        _expBarFill.style.width = Length.Percent(percentage);
    }

    private void SetHealthBarPercent(float currentHealth, float maxHealth)
    {
        // formula: 1/max * current is 0-1 value. *100 to convert to %
        float percentage = ((1 / maxHealth) * currentHealth) * 100;
        Debug.Log("Percentage: " + percentage);
        // set width as %
        _healthBarFill.style.width = Length.Percent(percentage);
    }

    
}
