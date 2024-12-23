# Lucio - Stepper motor controller
- Controller hardware (실제이미지 업로드 예정)
 ![Cap 2024-12-23 14-17-44-029](https://github.com/user-attachments/assets/23358563-fd62-4e44-ae52-b043a3e1e24c)


# Controller UI Software
- 아래 프로토콜이 적용된 코드가 있으며, 바로 동작 및 C# DLL 형태로 사용가능
 ![Cap 2024-12-23 14-17-54-674](https://github.com/user-attachments/assets/c0779756-993b-47dd-a558-21ea251d4a3a)
 ![image](https://github.com/user-attachments/assets/3c66a0a9-d623-4b1f-a220-b6824e154561)


# Protocol
| **명령어** | **형식**                        | **설명**                          | **응답**                                                                                      |
|------------|----------------------------------|------------------------------------|---------------------------------------------------------------------------------------------|
| **CMV**    | `CMV<motor_num>,<absolute_position>` | 모터를 지정된 절대 위치로 이동       | - `OK,<command>`: 성공<br> - `ERR,01`: 잘못된 형식<br> - `ERR,02`: 잘못된 모터 번호            |
| **SVL**    | `SVL<motor_num>,<speed>`          | 모터 속도를 설정                   | - `OK,<command>`: 성공<br> - `ERR,01`: 잘못된 형식<br> - `ERR,02`: 잘못된 모터 번호<br> - `ERR,03`: 모터 사용 불가 |
| **GPS**    | `GPS<motor_num>`                  | 모터의 현재 위치를 조회            | - `POS,<motor_num>,<current_position>`: 현재 위치 반환<br> - `ERR,02`: 잘못된 모터 번호<br> - `ERR,03`: 모터 사용 불가 |
| **GIM**    | `GIM<motor_num>`                  | 모터가 이동 중인지 조회            | - `GIM,<motor_num>,<is_running>`: 이동 상태 반환 (`1`: 이동 중, `0`: 정지)<br> - `ERR,02`: 잘못된 모터 번호<br> - `ERR,03`: 모터 사용 불가 |
| **GLM**    | `GLM<motor_num>`                  | 모터의 제한값(최소/최대) 조회       | - `LMT,<motor_num>,<min_limit>,<max_limit>`: 제한값 반환<br> - `ERR,02`: 잘못된 모터 번호<br> - `ERR,03`: 모터 사용 불가 |
| **GVL**    | `GVL<motor_num>`                  | 모터의 현재 속도 조회              | - `SPD,<motor_num>,<speed>`: 속도 반환<br> - `ERR,02`: 잘못된 모터 번호<br> - `ERR,03`: 모터 사용 불가 |
| **CRS**    | `CRS<motor_num>`                  | 특정 모터를 리셋                   | - `OK,<command>`: 성공<br> - `ERR,02`: 잘못된 모터 번호<br> - `ERR,03`: 모터 사용 불가        |
| **CHM**    | `CHM`                             | 모든 모터를 리셋                   | - `OK,<command>`: 성공                                                                        |
| **GHS**    | `GHS<motor_num>`                  | 특정 모터의 홈 상태 조회           | - `HMS,<motor_num>,<home_state>`: 홈 상태 반환<br> - `ERR,02`: 잘못된 모터 번호<br> - `ERR,03`: 모터 사용 불가 |
| **SAC**    | `SAC<motor_num>,<acceleration>`   | 모터 가속도 설정                   | - `OK,<command>`: 성공<br> - `ERR,01`: 잘못된 형식<br> - `ERR,02`: 잘못된 모터 번호<br> - `ERR,03`: 모터 사용 불가 |
| **GAC**    | `GAC<motor_num>`                  | 모터 가속도 조회                   | - `ACC,<motor_num>,<acceleration>`: 가속도 반환<br> - `ERR,02`: 잘못된 모터 번호<br> - `ERR,03`: 모터 사용 불가 |
| **C!!**    | `C!!`                             | 모든 모터 정지                     | - `OK,<command>`: 성공                                                                        |


# Motor pin map
- D-Sub 9 pin (Standard)
  ![image](https://github.com/user-attachments/assets/25dd3128-546e-4825-98f2-61b1e1386cde)
  
| **핀 번호** | **신호 이름**         | **설명**                    |
|-------------|-----------------------|-----------------------------|
| 1           | VCC (5V)             | 전원 공급 (+5V)             |
| 2           | Forward limit        | 전진 제한 스위치 (Active Low) |
| 3           | Backward limit       | 후진 제한 스위치 (Active Low) |
| 4           | GND (0V)             | 접지                       |
| 5           | Unused               | 사용되지 않음               |
| 6           | Motor A＋            | 스텝 모터 코일 A＋           |
| 7           | Motor A－            | 스텝 모터 코일 A－           |
| 8           | Motor B＋            | 스텝 모터 코일 B＋           |
| 9           | Motor B－            | 스텝 모터 코일 B－           |
