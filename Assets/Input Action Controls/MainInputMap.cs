// GENERATED AUTOMATICALLY FROM 'Assets/Input Action Controls/MainInputMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInputMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInputMap"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e296e447-a6d2-40b8-91e4-a86851f3c3bf"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""820e23be-5071-4d18-8989-ac3fbdf7ad05"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""80831289-abfc-4dac-a3ea-cf7e6ea33562"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""bc15de9a-76d4-4e10-b7ae-a5fd444d17e4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e6a82c7f-79cb-4d23-81a2-58f151fbdc71"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e94201be-eec2-42ab-a3a6-8f34c82f19bd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f4882300-a030-4944-8586-e4b973650625"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3eb52194-97b0-4e32-b008-66957065fd1d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller"",
                    ""id"": ""4f2714e7-08a8-4880-8383-0cb26ee79125"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5e7ca5ee-9f89-4322-9355-a69556183bd9"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3940740e-5e61-40f4-bfc9-1e202930e672"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0cf38d13-4233-4af1-86ca-de77ad5411cd"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f1e8667a-c56d-44fe-92f1-e065f91984dd"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6e0c94c5-ba38-46fe-803f-66509f716786"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44373d0b-86ed-434a-9e52-e5884fc08a39"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameManager"",
            ""id"": ""1f38424d-000f-4ab8-bf86-78af15918ed1"",
            ""actions"": [
                {
                    ""name"": ""ToggleConsole"",
                    ""type"": ""Button"",
                    ""id"": ""bbad74fb-713f-4933-bade-93bfa7158adb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleConsoleMode"",
                    ""type"": ""Button"",
                    ""id"": ""65ab542a-e459-4b80-8b60-82cf7a56376a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleDebugScreen"",
                    ""type"": ""Button"",
                    ""id"": ""7fedda3a-b0ff-47d3-9184-cd6801181a03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""79b286e8-cde9-46a2-af53-90f42df5e0e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0b20612-b93a-4035-8bfb-c65386cd1882"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleDebugScreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f2bbfb9-b9fe-4337-ae04-558c7b84e930"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleConsoleMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f966a9a-154a-4dc9-8821-82ca2227b007"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleConsole"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a61a811e-ce56-4f73-9dfe-9759da1369d4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e5fcdbb-3781-44da-814b-a73064d1993b"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Use = m_Player.FindAction("Use", throwIfNotFound: true);
        // GameManager
        m_GameManager = asset.FindActionMap("GameManager", throwIfNotFound: true);
        m_GameManager_ToggleConsole = m_GameManager.FindAction("ToggleConsole", throwIfNotFound: true);
        m_GameManager_ToggleConsoleMode = m_GameManager.FindAction("ToggleConsoleMode", throwIfNotFound: true);
        m_GameManager_ToggleDebugScreen = m_GameManager.FindAction("ToggleDebugScreen", throwIfNotFound: true);
        m_GameManager_Quit = m_GameManager.FindAction("Quit", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Use;
    public struct PlayerActions
    {
        private @MainInputMap m_Wrapper;
        public PlayerActions(@MainInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Use => m_Wrapper.m_Player_Use;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Use.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // GameManager
    private readonly InputActionMap m_GameManager;
    private IGameManagerActions m_GameManagerActionsCallbackInterface;
    private readonly InputAction m_GameManager_ToggleConsole;
    private readonly InputAction m_GameManager_ToggleConsoleMode;
    private readonly InputAction m_GameManager_ToggleDebugScreen;
    private readonly InputAction m_GameManager_Quit;
    public struct GameManagerActions
    {
        private @MainInputMap m_Wrapper;
        public GameManagerActions(@MainInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleConsole => m_Wrapper.m_GameManager_ToggleConsole;
        public InputAction @ToggleConsoleMode => m_Wrapper.m_GameManager_ToggleConsoleMode;
        public InputAction @ToggleDebugScreen => m_Wrapper.m_GameManager_ToggleDebugScreen;
        public InputAction @Quit => m_Wrapper.m_GameManager_Quit;
        public InputActionMap Get() { return m_Wrapper.m_GameManager; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameManagerActions set) { return set.Get(); }
        public void SetCallbacks(IGameManagerActions instance)
        {
            if (m_Wrapper.m_GameManagerActionsCallbackInterface != null)
            {
                @ToggleConsole.started -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnToggleConsole;
                @ToggleConsole.performed -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnToggleConsole;
                @ToggleConsole.canceled -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnToggleConsole;
                @ToggleConsoleMode.started -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnToggleConsoleMode;
                @ToggleConsoleMode.performed -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnToggleConsoleMode;
                @ToggleConsoleMode.canceled -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnToggleConsoleMode;
                @ToggleDebugScreen.started -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnToggleDebugScreen;
                @ToggleDebugScreen.performed -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnToggleDebugScreen;
                @ToggleDebugScreen.canceled -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnToggleDebugScreen;
                @Quit.started -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_GameManagerActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_GameManagerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleConsole.started += instance.OnToggleConsole;
                @ToggleConsole.performed += instance.OnToggleConsole;
                @ToggleConsole.canceled += instance.OnToggleConsole;
                @ToggleConsoleMode.started += instance.OnToggleConsoleMode;
                @ToggleConsoleMode.performed += instance.OnToggleConsoleMode;
                @ToggleConsoleMode.canceled += instance.OnToggleConsoleMode;
                @ToggleDebugScreen.started += instance.OnToggleDebugScreen;
                @ToggleDebugScreen.performed += instance.OnToggleDebugScreen;
                @ToggleDebugScreen.canceled += instance.OnToggleDebugScreen;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public GameManagerActions @GameManager => new GameManagerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
    }
    public interface IGameManagerActions
    {
        void OnToggleConsole(InputAction.CallbackContext context);
        void OnToggleConsoleMode(InputAction.CallbackContext context);
        void OnToggleDebugScreen(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
