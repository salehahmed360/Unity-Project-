using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BlueTriggerTest
    {
        [UnityTest]
        public IEnumerator BlueBoxTrigger_Check_Box_InList_Tag_bluebox1()
        {
            //create a new object   
            var BlueTriggerObj = new GameObject();
            BlueTriggerObj.name = "blueTrigger";

            //create a new box object with its name and tag
            var BlueBoxObj = GameObject.Instantiate(new GameObject());
            BlueBoxObj.name = "blueBox";
            BlueBoxObj.tag = "bluebox1";
            BlueBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(BlueBoxObj, "bluebox1", "bluebox2", "bluebox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(BlueBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }
        [UnityTest]
        public IEnumerator BlueBoxTrigger_Check_Box_InList_Tag_bluebox2()
        {
            //create a new object   
            var BlueTriggerObj = new GameObject();
            BlueTriggerObj.name = "blueTrigger";

            //create a new box object with its name and tag
            var BlueBoxObj = GameObject.Instantiate(new GameObject());
            BlueBoxObj.name = "blueBox";
            BlueBoxObj.tag = "bluebox2";
            BlueBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(BlueBoxObj, "bluebox1", "bluebox2", "bluebox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(BlueBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }
        [UnityTest]
        public IEnumerator BlueBoxTrigger_Check_Box_InList_Tag_bluebox3()
        {
            //create a new object   
            var BlueTriggerObj = new GameObject();
            BlueTriggerObj.name = "blueTrigger";

            //create a new box object with its name and tag
            var BlueBoxObj = GameObject.Instantiate(new GameObject());
            BlueBoxObj.name = "blueBox";
            BlueBoxObj.tag = "bluebox3";
            BlueBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(BlueBoxObj, "bluebox1", "bluebox2", "bluebox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(BlueBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }
    }
}
