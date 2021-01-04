using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject blockSparklesVFX;
    
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;

    // state variables
    [SerializeField] int timesHit; //TODO only serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();  

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            
            level.CountBlocks();  //Check how many blocks are the in this level
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    //If a block is hit then it augments the time that block has been hit, and if it reaches its limits then it gets destroyed
    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else                                       
        {
            ShowNextHitSprite();
        }
    }

    //Changes the animation of the block after it gets hit
    private void ShowNextHitSprite()  
    {
        int spriteIndex = timesHit - 1 ;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite si missing from array" + gameObject.name);
            
        }
    }

    //Destroys the block and triggers the effects
    private void DestroyBlock()
    {
        Destroy(gameObject);
        PlayAudioSFX();
        level.BlockDestroyed();
        TriggerSparklesVF();
    }

    private void PlayAudioSFX()
    {
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore();
    }

    private void TriggerSparklesVF()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
