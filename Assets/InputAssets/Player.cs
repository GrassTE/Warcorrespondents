// GENERATED AUTOMATICALLY FROM 'Assets/InputAssets/Player.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""PlayerNormal"",
            ""id"": ""fed7b745-1bc5-4e0b-a0e3-12ba77260d19"",
            ""actions"": [
                {
                    ""name"": ""MoveHorizons"",
                    ""type"": ""Value"",
                    ""id"": ""5a93f020-27b4-4cb6-975f-af9ed1ef4ec3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""5c554403-34b9-4a85-a8f5-ac58363cad75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""a3099043-3ac2-4656-8595-f0c577842621"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Coding"",
                    ""type"": ""Button"",
                    ""id"": ""f7af9390-5dad-4c80-a4a7-83d8314f8e88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""1fbfd71c-7027-405d-a1ed-1fc210b6164f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizons"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""68266135-01e4-4afc-96c0-ea13a80f3480"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveHorizons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""239ae58a-4ed8-4a1c-a712-875cc1a5a00b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveHorizons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""fe14fc96-6976-4535-9110-34ee485476e9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHorizons"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""28b72bc6-4f68-4a0a-b630-d71e22d0d6ec"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveHorizons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""81388851-93e1-42a6-88f8-2eccb63c984d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveHorizons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b0789a3f-5494-4bae-96bb-36eab3a52419"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""975884c6-576e-4b0b-adb7-f0883ff247e9"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c35dfc0f-020b-4d7f-b2ca-5b54e24145f5"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31e28f16-f6f5-4fc1-b9b6-7b1d27b1b051"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f934f611-8c36-46c6-ac79-b5cb10f172f8"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Coding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb88999b-e1c9-4d1e-9b74-683dc913e3a1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Coding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerNormal
        m_PlayerNormal = asset.FindActionMap("PlayerNormal", throwIfNotFound: true);
        m_PlayerNormal_MoveHorizons = m_PlayerNormal.FindAction("MoveHorizons", throwIfNotFound: true);
        m_PlayerNormal_Run = m_PlayerNormal.FindAction("Run", throwIfNotFound: true);
        m_PlayerNormal_Interaction = m_PlayerNormal.FindAction("Interaction", throwIfNotFound: true);
        m_PlayerNormal_Coding = m_PlayerNormal.FindAction("Coding", throwIfNotFound: true);
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

    // PlayerNormal
    private readonly InputActionMap m_PlayerNormal;
    private IPlayerNormalActions m_PlayerNormalActionsCallbackInterface;
    private readonly InputAction m_PlayerNormal_MoveHorizons;
    private readonly InputAction m_PlayerNormal_Run;
    private readonly InputAction m_PlayerNormal_Interaction;
    private readonly InputAction m_PlayerNormal_Coding;
    public struct PlayerNormalActions
    {
        private @Player m_Wrapper;
        public PlayerNormalActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveHorizons => m_Wrapper.m_PlayerNormal_MoveHorizons;
        public InputAction @Run => m_Wrapper.m_PlayerNormal_Run;
        public InputAction @Interaction => m_Wrapper.m_PlayerNormal_Interaction;
        public InputAction @Coding => m_Wrapper.m_PlayerNormal_Coding;
        public InputActionMap Get() { return m_Wrapper.m_PlayerNormal; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerNormalActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerNormalActions instance)
        {
            if (m_Wrapper.m_PlayerNormalActionsCallbackInterface != null)
            {
                @MoveHorizons.started -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnMoveHorizons;
                @MoveHorizons.performed -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnMoveHorizons;
                @MoveHorizons.canceled -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnMoveHorizons;
                @Run.started -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnRun;
                @Interaction.started -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnInteraction;
                @Coding.started -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnCoding;
                @Coding.performed -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnCoding;
                @Coding.canceled -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnCoding;
            }
            m_Wrapper.m_PlayerNormalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveHorizons.started += instance.OnMoveHorizons;
                @MoveHorizons.performed += instance.OnMoveHorizons;
                @MoveHorizons.canceled += instance.OnMoveHorizons;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @Coding.started += instance.OnCoding;
                @Coding.performed += instance.OnCoding;
                @Coding.canceled += instance.OnCoding;
            }
        }
    }
    public PlayerNormalActions @PlayerNormal => new PlayerNormalActions(this);
    private int m_PlayerSchemeIndex = -1;
    public InputControlScheme PlayerScheme
    {
        get
        {
            if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
            return asset.controlSchemes[m_PlayerSchemeIndex];
        }
    }
    public interface IPlayerNormalActions
    {
        void OnMoveHorizons(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnCoding(InputAction.CallbackContext context);
    }
}
