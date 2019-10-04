//Author: Ethan Kamus
//Email: ethanjpkamus@csu.fullerton.edu

//Purpose: to emulate a stoplight

using System;
using System.Drawing;
using System.Windows.Forms; //GroupBox and RadioButton
using System.Timers;

public class stoplightuserinterface : Form
{

       //items to be used in user interface
       private Button start_button = new Button();
       private Button play_pause_button = new Button();
       private Button exit_button = new Button();

       private enum TrafficColor {red,yellow,green}; //arbitrary names, have no relation to any library class
       TrafficColor Light = TrafficColor.red;

       private GroupBox groupbox = new GroupBox();
       private RadioButton slow_button = new RadioButton();
       private RadioButton fast_button = new RadioButton();

       private static System.Timers.Timer patek = new System.Timers.Timer();
       private int tickcounter = 0;

       private Size maximum_window_size = new Size(500,1000);
       private Size minimum_window_size = new Size(500,1000);

       //brushes for ellipses in OnPaint
       private SolidBrush redbrush = new SolidBrush(Color.Red);
       private SolidBrush yellowbrush = new SolidBrush(Color.Yellow);
       private SolidBrush greenbrush = new SolidBrush(Color.Green);
       private SolidBrush clearbrush = new SolidBrush(Color.Transparent);

       //constructor
       public stoplightuserinterface(){

              MaximumSize = maximum_window_size;
              MinimumSize = minimum_window_size;

              //Timer Properties
              patek.Interval = 1000;
              patek.Enabled = false;

              //Labels and Buttons
              Text = "Stoplight project by Ethan Kamus";

              start_button.Text = "Start";
              play_pause_button.Text = "Pause";
              exit_button.Text = "Exit";

              //set sizes
              start_button.Size = new Size(75,30);
              play_pause_button.Size = new Size(75,30);
              exit_button.Size = new Size(75,30);
              groupbox.Size = new Size(150,75);
              slow_button.Size = new Size(50,50);
              fast_button.Size = new Size(50,50);

              //set locations of buttons not in groupbox
              start_button.Location = new Point(0,900);
              play_pause_button.Location = new Point(100,900);
              exit_button.Location = new Point(200,900);
              groupbox.Location = new Point(300,850);

              //set locations of buttons within groupbox
              fast_button.Location = new Point(0,0);
              slow_button.Location = new Point(0,45);

              //add controls to the Form
              Controls.Add(start_button);
              Controls.Add(play_pause_button);
              Controls.Add(exit_button);

              //add radiobuttons to groupbox
              groupbox.Controls.Add(slow_button);
              groupbox.Controls.Add(fast_button);

              //set text for radiobuttons
              slow_button.Text = "Slow";
              fast_button.Text = "Fast";

              //add groupbox to Form
              Controls.Add(groupbox);

              //Timer
              patek.Elapsed += new ElapsedEventHandler(updateStoplight);
              patek.AutoReset = true;
              patek.Enabled = false;

              //intitail Radio Button states
              slow_button.Checked = true;
              fast_button.Checked = false;

              //event handler for buttons
              start_button.Click += new EventHandler(startStoplight);
              play_pause_button.Click += new EventHandler(manageTimer);
              exit_button.Click += new EventHandler(stopProgram);

              slow_button.CheckedChanged += new EventHandler(setSlowButton);
              fast_button.CheckedChanged += new EventHandler(setFastButton);

       } //end of constructor

       protected override void OnPaint(PaintEventArgs e){

              Graphics graph = e.Graphics;
              switch(Light){
                     case TrafficColor.red:
                            graph.FillEllipse(redbrush,100,0,175,175);

                            //cover other two ellipses
                            graph.FillEllipse(clearbrush,100,180,175,175);
                            graph.FillEllipse(clearbrush,100,360,175,175);
                            break;

                     case TrafficColor.yellow:
                            graph.FillEllipse(yellowbrush,100,180,175,175);

                            graph.FillEllipse(clearbrush,100,0,175,175);
                            graph.FillEllipse(clearbrush,100,360,175,175);
                            break;
                     case TrafficColor.green:
                            graph.FillEllipse(greenbrush,100,360,175,175);

                            graph.FillEllipse(clearbrush,100,0,175,175);
                            graph.FillEllipse(clearbrush,100,180,175,175);
                            break;

              }
              base.OnPaint(e);

       }

       protected void updateStoplight(Object o, ElapsedEventArgs e){

              //algorithm to determine the light that is switched on
              switch(Light){
                     case TrafficColor.red:
                            if(tickcounter < 4){
                                   tickcounter++;
                            }
                            else {
                                   tickcounter = 0;
                                   Light = TrafficColor.yellow;
                            }

                            Invalidate();
                            break;
                     case TrafficColor.yellow:
                            if(tickcounter < 2){
                                   tickcounter++;
                            }
                            else {
                                   tickcounter = 0;
                                   Light = TrafficColor.green;
                            }

                            Invalidate();
                            break;
                     case TrafficColor.green:
                            if(tickcounter < 3){
                                   tickcounter++;
                            }
                            else {
                                   tickcounter = 0;
                                   Light = TrafficColor.red;
                            }

                            Invalidate();
                            break;
              }

       }//end of updateStoplight

       protected void startStoplight(Object o, EventArgs e){

              patek.Enabled = true;
              start_button.Text = "Running...";
              play_pause_button.Text = setPPButton();

       }//end of startStoplight

       protected void manageTimer(Object o, EventArgs e){

              patek.Enabled = !patek.Enabled;
              play_pause_button.Text = setPPButton();

       }//end of manageTimer

       protected void stopProgram(Object o, EventArgs e){

              Close();

       }//end of stopProgram

       public string setPPButton(){

              if (patek.Enabled){
                     return "Pause";
              }
              return "Resume";

       }//end of setPPButton

       public void setSlowButton(Object o, EventArgs e){

              patek.Interval = 1000;

              //slow_button.Checked = true;
              //fast_button.Checked = false;

       }//end of setSlowButton

       public void setFastButton(Object o, EventArgs e){

              patek.Interval = 500;

              //slow_button.Checked = false;
              //fast_button.Checked = true;

       }//end of setFastButton


}//end of stoplightuserinferface
