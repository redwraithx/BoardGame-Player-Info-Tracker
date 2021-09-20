using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGame_Player_Information_Tracker
{
    public partial class Form1 : Form
    {
        //PlayerTrackerInfo[] player;

        internal int player1HP = 0;
        internal int player2HP = 0;
        internal int player3HP = 0;
        internal int player4HP = 0;

        internal const int maxPlayerTickTrackingButtons = 4;
        internal const int maxGlobalTickTrackingButtons = 6;

        internal int player1CurrentTick = 0;
        internal int player2CurrentTick = 0;
        internal int player3CurrentTick = 0;
        internal int player4CurrentTick = 0;
        internal int globalCurrentTick = 0;

        //internal Color player1currentColor = Color.Green;
        //internal Color player2currentColor = Color.Green;
        //internal Color player3currentColor = Color.Green;
        //internal Color player4currentColor = Color.Green;


        // collections
        internal List<Button> globalButtons = new List<Button>();
        internal List<Button> player1Buttons = new List<Button>();
        internal List<Button> player2Buttons = new List<Button>();
        internal List<Button> player3Buttons = new List<Button>();
        internal List<Button> player4Buttons = new List<Button>();


        private void FillPlayer1ButtonListContainer()
        {
            player1Buttons.Add(Player1_Tick_Button1);
            player1Buttons.Add(Player1_Tick_Button2);
            player1Buttons.Add(Player1_Tick_Button3);
            player1Buttons.Add(Player1_Tick_Button4);
        }

        private void FillPlayer2ButtonListContainer()
        {
            player2Buttons.Add(Player2_Tick_Button1);
            player2Buttons.Add(Player2_Tick_Button2);
            player2Buttons.Add(Player2_Tick_Button3);
            player2Buttons.Add(Player2_Tick_Button4);
        }

        private void FillPlayer3ButtonListContainer()
        {
            player3Buttons.Add(Player3_Tick_Button1);
            player3Buttons.Add(Player3_Tick_Button2);
            player3Buttons.Add(Player3_Tick_Button3);
            player3Buttons.Add(Player3_Tick_Button4);
        }

        private void FillPlayer4ButtonListContainer()
        {
            player4Buttons.Add(Player4_Tick_Button1);
            player4Buttons.Add(Player4_Tick_Button2);
            player4Buttons.Add(Player4_Tick_Button3);
            player4Buttons.Add(Player4_Tick_Button4);
        }


        private void FillGlobalButtonListContainer()
        {
            globalButtons.Add(globalTickTracker_Button1);
            globalButtons.Add(globalTickTracker_Button2);
            globalButtons.Add(globalTickTracker_Button3);
            globalButtons.Add(globalTickTracker_Button4);
            globalButtons.Add(globalTickTracker_Button5);
            globalButtons.Add(globalTickTracker_Button6);
        }



        internal enum MovementCondition
        {
            Incapacitated = 0,
            Injured = 1,
            Walking = 2,
            Running = 3
        }

        internal enum HealthStatus
        {
            Poisoned = 0,
            Normal = 1,
            Regeneration = 2,
            QuickHeal = 3
        }


        public Form1()
        {
            InitializeComponent();

            //player = new PlayerTrackerInfo[4];

            InitializeVariables();

            // set values to defaults
            ResetValues();

            SetEndGameButtonStatus("false");

            SetDeadLabels();
            SetHPNumberLabels();



            
            



            //Player1_Tick_Button1.BackColor = player1currentColor;
            //Player1_Tick_Button2.BackColor = player1currentColor;
            //Player1_Tick_Button3.BackColor = player1currentColor;
            //Player1_Tick_Button4.BackColor = player1currentColor;


            //Player2_Tick_Button1.BackColor = player2currentColor;
            //Player2_Tick_Button2.BackColor = player2currentColor;
            //Player2_Tick_Button3.BackColor = player2currentColor;
            //Player2_Tick_Button4.BackColor = player2currentColor;

            //Player3_Tick_Button1.BackColor = player3currentColor;
            //Player3_Tick_Button2.BackColor = player3currentColor;
            //Player3_Tick_Button3.BackColor = player3currentColor;
            //Player3_Tick_Button4.BackColor = player3currentColor;

            //Player4_Tick_Button1.BackColor = player4currentColor;
            //Player4_Tick_Button2.BackColor = player4currentColor;
            //Player4_Tick_Button3.BackColor = player4currentColor;
            //Player4_Tick_Button4.BackColor = player4currentColor;

            // the tick count tracker for the Fire Tracking effecting all players
            FillPlayer1ButtonListContainer();
            UpdatePlayer1TickTrackingButtons();

            FillPlayer2ButtonListContainer();
            UpdatePlayer2TickTrackingButtons();

            FillPlayer3ButtonListContainer();
            UpdatePlayer3TickTrackingButtons();

            FillPlayer4ButtonListContainer();
            UpdatePlayer4TickTrackingButtons();

            FillGlobalButtonListContainer();
            UpdateGlobalTickTrackingButtons();

        }

        private void SetAndUpdateCurrentTick(object sender)
        {
            int tickValue = int.Parse((sender as Button).Text);

            SetPlayer1CurrentTickCount(tickValue);
            UpdatePlayer1TickTrackingButtons();
        }

        private void SetGlobalCurrentTickCount(int value)
        {
            globalCurrentTick += value;

            if (globalCurrentTick > maxGlobalTickTrackingButtons)
                globalCurrentTick = maxGlobalTickTrackingButtons;

            if (globalCurrentTick < 0)
                globalCurrentTick = 0;
        }

        private void SetPlayer1CurrentTickCount(int value)
        {
            //MessageBox.Show("player1currentTicks: " + player1CurrentTick + ", value in: " + value.ToString());
            player1CurrentTick += value; // could be + or - value

            if (player1CurrentTick > maxPlayerTickTrackingButtons)
                player1CurrentTick = maxPlayerTickTrackingButtons;

            if (player1CurrentTick < 0)
                player1CurrentTick = 0;
        }

        private void SetPlayer2CurrentTickCount(int value)
        {
            player2CurrentTick += value; // could be + or - value

            if (player2CurrentTick > maxPlayerTickTrackingButtons)
                player2CurrentTick = maxPlayerTickTrackingButtons;

            if (player2CurrentTick < 0)
                player2CurrentTick = 0;
        }

        private void SetPlayer3CurrentTickCount(int value)
        {
            player3CurrentTick += value; // could be + or - value

            if (player3CurrentTick > maxPlayerTickTrackingButtons)
                player3CurrentTick = maxPlayerTickTrackingButtons;

            if (player3CurrentTick < 0)
                player3CurrentTick = 0;
        }


        private void SetPlayer4CurrentTickCount(int value)
        {
            player4CurrentTick += value; // could be + or - value

            if (player4CurrentTick > maxPlayerTickTrackingButtons)
                player4CurrentTick = maxPlayerTickTrackingButtons;

            if (player4CurrentTick < 0)
                player4CurrentTick = 0;
        
        //private void SetPlayer4CurrentTickCount(string stringValue)
        //{
        //    int value = 0;

        //    if (stringValue == "P1 Add")
        //        value = 1;
        //    else
        //        value = -1;

        //    player4CurrentTick += value; // could be + or - value

        //    if (player4CurrentTick > maxPlayerTickTrackingButtons)
        //        player4CurrentTick = maxPlayerTickTrackingButtons;

        //    if (player4CurrentTick < 0)
        //        player4CurrentTick = 0;
        }

        private void UpdateGlobalTickTrackingButtons()
        {
            int counter = 0;
            foreach (Button globalButton in globalButtons)
            {
                if (counter >= globalCurrentTick)
                    globalButton.BackColor = Color.Green;
                else
                    globalButton.BackColor = Color.Red;

                counter++;
            }
        }

        private void UpdatePlayer1TickTrackingButtons()
        {
            // max of 4 buttons
            int counter = 0;
            foreach (Button p1Button in player1Buttons)
            {
                if (counter >= player1CurrentTick)
                    p1Button.BackColor = Color.Green;
                else
                    p1Button.BackColor = Color.Red;

                counter++;
            }
        }

        private void UpdatePlayer2TickTrackingButtons()
        {
            // max of 4 buttons
            int counter = 0;
            foreach (Button p2Button in player2Buttons)
            {
                if (counter >= player2CurrentTick)
                    p2Button.BackColor = Color.Green;
                else
                    p2Button.BackColor = Color.Red;

                counter++;
            }
        }

        private void UpdatePlayer3TickTrackingButtons()
        {
            // max of 4 buttons
            int counter = 0;
            foreach (Button p3Button in player3Buttons)
            {
                if (counter >= player3CurrentTick)
                    p3Button.BackColor = Color.Green;
                else
                    p3Button.BackColor = Color.Red;

                counter++;
            }
        }

        private void UpdatePlayer4TickTrackingButtons()
        {
            // max of 4 buttons
            int counter = 0;
            foreach (Button p4Button in player4Buttons)
            {
                if (counter >= player4CurrentTick)
                    p4Button.BackColor = Color.Green;
                else
                    p4Button.BackColor = Color.Red;

                counter++;
            }
        }

        //private void SetPlayer2TrackerButtons(Color value, int numberOfButtonsToSet)
        //{
        //    // max of 4 buttons
        //    int counter = 0;
        //    foreach (Button p2Button in player2Buttons)
        //    {
        //        if (counter >= numberOfButtonsToSet)
        //            break;

        //        p2Button.BackColor = value;

        //        counter++;
        //    }
        //}

        //private void SetPlayer3TrackerButtons(Color value, int numberOfButtonsToSet)
        //{
        //    // max of 4 buttons
        //    int counter = 0;
        //    foreach (Button p3Button in player3Buttons)
        //    {
        //        if (counter >= numberOfButtonsToSet)
        //            break;

        //        p3Button.BackColor = value;

        //        counter++;
        //    }
        //}

        //private void SetPlayer4TrackerButtons(Color value, int numberOfButtonsToSet)
        //{
        //    // max of 4 buttons
        //    int counter = 0;
        //    foreach (Button p4Button in player4Buttons)
        //    {
        //        if (counter >= numberOfButtonsToSet)
        //            break;

        //        p4Button.BackColor = value;

        //        counter++;
        //    }
        //}

        //private void UpdateGlobalTickTrackingButtons()
        //{
        //    // max of 4 buttons
        //    int counter = 0;
        //    foreach (Button globalButton in globalButtons)
        //    {
        //        if (counter >= maxGlobalTickTrackingButtons)
        //            globalButton.BackColor = Color.Green;
        //        else
        //            globalButton.BackColor = Color.Red;

        //        counter++;
        //    }
        //}




        private void InitializeVariables()
        {
            // fill starterHPComboBox 
            FillStartHPComboBox();

            // Fill all players Health Status and MovementCondition combobox values
            FillHealthStatusComboBoxes();
            FillMovementConditionComboBoxes();

            // set default hp value
            starterHP_ComboBox.SelectedIndex = 7;


        }

        private void FillStartHPComboBox()
        {
            for (int i = 5; i < 26; i++)
            {
                starterHP_ComboBox.Items.Add(i);
            }
        }

        private void FillMovementConditionComboBoxes()
        {
            // player 1
            player1MovementCondition_ComboBox.Items.Add(MovementCondition.Incapacitated);
            player1MovementCondition_ComboBox.Items.Add(MovementCondition.Injured);
            player1MovementCondition_ComboBox.Items.Add(MovementCondition.Walking);
            player1MovementCondition_ComboBox.Items.Add(MovementCondition.Running);

            // player 2
            player2MovementCondition_ComboBox.Items.Add(MovementCondition.Incapacitated);
            player2MovementCondition_ComboBox.Items.Add(MovementCondition.Injured);
            player2MovementCondition_ComboBox.Items.Add(MovementCondition.Walking);
            player2MovementCondition_ComboBox.Items.Add(MovementCondition.Running);

            // player 3
            player3MovementCondition_ComboBox.Items.Add(MovementCondition.Incapacitated);
            player3MovementCondition_ComboBox.Items.Add(MovementCondition.Injured);
            player3MovementCondition_ComboBox.Items.Add(MovementCondition.Walking);
            player3MovementCondition_ComboBox.Items.Add(MovementCondition.Running);

            // player 4
            player4MovementCondition_ComboBox.Items.Add(MovementCondition.Incapacitated);
            player4MovementCondition_ComboBox.Items.Add(MovementCondition.Injured);
            player4MovementCondition_ComboBox.Items.Add(MovementCondition.Walking);
            player4MovementCondition_ComboBox.Items.Add(MovementCondition.Running);
        }

        private void FillHealthStatusComboBoxes()
        {
            // player 1
            player1HealthStatus_ComboBox.Items.Add(HealthStatus.Poisoned);
            player1HealthStatus_ComboBox.Items.Add(HealthStatus.Normal);
            player1HealthStatus_ComboBox.Items.Add(HealthStatus.QuickHeal);
            player1HealthStatus_ComboBox.Items.Add(HealthStatus.Regeneration);

            // player 2
            player2HealthStatus_ComboBox.Items.Add(HealthStatus.Poisoned);
            player2HealthStatus_ComboBox.Items.Add(HealthStatus.Normal);
            player2HealthStatus_ComboBox.Items.Add(HealthStatus.QuickHeal);
            player2HealthStatus_ComboBox.Items.Add(HealthStatus.Regeneration);

            // player 3
            player3HealthStatus_ComboBox.Items.Add(HealthStatus.Poisoned);
            player3HealthStatus_ComboBox.Items.Add(HealthStatus.Normal);
            player3HealthStatus_ComboBox.Items.Add(HealthStatus.QuickHeal);
            player3HealthStatus_ComboBox.Items.Add(HealthStatus.Regeneration);

            // player 4
            player4HealthStatus_ComboBox.Items.Add(HealthStatus.Poisoned);
            player4HealthStatus_ComboBox.Items.Add(HealthStatus.Normal);
            player4HealthStatus_ComboBox.Items.Add(HealthStatus.QuickHeal);
            player4HealthStatus_ComboBox.Items.Add(HealthStatus.Regeneration);
        }

        private void ResetValues()
        {
            // set hp value as per the set value
            SetPlayersHPValues();

            // player1
            player1Name_TextBox.Text = "Change ME";
            player1MovementCondition_ComboBox.SelectedIndex = 2;
            player1HealthStatus_ComboBox.SelectedIndex = 1;

            UpdatePlayer1HPValue();


            // player2
            player2Name_TextBox.Text = "Change ME";
            player2MovementCondition_ComboBox.SelectedIndex = 2;
            player2HealthStatus_ComboBox.SelectedIndex = 1;

            UpdatePlayer2HPValue();


            // player3
            player3Name_TextBox.Text = "Change ME";
            player3MovementCondition_ComboBox.SelectedIndex = 2;
            player3HealthStatus_ComboBox.SelectedIndex = 1;

            UpdatePlayer3HPValue();


            // player4
            player4Name_TextBox.Text = "Change ME";
            player4MovementCondition_ComboBox.SelectedIndex = 2;
            player4HealthStatus_ComboBox.SelectedIndex = 1;

            UpdatePlayer4HPValue();



            // player1 update health displayed value
            player1HealthPointsText_Label.Text = player1HP.ToString();

            // player2 update health displayed value
            player2HealthPointsText_Label.Text = player2HP.ToString();

            // player1 update health displayed value
            player3HealthPointsText_Label.Text = player3HP.ToString();

            // player1 update health displayed value
            player4HealthPointsText_Label.Text = player4HP.ToString();


            //// player2
            //player2Name_TextBox.Text = "Change ME";
            //player2MovementCondition_ComboBox.SelectedIndex = 2;
            //player2HealthStatus_ComboBox.SelectedIndex = 1;
            //player2HealthPointsText_Label.Text = starterHP_ComboBox.Text;

            //// player3
            //player3Name_TextBox.Text = "Change ME";
            //player3MovementCondition_ComboBox.SelectedIndex = 2;
            //player3HealthStatus_ComboBox.SelectedIndex = 1;
            //player3HealthPointsText_Label.Text = starterHP_ComboBox.Text;

            //// player4
            //player4Name_TextBox.Text = "Change ME";
            //player4MovementCondition_ComboBox.SelectedIndex = 2;
            //player4HealthStatus_ComboBox.SelectedIndex = 1;
            //player4HealthPointsText_Label.Text = starterHP_ComboBox.Text;



            // reset death status for each character
            PlayerIsAlive("player1");
            PlayerIsAlive("player2");
            PlayerIsAlive("player3");
            PlayerIsAlive("player4");


            // Button Resets
            player1CurrentTick = 0;
            UpdatePlayer1TickTrackingButtons();
            player2CurrentTick = 0;
            UpdatePlayer2TickTrackingButtons();
            player3CurrentTick = 0;
            UpdatePlayer3TickTrackingButtons();
            player4CurrentTick = 0;
            UpdatePlayer4TickTrackingButtons();

            globalCurrentTick = 0;
            UpdateGlobalTickTrackingButtons();
        }


        //// reset players
        //private void UpdatePlayer1HPValue()
        //{
        //    int getHP;
        //    if (!int.TryParse(starterHP_ComboBox.Text, out getHP))
        //        MessageBox.Show("Error player 1 converting starterHP_ComboBox.Text in ResetValues Func");

        //    player1HP = getHP;
        //}


        // initial player setup
        private void UpdatePlayer1HPValue()
        {
            int getHP;
            if (!int.TryParse(starterHP_ComboBox.Text, out getHP))
                MessageBox.Show("Error player 1 converting starterHP_ComboBox.Text in ResetValues Func");

            player1HP = getHP;
        }

        private void UpdatePlayer2HPValue()
        {
            int getHP;
            if (!int.TryParse(starterHP_ComboBox.Text, out getHP))
                MessageBox.Show("Error player 2 converting starterHP_ComboBox.Text in ResetValues Func");

            player2HP = getHP;
        }

        private void UpdatePlayer3HPValue()
        {
            int getHP;
            if (!int.TryParse(starterHP_ComboBox.Text, out getHP))
                MessageBox.Show("Error player 3 converting starterHP_ComboBox.Text in ResetValues Func");

            player3HP = getHP;
        }

        private void UpdatePlayer4HPValue()
        {
            int getHP;
            if (!int.TryParse(starterHP_ComboBox.Text, out getHP))
                MessageBox.Show("Error player 4 converting starterHP_ComboBox.Text in ResetValues Func");

            player4HP = getHP;
        }

        private void setStartHPButton_Click(object sender, EventArgs e)
        {
            SetPlayersHPValues();
        }

        internal void SetPlayersHPValues()
        { 
            UpdatePlayer1HPValue();
            player1HealthPointsText_Label.Text = player1HP.ToString();

            UpdatePlayer2HPValue();
            player2HealthPointsText_Label.Text = player2HP.ToString();

            UpdatePlayer3HPValue();
            player3HealthPointsText_Label.Text = player3HP.ToString();

            UpdatePlayer4HPValue();
            player4HealthPointsText_Label.Text = player4HP.ToString();

        }

        private void resetToDefaults_Button_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void startTheGame_Button_Click(object sender, EventArgs e)
        {
            SetEndGameButtonStatus("true");

            SetStartGameButtonStatus("false");

            SetStartingHPButton("false");
            SetResetAppButton("false");

        }

        private void gameHasEnded_Button_Click(object sender, EventArgs e)
        {
            SetEndGameButtonStatus("false");

            SetStartGameButtonStatus("true");

            SetStartingHPButton("true");
            SetResetAppButton("true");
        }


        private void SetEndGameButtonStatus(string value)
        {
            if (value == "true")
                gameHasEnded_Button.Enabled = true;
            else
                gameHasEnded_Button.Enabled = false;
        }

        private void SetStartGameButtonStatus(string value)
        {
            if (value == "true")
                startTheGame_Button.Enabled = true;
            else
                startTheGame_Button.Enabled = false;
        }

        private void SetResetAppButton(string value)
        {
            if (value == "true")
                resetToDefaults_Button.Enabled = true;
            else
                resetToDefaults_Button.Enabled = false;
        }


        private void SetStartingHPButton(string value)
        {
            if (value == "true")
            {
                starterHP_ComboBox.Enabled = true;
                setStartHP_Button.Enabled = true;
            }
            else
            {
                starterHP_ComboBox.Enabled = false;
                setStartHP_Button.Enabled = false;
            }

        }

        
        private void SetHPNumberLabels()
        {
            player1HealthPointsText_Label.Enabled = true;
            player2HealthPointsText_Label.Enabled = true;
            player3HealthPointsText_Label.Enabled = true;
            player4HealthPointsText_Label.Enabled = true;

            player1HealthPointsText_Label.Visible = true;
            player2HealthPointsText_Label.Visible = true;
            player3HealthPointsText_Label.Visible = true;
            player4HealthPointsText_Label.Visible = true;

        }


        private void SetDeadLabels()
        {
            player1DeadText_Label.Visible = false;
            player2DeadText_Label.Visible = false;
            player3DeadText_Label.Visible = false;
            player4DeadText_Label.Visible = false;

            player1DeadText_Label.Enabled = false;
            player2DeadText_Label.Enabled = false;
            player3DeadText_Label.Enabled = false;
            player4DeadText_Label.Enabled = false;
        }


        private void Player1HealthButton_Click(object sender, EventArgs e)
        {
            string buttonString = (sender as Button).Text;
            //MessageBox.Show(s);

            Player1UpdateHealthPoints(buttonString);
        }

        private void Player2HealthButton_Click(object sender, EventArgs e)
        {
            string buttonString = (sender as Button).Text;
            //MessageBox.Show(s);

            Player2UpdateHealthPoints(buttonString);
        }

        private void Player3HealthButton_Click(object sender, EventArgs e)
        {
            string buttonString = (sender as Button).Text;
            //MessageBox.Show(s);

            Player3UpdateHealthPoints(buttonString);
        }

        private void Player4HealthButton_Click(object sender, EventArgs e)
        {
            string buttonString = (sender as Button).Text;
            //MessageBox.Show(s);

            Player4UpdateHealthPoints(buttonString);
        }


        private void Player1UpdateHealthPoints(string value)
        {
            // use current players health variable.
            // convert the value to a number and add them together.
            Player1UpdateHPandConvertValue(value);

            // check for player death
            if (player1HP <= 0)
            {
                PlayerIsDead("player1");

                return;
            }

            // update players hp visually in label
            player1HealthPointsText_Label.Text = player1HP.ToString();
        }

        private void Player1UpdateHPandConvertValue(string value)
        {
            int hpChangesBy;

            if (!int.TryParse(value, out hpChangesBy))
                MessageBox.Show("Error: Player1UpdateHPandConvertValue func by " + value);

            //MessageBox.Show("Updating health by: " + value);

            player1HP += hpChangesBy;
        }


        private void Player2UpdateHealthPoints(string value)
        {
            // use current players health variable.
            // convert the value to a number and add them together.
            Player2UpdateHPandConvertValue(value);

            // check for player death
            if (player2HP <= 0)
            {
                PlayerIsDead("player2");

                return;
            }

            // update players hp visually in label
            player2HealthPointsText_Label.Text = player2HP.ToString();
        }

        private void Player2UpdateHPandConvertValue(string value)
        {
            int hpChangesBy;

            if (!int.TryParse(value, out hpChangesBy))
                MessageBox.Show("Error: Player2UpdateHPandConvertValue func by " + value);

            player2HP += hpChangesBy;
        }


        private void Player3UpdateHealthPoints(string value)
        {
            // use current players health variable.
            // convert the value to a number and add them together.
            Player3UpdateHPandConvertValue(value);

            // check for player death
            if (player3HP <= 0)
            {
                PlayerIsDead("player3");

                return;
            }

            // update players hp visually in label
            player3HealthPointsText_Label.Text = player3HP.ToString();

        }

        private void Player3UpdateHPandConvertValue(string value)
        {
            int hpChangesBy;

            if (!int.TryParse(value, out hpChangesBy))
                MessageBox.Show("Error: Player3UpdateHPandConvertValue func by " + value);

            player3HP += hpChangesBy;
        }

        private void Player4UpdateHealthPoints(string value)
        {
            // use current players health variable.
            // convert the value to a number and add them together.
            Player4UpdateHPandConvertValue(value);

            // check for player death
            if (player4HP <= 0)
            {
                PlayerIsDead("player4");

                return;
            }

            // update players hp visually in label
            player4HealthPointsText_Label.Text = player4HP.ToString();
        }

        private void Player4UpdateHPandConvertValue(string value)
        {
            int hpChangesBy;

            if (!int.TryParse(value, out hpChangesBy))
                MessageBox.Show("Error: Player4UpdateHPandConvertValue func by " + value);

            player4HP += hpChangesBy;
        }



        private void PlayerIsDead(string value)
        {
            switch (value)
            {
                case "player1":
                    {
                        player1HealthPointsText_Label.Enabled = false;
                        player1HealthPointsText_Label.Visible = false;

                        player1DeadText_Label.Enabled = true;
                        player1DeadText_Label.Visible = true;

                        break;
                    }

                case "player2":
                    {
                        player2HealthPointsText_Label.Enabled = false;
                        player2HealthPointsText_Label.Visible = false;

                        player2DeadText_Label.Enabled = true;
                        player2DeadText_Label.Visible = true;

                        break;
                    }

                case "player3":
                    {
                        player3HealthPointsText_Label.Enabled = false;
                        player3HealthPointsText_Label.Visible = false;

                        player3DeadText_Label.Enabled = true;
                        player3DeadText_Label.Visible = true;

                        break;
                    }

                case "player4":
                    {
                        player4HealthPointsText_Label.Enabled = false;
                        player4HealthPointsText_Label.Visible = false;

                        player4DeadText_Label.Enabled = true;
                        player4DeadText_Label.Visible = true;

                        break;
                    }

                default:
                    MessageBox.Show(value + " has caused an error in the function PlayerIsDead");

                    break;
            }
        }

        private void PlayerIsAlive(string value)
        {
            switch (value)
            {
                case "player1":
                    {
                        player1HealthPointsText_Label.Enabled = true;
                        player1HealthPointsText_Label.Visible = true;

                        player1DeadText_Label.Enabled = false;
                        player1DeadText_Label.Visible = false;

                        break;
                    }

                case "player2":
                    {
                        player2HealthPointsText_Label.Enabled = true;
                        player2HealthPointsText_Label.Visible = true;

                        player2DeadText_Label.Enabled = false;
                        player2DeadText_Label.Visible = false;

                        break;
                    }

                case "player3":
                    {
                        player3HealthPointsText_Label.Enabled = true;
                        player3HealthPointsText_Label.Visible = true;

                        player3DeadText_Label.Enabled = false;
                        player3DeadText_Label.Visible = false;

                        break;
                    }

                case "player4":
                    {
                        player4HealthPointsText_Label.Enabled = true;
                        player4HealthPointsText_Label.Visible = true;

                        player4DeadText_Label.Enabled = false;
                        player4DeadText_Label.Visible = false;

                        break;
                    }

                default:
                    MessageBox.Show(value + " has caused an error in the function PlayerIsAlive");

                    break;
            }
        }

        private void PlayerTickButtonColorUpdate(object sender, EventArgs e)
        {

        }


        private void UpdatePlayerButtonColor(Button button, Color setColor)
        {
            if (setColor != Color.Green || setColor != Color.Red)
                setColor = Color.Green;

            if (button.BackColor == Color.Red)
                button.BackColor = Color.Green;
            else
                button.BackColor = Color.Red;
        }

        private void GlobalTickUpdater(object sender, EventArgs e)
        {
            string buttonTag = (sender as Button).Text;

            switch (buttonTag)
            {
                case "Add":
                    {
                        SetGlobalCurrentTickCount(1);
                        UpdateGlobalTickTrackingButtons();

                        break;
                    }
                case "Sub":
                    {
                        SetGlobalCurrentTickCount(-1);
                        UpdateGlobalTickTrackingButtons();

                        break;
                    }
                default:
                    MessageBox.Show("Error with GlobalTickUpdater with object: " + sender.ToString());

                    break;
            }

        }


        private void PlayerTickUpdater(object sender, EventArgs e)
        {
            string buttonTag = (sender as Button).Text;


            switch (buttonTag)
            {
                case "P1 Add":
                    {
                        SetPlayer1CurrentTickCount(1);
                        UpdatePlayer1TickTrackingButtons();

                        break;
                    }
                case "P1 Sub":
                    {
                        SetPlayer1CurrentTickCount(-1);
                        UpdatePlayer1TickTrackingButtons();

                        break;
                    }
                case "P2 Add":
                    {
                        SetPlayer2CurrentTickCount(1);
                        UpdatePlayer2TickTrackingButtons();

                        break;
                    }
                case "P2 Sub":
                    {
                        SetPlayer2CurrentTickCount(-1);
                        UpdatePlayer2TickTrackingButtons();

                        break;
                    }
                case "P3 Add":
                    {
                        SetPlayer3CurrentTickCount(1);
                        UpdatePlayer3TickTrackingButtons();

                        break;
                    }
                case "P3 Sub":
                    {
                        SetPlayer3CurrentTickCount(-1);
                        UpdatePlayer3TickTrackingButtons();

                        break;
                    }
                case "P4 Add":
                    {
                        SetPlayer4CurrentTickCount(1);
                        UpdatePlayer4TickTrackingButtons();

                        break;
                    }
                case "P4 Sub":
                    {
                        SetPlayer4CurrentTickCount(-1);
                        UpdatePlayer4TickTrackingButtons();

                        break;
                    }
                default:
                    {
                        MessageBox.Show("Error with PlayerTickUpdater");
                        break;
                    }
            }


            //for (int i = 4; i > 1; i--)
            //{
                
                        
               
            //}
        }
    }
}
