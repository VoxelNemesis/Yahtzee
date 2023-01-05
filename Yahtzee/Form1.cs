namespace Yahtzee
{
    public partial class Yahtzee : Form
    {
        public Yahtzee()
        {
            InitializeComponent();
            CKB_DiceKeeper1.Visible = false;
            CKB_DiceKeeper2.Visible = false;
            CKB_DiceKeeper3.Visible = false;
            CKB_DiceKeeper4.Visible = false;
            CKB_DiceKeeper5.Visible = false;
        }

        #region Globus variables

        private static Random RNG = new Random();
        private static int[] StoreTMB = new int[5];

        private static bool DiceKeep1 = false;
        private static bool DiceKeep2 = false;
        private static bool DiceKeep3 = false;
        private static bool DiceKeep4 = false;
        private static bool DiceKeep5 = false;

        private static bool Ones = false;
        private static bool Twos = false;
        private static bool Threes = false;
        private static bool Fours = false;
        private static bool Fives = false;
        private static bool Sixes = false;
        private static bool Bonus = false;
        private static bool ThreeOfAKind = false;
        private static bool FourOfAKind = false;
        private static bool FullHouse = false;
        private static bool SmallStraight = false;
        private static bool LargeStraight = false;
        private static bool Chance = false;
        private static bool YahtzeePont = false;

        #endregion Globus variables

        private void Yahtzee_Load(object sender, EventArgs e)
        {
        }

        // Dice Roller
        private static int RollsRemaining = 2;

        private static void Checker()
        {
            Array.Sort(StoreTMB, (x, y) => y.CompareTo(x));
            foreach (int i in StoreTMB)
            {
                if (i == 1) Ones = true;
            }

            //Kettes Ellenõrzés

            foreach (int i in StoreTMB)
            {
                if (i == 2) Twos = true;
            }
            //hármasok

            foreach (int i in StoreTMB)
            {
                if (i == 3) Threes = true;
            }
            // négyesek

            foreach (int i in StoreTMB)
            {
                if (i == 4) Fours = true;
            }
            // ötösök

            foreach (int i in StoreTMB)
            {
                if (i == 5) Fives = true;
            }
            // hatosok

            foreach (int i in StoreTMB)
            {
                if (i == 6) Sixes = true;
            }
            //Three of a kind
            int count = 1;

            for (int i = 0; i < StoreTMB.Length; i++)
            {
                for (int j = 0; j < StoreTMB.Length - 1; j++)
                {
                    if (StoreTMB[i] == StoreTMB[j + 1])
                    {
                        count++;
                    }
                }
                if (count > 3)
                {
                    ThreeOfAKind = true;
                }
                else count = 1;
            }

            //Four of a kind
            int countFour = 1;
            for (int i = 0; i < StoreTMB.Length; i++)
            {
                for (int j = 0; j < StoreTMB.Length - 1; j++)
                {
                    if (StoreTMB[i] == StoreTMB[j + 1])
                    {
                        count++;
                    }
                }
                if (count > 4)
                {
                    ThreeOfAKind = true;
                }
                else count = 1;
            }
            // Full house
            int countPair = 1;
            bool pair = false;
            for (int i = 0; i < StoreTMB.Length; i++)
            {
                for (int j = 0; j < StoreTMB.Length - 1; j++)
                {
                    if (StoreTMB[i] == StoreTMB[j + 1])
                    {
                        count++;
                    }
                }
                if (count > 2)
                {
                    pair = true;
                }
                else count = 1;
            }
            if (pair == true && ThreeOfAKind == true)
            {
                FullHouse = true;
            }
            //small straight

            int leptetostraightsmall = 2;
            while (StoreTMB[leptetostraightsmall] != StoreTMB.Length)
            {
                for (int i = 0; i < StoreTMB.Length; i++)
                {
                    for (int j = 0; j < StoreTMB.Length - 1; j++)
                    {
                        if (StoreTMB[i] + 1 == StoreTMB[j + 1] && StoreTMB[i] + 2 == StoreTMB[j + 2])
                        {
                            SmallStraight = true;
                        }
                    }
                }
                leptetostraightsmall++;
            }

            // Large Straight
            int leptetostraightlarge = 2;
            while (StoreTMB[leptetostraightlarge] == StoreTMB.Length)
            {
                for (int i = 0; i < StoreTMB.Length; i++)
                {
                    for (int j = 0; j < StoreTMB.Length - 1; j++)
                    {
                        if (StoreTMB[i] + 1 == StoreTMB[j + 1] && StoreTMB[i] + 2 == StoreTMB[j + 2] && StoreTMB[i] + 3 == StoreTMB[j + 3] && StoreTMB[i] + 4 == StoreTMB[j + 4])
                        {
                            LargeStraight = true;
                        }
                    }
                }
                leptetostraightlarge++;
            }
            // chance
            //mindig true, pontok:
            Chance = true;

            int countyahtzee = 1;
            for (int i = 1; i < StoreTMB.Length; i++)
            {
                if (StoreTMB[i] == StoreTMB[i - 1])
                {
                    countyahtzee++;
                }
            }
            if (countyahtzee == 5)
            {
                YahtzeePont = true;
            }
            //pont = 50
        }

        private void BTN_Roll_Click(object sender, EventArgs e)
        {
            // Checks if out of rolls
            if (RollsRemaining == 0)
            {
                BTN_Roll.Enabled = false;
                BTN_Roll.Text = "Out Of Rolls";
            }

            for (int i = 0; i < StoreTMB.Length; i++)
            {
                StoreTMB[i] = RNG.Next(1, 7);
            }
            CKB_DiceKeeper1.Visible = true;
            CKB_DiceKeeper2.Visible = true;
            CKB_DiceKeeper3.Visible = true;
            CKB_DiceKeeper4.Visible = true;
            CKB_DiceKeeper5.Visible = true;

            #region DICE

            //Dice 1 Faces

            if (DiceKeep1 == false)
            {
                if (StoreTMB[0] == 1)
                {
                    PCB_Dice1.Image = Image.FromFile($@"..\..\..\RES\Dice1.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[0] == 2)
                {
                    PCB_Dice1.Image = Image.FromFile(@"..\..\..\RES\Dice2.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[0] == 3)
                {
                    PCB_Dice1.Image = Image.FromFile(@"..\..\..\RES\Dice3.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[0] == 4)
                {
                    PCB_Dice1.Image = Image.FromFile(@"..\..\..\RES\Dice4.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[0] == 5)
                {
                    PCB_Dice1.Image = Image.FromFile(@"..\..\..\RES\Dice5.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[0] == 6)
                {
                    PCB_Dice1.Image = Image.FromFile(@"..\..\..\RES\Dice6.png");
                    PCB_Dice1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            //Dice 2 Faces
            if (DiceKeep2 == false)
            {
                if (StoreTMB[1] == 1)
                {
                    PCB_Dice2.Image = Image.FromFile($@"..\..\..\RES\Dice1.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[1] == 2)
                {
                    PCB_Dice2.Image = Image.FromFile(@"..\..\..\RES\Dice2.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[1] == 3)
                {
                    PCB_Dice2.Image = Image.FromFile(@"..\..\..\RES\Dice3.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[1] == 4)
                {
                    PCB_Dice2.Image = Image.FromFile(@"..\..\..\RES\Dice4.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[1] == 5)
                {
                    PCB_Dice2.Image = Image.FromFile(@"..\..\..\RES\Dice5.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[1] == 6)
                {
                    PCB_Dice2.Image = Image.FromFile(@"..\..\..\RES\Dice6.png");
                    PCB_Dice2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            //Dice 3 Faces
            if (DiceKeep3 == false)
            {
                if (StoreTMB[2] == 1)
                {
                    PCB_Dice3.Image = Image.FromFile($@"..\..\..\RES\Dice1.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[2] == 2)
                {
                    PCB_Dice3.Image = Image.FromFile(@"..\..\..\RES\Dice2.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[2] == 3)
                {
                    PCB_Dice3.Image = Image.FromFile(@"..\..\..\RES\Dice3.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[2] == 4)
                {
                    PCB_Dice3.Image = Image.FromFile(@"..\..\..\RES\Dice4.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[2] == 5)
                {
                    PCB_Dice3.Image = Image.FromFile(@"..\..\..\RES\Dice5.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[2] == 6)
                {
                    PCB_Dice3.Image = Image.FromFile(@"..\..\..\RES\Dice6.png");
                    PCB_Dice3.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            //Dice 4 Faces
            if (DiceKeep4 == false)
            {
                if (StoreTMB[3] == 1)
                {
                    PCB_Dice4.Image = Image.FromFile($@"..\..\..\RES\Dice1.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[3] == 2)
                {
                    PCB_Dice4.Image = Image.FromFile(@"..\..\..\RES\Dice2.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[3] == 3)
                {
                    PCB_Dice4.Image = Image.FromFile(@"..\..\..\RES\Dice3.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[3] == 4)
                {
                    PCB_Dice4.Image = Image.FromFile(@"..\..\..\RES\Dice4.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[3] == 5)
                {
                    PCB_Dice4.Image = Image.FromFile(@"..\..\..\RES\Dice5.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[3] == 6)
                {
                    PCB_Dice4.Image = Image.FromFile(@"..\..\..\RES\Dice6.png");
                    PCB_Dice4.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            //Dice 5 Faces
            if (DiceKeep5 == false)
            {
                if (StoreTMB[4] == 1)
                {
                    PCB_Dice5.Image = Image.FromFile($@"..\..\..\RES\Dice1.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[4] == 2)
                {
                    PCB_Dice5.Image = Image.FromFile(@"..\..\..\RES\Dice2.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[4] == 3)
                {
                    PCB_Dice5.Image = Image.FromFile(@"..\..\..\RES\Dice3.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[4] == 4)
                {
                    PCB_Dice5.Image = Image.FromFile(@"..\..\..\RES\Dice4.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[4] == 5)
                {
                    PCB_Dice5.Image = Image.FromFile(@"..\..\..\RES\Dice5.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (StoreTMB[4] == 6)
                {
                    PCB_Dice5.Image = Image.FromFile(@"..\..\..\RES\Dice6.png");
                    PCB_Dice5.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            #endregion DICE

            Checker();
            RollsRemaining--;
        }

        //Dice 1 Keeper
        private void CKB_DiceKeeper1_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep1 = true;
            if (CKB_DiceKeeper1.Checked == false)
                DiceKeep1 = false;
        }

        //Dice 2 Keeper
        private void CKB_DiceKeeper2_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep2 = true;
            if (CKB_DiceKeeper2.Checked == false)
                DiceKeep2 = false;
        }

        //Dice 3 Keeper
        private void CKB_DiceKeeper3_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep3 = true;
            if (CKB_DiceKeeper3.Checked == false)
                DiceKeep3 = false;
        }

        //Dice 4 Keeper
        private void CKB_DiceKeeper4_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep4 = true;
            if (CKB_DiceKeeper4.Checked == false)
                DiceKeep4 = false;
        }

        //Dice 5 Keeper
        private void CKB_DiceKeeper5_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep5 = true;
            if (CKB_DiceKeeper5.Checked == false)
                DiceKeep5 = false;
        }

        private void BTN_Ones_Click(object sender, EventArgs e)
        {
        }

        private void BTN_Twos_Click(object sender, EventArgs e)
        {
        }
    }
}