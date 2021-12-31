using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PurpleTriggerTest
    {
        [UnityTest]
        public IEnumerator PurpleBoxTrigger_Check_Box_InList_Tag_purplebox1()
        {
            //create a new object   
            var PurpleTriggerObj = new GameObject();
            PurpleTriggerObj.name = "greenTrigger";

            //create a new box object with its name and tag
            var PurpleBoxObj = GameObject.Instantiate(new GameObject());
            PurpleBoxObj.name = "purpleBox";
            PurpleBoxObj.tag = "purplebox1";
            PurpleBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(PurpleBoxObj, "purplebox1", "purplebox2", "purplebox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(PurpleBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }

        [UnityTest]
        public IEnumerator PurpleBoxTrigger_Check_Box_InList_Tag_purplebox2()
        {
            //create a new object   
            var PurpleTriggerObj = new GameObject();
            PurpleTriggerObj.name = "greenTrigger";

            //create a new box object with its name and tag
            var PurpleBoxObj = GameObject.Instantiate(new GameObject());
            PurpleBoxObj.name = "purpleBox";
            PurpleBoxObj.tag = "purplebox2";
            PurpleBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(PurpleBoxObj, "purplebox1", "purplebox2", "purplebox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(PurpleBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }

        [UnityTest]
        public IEnumerator PurpleBoxTrigger_Check_Box_InList_Tag_purplebox3()
        {
            //create a new object   
            var PurpleTriggerObj = new GameObject();
            PurpleTriggerObj.name = "greenTrigger";

            //create a new box object with its name and tag
            var PurpleBoxObj = GameObject.Instantiate(new GameObject());
            PurpleBoxObj.name = "purpleBox";
            PurpleBoxObj.tag = "purplebox3";
            PurpleBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(PurpleBoxObj, "purplebox1", "purplebox2", "purplebox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(PurpleBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }
    }
}
