using mecanumWheelRobot.Bluetooth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mecanumWheelRobot.Views
{
    public partial class MainPage : ContentPage
    {
        public static Bluetooth.IBth bth = new Bluetooth.Bth();

        public MainPage()
        {
            InitializeComponent();

            bth.Start("mecanumWheelRobot", 200, false);
            RunTimer();
        }

        System.Threading.Timer Timer;
        public void RunTimer()
        {
            Timer = new System.Threading.Timer(TimerCallback, null, 0, 100);
        }

        private void TimerCallback(object state)
        {
            int speedFaktor = 2;

            int speedLF = 0, dirLF = 0, enLF = 0,
                speedLB = 0, dirLB = 0, enLB = 0,
                speedRF = 0, dirRF = 0, enRF = 0,
                speedRB = 0, dirRB = 0, enRB = 0;

            if(JoystickControl.Xposition == 0 && JoystickControl.Yposition == 0)
            {
                if(JoystickControl1.Angle < 40 || JoystickControl1.Angle > 320) //forward moving
                {
                    speedLF = Math.Abs(JoystickControl1.Yposition);
                    speedLB = Math.Abs(JoystickControl1.Yposition);
                    speedRF = Math.Abs(JoystickControl1.Yposition);
                    speedRB = Math.Abs(JoystickControl1.Yposition);

                    dirLF = 0;
                    dirLB = 0;
                    dirRB = 1;
                    dirRF = 1;
                }else if(JoystickControl1.Angle > 140 && JoystickControl1.Angle < 220) //backward moving
                {
                    speedLF = Math.Abs(JoystickControl1.Yposition);
                    speedLB = Math.Abs(JoystickControl1.Yposition);
                    speedRF = Math.Abs(JoystickControl1.Yposition);
                    speedRB = Math.Abs(JoystickControl1.Yposition);

                    dirLF = 1;
                    dirLB = 1;
                    dirRB = 0;
                    dirRF = 0;
                }else if (JoystickControl1.Angle > 230 && JoystickControl1.Angle < 310) //left moving
                {
                    speedLF = Math.Abs(JoystickControl1.Xposition);
                    speedLB = Math.Abs(JoystickControl1.Xposition);
                    speedRF = Math.Abs(JoystickControl1.Xposition);
                    speedRB = Math.Abs(JoystickControl1.Xposition);

                    dirLF = 1;
                    dirLB = 0;
                    dirRB = 0;
                    dirRF = 1;
                }
                else if(JoystickControl1.Angle > 50 && JoystickControl1.Angle < 130) //right moving
                {
                    speedLF = Math.Abs(JoystickControl1.Xposition);
                    speedLB = Math.Abs(JoystickControl1.Xposition);
                    speedRF = Math.Abs(JoystickControl1.Xposition);
                    speedRB = Math.Abs(JoystickControl1.Xposition);

                    dirLF = 0;
                    dirLB = 1;
                    dirRB = 1;
                    dirRF = 0;
                }
                else if (JoystickControl1.Angle >= 310 && JoystickControl1.Angle <= 320) //forward left diaglonal moving
                {
                    //speedLF = (Math.Abs(JoystickControl1.Xposition)+ Math.Abs(JoystickControl1.Xposition))/2;
                    speedLB = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;
                    speedRF = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;
                    //speedRB = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;

                    dirLF = 0;
                    dirLB = 0;
                    dirRB = 1;
                    dirRF = 1;

                    enLF = 0;
                    enLB = 0;
                    enRF = 0;
                    enRB = 0;
                }
                else if (JoystickControl1.Angle >= 40 && JoystickControl1.Angle <= 50) //forward right diaglonal moving
                {
                    speedLF = (Math.Abs(JoystickControl1.Xposition)+ Math.Abs(JoystickControl1.Xposition))/2;
                    //speedLB = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;
                    //speedRF = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;
                    speedRB = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;

                    dirLF = 0;
                    dirLB = 0;
                    dirRB = 1;
                    dirRF = 1;

                    enLF = 0;
                    enLB = 0;
                    enRF = 0;
                    enRB = 0;
                }
                else if (JoystickControl1.Angle >= 220 && JoystickControl1.Angle <= 230) //backwords left diaglonal moving
                {
                    speedLF = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;
                    //speedLB = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;
                    //speedRF = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;
                    speedRB = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;

                    dirLF = 1;
                    dirLB = 1;
                    dirRB = 0;
                    dirRF = 0;

                    enLF = 0;
                    enLB = 0;
                    enRF = 0;
                    enRB = 0;
                }
                else if (JoystickControl1.Angle >= 130 && JoystickControl1.Angle <= 140) //backwords right diaglonal moving
                {
                    //speedLF = (Math.Abs(JoystickControl1.Xposition)+ Math.Abs(JoystickControl1.Xposition))/2;
                    speedLB = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;
                    speedRF = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;
                    //speedRB = (Math.Abs(JoystickControl1.Xposition) + Math.Abs(JoystickControl1.Xposition)) / 2;

                    dirLF = 1;
                    dirLB = 1;
                    dirRB = 0;
                    dirRF = 0;

                    enLF = 0;
                    enLB = 0;
                    enRF = 0;
                    enRB = 0;
                }
            }
            else
            {
                if (JoystickControl.Xposition > 0) //turning left
                {
                    speedLF = Math.Abs(JoystickControl.Xposition);
                    speedLB = Math.Abs(JoystickControl.Xposition);
                    speedRF = Math.Abs(JoystickControl.Xposition);
                    speedRB = Math.Abs(JoystickControl.Xposition);

                    dirLF = 0;
                    dirLB = 0;
                    dirRB = 0;
                    dirRF = 0;
                }
                else                            //turning right
                {
                    speedLF = Math.Abs(JoystickControl.Xposition);
                    speedLB = Math.Abs(JoystickControl.Xposition);
                    speedRF = Math.Abs(JoystickControl.Xposition);
                    speedRB = Math.Abs(JoystickControl.Xposition);

                    dirLF = 1;
                    dirLB = 1;
                    dirRB = 1;
                    dirRF = 1;
                }
            }

            if(speedLF == 0 && speedLB == 0 && speedRF == 0 && speedRB == 0)
            {
                enLF = 1;
                enLB = 1;
                enRF = 1;
                enRB = 1;
            }



            string result = "{\"speedLF\":\"" + speedLF* speedFaktor + "\",\"dirLF\":\"" + dirLF + "\",\"enLF\":\"" + enLF + "\",\"speedLB\":\"" + speedLB* speedFaktor + "\",\"dirLB\":\"" + dirLB + "\",\"enLB\":\"" + enLB + "\",\"speedRF\":\"" + speedRF* speedFaktor + "\",\"dirRF\":\"" + dirRF + "\",\"enRF\":\"" + enRF + "\",\"speedRB\":\"" + speedRB* speedFaktor + "\",\"dirRB\":\"" + dirRB + "\",\"enRB\":\"" + enRB + "\"}";
            bth.Write(result);
            System.Diagnostics.Debug.WriteLine(result);
        }


        
    }
}
