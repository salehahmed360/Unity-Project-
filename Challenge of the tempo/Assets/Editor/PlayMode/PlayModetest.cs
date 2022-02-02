using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayModetest
    {
        GameObject testObject;
        CharacterController controller;

        [SetUp]
        public void Setup()
        {
            testObject = GameObject.Instantiate(new GameObject());

            testObject.AddComponent<Rigidbody>();
            controller = testObject.AddComponent<CharacterController>();

        }
        // A Test behaves as an ordinary method
        [Test]
        public void PlayModetestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator checkObjectHasRigidBody()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(0.1f);
            Assert.NotNull(testObject.GetComponent<Rigidbody>());
        } [UnityTest]
        public IEnumerator checkPlayerMovement()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var originalPos = testObject.transform.position = Vector3.forward*5;
           
           
            var moving = testObject.transform.position = Vector3.forward;


            //Vector3 movement = transform.right * x + transform.forward * z;
            controller.Move(moving * 5);
             
            var moved = testObject.transform.position;
            Assert.AreEqual(moved,originalPos);
            yield return new WaitForSeconds(0.5f);
        }
        [UnityTest]
        public IEnumerator RedTrigger_addBox_returnSize()
        {
            GameObject testObject = GameObject.Instantiate(new GameObject());
            

           // RedTrigger redTrigger = testObject.AddComponent<RedTrigger>(); 
            List<GameObject> redBoxes = new List<GameObject>();

            //bool tagFound = false;
            GameObject redBox = GameObject.Instantiate(new GameObject());
            //redBox.tag = "redBox1";
            redBoxes.Add(redBox);
            GameObject []array = redBoxes.ToArray();
            
           /* for(int i = 0; i<array.Length; i++)
            {
                if (array[i].tag == "redBox1")
                {

                    tagFound = true;
                }
                else
                {
                    tagFound = false;
                }

            }*/

            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(redBoxes.Count==1);
        }
    }
}
