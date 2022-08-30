using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ValueTests
{
    [Test]
    public void CheckAmountOfLives()
    {
        Assert.AreEqual(3, HasLives.totalAmountOfLivesS);
    }

    [Test]
    public void CheckJumpForce()
    {
        Assert.AreEqual(new Vector3(0, 250, 0), Movement.jumpForce);
    }
}
