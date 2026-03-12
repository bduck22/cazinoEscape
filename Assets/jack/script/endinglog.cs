using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class endinglog : MonoBehaviour
{
    TMP_Text text;
    data_manager data;
    void Start()
    {
        data = GameObject.FindWithTag("save").GetComponent<data_manager>();
        text = GetComponent<TMP_Text>();
        text.text = "획득한 돈 : " + data.elog.getmoney.ToString("#,##0")+
            "\r\n잃은 돈 : " + data.elog.lostmoney.ToString("#,##0") +
            "\r\n총 늘어난 이자 : " + data.elog.adddept.ToString("#,##0") +
            "\r\n총 대출한 돈 : " + data.elog.dept.ToString("#,##0") +
            "\r\n총 상환한 빚 : " + data.elog.paydept.ToString("#,##0") +
            "\r\n카지노에서 보낸 주 : " + data.elog.week.ToString("#,##0") +
            "\r\n카지노에서 보낸 일 : " + data.elog.day.ToString("#,##0") +
            "\r\n핀볼 1.5배 걸린 횟수 : " + data.elog.ball1_5times.ToString("#,##0") +
            "\r\n핀볼 1.2배 걸린 횟수 : " + data.elog.ball1_2times.ToString("#,##0") +
            "\r\n핀볼 1배 걸린 횟수 : " + data.elog.ball1times.ToString("#,##0") +
            "\r\n핀볼 0배 걸린 횟수 : " + data.elog.ball0times.ToString("#,##0") +
            "\r\n핀볼 포기한 횟수 : " + data.elog.ballquit.ToString("#,##0") +
            "\r\n동전던지기 최대 횟수 : " + data.elog.coinmax.ToString("#,##0") +
            "\r\n동전던지기 성공한 횟수 : " + data.elog.coinwin.ToString("#,##0") +
            "\r\n동전던지기 실패한 횟수 : " + data.elog.ball1_5times.ToString("#,##0") +
            "\r\n블랙잭 카드를 뒤집은 횟수 : " + data.elog.coinlose.ToString("#,##0") +
            "\r\n블랙잭 승리한 횟수 : " + data.elog.cardwin.ToString("#,##0") +
            "\r\n블랙잭 포기한 횟수 : " + data.elog.cardquit.ToString("#,##0") +
            "\r\n블랙잭 패배한 횟수 : " + data.elog.cardlose.ToString("#,##0") +
            "\r\n블랙잭 무승부한 횟수 : " + data.elog.carddraw.ToString("#,##0") +
            "\r\n블랙잭을 뽑은 횟수 : " + data.elog.blackjack.ToString("#,##0") +
            "\r\n폐지를 주운 횟수 : " + data.elog.paperget.ToString("#,##0") +
            "\r\n본 광고 수 : " + data.elog.watchadd.ToString("#,##0") +
            "\r\n사용한 행동력 : " + data.elog.usestamina.ToString("#,##0") +
            "\r\n회복한 행동력 : " + data.elog.healstamina.ToString("#,##0") +
            "\r\n복권 구매 횟수 : " + data.elog.buygacha.ToString("#,##0") +
            "\r\n복권 당첨 횟수 : " + data.elog.getgacha.ToString("#,##0") +
            "\r\n에너지 드링크 마신 횟수 : " + data.elog.drink.ToString("#,##0") +
            "\r\n제곱을 산 횟수 : " + data.elog.buydouble.ToString("#,##0") +
            "\r\n제곱을 한 횟수 : " + data.elog.getdouble.ToString("#,##0") +
            "\r\n보험을 산 횟수 : " + data.elog.buyinsurance.ToString("#,##0") +
            "\r\n보험을 적용받은 횟수 : " + data.elog.getinsurance.ToString("#,##0") +
            "\r\n숙박권 산 횟수 : " + data.elog.buyhotel.ToString("#,##0") +
            "\r\n은행을 간 횟수 : " + data.elog.gobank.ToString("#,##0") +
            "\r\n설명서를 연 횟수 : " + data.elog.manualopen.ToString("#,##0") +
            "\r\n설명서를 넘긴 횟수 : " + data.elog.manualmove.ToString("#,##0") +
            "\r\n설명서를 끈 횟수 : "+ data.elog.manualclose.ToString("#,##0")+
            "\r\n결과창을 끈 횟수 : " + data.elog.resultclose.ToString("#,##0");
    }
}
