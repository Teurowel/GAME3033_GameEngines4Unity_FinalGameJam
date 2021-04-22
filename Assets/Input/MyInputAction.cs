// GENERATED AUTOMATICALLY FROM 'Assets/Input/MyInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MyInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyInputAction"",
    ""maps"": [
        {
            ""name"": ""TopDown"",
            ""id"": ""62382112-2d49-4dea-b403-513a9d6a7255"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""12cc5d04-c44b-44cd-9710-9a1f1265cd51"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""Value"",
                    ""id"": ""1a2ffa7a-f26d-4fe0-9e83-06d4eff699a5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""c46d1691-0135-42db-b1f9-96c77b7450f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Number1"",
                    ""type"": ""Button"",
                    ""id"": ""be91b87b-ef95-4bf6-b151-12925a1b91df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Number2"",
                    ""type"": ""Button"",
                    ""id"": ""bcb1a752-33ac-4414-98bd-ed6ea2143b1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Number3"",
                    ""type"": ""Button"",
                    ""id"": ""60d39407-b6bd-4301-9de0-ea0ce4da8f72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""5c230138-4270-4b54-94c1-46801a61ca9f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""13b3fe05-053c-4485-9925-11ec4e70be36"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""6fb10f26-989c-4cca-970b-0c2f26046016"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""0da3f3f5-43f4-4562-b0de-4a2d820a901e"",
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
                    ""id"": ""26c9e996-2ba7-41bc-9cc4-e4f32e08c09b"",
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
                    ""id"": ""46052a43-cdc7-4d77-b2b8-4552c341e5e4"",
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
                    ""id"": ""b15fdb8b-132c-4137-ba32-3e4082438c9b"",
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
                    ""id"": ""f8ca2b42-c32e-4cd5-8662-31d3e72ba98a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""febe3d2a-2d36-43ca-b1a1-265b83a29b43"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""182ca4b6-62b3-4302-ac2f-c67c08530521"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c21b7e9-6b7a-4f5d-8744-31fc5f5b177a"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e3046cb-2d2a-4307-93c1-c4a93651d609"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""291519f1-b6f2-4fe7-8511-4ecc946f64f2"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Number3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a305009b-4292-4c27-9510-878a4fb664e1"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a82ce751-2f41-4fca-b1b9-2b52fabf79d4"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08db2835-6477-4f7e-b7cd-c710dbc63305"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TopDown
        m_TopDown = asset.FindActionMap("TopDown", throwIfNotFound: true);
        m_TopDown_Movement = m_TopDown.FindAction("Movement", throwIfNotFound: true);
        m_TopDown_MouseMove = m_TopDown.FindAction("MouseMove", throwIfNotFound: true);
        m_TopDown_Fire = m_TopDown.FindAction("Fire", throwIfNotFound: true);
        m_TopDown_Number1 = m_TopDown.FindAction("Number1", throwIfNotFound: true);
        m_TopDown_Number2 = m_TopDown.FindAction("Number2", throwIfNotFound: true);
        m_TopDown_Number3 = m_TopDown.FindAction("Number3", throwIfNotFound: true);
        m_TopDown_Pause = m_TopDown.FindAction("Pause", throwIfNotFound: true);
        m_TopDown_MousePosition = m_TopDown.FindAction("MousePosition", throwIfNotFound: true);
        m_TopDown_Interact = m_TopDown.FindAction("Interact", throwIfNotFound: true);
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

    // TopDown
    private readonly InputActionMap m_TopDown;
    private ITopDownActions m_TopDownActionsCallbackInterface;
    private readonly InputAction m_TopDown_Movement;
    private readonly InputAction m_TopDown_MouseMove;
    private readonly InputAction m_TopDown_Fire;
    private readonly InputAction m_TopDown_Number1;
    private readonly InputAction m_TopDown_Number2;
    private readonly InputAction m_TopDown_Number3;
    private readonly InputAction m_TopDown_Pause;
    private readonly InputAction m_TopDown_MousePosition;
    private readonly InputAction m_TopDown_Interact;
    public struct TopDownActions
    {
        private @MyInputAction m_Wrapper;
        public TopDownActions(@MyInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_TopDown_Movement;
        public InputAction @MouseMove => m_Wrapper.m_TopDown_MouseMove;
        public InputAction @Fire => m_Wrapper.m_TopDown_Fire;
        public InputAction @Number1 => m_Wrapper.m_TopDown_Number1;
        public InputAction @Number2 => m_Wrapper.m_TopDown_Number2;
        public InputAction @Number3 => m_Wrapper.m_TopDown_Number3;
        public InputAction @Pause => m_Wrapper.m_TopDown_Pause;
        public InputAction @MousePosition => m_Wrapper.m_TopDown_MousePosition;
        public InputAction @Interact => m_Wrapper.m_TopDown_Interact;
        public InputActionMap Get() { return m_Wrapper.m_TopDown; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TopDownActions set) { return set.Get(); }
        public void SetCallbacks(ITopDownActions instance)
        {
            if (m_Wrapper.m_TopDownActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMovement;
                @MouseMove.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMouseMove;
                @MouseMove.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMouseMove;
                @MouseMove.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMouseMove;
                @Fire.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnFire;
                @Number1.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnNumber1;
                @Number1.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnNumber1;
                @Number1.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnNumber1;
                @Number2.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnNumber2;
                @Number2.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnNumber2;
                @Number2.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnNumber2;
                @Number3.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnNumber3;
                @Number3.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnNumber3;
                @Number3.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnNumber3;
                @Pause.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnPause;
                @MousePosition.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnMousePosition;
                @Interact.started -= m_Wrapper.m_TopDownActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_TopDownActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_TopDownActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_TopDownActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MouseMove.started += instance.OnMouseMove;
                @MouseMove.performed += instance.OnMouseMove;
                @MouseMove.canceled += instance.OnMouseMove;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Number1.started += instance.OnNumber1;
                @Number1.performed += instance.OnNumber1;
                @Number1.canceled += instance.OnNumber1;
                @Number2.started += instance.OnNumber2;
                @Number2.performed += instance.OnNumber2;
                @Number2.canceled += instance.OnNumber2;
                @Number3.started += instance.OnNumber3;
                @Number3.performed += instance.OnNumber3;
                @Number3.canceled += instance.OnNumber3;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public TopDownActions @TopDown => new TopDownActions(this);
    public interface ITopDownActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseMove(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnNumber1(InputAction.CallbackContext context);
        void OnNumber2(InputAction.CallbackContext context);
        void OnNumber3(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
