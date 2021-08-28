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
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""8d490180-d97c-4d4f-836c-a6f7a4392b67"",
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
                    ""id"": ""9fc9a4fc-1140-4bf4-acb9-5e210bf4f365"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bcc3236-8109-4b58-89db-131cb9301bf4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""NullMap"",
            ""id"": ""c4624120-51ed-40d4-859d-23407e1af549"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""26b56a36-3d1d-4cb2-9efb-beb11a1d5267"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9eff2e95-3f55-48f7-9135-a5be0149d9ae"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerInThrowing"",
            ""id"": ""ce68185c-0387-41f3-b3e6-fa39ba2919e5"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""078b3370-2cb6-4574-9156-0146ae814573"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""6bab4454-55d6-409c-9736-d1640a407628"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AdjustTheAngle"",
                    ""type"": ""Value"",
                    ""id"": ""fddd4068-5ae8-4c1a-8498-4c8c30327f57"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4c3ccd32-0010-4273-951a-4280201b6418"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e28bf435-0e2c-4e22-887e-66dc54eb99c2"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72d81a4a-c61f-4b02-8495-19d0fe279d6c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42108f89-0858-4a1e-8ca9-f92d541b2328"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ea410c6c-a556-403c-8a68-002f5b70e7c0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustTheAngle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""96e2ca69-cab5-4c52-8bf7-8e3e98800a2f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""AdjustTheAngle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c016c203-a320-411b-9ec1-2dadd19d628a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""AdjustTheAngle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""85e86d8c-ef51-4e91-9833-416f07830ef7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AdjustTheAngle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dbde76be-6fa4-4ffa-b56c-889e98ce208a"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""AdjustTheAngle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b0d81269-947f-44bf-9dc6-4f11746d6eb2"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""AdjustTheAngle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PlayerInCoding"",
            ""id"": ""cf9f6510-ef62-47c2-9169-7097bc6c6b59"",
            ""actions"": [
                {
                    ""name"": ""Coding"",
                    ""type"": ""Button"",
                    ""id"": ""7740a478-a400-40d6-96a6-27525d86c2dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ddf24efa-fd79-4857-a09e-67b1843f0e5d"",
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
                    ""id"": ""d7103191-c434-42b6-a74c-50ad51ec6322"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Coding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerInReparingTheMachine"",
            ""id"": ""d71f6668-2465-4d0b-9fab-d5bc6a92e671"",
            ""actions"": [
                {
                    ""name"": ""Comfirm"",
                    ""type"": ""Button"",
                    ""id"": ""43dde524-dc10-473f-b1e8-7ce5297afc88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0d7b7b13-bcb1-4c78-aea2-c52004d78d00"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Comfirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1d323fa-54ce-4fd5-90dc-24af8e3f1115"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Comfirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerInMissionBook"",
            ""id"": ""fc5b786d-017d-4ed3-97f8-cb2cd03a606b"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""4d4b3e51-6a09-47af-84d0-6c113e870633"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2cec3d75-a26d-40af-bdd6-006ee4386738"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51d166a5-9d42-461c-9da2-d14d84af00a5"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Quit"",
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
        m_PlayerNormal_Quit = m_PlayerNormal.FindAction("Quit", throwIfNotFound: true);
        // NullMap
        m_NullMap = asset.FindActionMap("NullMap", throwIfNotFound: true);
        m_NullMap_Newaction = m_NullMap.FindAction("New action", throwIfNotFound: true);
        // PlayerInThrowing
        m_PlayerInThrowing = asset.FindActionMap("PlayerInThrowing", throwIfNotFound: true);
        m_PlayerInThrowing_Quit = m_PlayerInThrowing.FindAction("Quit", throwIfNotFound: true);
        m_PlayerInThrowing_Throw = m_PlayerInThrowing.FindAction("Throw", throwIfNotFound: true);
        m_PlayerInThrowing_AdjustTheAngle = m_PlayerInThrowing.FindAction("AdjustTheAngle", throwIfNotFound: true);
        // PlayerInCoding
        m_PlayerInCoding = asset.FindActionMap("PlayerInCoding", throwIfNotFound: true);
        m_PlayerInCoding_Coding = m_PlayerInCoding.FindAction("Coding", throwIfNotFound: true);
        // PlayerInReparingTheMachine
        m_PlayerInReparingTheMachine = asset.FindActionMap("PlayerInReparingTheMachine", throwIfNotFound: true);
        m_PlayerInReparingTheMachine_Comfirm = m_PlayerInReparingTheMachine.FindAction("Comfirm", throwIfNotFound: true);
        // PlayerInMissionBook
        m_PlayerInMissionBook = asset.FindActionMap("PlayerInMissionBook", throwIfNotFound: true);
        m_PlayerInMissionBook_Quit = m_PlayerInMissionBook.FindAction("Quit", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerNormal_Quit;
    public struct PlayerNormalActions
    {
        private @Player m_Wrapper;
        public PlayerNormalActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveHorizons => m_Wrapper.m_PlayerNormal_MoveHorizons;
        public InputAction @Run => m_Wrapper.m_PlayerNormal_Run;
        public InputAction @Interaction => m_Wrapper.m_PlayerNormal_Interaction;
        public InputAction @Quit => m_Wrapper.m_PlayerNormal_Quit;
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
                @Quit.started -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_PlayerNormalActionsCallbackInterface.OnQuit;
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
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public PlayerNormalActions @PlayerNormal => new PlayerNormalActions(this);

    // NullMap
    private readonly InputActionMap m_NullMap;
    private INullMapActions m_NullMapActionsCallbackInterface;
    private readonly InputAction m_NullMap_Newaction;
    public struct NullMapActions
    {
        private @Player m_Wrapper;
        public NullMapActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_NullMap_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_NullMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NullMapActions set) { return set.Get(); }
        public void SetCallbacks(INullMapActions instance)
        {
            if (m_Wrapper.m_NullMapActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_NullMapActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_NullMapActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_NullMapActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_NullMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public NullMapActions @NullMap => new NullMapActions(this);

    // PlayerInThrowing
    private readonly InputActionMap m_PlayerInThrowing;
    private IPlayerInThrowingActions m_PlayerInThrowingActionsCallbackInterface;
    private readonly InputAction m_PlayerInThrowing_Quit;
    private readonly InputAction m_PlayerInThrowing_Throw;
    private readonly InputAction m_PlayerInThrowing_AdjustTheAngle;
    public struct PlayerInThrowingActions
    {
        private @Player m_Wrapper;
        public PlayerInThrowingActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quit => m_Wrapper.m_PlayerInThrowing_Quit;
        public InputAction @Throw => m_Wrapper.m_PlayerInThrowing_Throw;
        public InputAction @AdjustTheAngle => m_Wrapper.m_PlayerInThrowing_AdjustTheAngle;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInThrowing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInThrowingActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInThrowingActions instance)
        {
            if (m_Wrapper.m_PlayerInThrowingActionsCallbackInterface != null)
            {
                @Quit.started -= m_Wrapper.m_PlayerInThrowingActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_PlayerInThrowingActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_PlayerInThrowingActionsCallbackInterface.OnQuit;
                @Throw.started -= m_Wrapper.m_PlayerInThrowingActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_PlayerInThrowingActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_PlayerInThrowingActionsCallbackInterface.OnThrow;
                @AdjustTheAngle.started -= m_Wrapper.m_PlayerInThrowingActionsCallbackInterface.OnAdjustTheAngle;
                @AdjustTheAngle.performed -= m_Wrapper.m_PlayerInThrowingActionsCallbackInterface.OnAdjustTheAngle;
                @AdjustTheAngle.canceled -= m_Wrapper.m_PlayerInThrowingActionsCallbackInterface.OnAdjustTheAngle;
            }
            m_Wrapper.m_PlayerInThrowingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @AdjustTheAngle.started += instance.OnAdjustTheAngle;
                @AdjustTheAngle.performed += instance.OnAdjustTheAngle;
                @AdjustTheAngle.canceled += instance.OnAdjustTheAngle;
            }
        }
    }
    public PlayerInThrowingActions @PlayerInThrowing => new PlayerInThrowingActions(this);

    // PlayerInCoding
    private readonly InputActionMap m_PlayerInCoding;
    private IPlayerInCodingActions m_PlayerInCodingActionsCallbackInterface;
    private readonly InputAction m_PlayerInCoding_Coding;
    public struct PlayerInCodingActions
    {
        private @Player m_Wrapper;
        public PlayerInCodingActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Coding => m_Wrapper.m_PlayerInCoding_Coding;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInCoding; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInCodingActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInCodingActions instance)
        {
            if (m_Wrapper.m_PlayerInCodingActionsCallbackInterface != null)
            {
                @Coding.started -= m_Wrapper.m_PlayerInCodingActionsCallbackInterface.OnCoding;
                @Coding.performed -= m_Wrapper.m_PlayerInCodingActionsCallbackInterface.OnCoding;
                @Coding.canceled -= m_Wrapper.m_PlayerInCodingActionsCallbackInterface.OnCoding;
            }
            m_Wrapper.m_PlayerInCodingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Coding.started += instance.OnCoding;
                @Coding.performed += instance.OnCoding;
                @Coding.canceled += instance.OnCoding;
            }
        }
    }
    public PlayerInCodingActions @PlayerInCoding => new PlayerInCodingActions(this);

    // PlayerInReparingTheMachine
    private readonly InputActionMap m_PlayerInReparingTheMachine;
    private IPlayerInReparingTheMachineActions m_PlayerInReparingTheMachineActionsCallbackInterface;
    private readonly InputAction m_PlayerInReparingTheMachine_Comfirm;
    public struct PlayerInReparingTheMachineActions
    {
        private @Player m_Wrapper;
        public PlayerInReparingTheMachineActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Comfirm => m_Wrapper.m_PlayerInReparingTheMachine_Comfirm;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInReparingTheMachine; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInReparingTheMachineActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInReparingTheMachineActions instance)
        {
            if (m_Wrapper.m_PlayerInReparingTheMachineActionsCallbackInterface != null)
            {
                @Comfirm.started -= m_Wrapper.m_PlayerInReparingTheMachineActionsCallbackInterface.OnComfirm;
                @Comfirm.performed -= m_Wrapper.m_PlayerInReparingTheMachineActionsCallbackInterface.OnComfirm;
                @Comfirm.canceled -= m_Wrapper.m_PlayerInReparingTheMachineActionsCallbackInterface.OnComfirm;
            }
            m_Wrapper.m_PlayerInReparingTheMachineActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Comfirm.started += instance.OnComfirm;
                @Comfirm.performed += instance.OnComfirm;
                @Comfirm.canceled += instance.OnComfirm;
            }
        }
    }
    public PlayerInReparingTheMachineActions @PlayerInReparingTheMachine => new PlayerInReparingTheMachineActions(this);

    // PlayerInMissionBook
    private readonly InputActionMap m_PlayerInMissionBook;
    private IPlayerInMissionBookActions m_PlayerInMissionBookActionsCallbackInterface;
    private readonly InputAction m_PlayerInMissionBook_Quit;
    public struct PlayerInMissionBookActions
    {
        private @Player m_Wrapper;
        public PlayerInMissionBookActions(@Player wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quit => m_Wrapper.m_PlayerInMissionBook_Quit;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInMissionBook; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInMissionBookActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInMissionBookActions instance)
        {
            if (m_Wrapper.m_PlayerInMissionBookActionsCallbackInterface != null)
            {
                @Quit.started -= m_Wrapper.m_PlayerInMissionBookActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_PlayerInMissionBookActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_PlayerInMissionBookActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_PlayerInMissionBookActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public PlayerInMissionBookActions @PlayerInMissionBook => new PlayerInMissionBookActions(this);
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
        void OnQuit(InputAction.CallbackContext context);
    }
    public interface INullMapActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IPlayerInThrowingActions
    {
        void OnQuit(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnAdjustTheAngle(InputAction.CallbackContext context);
    }
    public interface IPlayerInCodingActions
    {
        void OnCoding(InputAction.CallbackContext context);
    }
    public interface IPlayerInReparingTheMachineActions
    {
        void OnComfirm(InputAction.CallbackContext context);
    }
    public interface IPlayerInMissionBookActions
    {
        void OnQuit(InputAction.CallbackContext context);
    }
}
