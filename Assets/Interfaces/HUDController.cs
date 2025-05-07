using UnityEngine;
using UnityEngine.UIElements;
[System.Serializable]
public class HUDController : MonoBehaviour
{
    public int maxAmmo = 0;
    public int currentAmmo = 0;
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public PlayerData playerData;

    private Label ammoLabel;
    private ProgressBar healthBar;
    private Label crosshair;

    void OnEnable()
    {
        // var root = GetComponent<UIDocument>().rootVisualElement;
        // ammoLabel = root.Q<Label>("AmmoLabel");
        // ammoLabel.text = "111";
        // healthBar = root.Q<ProgressBar>("HealthBar");

        // crosshair = root.Q<Label>("Crosshair");
        // crosshair.style.position = Position.Absolute;
        // crosshair.style.top = new Length(50, LengthUnit.Percent);
        // crosshair.style.left = new Length(50, LengthUnit.Percent);
        // crosshair.style.translate = new StyleTranslate(new Translate(new Length(-50, LengthUnit.Percent), new Length(-50, LengthUnit.Percent)));

        // playerData = FindFirstObjectByType<PlayerData>();

        // maxAmmo = playerData.maxAmmo;
        // currentAmmo = playerData.currentAmmo;
        // maxHealth = playerData.MaxHealth;
        // currentHealth = playerData.CurrentHealth;
        UpdateUI();
    }

    public void UpdateUI()
    {
        ammoLabel.text = $"Ammo: {currentAmmo}/{maxAmmo}";
        healthBar.value = (currentHealth / maxHealth) * 100f;
    }

    // 用于测试
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentAmmo = Mathf.Max(currentAmmo - 1, 0);
            currentHealth -= 5f;
            UpdateUI();
        }
    }
}
