using UnityEngine;

public class Test : MonoBehaviour
{
    public int health;
    public int score;

    public void MovementTesting(string input)
    {
        Vector3 moveDirection = Vector3.zero;

        switch (input)
        {
           
            case "A":
                moveDirection = Vector3.left;
                break;
            case "D":
                moveDirection = Vector3.right;
                break;
            case "Space":
                moveDirection = Vector3.up;
                break;
        }

        //transform.position += moveDirection * 10f * Time.deltaTime;
    }

    public void HealthTest(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
    }

    public void ScoreTest(int minusScore)
    {
        score -= minusScore;
    }

   
}
