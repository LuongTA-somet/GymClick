using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BotFinish : MonoBehaviour
{
  public Animator anim;
    public Transform FightPos;
    public GameObject hitPrefab;
    public Transform hitPos;
    private void Update()
    {
        if (GameManager.Instance.isBotFinish)
        {
            Move();
        }
        
    }
    public void ActiveHit()
    {
        hitPrefab.SetActive(true);
        GameManager.Instance.player.GetSlap();
        GameObject hit = Instantiate(hitPrefab, hitPos);
       GameManager.Instance.player.SlapEnd();
    }
    public void Move()
    {
        anim.SetTrigger("run");
      gameObject.transform.DOMove(FightPos.position,2f);
        GameManager.Instance.isBotFinish = false;
       StartCoroutine(Slap());
    }
    public IEnumerator Slap()
    {
        yield return new WaitForSeconds(3f);

        anim.SetTrigger("slap");
    }
}
