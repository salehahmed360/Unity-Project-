using System.Collections;
using UnityEditor;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
namespace Tests
{
    public class LaserTest
    {
        //uses objects in the resource folder to instantiate them
        GameObject laser = GameObject.Instantiate(Resources.Load("laser 2", typeof(GameObject))) as GameObject;
        GameObject wall = GameObject.Instantiate(Resources.Load("wall 1", typeof(GameObject))) as GameObject;
        [UnityTest]
        public IEnumerator LaserEndIsGreaterThanStartPosition()
        {
            float wallPos = wall.transform.position.z + 1; //making the wall in front of the laser

            var l = laser.GetComponent<laser>();

            yield return new WaitForSeconds(1f); 

            Assert.IsTrue(l.GetEndLaserPosition() > l.GetStartLaserPosition()); //checks that the laser goes in the z axis

        }
        [UnityTest]
        public IEnumerator LaserReturnObjectOrWallHit()
        {
            //uses objects in the resource folder to instantiate them and check the laser hits the wall and if the wall name is "wall 1"
            float wallPos = wall.transform.position.z+1; 

            var l = laser.GetComponent<laser>();

            yield return new WaitForSeconds(1f);

            Assert.AreEqual("wall 1", l.hit.transform.gameObject.name="wall 1");

        }
    }
}
