# 성경2PPT
> 성경 구절을 PPT로 만들어주는 프로그램

<p align="center"><img src="https://user-images.githubusercontent.com/4927894/36576622-1def6d7a-1895-11e8-9c68-bf402e0e89d1.png" alt="성경2PPT 스크린샷"></p>
<p align="center">⬇️</p>
<p align="center"><img src="https://user-images.githubusercontent.com/4927894/36557220-072f3588-184b-11e8-85b4-05845fbe76c1.png" alt="성경2PPT로 만든 PPT 스크린샷"></p>


## 성경 구절 입력 방법
![성경2PPT 성경 구절 입력란 강조 스크린샷](https://user-images.githubusercontent.com/4927894/36576619-1bbd85aa-1895-11e8-9d3c-7b4a58cf807f.png)

**성경2PPT**에는 **성경 구절**을 아래 규칙대로 입력해야 하며 여러 **성경 구절**을 띄어쓰기(<kbd>Space</kbd>)로 구분하여 입력할 수 있습니다.

### 규칙
```
짧은_제목[시작_장[:시작_절][-[마지막_장[:마지막_절]|마지막_절]]]
```

### 예시
| 성경 구절 | 설명 |
| --- | --- |
| `창` | 창세기 전체 |
| `창1` | 창세기 1장 전체 |
| `롬1-3` | 로마서 1장 1절 - 3장 전체 |
| `레1-3:9` | 레위기 1장 1절 - 3장 9절 |
| `전1:3` | 전도서 1장 3절 |
| `스1:3-9` | 에스라 1장 3절 - 1장 9절 |
| `사1:3-3:9` | 이사야 1장 3절 - 3장 9절 |


## 기능

### 템플릿
![성경2PPT 템플릿 스크린샷](https://user-images.githubusercontent.com/4927894/36580193-9972bece-18aa-11e8-93f2-035283e1a387.png)

**성경2PPT**는 PPT를 만들 때 **템플릿**을 사용합니다. **템플릿**을 꾸미고 좋아하는 스타일로 PPT를 만드세요!

- **치환자**: 텍스트를 특수한 내용으로 바꿔줍니다.

    | 치환자 | 설명 | _접미사_ 지원 |
    | --- | --- | --- |
    | `[TITLE]` | 긴 제목 | O |
    | `[STITLE]` | 짧은 제목 | O |
    | `[CHAP]` | 장 번호 | O |
    | `[PARA]` | 절 번호 | X |
    | `[BODY]` | 내용 | X |

- **접미사**: **치환자** `[CHAP:장]`을 `n장`으로 바꿔줍니다. 이 때, **치환자**를 표시하지 않으면 **접미사**도 표시하지 않습니다.

### 기타 기능
- **장별로 PPT 나누기**: `성경 제목/장 번호.pptx`의 구조로 장별로 PPT를 만들어 저장합니다.


## 설치 방법
**성경2PPT**는 [실행 요구 사항](#실행-요구-사항)만 만족하면 설치 없이 사용할 수 있습니다. [Releases](https://github.com/sunghwan2789/Bible2PPT/releases) 페이지에서 최신 버전을 내려받고 바로 사용하세요!


## 실행 요구 사항

### .NET Framework 4 Client Profile 이상
**성경2PPT**를 실행하는 데 필요한 프레임워크입니다. [여기](http://go.microsoft.com/fwlink/?LinkId=181012)에서 내려받으세요.

### Microsoft PowerPoint 2007 이상
PPT를 만들고 보는 데 필요한 프로그램입니다. 프로그램 구성 요소로 _Office 공유 기능_ - _Visual Basic for Applications_ 를 설치해야 합니다.

### 인터넷 연결
성경 구절을 [갓피플](http://godpeople.com)에서 받아올 때 인터넷 연결이 필요합니다.


## 기여 방법
**성경2PPT**는 당신의 기여를 기다리고 있습니다~ 사용 중 발생한 오류 혹은 추가하고 싶은 기능을 [Issues](https://github.com/sunghwan2789/Bible2PPT/issues) 페이지에 올려주세요!


## License
This software is licenced under the [MIT](LICENSE) © [Bang Sunghwan](https://github.com/sunghwan2789).
