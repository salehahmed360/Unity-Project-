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
        GameObject laser;
        GameObject wall;
        GameObject player;
        [SetUp]
        public void SetUp()
        {
             laser = GameObject.Instantiate(Resources.Load("laser 2", typeof(GameObject))) as GameObject;//using the laser resource from the resource folder
             wall = GameObject.Instantiate(Resources.Load("wall 1", typeof(GameObject))) as GameObject;
        }


        //uses objects in the resource folder to instantiate them
       
        [UnityTest, Order(1)]
        public IEnumerator LaserEndIsGreaterThanStartPosition()
        {
            float wallPos = wall.transform.position.z + 1; //making the wall in front of the laser

            var l = laser.GetComponent<Laser>();

            yield return new WaitForSeconds(1f); 

            Assert.IsTrue(l.GetEndLaserPosition() > l.GetStartLaserPosition()); //checks that the laser goes in the z axis

        }
        [UnityTest, Order(2)]
        public IEnumerator LaserReturnObjectOrWallHit()
        {
            //uses objects in the resource folder to instantiate them and check the laser hits the wall and if the wall name is "wall 1"
            float wallPos = wall.transform.position.z+1; 

            var l = laser.GetComponent<Laser>();

            yield return new WaitForSeconds(1f);

            Assert.AreEqual("wall 1", l.hit.transform.gameObject.name="wall 1");

        }

        
        [UnityTest, Order(3)]
        public IEnumerator LaserDetectPlayerTagOnceHit()
        {
            //using a basic shape with player tag to check if the laser can detect the player tag
             player = GameObject.Instantiate(Resources.Load("player", typeof(GameObject))) as GameObject;
            var playerPos = player.transform.position;
            playerPos = laser.transform.position;

            var l = laser.GetComponent<Laser>(); //using the laser script to access its hit

            yield return new WaitForSeconds(1f);

            Assert.AreEqual("Player", l.hit.transform.tag="Player");

           


        } 
        [TearDown, Order(4)]
        public void TearDown()
        {
            GameObject.Destroy(player);
            GameObject.Destroy(wall);
            GameObject.Destroy(laser);
        }
    }
}
