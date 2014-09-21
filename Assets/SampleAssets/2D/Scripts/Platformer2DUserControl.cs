using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets._2D
{

		[RequireComponent(typeof(PlatformerCharacter2D))]
		public class Platformer2DUserControl : MonoBehaviour
		{
				private PlatformerCharacter2D character;
				private bool jump;

				private void Awake ()
				{
						character = GetComponent<PlatformerCharacter2D> ();

				}

				private void Update ()
				{
						if (!jump)
								jump = CrossPlatformInputManager.GetButtonDown ("Jump");	     // Read the jump input in Update so button presses aren't missed.
				}

				private void FixedUpdate ()
				{
            
						bool crouch = Input.GetKey (KeyCode.LeftControl);						// Read the inputs.
						float h = CrossPlatformInputManager.GetAxis ("Horizontal");
            
						character.Move (h, crouch, jump);										// Pass all parameters to the character control script.
						jump = false;
				}
		}
}