using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//player controle´Â ÇÃ·¹ÀÌ¾î Ä³¸¯ÅÍ·Î¼­  player°ÔÀÓ ¿ÀºêÁ§Æ® Á¦¾îÇÔ
public class Player_controller : MonoBehaviour
{
    //ÇÃ·¹ÀÌ¾î »ç¸Á½Ã Àç»ıÇÒ ¿Àµğ¿À Å¬¸³
    public AudioClip deathClip;
    public float jumpForse = 700f;

    //´©Àû Á¡ÇÁ È¸¼ö
    private int jumpCount = 0;

    //ÇÃ·¹ÀÌ¾î°¡ ¹Ù´Ú¿¡ ´ê¾Ò´ÂÁö È®ÀÎ
    private bool isGrounded = false;
    //ÇÁ ¤©·¹ÀÌ¾î°¡ »ç¸ÁÇß´ÂÁö »ç¸Á»óÅÂ
    private bool isDead = false;
    //»ç¿ëÇÒ ¸®Áöµå¹Ùµğ ÄÄÆ÷³ÍÆ®
    private Rigidbody2D playerRigidbody;
    //»ç¿ëÇÒ ¿Àµğ¿À ¼Ò½º ÄÄÆ÷³ÍÆ®
    private AudioSource playerAudio;

    //»ç¿ëÇÒ ¾Ö´Ï¸ŞÀÌ;ÅÍ ÄÄÆ÷³ÍÆ® 
    private Animator animator;
        
        // Start is called before the first frame update
    void Start()
    {
        //Àü¿ªº¯¼öÀÇ °ª ÃÊ±âÈ­ ÁøÇà
        //°ÔÀÓ ¿ÀºêÁ§Æ®·Î ºÎÅÍ »ç¿ëÇÒ ÄÄÆ÷³ÍÆ®µéÀ» °¡Á®¿Í ÇÒ´ç
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //»ç¿ëÀÚÀÇ ÀÔ·ÂÀ» °¨ÁöÇÏ°í Á¡ÇÁÇÏ´Â Ã³¸®
        //1.ÇöÀç »óÈ²¿¡ ¾Ë¸ÂÀº ¾Ö´Ï¸ŞÀÌ¼Ç Àç»ı
        //2.¸¶¿ì½º¿¡ ¿ŞÂÊ Å¬¸¯À» °¨ÁöÇÏ°í Á¡ÇÁ¸¦ ÇÒ ¼ö ÀÖ°Ô ±¸Çü
        //3.¸¶¿ì½º ¿ŞÂÊ ¹öÆ°À» ¿À·¡ ´©¸£¸é ³ôÀÌ Á¡ÇÁÇÏ°Ô ²û Ã³¸®
        //4. ÃÖ´ë Á¡ÇÁÈ½¼ö¿¡ µµ´ŞÇÏ¸é Á¡ÇÁ¸¦ ¸øÇÏ°Ô ¸·±â

        //»ç¸Á½Ã ´õÀÌ»ó Ã³¸®¸¦ ÁøÇàÇÏÁö ¾Ê°í Á¾·áÇÏ´Â Ã³¸®¸¦ ±¸Çö
        if (isDead) return;
        //¸¶¿ì½º ¿ŞÂÊ ¹öÆ°À» ´­·¶À¸¸é& ÃÖ´ë Á¡ÇÁÈ½¼ö (2)¿¡ µµ´ŞÇÏÁö ¾Ê¾Ò´Ù¸é 
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //Á¡ÇÁ È½¼ö¸¦ Áõ°¡ 
            jumpCount++;
            // Á¡ÇÁÁ÷Àü¿¡ ¼Óµµ¸¦ ¼ø°£ÀûÀ¸·Î Á¦·Î(0,0)·Î º¯°æ
            // Á¡ÇÁ Á÷Àü±îÁöÀÇ Èû ¶Ç´Â ¼Óµµ°¡ »ó¼âµÇ°Å³ª ÇÕÃÄÁ®¼­ 
            //Á¡ÇÁ ³ôÀÌ°¡ ºñÀÏ°üÀûÀ¸·Î µÇ´Â Çö»óÀ» ¸·±âÀ§ÇØ
            playerRigidbody.velocity = Vector2.zero;
            //¸®Áöµå ¹Ùµğ¿¡ À§ÂÊÀ¸·Î ÈûÁÖ±â
            playerRigidbody.AddForce(new Vector2(0, jumpForse));

            //¿Àµğ¿À¤Ã ¼Ò½º Àç»ı
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0) {
            //¸¶¿ì½º ¿ŞÂÊ ¹öÆ°¿¡¼­ ¼ÕÀ» ¶§´Â ¼ø°£°ú ¼ÓµµÀÇ y°ªÀÌ ¾ç¼ö¶ó¸é(À§·Î »ó½Â Áß)
            //ÇöÀç¼Óµµ¸¦ Àı¹İÀ¸·Î º¯°æ
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
            
        }

        //¾Ö´Ï¸ŞÀÌÅÍÀÇ grounded ÆÄ¶ó¹ÌÅÍ¸¦ isGrounded °ªÀ¸·Î °»½Å
        animator.SetBool("Grounded", isGrounded);

        
    }

    void Die() {
        //»ç¸ÁÃ³¸®ÇÏ´Â ½ºÅ©¸³Æ®
        //¾Ö´Ï¸ŞÀÌÅÍÀÇ Die Æ®¸®°Å ÆÄ¶ó¹ÌÅÍ¸¦ ¼Â
        animator.SetTrigger("Die");


        //audio ¼Ò½º¿¡ ÇÒ´çµÈ ¿Àµğ¿À Å¬¸³À» deathclipÀ¸·Î º¯°æ
        playerAudio.clip = deathClip;
        //
        //»ç¸Á È¿°úÀ½ Àç»ı
        playerAudio.Play();

        //¼Óµµ¸¦ Á¦·Î(0,0)
        playerRigidbody.velocity = Vector2.zero;
        //³ª »ç¸ÁÇß¾î »ç¸Á»óÅÂ¸¦ true·Î
        isDead = true;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ÇÃ·¹ÀÌ¾î°¡ ¹Ù´Ú¿¡ ´êÀÚ ¸¶ÀÚ °¨ÁöÇÏ´Â Ã³¸®
        //¾î¶² Äİ¶óÀÌ´õ¶û ´ê¾ÒÀ¸¸é Ãæµ¹ Ç¥¸éÀÌ À§ÂÊÀ» º¸°í ÀÖ´ÂÁö
        if (collision.contacts[0].normal.y > 0.7f) {
            //contacts´Â Ãæµ¹ ÁöÁ¡µéÀÇ Á¤º¸¸¦ ´ã´Â 
            // contactPointÅ¸ÀÔÀÇ µ¥ÀÌÅÍ¸¦ contacts¶ó´Â ¹è¿­ º¯¼ö·Î Àç°ø¹ŞÀ½
            //normar ¤²Ãæµ¹ ÁöÁ¡¿¡¼­ Ãæµ¹ Ç¥¸éÀÇ ¹æÇâ (³ë¸» º¤ÅÍ)
            //À» ¾Ë·ÁÁÖ´Â º¯¼öÀÔ´Ï´Ù.


            //isgrounded¸¦ true·Î º¯°æÇÏ°í  ´©Àû Á¡ÇÁ È½¼ö¸¦ 
            //0À¸·Î ¸®¼Â
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //¹Ù´Ú¿¡¼­ ¹ş¾î³ªÀÚ¸¶ÀÚ Ã³¸®

        //¾î¶² Äİ¶óÀÌ´õ¿¡¼­ ¶§¾îÁø °æ¿ì is grounded·Î false º¯°æ
        isGrounded = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Æ®¸®°Å Äİ¶óÀÌ´õ¸¦ °¡Áø Àå¾Ö¹°°úÀÇ Ãæµ¹ °¨Áö
        if (collision.tag == "Dead" && !isDead) {
            Die();
        }
        //Ãæµ¹ÇÑ »ó´ë¹æÀÇ ÅÂ±×°¡ deadÀÎ°¡¿ä?
       



    }
    //Ãæµ¹ À¯´ÏÆ¼ Ãæµ¹ ´Ù¾çÈ÷ »ç¿ë
    // ­w¤·µ¹ Å©°Ô µÎ°¡Áö·Î ³ª´®
    //1.Oncollider¤¡°è¿µ¤© enter stay exit
    //2.ontirigger°è¿­  enter stay exit

    // OnCollision °è¿­Àº µÎ Äİ¶óÀÌ´õ ³¢¸®ÀÇ Ãæµ¹¿¡¼­ 
    //´ÜÇÏ³ªµµ istrigger°¡ Ã¼Å©°¡ µÇ¤Ó¾î ÀÖÁö ¾ÊÀº °æ¿ì 
    //ontrigger r°è¿­Àº ´ÜÇÏ³ª¶óµµ istrigger°¡ Ã¼Å©µÇ¾î ÀÖÀ» ¶§ »ç¿ë
}
