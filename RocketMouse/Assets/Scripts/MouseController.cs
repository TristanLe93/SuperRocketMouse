using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseController : MonoBehaviour {
	public float jetpackForce = 35.0f;
	public float forwardMovementSpeed = 6.0f;
	private float increaseSpeed = 0.6f;
	public ParticleSystem jetpack;
	private Rigidbody2D mouseRigidBody;

	public AudioClip coinCollectSound;
	public AudioSource jetpackAudio;

	public ScorePanelScript ScorePanel;
	public GenerateObjectsScript ObjGenScript;
	public SpeedGaugeScript SpeedGaugeScript;

	public ParallaxScript parallax;
	public GameObject LightingStrike;

	private bool dead = false;

	// detecting ground variables
	public Transform groundCheckTransform;
	public LayerMask groundCheckLayerMask;
	private bool grounded = false;
	Animator animator;
	

	private int currentLevel = 1;
	public int currentDistanceTier;
	private int[] distanceTiers = {90, 250, 500, 850, 850};//90, 250,500,850,850
	private bool showScorePanel = true;


	public bool IsDead() {
		return dead;
	}

	void Awake() {
		currentDistanceTier = distanceTiers[0];
	}

	void Start() {
		animator = GetComponent<Animator>();
		mouseRigidBody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		bool jetpackActive = Input.GetButton("Fire1");

		if (jetpackActive && !dead) {
			// apply upwards force to the mouse when fire1 is pressed
			mouseRigidBody.AddForce(new Vector2(0, jetpackForce));
		}

		if (!dead) {
			// apply forward movement to the mouse
			Vector2 newVelocity = mouseRigidBody.velocity;
			newVelocity.x = forwardMovementSpeed;
			mouseRigidBody.velocity = newVelocity;

			// update distance score
			DistanceScoreManager.UpdateDistanceScore(transform.position.x);
		}

		// show the score panel when dead and grounded
		if (dead && grounded && showScorePanel) {
			ShowScorePanel();
			showScorePanel = false;
		}

		AdjustJetpack(jetpackActive);
		UpdateGroundedStatus();
		CheckForNextLevel();

		parallax.offset = transform.position.x;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (dead) return;

		if (collider.gameObject.CompareTag("Coins"))
			CollectCoin(collider);
		else
			HitByLaser(collider);
	}
	
	void HitByLaser(Collider2D laserCollider) {
		// activate lightning animation
		LightingStrike.SetActive(true);

		// play laser sound
		if (!jetpackAudio.mute)
			laserCollider.gameObject.GetComponent<AudioSource>().Play();

		dead = true;
		animator.SetBool("dead", dead);
	}

	void AdjustJetpack(bool jetpackActive) {
		jetpack.enableEmission = !grounded && !dead;
		jetpack.emissionRate = jetpackActive ? 300.0f : 75.0f; 
		jetpackAudio.enabled = jetpackActive && !dead;
	}

	void CollectCoin(Collider2D coinCollider) {
		// play coin sound
		if (!jetpackAudio.mute)
			AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);

		ScoreManager.UpdateScore();
		Destroy(coinCollider.gameObject);
	}

	void UpdateGroundedStatus() {
		grounded = Physics2D.OverlapCircle(
			groundCheckTransform.position, 0.1f, groundCheckLayerMask);

		animator.SetBool("grounded", grounded);
	}

	void ShowScorePanel() {
		ScorePanel.ShowScorePanel(
			ScoreManager.GetCoinsScore(), DistanceScoreManager.GetDistanceScore());
	}

	void CheckForNextLevel() {
		if (currentLevel == distanceTiers.Length) return;

		bool tierComplete = DistanceScoreManager.GetDistanceScore() > currentDistanceTier;

		if (tierComplete) {
			ObjGenScript.LoadNextLevelObjects(currentLevel);

			currentDistanceTier = distanceTiers[currentLevel];

			forwardMovementSpeed += increaseSpeed;
			SpeedGaugeScript.UpdateNextTier();
			currentLevel++;
		}
	}
}
