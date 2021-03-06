using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Private Properties

    // Funky singleton stuff
    private static GameManager instance;
    public static GameManager Instance => instance;

    private static bool wasFadeEntry = true;
    private string consoleOutput;
    
    // Debug Screen Properties
    [SerializeField] private VersionInfo versionInfo;
    [SerializeField] private bool showDebugScreen;
    [SerializeField] private GameObject debugCanvasObj;
    [SerializeField] private Text versionNumberText;
    [SerializeField] private GameObject changeLogPanel;
    [SerializeField] private Text changeLogText;

    // Input Handling
    private MainInputMap _MainInputMap;

    // Tiles
    private Tilemap[] tilemaps = Array.Empty<Tilemap>();
    [SerializeField] private Season _CurrentSeason = Season.SPRING;

    #endregion

    #region Public Properties

    public MainInputMap MainInputMap { get; private set; }
    public string VersionNumber { get; private set; }
    public Season CurrentSeason 
    { 
        get { return _CurrentSeason; }
        
        set
        {
            _CurrentSeason = value;
            UpdateAllTilemaps();
        }
    }

    #endregion

    #region Private Methods

    private void InitializeDebugScreen()
    {
        debugCanvasObj.SetActive(showDebugScreen);

        this.VersionNumber = versionInfo.VersionNumber;
        versionNumberText.text = "v" + this.VersionNumber;

        changeLogText.text = versionInfo.ChangeLog;
    }

    private void GetAllTilemaps() 
    { 
        this.tilemaps = GameObject.FindObjectsOfType<Tilemap>();
        if (this.tilemaps.Length == 0) PrintToConsole("GameManager", "UpdateAllTilemaps", "No tilemaps found!", LogType.Warning); 
    }

    private void UpdateAllTilemaps() 
    {
        if (this.tilemaps.Length == 0) GetAllTilemaps();
        foreach (Tilemap tilemap in this.tilemaps) tilemap.RefreshAllTiles();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        Debug.Log($"[GameManager](OnSceneLoaded): Loaded Scene \"{scene.name}\".");
        if (wasFadeEntry)
            try { GameObject.FindGameObjectWithTag("VCam").GetComponent<Animator>().Play("FadeIn"); } 
            catch (NullReferenceException) { PrintToConsole("GameManager", "OnSceneLoaded", "Couldn't play FadeIn animation (was virtual camera disabled?).", LogType.Error); }
    }

    private void SingletonCheck()
    {
        if (instance && instance != this) { UnityEngine.Object.Destroy(this.gameObject); return; }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void ToggleConsole(InputAction.CallbackContext ctx)
    {
        Time.timeScale = changeLogPanel.activeInHierarchy ? 1f : 0f;
        changeLogPanel.SetActive(!changeLogPanel.activeInHierarchy);
    }

    private void ToggleConsoleMode(InputAction.CallbackContext ctx)
    {
        if (changeLogPanel.activeInHierarchy)
        {
            if (changeLogText.alignment == TextAnchor.UpperLeft)    // Console is NOT currently enabled.
            {
                changeLogText.alignment = TextAnchor.LowerCenter;
                changeLogText.text = consoleOutput;
            } else  // Console IS already enabled (switch back)
            {
                changeLogText.alignment = TextAnchor.UpperLeft;
                changeLogText.text = versionInfo.ChangeLog;
            }
        }
    }

    #endregion

    #region Public Methods

    public static void PrintToConsole(string className, string methodName, string message, LogType logType = LogType.Log)
    {
        switch (logType)
        {
            case LogType.Assert: PrintToConsole("GameManager", "PrintToConsole", "Asserts are not supported.", LogType.Error); break;
            case LogType.Error: Debug.LogError($"{{ERROR}}[{className}]({methodName}): {message}"); break;
            case LogType.Exception: PrintToConsole("GameManager", "PrintToConsole", "Exceptions are not supported.", LogType.Error); break;
            case LogType.Log: Debug.Log($"{{INFO}}[{className}]({methodName}): {message}"); break;
            case LogType.Warning: Debug.LogWarning($"{{WARN}}[{className}]({methodName}): {message}"); break;
        }
    }

    #endregion

    #region Static Methods

    public static void LoadScene(string sceneName) 
    { 
        if (sceneName != null && sceneName != string.Empty) 
        { 
            Debug.Log($"[GameManager](LoadScene): Loading Scene \"{sceneName}\"."); 
            SceneManager.LoadScene(sceneName); 
        } 
        else Debug.LogError("[GameManager](LoadScene): No sceneName provided!"); 
    }

    public static void LoadScene(int buildIndex) 
    {
        Debug.Log($"[GameManager](LoadScene): Loading Scene #{buildIndex}."); 
        SceneManager.LoadScene(buildIndex); 
    }

    public static void LoadSceneWithTransition(string sceneName, bool isFadeEntry = true, bool isSpinExit = false)
    {
        wasFadeEntry = isFadeEntry;
        StaticCoroutine.Start(LoadSceneTransition(sceneName, isSpinExit));
    }

    public static void LoadSceneWithTransition(int buildIndex, bool isFadeEntry = true, bool isSpinExit = false)
    {
        wasFadeEntry = isFadeEntry;
        StaticCoroutine.Start(LoadSceneTransition(buildIndex, isSpinExit));
    }

    #endregion
    
    #region Coroutines

    private static IEnumerator LoadSceneTransition(string sceneName, bool isSpinExit) 
    {
        Animator camAnim = GameObject.FindGameObjectWithTag("VCam").GetComponent<Animator>();
        camAnim.SetBool("isSpinExit", isSpinExit);
        camAnim.SetTrigger("Exit Scene");

        yield return new WaitForSeconds(isSpinExit ? 3.5f : 1f);

        LoadScene(sceneName);
    }

    private static IEnumerator LoadSceneTransition(int buildIndex, bool isSpinExit) 
    {
        Animator camAnim = GameObject.FindGameObjectWithTag("VCam").GetComponent<Animator>();
        camAnim.SetBool("isSpinExit", isSpinExit);
        camAnim.SetTrigger("Exit Scene");

        yield return new WaitForSeconds(isSpinExit ? 3.5f : 1f);

        LoadScene(buildIndex);
    }

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake() 
    { 
        SingletonCheck();
        UpdateAllTilemaps();
        
        this.MainInputMap = new MainInputMap();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnEnable()
    {
        this.MainInputMap.GameManager.ToggleConsole.performed += ToggleConsole;
        this.MainInputMap.GameManager.ToggleConsole.Enable();

        this.MainInputMap.GameManager.ToggleConsoleMode.performed += ToggleConsoleMode;
        this.MainInputMap.GameManager.ToggleConsoleMode.Enable();
        
        this.MainInputMap.GameManager.ToggleDebugScreen.performed += (InputAction.CallbackContext ctx) => debugCanvasObj.SetActive(!debugCanvasObj.activeInHierarchy);
        this.MainInputMap.GameManager.ToggleDebugScreen.Enable();
    
        this.MainInputMap.GameManager.Quit.performed += (InputAction.CallbackContext ctx) => Application.Quit();
        this.MainInputMap.GameManager.Quit.Enable();

        this.MainInputMap.Player.Use.performed += (InputAction.CallbackContext ctx) => CurrentSeason = (Season)(((int)CurrentSeason + 1) % 4);
        this.MainInputMap.Player.Use.Enable();
    }

    private void OnDisable()
    {
        try
        {
            this.MainInputMap.GameManager.ToggleConsole.performed -= ToggleConsole;
            this.MainInputMap.GameManager.ToggleConsole.Disable();

            this.MainInputMap.GameManager.ToggleConsoleMode.performed -= ToggleConsoleMode;
            this.MainInputMap.GameManager.ToggleConsoleMode.Disable();
            
            this.MainInputMap.GameManager.ToggleDebugScreen.performed -= (InputAction.CallbackContext ctx) => debugCanvasObj.SetActive(!debugCanvasObj.activeInHierarchy);
            this.MainInputMap.GameManager.ToggleDebugScreen.Disable();

            this.MainInputMap.GameManager.Quit.performed -= (InputAction.CallbackContext ctx) => Application.Quit();
            this.MainInputMap.GameManager.Quit.Disable();

            this.MainInputMap.Player.Use.performed -= (InputAction.CallbackContext ctx) => CurrentSeason = (Season)(((int)CurrentSeason + 1) % 4);
            this.MainInputMap.Player.Use.Disable();
        } catch (NullReferenceException) { /* Object probably destroyed by singleton check */ }
    }

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;

        Application.logMessageReceived += (string logString, string stackTrace, LogType type) => consoleOutput += $"{logString}\n";
        InitializeDebugScreen();
    }

    #endregion
}
