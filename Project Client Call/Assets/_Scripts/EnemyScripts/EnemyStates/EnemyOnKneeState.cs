using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class EnemyOnKneeState : AbstractState<EnemyFsmController>
{
    bool isActivated;
   
    public void Start()
    {
        isActivated = false;
    }
    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        Debug.Log("OnKnee");
        GetComponent<EnemyAnimations>().TrigerOnKneeAnimation();
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<BoxCollider2D>().offset -= new Vector2(-4, 0);
    }

    void Update()
    {

    }

    public void FinishHim()
    {
        if (isActivated) return;
        Debug.Log("FINISH HIM");
        GetComponent<EnemyAnimations>().SetDeathState(true);
        GetComponent<EnemyFsmController>().fsm.ChangeState<EnemyDeadState>();
        
        isActivated = true;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword Collider")&&!isActivated)
        {

        }
    }
}
