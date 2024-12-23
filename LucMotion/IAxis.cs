using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luc.Motion
{
    public interface IAxis
    {
        void Home();                            // Homing
        uint GetHomeState();                    // Home 상태확인
        void Move(double pos, bool isRelative); // 이동
        void MoveJog(bool isDirectionPostive);  // Jog 이동
        void Stop();                            // 정지
        void SetServoOn(bool isOn);             // Servo on/off
        bool GetServoOnState();                 // Servo on/off 상택확인
        void PositionClear();                   // 현재위치 Zero 세팅
        void SaveAxisINI(string path);          // 세팅값 저장
        void LoadAxisINI(string path);          // 세팅값 로드
        double GetActualPosition();             // 현재 위치 확인
        bool IsBusy();                          // 이동 상태 (이동wnd -> Busy)
        bool IsUse();                           // 사용여부        
        bool IsCompletedHome();                 // Home 완료 여부
        bool IsPositiveLimit();                 // (+) limit sensing
        bool IsNegativeLimit();                 // (-) limit sensing
        AxisBase AxisBase { get; }
    }
}
