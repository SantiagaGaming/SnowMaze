using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
  
    public UnityAction<int> RecountHPEvent;
    public UnityAction <bool>RestartEvent;

    private Animator _anim;


    private int _hp = 3;

    private void Start()
    {
        _anim = GetComponent<Animator>();

    }
    public void PlayAnimation(bool anim)
    {
        if(anim)
        {
            _anim.SetBool(Helper.PLAYER_WALK_ANIM, true);
        }
        else if(!anim)
        {
            _anim.SetBool(Helper.PLAYER_WALK_ANIM, false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Finish finish))
        {
            finish.CloseFinish();
      
            RestartGame(true);
            
        }
    }

    public void RecountHp(int value)
    {
        _hp += value;
        StartCoroutine(GetDmg());
        RecountHPEvent.Invoke(_hp);
        SoundPlayer.Instance.PlayDamageSound();
        if(_hp<1)
        {
            RestartGame(false);
        }
    }
    private IEnumerator GetDmg()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }
    private void RestartGame(bool win)
    {
        if(!win)
        {
            RestartEvent.Invoke(true);
            SoundPlayer.Instance.PlayLoseSound();
        }
    if(win)
        {
            RestartEvent.Invoke(false);
            SoundPlayer.Instance.PlayWinSound();
        }
        gameObject.SetActive(false);
    }


}
