using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;


namespace NaughtyCharacter
{
    public class PlayerInputComponent : MonoBehaviour
    {

        [SerializeField] bool TestGame;
        public Vector2 MoveInput { get; private set; }
        public Vector2 LastMoveInput { get; private set; }
        public Vector2 CameraInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool HasMoveInput { get; private set; }

        GameManager gameManager = GameManager.Instance;
        public void OnMoveEvent(InputAction.CallbackContext context)
        {
            if (!TestGame)
            {
                if (gameManager!=null && gameManager.currentState != GameManager.GameState.Playing)
                {
                    return;
                }
            }
            Vector2 moveInput = context.ReadValue<Vector2>();
            
            bool hasMoveInput = moveInput.sqrMagnitude > 0.0f;
            if (HasMoveInput && !hasMoveInput)
            {
                LastMoveInput = MoveInput;
            }

            MoveInput = moveInput;
            HasMoveInput = hasMoveInput;
        }

        public void OnLookEvent(InputAction.CallbackContext context)
        {
            if (!TestGame)
            {
                if (gameManager != null && gameManager.currentState != GameManager.GameState.Playing)
                {
                    return;
                }
            }
            CameraInput = context.ReadValue<Vector2>();
        }

        public void OnJumpEvent(InputAction.CallbackContext context)
        {
            if (TestGame)
            {
                if (gameManager != null &&gameManager.currentState != GameManager.GameState.Playing)
                {
                    return;
                }
            }
            if (context.started || context.performed)
            {
                JumpInput = true;
            }
            else if (context.canceled)
            {
                JumpInput = false;
            }
        }
    }
}
