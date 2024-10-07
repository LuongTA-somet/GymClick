using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public Animator botAnim;
    public GameObject hitPrefab;
    public Transform hitPos;
    private void Start()
    {
        StartCoroutine(SlapPlayer());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            botAnim.SetTrigger("slap");
            
        }
        
    }
    public void ActiveHit()
    {
        hitPrefab.SetActive(true);
        GameManager.Instance.player.GetSlap();
        GameObject hit = Instantiate(hitPrefab, hitPos);
        StartCoroutine(DeActiveHit(hit));
    }
    public IEnumerator SlapPlayer()
    {
        yield return new WaitForSeconds(1);
        botAnim.SetTrigger("slap");
    }
    public IEnumerator DeActiveHit(GameObject gameObject)
    {
       
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    public void GetSlap()
    {
        botAnim.SetTrigger("fall");
    }
    public void Fall()
    {
        gameObject.SetActive(false);
        GameManager.Instance.isBotFinish=true;
    }
}
