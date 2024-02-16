using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character

{
    public HealthBar healthBarPrefab; // Referencia a Prefab
    HealthBar healthBar; // Barra de vida instanciada

    // Este método se ejecuta una vez
    private void Start()
    {
        hitPoints.value = startingHitPoints; // Puntos Iniciales
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }

    /*
    * Método invocado cuando otro collider colisiona.
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto colisionado tiene como etiqueta CanBePickedUp
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Comsumible>().item;
            if (hitObject != null)
            {
                bool shouldDisappear = false;
                print("Nombre: " + hitObject.objectName);
                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        shouldDisappear = true;
                        break;
                    case Item.ItemType.HEALTH:
                        Debug.Log("Aumento barra " + hitObject.quantity);
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }
                if (shouldDisappear)
                {
                    // Ocultamos el objeto de la escena
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    public void dano(float restar){
        hitPoints.value = hitPoints.value - restar;
        if(hitPoints.value <=0){
             hitPoints.value = hitPoints.value;
            Destroy(gameObject);
        }
    }

    public bool AdjustHitPoints(float amount)
    {
        if (hitPoints.value < maxHitPoints)
        {
            print("Ajustando Puntos: " + amount + ". HitPoints: " + hitPoints.value);
            hitPoints.value = hitPoints.value + amount/10;
            print("Ajustando Puntos: " + amount + ". Nuevo Valor: " + hitPoints.value);
            return true;
        }
        return false;
    }
}

