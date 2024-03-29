﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public static TalkManager instance=null;

    Dictionary<int, string[]> talkData;
    //Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(instance);

        talkData = new Dictionary<int, string[]>();
      //  portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }
    void GenerateData()
    {
        //id=1000 : 플레이어
        talkData.Add(1000, new string[] { "'어디 보자... 그러니까, 아무도 없을 때 5층 복도 거울 앞에 서면 괴물이 비친다..':0",
            "'...사람이 있네. 뭐, 갈 때까지 잠깐만 기다리자.':0", "'그러고 보니 뭔가 얼굴이 익숙한데. 같은 반 애였나...? 여기서 혼자 뭐 하는 거람.':0", //npc가 올라감
            "\"....?!\":0", "\"자, 잠깐만. 너 지금 무슨... 그만둬!!\":0",/*떨어짐*/"\"이게 뭔..... 아냐. 5층이니까... 살아있을지도 몰라. 가서.. 구급차를...\":0", //1층으로 이동
            "\"뭐지. 이거...? 떨어졌나...?\":0", "부서진 명찰을 주웠다.:",
            "\".....\":0",//아래부터 나레이션
            "피웅덩이 위로 처참한 모습의 사람이 떨어져 있다.:" , 
           //나레이션 끝
            "\"아, 아냐. 살아있을지도 몰라. 혹시.....\":0",/*에너미 움직임*/ "\".....!\":0", //다시 아래부터 나레이션
            "인간이었다면 분명히 죽었다.:","시체가 움직이고 있다.:","등골을 타고 오한과 함께 깨달음이 엄습한다. 진득한 피 냄새가 가까워진다.:","도망쳐야 한다.:", //오프닝 이벤트 종료.15
           //양호실 진입
            "...! 문 안쪽에 잠금장치가 있다.:", "문을 잠궜다.:", "\"살았다.....\":0", "문을 두드리는 듯한 소리가 몇 번 들리다 멎었다. 한동안은 괜찮을 것 같다.:",//repeat5, talkindex4
          //양호실 이벤트
            "\"으, 으아아아악!\":0",//talk 20
            //미술실~복도 이벤트
            "'그런데 쟤 이름을 모르는데... 뭐였지? 사람 이름 좀 외워둘 걸......':0","눈 앞에 신발장이 보인다.:","'아, 그래. 신발장에는 이름을 쓴 종이가 끼워져 있으니까... 같은 반이니까 지금은 기억 안 나도, 직접 이름을 보면 알 수 있을지도.':0",//talk23
           //엔딩 괴물사라짐
            "모든 물품을 모았다.:", "종이에서 봤던 설명을 따라 차근차근 진행한다.\n조각을 모으고, 풀로 붙이고... 물에 넣고, 피를 떨어뜨리고.:",
            "'남은 건 이제 쥐고 있는 거 뿐인가... 고쳐지면, 저것도 원래대로 돌아가는 거지? 어떻게 되는 걸까.':0","'...시체로 돌아가는 건가? 뭔가 미안하네. 하지만 계속 이렇게 쫒겨다니긴 싫어.':0",
/*+1*/            "''제발 돼라.....'':0", "축축하게 젖은 이름표를 손으로 꾹 쥐었다.:","...하지만 아무 일도 일어나지 않았다.:",
            "\".....\":0","혹시 충분히 간절하지 못했던 걸까 생각하며, 그대로 손에 힘을 줬다.\n하지만 아무것도 바뀌지 않았다.:",
          //괴물등장
 /*+1*/            "'피가 아니었던 건가...? 아니면 이름을 틀렸나? 뭐가 문제지.':0","'왜, 왜 안 되는 거야.':0", "'...바보 같아. 애초에 저런 걸 믿는 게 아니었어. 아니, 괴담 같은 걸 확인하러 오는 게 아니었어.....':0",
            "'정문으로 가자. 유리니까, 아무튼 두드리면 깨지지 않을까. 가서 안 되면, 안 되면.....':0",
            //창고문->중앙복도->핏자국앞
            "저 괴물과 함께 완전히 갇혀버렸는데, 그것까지 안 되면 대체 뭘 할 수 있지?\n...그런 생각을 하며 무작정 정문을 향해 뛰어가다 발이 미끄러진다.:",
 /*+1*/             "...핏자국이 옷에 튀어 끈적거린다. 일어나야 하는데, 다리에 힘이 들어가지 않는다. 발이 무겁다.:","지금까지 계속 뛰어다니고 있었다는 사실이 새삼스럽게 생각난다.:", 
            //괴물다가옴
            "\"오, 오지마...!!\":0","움직일 수가 없다. 죽고 싶지 않다. 죽고 싶지 않은데... 여기서 더 도망쳐 봤자 뭘 할 수 있을까. 두려움에 떨면서 도망쳐 다니다 결국 언젠가 붙잡혀서 살해당하기?:",
        //괴물다가옴
  /*+3*/       "공포에 몸이 덜덜 떨린다. 죽음은 많이 아플까. 죽고 난 뒤에는 어떻게 되는 걸까. 저렇게?:","아니, 애초에 저 애는 어쩌다가 저런 모습이 되어버린 걸까.:","더 이상 도망칠 방법도 없다고 생각하자 묘하게 마음이 가라앉는다.:",
            "왜 그렇게 아무 망설임도 없이 뛰어내린 걸까. 갑자기 이해할 수 없어졌다. 죽는다는 건 이렇게나 두려운 일인데. 지금이라도 살아날 방법이 있다면 뭐든 할 텐데.:",
        "아직까지 손에 쥐고 있었던 이름표가 아프게 파고든다.:","아니, 어쩌면 저 애도 엄청나게 고민했을지도 모른다. 5층 아래를 바라보면서 지금의 나처럼 두려움에 떨고 있었을지도 모른다.:",
        //괴물다가옴
 /*+1*/             "그리고 자신은 가만히 앉아서 죽음을 기다리고 있는 것까지 전부.:",
        "도저히 견딜 수가 없어져서, 손에 꾹 쥐고 있던 망가진 이름표를 힘껏 던져버렸다.:","\"가져가! 가져가라고...! 네 이름, 이제 나도 기억하니까..... 네가 잊지 말고 가져가라고!!\":0",
        "툭, 하고 이름표가 떨어지는 소리와 동시에 눈을 질끈 감았다.:", //컷인삽입
        "\"...아.....\":3"});



        //1층 중앙복도
        talkData.Add(100, new string[] { ":", "신발장이다. 지금은 볼일이 없다.:" });//신발장
        talkData.Add(105, new string[] { ":", "잠겨 있다.:", "열려! 열리라고! 젠장.....:0" });//정문
        talkData.Add(110, new string[] { ":", "아무도 보지 않는 학교 소식과 흔해빠진 교훈이 붙어 있는 학교 게시판이다.\n...? 잠깐. 평소와는 내용이 다르다.:",
        "교훈\n이름을 버리지 맙시다.\n이름을 빼앗지 맙시다.\n이름을 잃어버리지 맙시다.:","이건 뭐야...?:0" });//게시판

        //교장실
        talkData.Add(130, new string[] { ":", "돈다발이 거의 내 키만큼 쌓여 있다:" });//돈다발
        talkData.Add(135, new string[] { ":", "두꺼운 양장본이 가득 꽃혀 있다. 책등에는 '장식용 책'이라는 글자가 적혀 있다.\n...안은 백지다.:" });//책장
        talkData.Add(140, new string[] { ":", "시계는 전혀 움직이지 않는다..:" });//시계
        talkData.Add(145, new string[] { ":", "트로피와 표창장이 유리 케이스 안에 장식되어 있다.:",
            "...상을 탄 학생의 이름이 있어야 할 부분에 이름 대신 '학교의 영광'만 적혀 있다.:" });//장식품
        talkData.Add(150, new string[] { ":", "학교가 받은 상장이 자랑스럽게 벽에 걸려 있다.:", "[판매 실적 우수 학교]:" });//상장
        talkData.Add(155, new string[] { ":", "교장이 돈다발을 세고 있다.:", "\"사, 사람이다... 교장 선생님..살려 주세요!!\":0", "\"1..3... 5..10.\":1",
        "\"교장 선생님? 저기요. 저기요....? 안 보여요?\":0","\"1.. 3... 5.. 10. 1.. 3.. 5...\":1", "\"안 보이냐고요! 야!! 안 보이냐고!!\":0",
        "\"1.. 3... 5.. 10. 1.. 3... 모자라. 1.. 3... 5..\":1", "\".....\":0"});//교장

        //회의실
        talkData.Add(175, new string[] { ":", "회의에 쓰이는 화이트보드다.:", "[오늘의 회의 참석자 0명]:" });//화이트보드
        talkData.Add(180, new string[] { ":", "서류더미가 쌓여 있다..:" });//서류더미
        talkData.Add(185, new string[] { ":", "서류가 놓여 있다.:","[최근 교내에서 이름을 잃어버린 학생이 발생하고 있습니다.\n각 교사들과 학부모님들의 관심과 지원이 필요합니다.]:" });//좌측서류
        talkData.Add(190, new string[] { ":", "내용 없는 서류 위에 휘갈긴 듯한 낙서가 적혀 있다.:", "[이름 통보실로 바꾸자 어차피 여기에서 회의하는 건 아무것도 없어]:" });//가운데서류
        talkData.Add(195, new string[] { ":", "내용 없는 서류 위쪽에 열쇠가 떨어져 있다. 열쇠에는 [양호실] 이라고 적힌 스티커가 붙어 있다.:", "양호실 열쇠를 얻었다.:" });//우측서류


        //양호실
        talkData.Add(245, new string[] { ":", "양호실 책상이다. 자리에는 아무도 없다.:", "\"양호는 한번도 제자리에 있던 적이 없어...\":0",
        "책상 서랍에는 열쇠 하나를 제외하면 진통제만 가득 쌓여 있다.:", "미술실 열쇠를 얻었다.:"});//양호실책상
        talkData.Add(250, new string[] { ":", "양호실의 냉장고다. 안쪽에는 물 몇 병과 알 수 없는 약품들이 들어 있다.:" });//냉장고
        //talkData.Add(255, new string[] { ":", "책장이다.:", "책이 꽂혀있다.:" });//책장
        talkData.Add(260, new string[] { ":", "흰 시트가 깔린 침대다. 누워도 그다지 편안하지는 않다.:" });//침대
        talkData.Add(265, new string[] { ":", "흰 시트가 깔린 침대다. ...? 누군가 있다..:", "'...뭐, 뭐야. 누구야..':0", "'아주 살짝만.. 뭔지만 보자. 으.....':0",
       "잔뜩 긴장한 채로, 시트를 아주 살짝 걷었다.:","\"수업 듣기 싫어. 여기서 잘래.\":2","\".....\":0","어딘가 손해 본 기분이 들었다...:" });//사람이 있는 침대
        talkData.Add(270, new string[] { ":", "의료용품이 가득 들어 있는 서랍장이다. 정리되지 않은 주사기 하나가 굴러다니고 있다.:" });//왼쪽 서랍장
        talkData.Add(275, new string[] { ":", "의료용품이 가득 들어 있는 서랍장이다. 거즈나 붕대, 종교 기관에서 실시하는 성교육 캠페인 포스터 뭉치가 들어 있다.:" });//우측 서랍장
        talkData.Add(280, new string[] { ":", "책장에는 다양한 종류의 책이 꽃혀 있다.\n'이름을 잃어버린 이들 1'이라는 제목의 책을 발견했다.:",
        "[...이름을 잃은 이들은 괴물이 된다. 괴물이 된 이들은 이름을 찾아다닌다. 자신의 것이 아닌 이름을 달아도 이전으로 돌아갈 수 없지만, 현재의 모습을 견딜 수 없어 계속해서 빼앗는 것이다.]:",
       "...이 이후는 비어 있다.:"});//책장1
        talkData.Add(285, new string[] { ":", "책장에는 다양한 종류의 책이 꽃혀 있다.\n'이름을 잃어버린 이들 2'라는 제목의 책을 발견했다.:",
        "[이름을 잃어버린 이들은 언제나 최단 거리를 향해 움직인다. 그들을 따돌리는 방법은 간단하다. 물건을 사이에 두고 반대편에 서면 된다. 다만, 너무 오래 그런식으로 따돌릴 경우 그들이 한때 인간이었음을 증명할 만한 지능적인 움직임을 보게 될 지도 모른다.]:",
       "...이 이후는 비어 있다.:" });//책장2
        talkData.Add(290, new string[] { ":", "책장에는 다양한 종류의 책이 꽃혀 있다.\n'이름을 잃어버린 이들 3'이라는 제목의 책을 발견했다.:",
        "[이름은 우연히 부서지지 않는다.이름이 망가지는 경우는 두 가지 뿐이다.누군가 이름을 망가뜨렸거나, 스스로 부쉈거나.]:",
        "...이 이후는 비어 있다.:"});//책장3
        talkData.Add(295, new string[] { ":", "양호실의 서랍이다. 거의 텅 빈 내부에는 거즈 몇 장만 굴러다니고 있다.:" });//양호실서랍

        talkData.Add(120, new string[] { ":", "아직은 좀 더 쉬고싶어.:0" });//양호실 문

        //미술실
        talkData.Add(300, new string[] { ":", "미술부 학생들의 그림을 장식해놓는 게시판.\n...핏자국으로 뒤덮여 그림이 제대로 보이지 않는다.:",
            "핏자국 사이로 낙서가 보인다.:", "[무서워 할 거 없어. 그것들은 그저 고통에 몸부림치는 것 뿐이라고.]\n[웃기지 마. 그 고통이 내게 다가오고 있잖아.]:"}); //그림게시판
        talkData.Add(305, new string[] { ":", "쇠창살이 달린 창문. 창살 때문에 창문으로 나갈 수가 없다.:" });//창문
        talkData.Add(310, new string[] { ":", "수업에 사용하는 모습을 본 적 없는 조각상이 서랍 위에 올라가 있다.\n...시선이 계속해서 나를 향해 있다.:" }); //조각상
        talkData.Add(315, new string[] { ":", "위쪽이 유리로 덮여 있는 미술용 책상이다. 무거워서 잘 밀리지 않는다.:" }); //미술실책상
        talkData.Add(320, new string[] { ":", "잠겨 있는 미술실의 서랍장이다. 안쪽에서 뭔가를 꺼내는 모습을 본 적이 없다.:" }); //위쪽서랍
        talkData.Add(325, new string[] { ":", "내려와 있는 스크린이 더 자주 보이는 미술실의 칠판이다.\n흰 분필로 무언가 쓰여 있다..:",
        "[구하라, 그러면 주어지리라.]:","..아래쪽에 뭔가 떨어져 있다.:","창고 열쇠를 얻었다.:"}); //미술실 칠판
        talkData.Add(330, new string[] { ":", "날이 무딘 가위가 놓여 있다. 지금은 자를 종이가 없다.:" }); //가위
        talkData.Add(335, new string[] { ":", "미술실에 비치된 딱풀. 뚜껑 부분이 끈적끈적하다.:" }); //풀
        talkData.Add(340, new string[] { ":", "책에서 찢어낸 것 같은 종이 한 장이 책상에 놓여 있다.:",
            "[...이미 망가져버린 이름을 고치기 위해서는 다음의 물건이 필요하다.]:","[망가진 이름 조각\n풀\n가위:",
        "종이\n물 약간\n바구니 하나:","올바른 이름\n이름을 망가뜨린 사람의 피\n올바른 이름을 아는 사람의 간절함]:",
        "'뒤로 갈수록 이상한 게 필요한데..':0","[방법은 다음과 같다.\n1. 종이에 쓴 올바른 이름을 이름 크기만 남기고 오려낸다.\n2. 망가진 이름 조각을 맞춰, 위에 풀로 종이를 붙인다.:",
        "3. 바구니에 이름 조각이 잠길 정도로 물을 붓는다.\n4. 물에 잠긴 이름 조각 위로 이름을 망가뜨린 이의 피를 몇 방울 떨어뜨린다.\n5. 간절한 마음으로 이름이 복구되기를 바라며 손에 쥐고 있는다.]:",
        "[부서진 이름을 고칠 수 있는 것은 타인 뿐이다.\n충분히 간절하지 않다면 이름은 돌아오지 않는다.]:", "\".....\":0",
        "이런 소리를 믿어도 되는 걸까 싶지만... 문은 죄다 잠겨 있고, 다른 방법도 보이지 않는다.:", "종이의 내용을 따라 이름을 고쳐보기로 했다. 필요한 물품을 모아야 한다.:"}); //종이 이벤트

        //미술실이벤트
        talkData.Add(400, new string[] { ":", "이름이 적힌 종이의 여백을 잘라냈다.:" });//가위이벤트
        talkData.Add(405, new string[] { ":", "미술실에 비치된 딱풀이다. 이거면 될 것 같다.:","풀을 얻었다.:" });//풀이벤트
        talkData.Add(410, new string[] { ":", "양호실의 서랍장이다. 정리되지 않은 주사기 하나가 굴러다니고 있다.:","'아. 이 주사기를 괴물한테 찌르는.. 건 무리지만, 바닥의 핏자국에서 피를 얻을 수 있지 않을까.':0",
        "주사기를 얻었다.:"});//양호실서랍이벤트
        talkData.Add(415, new string[] { ":", "냉장고 안에는 물이 몇 병 들어 있다.:","물 한 병을 얻었다.:" });//냉장고이벤트
        talkData.Add(420, new string[] { ":", "신발장이다. 여기에는 그 애의 이름이 없다.:" });//신발장이벤트
        talkData.Add(425, new string[] { ":", "신발장이다.:","'그러니까 이 씨에... 지은? 지윤? 그런 이름이었는데... 뭐더라.....':0",
            "\"아, 찾았다! 맞아. 지유였어. 겨우 기억났네...\":0","신발장에서 이름이 적힌 종이를 빼냈다.:0", "이지유의 이름이 적힌 종이를 얻었다.:"});//가운데신발장이벤트
        talkData.Add(430, new string[] { ":", "시간이 지났는데도 피가 전혀 굳지 않았다.:","'적당한 도구가 있다면 여기서 피를 얻을 수 있을지도...':0" });//핏자국
        talkData.Add(435, new string[] { ":", "주사기를 사용해 피를 얻었다.:" });//핏자국이벤트
        talkData.Add(440, new string[] { ":", "물이 새지 않는 적당한 크기의 바구니다. 물품을 다 모으면 이리로 오자.:" });//바구니이벤트


        //미술창고
        talkData.Add(350, new string[] { ":", "보통은 풀이나 가위를 넣어두는 나무 바구니. 지금은 아무것도 들어 있지 않다.:" });//바구니
        talkData.Add(355, new string[] { ":", "미술부가 사용하는 캔버스가 구석에 나란히 놓여 있다.:" });//캰버스
        talkData.Add(360, new string[] { ":", "평범하게 생긴 나무 이젤이 켜켜히 쌓여 있다.:" });//이젤
        talkData.Add(365, new string[] { ":", "수업에 사용하는 모습을 본 적 없는 조각상이 창고에 놓여 있다.\n...시선이 계속해서 나를 향해 있다.:" });//조각상
        talkData.Add(370, new string[] { ":", "미술용품을 넣어둔 서랍장이다. 안쪽에는 온갖 크기의 붓이 보인다.:" });//서랍장
        talkData.Add(375, new string[] { ":", "미술 용품이 담겨 있는 박스. 수많은 종류의 물감이 들어 있다.:" });//박스


        //문 표지판
        talkData.Add(900, new string[] { ":", "명패에 교장실이라고 쓰여 있다.:" });//교장실옆
        talkData.Add(905, new string[] { ":", "명패에 회의실이라고 쓰여있다.:" });//회의실옆
        talkData.Add(910, new string[] { ":", "양호실이다.:" });//양호실옆
        talkData.Add(915, new string[] { ":", "잠겨있다.:" });//양호실 열쇠 없음
        talkData.Add(920, new string[] { ":", "계단으로 통하는 문이다. 잠겨있다.:" });//양호실 열쇠 없음
        talkData.Add(925, new string[] { ":", "미술실이다.:" });
        talkData.Add(930, new string[] { ":", "잠겨 있다.:" });//미술실 열쇠업음
        talkData.Add(935, new string[] { ":", "미술실의 비품을 보관하는 창고다.:" });
        talkData.Add(940, new string[] { ":", "잠겨 있다.:" });//창고열쇠없음.


        //  portraitData.Add(1000 + 0, portraitArr[0]);
        // portraitData.Add(1000 + 1, portraitArr[1]);

    }
    public string GetTalk(int id, int talkIndex)
    {
        return talkIndex==talkData[id].Length?null:talkData[id][talkIndex];
    }
    /*
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        //if는 npx넘버 / 표정번호
        return portraitData[id + portraitIndex];
    }*/
    public Sprite GetPortrait( int portraitIndex)
    {
        //if는 npx넘버 / 표정번호
        return portraitArr[portraitIndex];
    }

    // Start is called before the first frame update
    void Start()
    {
       // DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
