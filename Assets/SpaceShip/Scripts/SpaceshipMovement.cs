using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class SpaceshipMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float returnSpeed = 2f;
    public float speed = 5f;

    [Header("Horizontal Position Limits")]
    public float leftXPosition = -7f;
    public float rightXPosition = -5f;

    [Header("Vertical Position Limits")]
    public float topYPosition = 2.5f;
    public float bottomYPosition = -4f;

    [Header("Particle System Settings")]
    public ParticleSystem spaceshipParticles;
    public float defaultSpeedModifier = 0.5f;
    public float increasedSpeedModifier = 1.5f;
    public float decreasedSpeedModifier = 0.25f;
    public float adjustmentSpeed = 1f;

    [Header("Audio Settings")]
    public AudioSource spaceShipEngineSound;
    public float defaultEngineSound = 1f;
    public float slowEngineSound = 0.5f;
    public float fastEngineSound = 2f;

    [Header("UI Settings")]
    public TextMeshProUGUI engineSpeedText; 
    public Image fuelBar;                
    public TextMeshProUGUI fuelText;      

    [Header("Fuel Settings")]
    public float maxFuel = 100f;         
    public float normalFuelDrainRate = 0.75f; 
    public float slowFuelDrainRate = 0.25f;   
    public float fastFuelDrainRate = 1.25f;     
    public float currentDrainRate;         
    public AudioSource fuelPickupSound;    

    private Rigidbody2D rb;
    private Vector2 defaultPosition;
    private Vector2 targetPosition;
    private float currentY;
    private float currentX;
    private float currentSpeedModifier;
    private float currentPitch;
    private float currentFuel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultPosition = rb.position;
        currentX = defaultPosition.x;
        currentY = defaultPosition.y;
        currentSpeedModifier = defaultSpeedModifier;
        currentPitch = defaultEngineSound;
        currentFuel = maxFuel;
        currentDrainRate = normalFuelDrainRate; 

        if (spaceshipParticles == null)
        {
            Debug.LogWarning("No particle system assigned!");
        }

        if (spaceShipEngineSound == null)
        {
            Debug.LogWarning("No audio source assigned!");
        }
        else
        {
            spaceShipEngineSound.pitch = defaultEngineSound;
        }

        if (engineSpeedText == null)
        {
            Debug.LogWarning("No TextMeshProUGUI component assigned!");
        }

        UpdateFuelUI(); 
    }

    void Update()
    {
        HandleMovementInput();
        MoveTowardsTarget();
        AdjustParticleSpeedModifier();
        AdjustEngineSound();
        UpdateEngineSpeedText();
        UpdateFuel(); 
        UpdateFuelUI(); 
    }

    private void HandleMovementInput()
    {
        if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K))
        {
            //currentY = Mathf.Lerp(currentY, defaultPosition.y, returnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.I))
        {
            currentY = Mathf.Lerp(currentY, topYPosition, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.K))
        {
            currentY = Mathf.Lerp(currentY, bottomYPosition, speed * Time.deltaTime);
        }

        if (!Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
        {
            currentX = Mathf.Lerp(currentX, defaultPosition.x, returnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.L))
        {
            currentX = Mathf.Lerp(currentX, rightXPosition, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.J))
        {
            currentX = Mathf.Lerp(currentX, leftXPosition, speed * Time.deltaTime);
        }

        currentX = Mathf.Clamp(currentX, leftXPosition, rightXPosition);
        currentY = Mathf.Clamp(currentY, bottomYPosition, topYPosition);
    }

    private void MoveTowardsTarget()
    {
        targetPosition = new Vector2(currentX, currentY);
        rb.position = Vector2.Lerp(rb.position, targetPosition, Time.deltaTime * speed);
    }

    private void AdjustParticleSpeedModifier()
    {
        if (spaceshipParticles == null) return;

        var velocityModule = spaceshipParticles.velocityOverLifetime;

        if (Input.GetKey(KeyCode.L))
        {
            currentSpeedModifier = Mathf.Lerp(currentSpeedModifier, increasedSpeedModifier, adjustmentSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
        {
            currentSpeedModifier = Mathf.Lerp(currentSpeedModifier, decreasedSpeedModifier, adjustmentSpeed * Time.deltaTime);
        }
        else if (!Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.J))
        {
            currentSpeedModifier = Mathf.Lerp(currentSpeedModifier, defaultSpeedModifier, adjustmentSpeed * Time.deltaTime);
        }

        velocityModule.speedModifier = new ParticleSystem.MinMaxCurve(currentSpeedModifier);
    }

    private void AdjustEngineSound()
    {
        if (spaceShipEngineSound == null) return;

        if (Input.GetKey(KeyCode.L))
        {
            currentPitch = Mathf.Lerp(currentPitch, fastEngineSound, adjustmentSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
        {
            currentPitch = Mathf.Lerp(currentPitch, slowEngineSound, adjustmentSpeed * Time.deltaTime);
        }
        else if (!Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.J))
        {
            currentPitch = Mathf.Lerp(currentPitch, defaultEngineSound, adjustmentSpeed * Time.deltaTime);
        }

        spaceShipEngineSound.pitch = currentPitch;
    }

    private void UpdateEngineSpeedText()
    {
        if (engineSpeedText == null) return;

        float minPitch = 0.75f;
        float maxPitch = 1.25f;
        float minSpeed = 25f;
        float maxSpeed = 120f;

        int speed = Mathf.RoundToInt(Mathf.Lerp(minSpeed, maxSpeed, (currentPitch - minPitch) / (maxPitch - minPitch)));
        engineSpeedText.text = $"Engine: {speed}";
    }

    private void UpdateFuel()
    {
        
        if (Input.GetKey(KeyCode.J))
        {
            currentDrainRate = Mathf.Lerp(currentDrainRate, slowFuelDrainRate, adjustmentSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            currentDrainRate = Mathf.Lerp(currentDrainRate, fastFuelDrainRate, adjustmentSpeed * Time.deltaTime);
        }
        else
        {
            currentDrainRate = Mathf.Lerp(currentDrainRate, normalFuelDrainRate, adjustmentSpeed * Time.deltaTime);
        }
   
        currentFuel -= currentDrainRate * Time.deltaTime;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);

    }

    private void UpdateFuelUI()
    {
        if (fuelBar != null)
        {
            fuelBar.fillAmount = currentFuel / maxFuel;
        }

        if (fuelText != null)
        {
            fuelText.text = $"Fuel: {Mathf.RoundToInt(currentFuel)}";
        }
    }
	
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.StartsWith("FuelTank_"))
        {
            string tankTag = collision.gameObject.tag;
		
     
            string numberPart = tankTag.Substring(tankTag.LastIndexOf('_') + 1);


            if (int.TryParse(numberPart, out int fuelAmount))
            {
              
                currentFuel += fuelAmount;

             
                currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);

              
                UpdateFuelUI();

           
                if (fuelPickupSound != null)
                {
                    fuelPickupSound.Play(0);
                }

                // Optionally destroy the fuel tank object after collecting fuel
                //Destroy(collision.gameObject);
            }
            else
            {
                Debug.LogWarning("Failed to parse fuel amount from the fuel tank tag.");
            }
        }
    }
}
