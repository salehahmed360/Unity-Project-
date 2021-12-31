using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RedTriggerBoxTest
    {
        [UnityTest]
        public IEnumerator RedBoxTrigger_Check_Box_InList_Tag_redbox1()
        {
            //create a new object   
            var RedTriggerObj = new GameObject();
            RedTriggerObj.name = "redTrigger"; 
            
            //create a new box object with its name and tag
            var RedBoxObj = GameObject.Instantiate(new GameObject());
            RedBoxObj.name = "redBox";
            RedBoxObj.tag = "redbox1";
            RedBoxObj.layer =9; 

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(RedBoxObj, "redbox1", "redbox2", "redbox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(RedBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }
        [UnityTest]
        public IEnumerator RedBoxTrigger_Check_Box_InList_Tag_redbox2()
        {
            //create a new object   
            var RedTriggerObj = new GameObject();
            RedTriggerObj.name = "redTrigger";

            //create a new box object with its name and tag
            var RedBoxObj = GameObject.Instantiate(new GameObject());
            RedBoxObj.name = "redBox";
            RedBoxObj.tag = "redbox2";
            RedBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(RedBoxObj, "redbox1", "redbox2", "redbox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(RedBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }
        [UnityTest]
        public IEnumerator RedBoxTrigger_Check_Box_InList_Tag_redbox3()
        {
            //create a new object   
            var RedTriggerObj = new GameObject();
            RedTriggerObj.name = "redTrigger";

            //create a new box object with its name and tag
            var RedBoxObj = GameObject.Instantiate(new GameObject());
            RedBoxObj.name = "redBox";
            RedBoxObj.tag = "redbox3";
            RedBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(RedBoxObj, "redbox1", "redbox2", "redbox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(RedBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count,0.1f); 
    }
          
    }
}

