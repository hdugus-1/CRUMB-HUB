//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/Coder/Scipt/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e52d212d-9f21-467e-9823-702e0349f880"",
            ""actions"": [
                {
                    ""name"": ""steer"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b5523a2e-e05b-4988-b3ff-8119511ebec7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""accel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""73ce58f7-152a-41a8-b7a0-0d2a9b0ad2c4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""brake"",
                    ""type"": ""PassThrough"",
                    ""id"": ""86de9087-a0cf-480e-bbd1-9f9ba6c0c6e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""armmovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""427bba21-6e54-43dd-836f-a246cb709b0a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""fire"",
                    ""type"": ""Button"",
                    ""id"": ""4f0cb2aa-e82c-4827-91be-33d7759f64f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""gun_base_right"",
                    ""type"": ""Button"",
                    ""id"": ""5a752d17-f7e1-4744-a4a1-5ae7998c1c83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""gun_base_left"",
                    ""type"": ""Button"",
                    ""id"": ""a544b3c9-027f-47a1-889e-495376472cf6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""upgradeMenuEnter"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8d18f2e7-4baf-431b-9ac1-450533e0cf73"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""grab"",
                    ""type"": ""Value"",
                    ""id"": ""8f6f2bbc-b1eb-4565-8bb6-e0baa00d0045"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""pause"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5499f787-10d2-45c5-819c-9e09861ddeed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""unPause"",
                    ""type"": ""PassThrough"",
                    ""id"": ""eb3a9cac-c283-427e-b0c4-bf24b5869f8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""openHUD"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8cd7c4be-0a13-41e5-9ffd-07bc4876e0a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c71e8ea0-6733-447d-9d65-b105c0b7aa68"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""accel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cff75b6b-9773-412f-b899-a8eb7234569a"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e9913dd-d0cc-4731-8ab8-edb541bf0327"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""armmovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6bb8a33-89b5-45c3-925b-b535a7d7bea9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62f3a6b5-cd17-47df-be86-68bfc76aa7cf"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""gun_base_right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1750d998-be78-4281-9372-732db80ea486"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""gun_base_left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17813462-24e4-4ccb-9c92-c06388f16ac9"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""upgradeMenuEnter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39be4c9a-1f74-44ef-a3a4-edc6d90a5534"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c648686d-9766-4a70-b83f-a25b4c2908df"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e47b85a6-bc3e-4766-9bce-1ff6fb485a77"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""unPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7814913-9640-40d8-8336-05f2e5f5f924"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d7ad0af-4445-45a5-a455-1191214d4213"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""openHUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""New action map"",
            ""id"": ""a1d3b5ae-4476-4c29-bf74-bf3f03fc1b07"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""29160ad6-7b5f-4728-a93e-eb965d782dae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""20f9909d-0f28-474e-a488-0e2f24ee2a9f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
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
        m_Player_steer = m_Player.FindAction("steer", throwIfNotFound: true);
        m_Player_accel = m_Player.FindAction("accel", throwIfNotFound: true);
        m_Player_brake = m_Player.FindAction("brake", throwIfNotFound: true);
        m_Player_armmovement = m_Player.FindAction("armmovement", throwIfNotFound: true);
        m_Player_fire = m_Player.FindAction("fire", throwIfNotFound: true);
        m_Player_gun_base_right = m_Player.FindAction("gun_base_right", throwIfNotFound: true);
        m_Player_gun_base_left = m_Player.FindAction("gun_base_left", throwIfNotFound: true);
        m_Player_upgradeMenuEnter = m_Player.FindAction("upgradeMenuEnter", throwIfNotFound: true);
        m_Player_grab = m_Player.FindAction("grab", throwIfNotFound: true);
        m_Player_pause = m_Player.FindAction("pause", throwIfNotFound: true);
        m_Player_unPause = m_Player.FindAction("unPause", throwIfNotFound: true);
        m_Player_openHUD = m_Player.FindAction("openHUD", throwIfNotFound: true);
        // New action map
        m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
        m_Newactionmap_Newaction = m_Newactionmap.FindAction("New action", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_steer;
    private readonly InputAction m_Player_accel;
    private readonly InputAction m_Player_brake;
    private readonly InputAction m_Player_armmovement;
    private readonly InputAction m_Player_fire;
    private readonly InputAction m_Player_gun_base_right;
    private readonly InputAction m_Player_gun_base_left;
    private readonly InputAction m_Player_upgradeMenuEnter;
    private readonly InputAction m_Player_grab;
    private readonly InputAction m_Player_pause;
    private readonly InputAction m_Player_unPause;
    private readonly InputAction m_Player_openHUD;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @steer => m_Wrapper.m_Player_steer;
        public InputAction @accel => m_Wrapper.m_Player_accel;
        public InputAction @brake => m_Wrapper.m_Player_brake;
        public InputAction @armmovement => m_Wrapper.m_Player_armmovement;
        public InputAction @fire => m_Wrapper.m_Player_fire;
        public InputAction @gun_base_right => m_Wrapper.m_Player_gun_base_right;
        public InputAction @gun_base_left => m_Wrapper.m_Player_gun_base_left;
        public InputAction @upgradeMenuEnter => m_Wrapper.m_Player_upgradeMenuEnter;
        public InputAction @grab => m_Wrapper.m_Player_grab;
        public InputAction @pause => m_Wrapper.m_Player_pause;
        public InputAction @unPause => m_Wrapper.m_Player_unPause;
        public InputAction @openHUD => m_Wrapper.m_Player_openHUD;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @steer.started += instance.OnSteer;
            @steer.performed += instance.OnSteer;
            @steer.canceled += instance.OnSteer;
            @accel.started += instance.OnAccel;
            @accel.performed += instance.OnAccel;
            @accel.canceled += instance.OnAccel;
            @brake.started += instance.OnBrake;
            @brake.performed += instance.OnBrake;
            @brake.canceled += instance.OnBrake;
            @armmovement.started += instance.OnArmmovement;
            @armmovement.performed += instance.OnArmmovement;
            @armmovement.canceled += instance.OnArmmovement;
            @fire.started += instance.OnFire;
            @fire.performed += instance.OnFire;
            @fire.canceled += instance.OnFire;
            @gun_base_right.started += instance.OnGun_base_right;
            @gun_base_right.performed += instance.OnGun_base_right;
            @gun_base_right.canceled += instance.OnGun_base_right;
            @gun_base_left.started += instance.OnGun_base_left;
            @gun_base_left.performed += instance.OnGun_base_left;
            @gun_base_left.canceled += instance.OnGun_base_left;
            @upgradeMenuEnter.started += instance.OnUpgradeMenuEnter;
            @upgradeMenuEnter.performed += instance.OnUpgradeMenuEnter;
            @upgradeMenuEnter.canceled += instance.OnUpgradeMenuEnter;
            @grab.started += instance.OnGrab;
            @grab.performed += instance.OnGrab;
            @grab.canceled += instance.OnGrab;
            @pause.started += instance.OnPause;
            @pause.performed += instance.OnPause;
            @pause.canceled += instance.OnPause;
            @unPause.started += instance.OnUnPause;
            @unPause.performed += instance.OnUnPause;
            @unPause.canceled += instance.OnUnPause;
            @openHUD.started += instance.OnOpenHUD;
            @openHUD.performed += instance.OnOpenHUD;
            @openHUD.canceled += instance.OnOpenHUD;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @steer.started -= instance.OnSteer;
            @steer.performed -= instance.OnSteer;
            @steer.canceled -= instance.OnSteer;
            @accel.started -= instance.OnAccel;
            @accel.performed -= instance.OnAccel;
            @accel.canceled -= instance.OnAccel;
            @brake.started -= instance.OnBrake;
            @brake.performed -= instance.OnBrake;
            @brake.canceled -= instance.OnBrake;
            @armmovement.started -= instance.OnArmmovement;
            @armmovement.performed -= instance.OnArmmovement;
            @armmovement.canceled -= instance.OnArmmovement;
            @fire.started -= instance.OnFire;
            @fire.performed -= instance.OnFire;
            @fire.canceled -= instance.OnFire;
            @gun_base_right.started -= instance.OnGun_base_right;
            @gun_base_right.performed -= instance.OnGun_base_right;
            @gun_base_right.canceled -= instance.OnGun_base_right;
            @gun_base_left.started -= instance.OnGun_base_left;
            @gun_base_left.performed -= instance.OnGun_base_left;
            @gun_base_left.canceled -= instance.OnGun_base_left;
            @upgradeMenuEnter.started -= instance.OnUpgradeMenuEnter;
            @upgradeMenuEnter.performed -= instance.OnUpgradeMenuEnter;
            @upgradeMenuEnter.canceled -= instance.OnUpgradeMenuEnter;
            @grab.started -= instance.OnGrab;
            @grab.performed -= instance.OnGrab;
            @grab.canceled -= instance.OnGrab;
            @pause.started -= instance.OnPause;
            @pause.performed -= instance.OnPause;
            @pause.canceled -= instance.OnPause;
            @unPause.started -= instance.OnUnPause;
            @unPause.performed -= instance.OnUnPause;
            @unPause.canceled -= instance.OnUnPause;
            @openHUD.started -= instance.OnOpenHUD;
            @openHUD.performed -= instance.OnOpenHUD;
            @openHUD.canceled -= instance.OnOpenHUD;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private List<INewactionmapActions> m_NewactionmapActionsCallbackInterfaces = new List<INewactionmapActions>();
    private readonly InputAction m_Newactionmap_Newaction;
    public struct NewactionmapActions
    {
        private @Controls m_Wrapper;
        public NewactionmapActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Newactionmap_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void AddCallbacks(INewactionmapActions instance)
        {
            if (instance == null || m_Wrapper.m_NewactionmapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_NewactionmapActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(INewactionmapActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(INewactionmapActions instance)
        {
            foreach (var item in m_Wrapper.m_NewactionmapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_NewactionmapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
    public interface IPlayerActions
    {
        void OnSteer(InputAction.CallbackContext context);
        void OnAccel(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnArmmovement(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnGun_base_right(InputAction.CallbackContext context);
        void OnGun_base_left(InputAction.CallbackContext context);
        void OnUpgradeMenuEnter(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnUnPause(InputAction.CallbackContext context);
        void OnOpenHUD(InputAction.CallbackContext context);
    }
    public interface INewactionmapActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
