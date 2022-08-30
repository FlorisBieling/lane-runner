using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class RunTime
{
    private int totalLevelTime = 50, allKeysPressedTime = 10, timeUntilFirstItem = 3;

    [SetUp]
    public void SetUp()
  => SceneManager.LoadScene(0); 


    [UnityTest]
    public IEnumerator FinishLevelWithAllLives()
    {
        yield return new WaitForSeconds(totalLevelTime);
        Assert.AreEqual(185, Movement.totalDistanceS); 
        Assert.AreEqual(HasLives.totalAmountOfLivesS, HasLives.amountOfLivesS);
    }


    [UnityTest]
    public IEnumerator FinishLevelWithAllPickups()
    {
        yield return new WaitForSeconds(totalLevelTime);
        Assert.AreEqual(185, Movement.totalDistanceS);
        Assert.AreEqual(10, Scoring.totalPickupsS);
    }

    [UnityTest]
    public IEnumerator FinishLevelWithEightOrMoreJumps()
    {
        yield return new WaitForSeconds(totalLevelTime);
        Assert.AreEqual(185, Movement.totalDistanceS);
        Assert.AreEqual(8, Movement.totalAmountOfJumpsS);
    }

}
