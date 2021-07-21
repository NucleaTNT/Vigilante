using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Fields
    // Funky singleton stuff
    private static GameManager instance;
    public static GameManager Instance => instance;

    private static bool wasFadeEntry = true;
    private string consoleOutput;
    
    [Header("Debug Fields"), Space(5)]
    [SerializeField] private bool showDebugScreen;
    [SerializeField] private GameObject debugCanvasObj;

    public string versionNumber;
    [SerializeField] private Text versionNumberText;

    [Space(5)]
    [SerializeField, Multiline] private string changeLog; 
    [SerializeField] private GameObject changeLogPanel;
    [SerializeField] private Text changeLogText;

    #endregion

    #region Private Methods

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.C)) ToggleChangeLog();
        if (Input.GetKeyDown(KeyCode.D)) ToggleDebugInformation();
        if (Input.GetKeyDown(KeyCode.Space) && changeLogPanel.activeInHierarchy) ToggleConsole();
    }

    private void InitializeDebugScreen()
    {
        debugCanvasObj.SetActive(showDebugScreen);
        versionNumberText.text = "v" + versionNumber;

        changeLogText.text = changeLog;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        Debug.Log($"[GameManager](OnSceneLoaded): Loaded Scene \"{scene.name}\".");
        if (wasFadeEntry) GameObject.FindGameObjectWithTag("VCam").GetComponent<Animator>().Play("FadeIn");
    }

    private void SingletonCheck()
    {
        if (instance && instance != this) { Object.Destroy(this.gameObject); return; }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void ToggleChangeLog()
    {
        Time.timeScale = changeLogPanel.activeInHierarchy ? 1f : 0f;
        changeLogPanel.SetActive(!changeLogPanel.activeInHierarchy);
    }
    
    private void ToggleDebugInformation()
    {
        debugCanvasObj.SetActive(!debugCanvasObj.activeInHierarchy);
    }


    private void ToggleConsole()
    {
        if (changeLogText.alignment == TextAnchor.UpperLeft)    // Console is NOT currently enabled.
        {
            changeLogText.alignment = TextAnchor.LowerCenter;
            changeLogText.text = consoleOutput;
        } else  // Console IS already enabled (switch back)
        {
            changeLogText.alignment = TextAnchor.UpperLeft;
            changeLogText.text = changeLog;
        }
    }

    #endregion

    #region Public Methods


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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;

        Application.logMessageReceived += (string logString, string stackTrace, LogType type) => consoleOutput += $"{logString}\n";
        InitializeDebugScreen();
    }

    private void Update()
    {
        HandleInput();
    }

    #endregion
}
