using UnityEngine;

public class PowerupController :MonoBehaviour, IEndGameObserver
{
    #region Field Declarations

    public GameObject explosion;

    [SerializeField]
    private PowerType powerType;

    #endregion

    #region Movement

    void Update()
    {
       Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 3, Space.World);

        if (ScreenBounds.OutOfBounds(transform.position))
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region Collisons

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(powerType == PowerType.Shield)
        {
            PlayerController playerShip = collision.gameObject.GetComponent<PlayerController>();
            playerShip?.EnableShield();
        }

        removeAndDestroy();
    }

    private void removeAndDestroy()
    {
        GameSceneController gameSceneController = FindObjectOfType<GameSceneController>();
        gameSceneController.RemoveObserver(this);
        Destroy(gameObject);
    }

    public void Notify()
    {
        Destroy(this);
    }

    #endregion
}

public enum PowerType
{
    Shield,
    X2
};