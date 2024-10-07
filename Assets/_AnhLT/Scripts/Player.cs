using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
    public GameObject hitPrefab;
    public Transform hitPos;
    public Transform skyPos;
    public Transform landPos;
    public List<GameObject> dumbells;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.SetTrigger("slap");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerAnim.SetTrigger("slap");
           
        }
      
    }
    public void GetSlap()
    {
        playerAnim.SetTrigger("getslap");
    }
    public void ActiveHit()
    {      
     hitPrefab.SetActive(true);
        GameManager.Instance.bot.GetSlap();
       GameObject hit = Instantiate(hitPrefab,hitPos);
        StartCoroutine(DeActiveHit(hit));
    }
    public IEnumerator DeActiveHit(GameObject gameObject)
    {
        
        yield return new WaitForSeconds(1f);
     
      Destroy(gameObject);
    }
    public void SlapEnd()
    {
        StartCoroutine(KnockOut());
    }
    public IEnumerator KnockOut()
    {
        playerAnim.SetTrigger("slapend");
        gameObject.transform.DOMove(skyPos.position,0.5f);
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.DOMove(landPos.position,0.65f);
    }
    public void LiftBent()
    {
        foreach (var item in dumbells)
        {
            item.SetActive(true);
            playerAnim.SetTrigger("lift");
        }
    }
    public void FallDown()
    {

    }
}
