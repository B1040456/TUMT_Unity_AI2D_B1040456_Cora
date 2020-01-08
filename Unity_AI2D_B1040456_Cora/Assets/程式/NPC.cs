using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    public enum state
    {
        start, notready, complete
    }
    public state _state;

    public string missionStart = "";
    public string missionNotComplete = "";
    public string missionComplete = "";

    public bool complete;
    public float countCarrot;
    public int countFinish;

    public GameObject objCanvas;
    public Text textSay;

    public float speed;
    public static NPC carrot;

    public GameObject finsh;

    private void Start()
    {
        carrot = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
            Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
            SayClose();
    }

    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countCarrot >= countFinish)
        {
            _state = state.complete;

            Invoke("finish", 3f);
        }

        switch (_state)
        {
            case state.start:
                StartCoroutine(ShowDialog(missionStart));
                _state = state.notready;
                break;
            case state.notready:
                StartCoroutine(ShowDialog(missionNotComplete));
                break;
            case state.complete:
                StartCoroutine(ShowDialog(missionComplete));
                break;
        }
    }
    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";

        for (int i = 0; i < say.Length; i++)
        {
            textSay.text += say[i].ToString();
            yield return new WaitForSeconds(speed);
        }
    }

    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    public void PlayerGet()
    {
        countCarrot++;
    }

    void finish()
    {
        finsh.SetActive(true);

        Destroy(Player.fin);
    }
}
