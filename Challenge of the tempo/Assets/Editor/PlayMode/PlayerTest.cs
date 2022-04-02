using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTest
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MovePlayer_Along_X_Axis()
        {
            var player = GameObject.Instantiate(new GameObject()); 
            player.AddComponent<CharacterController>();

            Player playerScript =  player.AddComponent<Player>(); //attaching the player script to the game object player

            playerScript.movementSpeed = 1;
            var unityService = Substitute.For<IUnityService>();
           

            unityService.GetAxis("Horizontal").Returns(1); //moves player object by 1 along the horizontal axis
            unityService.GetDeltaTime().Returns(1);
            playerScript.UnityService = unityService;

            yield return null; 

            Assert.AreEqual(1, player.transform.position.x, 0.1f); //checks if player moved position from his last position
        
        }

        [UnityTest]
        public IEnumerator MovePlayer_Along_Z_Axis()
        {
            var player = GameObject.Instantiate(new GameObject());
            player.AddComponent<CharacterController>();

            Player playerScript = player.AddComponent<Player>();

            playerScript.movementSpeed = 1;
            var unityService = Substitute.For<IUnityService>();


            unityService.GetAxis("Vertical").Returns(1);
            unityService.GetDeltaTime().Returns(1);
            playerScript.UnityService = unityService;

            yield return null; 

            Assert.AreEqual(1, player.transform.position.z, 0.1f);

        }
    }
}
