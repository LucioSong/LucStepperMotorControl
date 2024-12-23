using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luc.Motion
{
    public interface IMotion
    {
        event EventHandler ChangedSetting;
        string GetDevName(int axisNum);
        void InitMotion();
        void AxisSetServoOn(int axisNum, bool isOn);
        bool AxisGetServoOnState(int axisNum);
        void AxisSetMoveParameter(int axisNum, double vel, double acc, double dec);
        void AxisMove(int axisNum, double pos, bool isRel);
        void AxisMoveJog(int axisNum, bool isDirectionPostive);
        void AxisHome(int axisNum);
        uint AxisHomeState(int axisNum);
        void AllHome();
        void AxisStop(int axisNum);
        void AllStop();
        void AxisPositionClear(int axisNum);
        void SaveMotionINI(string path);
        void LoadMotionINI(string path);
        double AxisGetActualPosition(int axisNum);            
        bool AxisIsBusy(int axisNum);
        bool IsInitMotion();
        bool IsMotionBusy();
        int GetAxisCount();
        string GetAxisDevName(int axisNum);
        bool AxisIsUse(int axisNum);
        double GetPosDst(int axisNum);        
        void AxisMoveV(int axisNum , double fPos, double fV);
        void AxisMoveV(int axisNum , double fPos, double fPosV, double fV);
        void SetTrigger(int axisNum, double dStartPos, double dEndPos, double dPeriodPos, bool bCmd, double dTrigTime = 2, uint triggerLevel = 1);
        void StopTrigger(int axisNum);
        void OverrideVel(int axisNum , double fV);
        bool IsAxisCompletedHome(int axisNum);
        bool IsAllCompletedHome();
        bool GantrySetEnable();
        bool GantrySetDisable();
        bool IsUseGantry();
        bool GantryGetStatus();
        bool AxisIsPositiveLimit(int axisNum);
        bool AxisIsNegativeLimit(int axisNum);
        IAxis GetAxis(int axisNum);
    }
}
