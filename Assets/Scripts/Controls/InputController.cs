using UnityEngine;

namespace TwinStickShooter
{
    public class InputController : MemoTools.SingletonMonoBehaviour<InputController>
    {
        protected override bool DestroyOnLoad { get => false; }

        public float HorizontalInput { get; private set; }
        public float VerticalInput { get; private set; }
        public Vector2 DirectionInput { get; private set; }
        public Vector2 MovementInput { get; private set; }

        public Vector2 TouchPosition { get; private set; }
        public bool OnAction { get; private set; }


        protected override void InitAwake()
        {

        }

        private void Update()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            VerticalInput = Input.GetAxisRaw("Vertical");
            DirectionInput = new Vector2(HorizontalInput, VerticalInput);
            MovementInput = Vector2.ClampMagnitude(DirectionInput, 1);
            OnAction = Input.GetButton("Action");
            TouchPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}
