using SamChauffe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public HealthBarController healthBarController;
    public int maxHealth = 100;
    public int fireDamage = 20;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBarController)
        {
            healthBarController.SetMaxHealth(maxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (healthBarController)
        {
            if (collision.gameObject.TryGetComponent<Fire>(out Fire fire))
            {
                currentHealth -= fireDamage;
                currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
                healthBarController.UpdateHealth(currentHealth);
                if (currentHealth == 0)
                {
                    ScoreManager.score = 0;
                    // Change scene to score board
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
