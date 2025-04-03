using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NewTestScript : InputTestFixture
{
    
    [Test]
    public void CharacterMovesLeft()
    {
        var animal = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<Test>();
        animal.MovementTesting("A");
        Assert.AreEqual(Vector3.left, -animal.transform.right);
    }

    [Test]
    public void CharacterMovesRight()
    {
        var animal = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<Test>();
        animal.MovementTesting("D");
        Assert.AreEqual(Vector3.right, animal.transform.right);
    }

    [Test]
    public void CharacterMovesJump()
    {
        var animal = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<Test>();
        animal.MovementTesting("Space");
        Assert.AreEqual(Vector3.up, animal.transform.up);
    }
    [Test]
    public void CharacterHealthDecreasesOnDamage()
    {
        var animal = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<Test>();
        animal.health = 100;
        animal.HealthTest(20);
        Assert.AreEqual(80, animal.health);

    }

    [Test]
    public void ScoreTest()
    {
        var animal = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<Test>();
        animal.score = 100;
        animal.ScoreTest(10);
        Assert.AreEqual(90, animal.score);
    }

    [Test]
    public void CharacterJumpsTest()
    {
        var animal = GameObject.CreatePrimitive(PrimitiveType.Capsule).AddComponent<Test>();
        animal.MovementTesting("Space");
        Assert.AreEqual(Vector3.up, animal.transform.up);
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    
    
}
