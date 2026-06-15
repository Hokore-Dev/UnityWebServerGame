# UnityWebServerGame

PHP + MySQL 백엔드와 통신하는 **Unity 웹 서버 게임 예제**입니다.
Unity 클라이언트가 HTTP로 PHP 스크립트를 호출하고, PHP가 MySQL(MariaDB)에 데이터를
읽고 쓰는 전형적인 클라이언트–서버 구조를 보여줍니다.

## 🧩 구조

```
Unity (C#)  ──HTTP──▶  PHP (Apache)  ──▶  MySQL / MariaDB
```

- **Client** — Unity (C#) · 게임 로직은 `Assets/` 아래
- **Server** — PHP 스크립트 (Apache)
- **DB** — MySQL / MariaDB

## ⚙️ 로컬 환경 설정

| 구성 요소 | 다운로드 | 설치 가이드 |
|---|---|---|
| Apache | https://www.apachelounge.com/download/ | http://jimnong.tistory.com/612 |
| PHP | https://windows.php.net/download/ | http://jimnong.tistory.com/613 |
| MariaDB | https://downloads.mariadb.org/ | http://pyonji.tistory.com/11 |

## ▶️ 실행

1. 위 가이드대로 **Apache + PHP + MariaDB** 설치 후 실행
2. PHP 스크립트를 Apache 웹 루트에 배치하고 DB 연결 정보 설정
3. Unity에서 프로젝트를 열고, 클라이언트의 서버 주소를 로컬 서버로 지정
4. 플레이 ▶️

---

> 클라이언트–서버 연동을 익히기 위한 학습용 예제 프로젝트입니다.
