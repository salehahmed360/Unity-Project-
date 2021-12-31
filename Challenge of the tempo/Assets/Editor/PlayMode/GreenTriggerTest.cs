using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GreenTriggerBox
    {
        [UnityTest]
        public IEnumerator GreenBoxTrigger_Check_Box_InList_Tag_greenbox1()
        {
            //create a new object   
            var GreenTriggerObj = new GameObject();
            GreenTriggerObj.name = "greenTrigger";

            //create a new box object with its name and tag
            var GreenBoxObj = GameObject.Instantiate(new GameObject());
            GreenBoxObj.name = "greenBox";
            GreenBoxObj.tag = "greenbox1";
            GreenBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(GreenBoxObj, "greenbox1", "greenbox2", "greenbox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(GreenBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }

        [UnityTest]
        public IEnumerator GreenBoxTrigger_Check_Box_InList_Tag_greenbox2()
        {
            //create a new object   
            var GreenTriggerObj = new GameObject();
            GreenTriggerObj.name = "greenTrigger";

            //create a new box object with its name and tag
            var GreenBoxObj = GameObject.Instantiate(new GameObject());
            GreenBoxObj.name = "greenBox";
            GreenBoxObj.tag = "greenbox2";
            GreenBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(GreenBoxObj, "greenbox1", "greenbox2", "greenbox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(GreenBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }

        [UnityTest]
        public IEnumerator GreenBoxTrigger_Check_Box_InList_Tag_greenbox3()
        {
            //create a new object   
            var GreenTriggerObj = new GameObject();
            GreenTriggerObj.name = "greenTrigger";

            //create a new box object with its name and tag
            var GreenBoxObj = GameObject.Instantiate(new GameObject());
            GreenBoxObj.name = "greenBox";
            GreenBoxObj.tag = "greenbox3";
            GreenBoxObj.layer = 9;

            //instantiating TriggerBox
            ITriggerBox triggerbox = new TriggerBox();

            //calling the addbox function
            triggerbox.AddBox(GreenBoxObj, "greenbox1", "greenbox2", "greenbox3");
            //waiting for 1 second
            yield return null;

            //checking box is added by checking its the object itself and check the list is not empty
            Assert.IsTrue(triggerbox.Boxes.Contains(GreenBoxObj));
            Assert.AreEqual(1, triggerbox.Boxes.Count, 0.1f);
        }
    }
}
