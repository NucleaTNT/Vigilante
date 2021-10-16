using Dev.NucleaTNT.Utilities;
using Dev.NucleaTNT.Vigilante.Tiles;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace Dev.NucleaTNT.Vigilante.Utilities 
{
    public class GameManager : MonoBehaviour
    {
        #region Private Properties
    
        // Funky singleton stuff
        private static GameManager s_instance;
        public static GameManager Instance => s_instance;
    
        
        // Debug Screen Properties
        private string _consoleOutput;
        [SerializeField] private VersionInfo _versionInfo;
        private bool _showDebugScreen;
        [SerializeField] private GameObject _debugCanvasObj;
        [SerializeField] private Text _versionNumberText;
        [SerializeField] private GameObject _changeLogPanel;
        [SerializeField] private Text _changeLogText;
        [SerializeField] private static DebugVars s_debugVars;
    
        // Input Handling
        private MainInputMap _mainInputMap;
    
        // Tiles
        private Tilemap[] _tilemaps = Array.Empty<Tilemap>();
        [SerializeField] private Season _currentSeason = Season.SPRING;
    
        #endregion
    
        #region Public Properties
    
        public Season CurrentSeason 
        { 
            get { return _currentSeason; }
            
            set
            {
                _currentSeason = value;
                StaticCoroutine.Start(UpdateAllTilemaps());
            }
        }
        public MainInputMap MainInputMap { get; private set; }
        public string VersionNumber { get; private set; }
    
        public static DebugVars DebugVars 
        { 
            get 
            { 
                if (s_debugVars == null) s_debugVars = Resources.Load<DebugVars>("ScriptableObjects/DebugVars");
                if (s_debugVars == null) PrintToConsole("GameManager", "DebugVars<GET>", "Couldn't load DebugVars Obj.", LogType.Error);
                return s_debugVars;
            }
        }

        #endregion
    
        #region Private Methods
    
        private void InitializeDebugScreen()
        {
            _debugCanvasObj.SetActive(_showDebugScreen);
    
            this.VersionNumber = _versionInfo.VersionNumber;
            _versionNumberText.text = "v" + this.VersionNumber;
    
            _changeLogText.text = _versionInfo.ChangeLog;
        }
    
        private void GetAllTilemaps() 
        { 
            this._tilemaps = GameObject.FindObjectsOfType<Tilemap>();
            if (this._tilemaps.Length == 0) PrintToConsole("GameManager", "UpdateAllTilemaps", "No tilemaps found!", LogType.Warning); 
        }
    
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
        {
            GameManager.PrintToConsole("GameManager", "OnSceneLoaded", $"Loaded Scene \"{scene.name}\".");
        }
    
        private void SingletonCheck()
        {
            if (s_instance && s_instance != this) { UnityEngine.Object.Destroy(this.gameObject); return; }
            s_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    
        private void ToggleConsole(InputAction.CallbackContext ctx)
        {
            Time.timeScale = _changeLogPanel.activeInHierarchy ? 1f : 0f;
            _changeLogPanel.SetActive(!_changeLogPanel.activeInHierarchy);
        }
    
        private void ToggleConsoleMode(InputAction.CallbackContext ctx)
        {
            if (_changeLogPanel.activeInHierarchy)
            {
                if (_changeLogText.alignment == TextAnchor.UpperLeft)    // Console is NOT currently enabled.
                {
                    _changeLogText.alignment = TextAnchor.LowerCenter;
                    _changeLogText.text = _consoleOutput;
                } else  // Console IS already enabled (switch back)
                {
                    _changeLogText.alignment = TextAnchor.UpperLeft;
                    _changeLogText.text = _versionInfo.ChangeLog;
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
                case LogType.Error: Debug.LogError($"<color=#FF0000>{{ERROR}}[{className}]({methodName}): {message}</color>"); break;
                case LogType.Exception: PrintToConsole("GameManager", "PrintToConsole", "Exceptions are not supported.", LogType.Error); break;
                case LogType.Log: Debug.Log($"<color=#53A8F5>{{INFO}}[{className}]({methodName}): {message}</color>"); break;
                case LogType.Warning: Debug.LogWarning($"<color=#FFFF00>{{WARN}}[{className}]({methodName}): {message}</color>"); break;
            }
        }
    
        #endregion
    
        #region Static Methods
    
        public static void LoadScene(string sceneName) 
        { 
            if (sceneName != null && sceneName != string.Empty) 
            { 
                GameManager.PrintToConsole("GameManager", "LoadScene", $"Loading Scene \"{sceneName}\"."); 
                SceneManager.LoadScene(sceneName); 
            } 
            else GameManager.PrintToConsole("GameManager", "LoadScene", "No sceneName provided!"); 
        }
    
        public static void LoadScene(int buildIndex) 
        {
            GameManager.PrintToConsole("GameManager", "LoadScene", $"Loading Scene #{buildIndex}."); 
            SceneManager.LoadScene(buildIndex); 
        }
    
        #endregion
        
        #region Coroutines

        private IEnumerator UpdateAllTilemaps() 
        {
            if (this._tilemaps.Length == 0) GetAllTilemaps();
            foreach (Tilemap tilemap in this._tilemaps) tilemap.RefreshAllTiles();
            
            return null;
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
            
            this.MainInputMap.GameManager.ToggleDebugScreen.performed += (InputAction.CallbackContext ctx) => _debugCanvasObj.SetActive(!_debugCanvasObj.activeInHierarchy);
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
                
                this.MainInputMap.GameManager.ToggleDebugScreen.performed -= (InputAction.CallbackContext ctx) => _debugCanvasObj.SetActive(!_debugCanvasObj.activeInHierarchy);
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
    
            Application.logMessageReceived += (string logString, string stackTrace, LogType type) => _consoleOutput += $"{logString}\n";
            InitializeDebugScreen();
        }
    
        #endregion
    }
}
