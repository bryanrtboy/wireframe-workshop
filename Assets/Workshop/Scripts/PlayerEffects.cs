using UnityEngine;
using System.Collections;

namespace Workshop
{

		public class PlayerEffects : MonoBehaviour
		{

				public AudioClip[] 	jumpClips;
				public AudioClip[] taunts;				// Array of clips for when the player taunts.
				public float tauntProbability = 50f;	// Chance of a taunt happening.
				public float tauntDelay = 1f;			// Delay for when the taunt should happen.
	
	
				private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
				private int jumpIndex;

				public IEnumerator Taunt ()
				{
						// Check the random chance of taunting.
						float tauntChance = Random.Range (0f, 100f);
						if (tauntChance > tauntProbability) {
								// Wait for tauntDelay number of seconds.
								yield return new WaitForSeconds (tauntDelay);
			
								// If there is no clip currently playing.
								if (!audio.isPlaying) {
										// Choose a random, but different taunt.
										tauntIndex = TauntRandom ();
				
										// Play the new taunt.
										audio.clip = taunts [tauntIndex];
										audio.Play ();
								}
						}
				}

	
				int TauntRandom ()
				{
						// Choose a random index of the taunts array.
						int i = Random.Range (0, taunts.Length);
		
						// If it's the same as the previous taunt...
						if (i == tauntIndex)
			// ... try another random taunt.
								return TauntRandom ();
						else
			// Otherwise return this index.
								return i;
				}

				public void JumpSound ()
				{
						jumpIndex = JumpRandom ();
						AudioSource.PlayClipAtPoint (jumpClips [jumpIndex], transform.position);
				}
		
				int JumpRandom ()
				{
						int i = Random.Range (0, jumpClips.Length);
						if (i == jumpIndex)
								return JumpRandom ();
						else
								return i;
				}

		}
}
