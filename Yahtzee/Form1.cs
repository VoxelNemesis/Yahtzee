namespace Yahtzee
{
    public partial class Yahtzee : Form
    {
        public Yahtzee()
        {
            // a pontszámolás vizsgálatát static boolokkal megcsinálni (ha vizsgálat után lehetséges, a button checkolható
            InitializeComponent();
            CKB_DiceKeeper1.Visible = false;
            CKB_DiceKeeper2.Visible = false;
            CKB_DiceKeeper3.Visible = false;
            CKB_DiceKeeper4.Visible = false;
            CKB_DiceKeeper5.Visible = false;

            DGV_ScoreBoard.Rows.Add("Ones");
            DGV_ScoreBoard.Rows.Add("Twos");
            DGV_ScoreBoard.Rows.Add("Threes");
            DGV_ScoreBoard.Rows.Add("Fours");
            DGV_ScoreBoard.Rows.Add("Fives");
            DGV_ScoreBoard.Rows.Add("Sixes");
            DGV_ScoreBoard.Rows.Add("Sum");
            DGV_ScoreBoard.Rows.Add("Bonus");
            DGV_ScoreBoard.Rows.Add("Three of a kind");
            DGV_ScoreBoard.Rows.Add("Four of a kind");
            DGV_ScoreBoard.Rows.Add("Full House");
            DGV_ScoreBoard.Rows.Add("Small straight");
            DGV_ScoreBoard.Rows.Add("Large straight");
            DGV_ScoreBoard.Rows.Add("Chance");
            DGV_ScoreBoard.Rows.Add("YAHTZEE");
            DGV_ScoreBoard.Rows.Add("TOTAL SCORE");
        }

        private static Random RNG = new Random();
        private static int[] StoreTMB = new int[5];

        private static bool DiceKeep1 = false;
        private static bool DiceKeep2 = false;
        private static bool DiceKeep3 = false;
        private static bool DiceKeep4 = false;
        private static bool DiceKeep5 = false;

        private void Yahtzee_Load(object sender, EventArgs e)
        {
        }

        // Dice Roller
        private static int RollsRemaining = 2;

        private static void kategoria()
        {
            //egyesek
            int sumegyesek = 0;
            foreach (int i in StoreTMB)
            {
                if (StoreTMB[i] == 1) sumegyesek += i;
            }
            //kettesek
            int sumkettesek = 0;
            foreach (int i in StoreTMB)
            {
                if (StoreTMB[i] == 2) sumkettesek += i;
            }
            //hármasok
            int sumharmasok = 0;
            foreach (int i in StoreTMB)
            {
                if (StoreTMB[i] == 3) sumharmasok += i;
            }
            // négyesek
            int sumnegyesek = 0;
            foreach (int i in StoreTMB)
            {
                if (StoreTMB[i] == 3) sumnegyesek += i;
            }
            // ötösök
            int sumotosok = 0;
            foreach (int i in StoreTMB)
            {
                if (StoreTMB[i] == 5) sumotosok += i;
            }
            // hatosok
            int sumhatosok = 0;
            foreach (int i in StoreTMB)
            {
                if (StoreTMB[i] == 6) sumotosok += i;
            }
            // Three of a kind
            int count = 1;
            int lepteto = 0;
            while (count != 3 && lepteto != StoreTMB.Length)
            {
                for (int i = 0; i < StoreTMB.Length; i++)
                {
                    for (int j = 0; j < StoreTMB.Length - 1; j++)
                    {
                        if (StoreTMB[i] == StoreTMB[j+1])
                        {
                            count++;
                        }
                    }
                }
                lepteto++;
            }
            int toksum = 0;
            foreach (var i in StoreTMB)
            {
                toksum += i;
            }
            // four of a kind
            int count4 = 1;
            int lepteto4 = 0;
            while (count != 4 && lepteto4 != StoreTMB.Length)
            {
                for (int i = 0; i < StoreTMB.Length; i++)
                {
                    for (int j = 0; j < StoreTMB.Length - 1; j++)
                    {
                        if (StoreTMB[i] == StoreTMB[j + 1])
                        {
                            count4++;
                        }
                    }
                }
                lepteto4++;
            }
            int foksum = 0;
            foreach (var i in StoreTMB)
            {
                foksum += i;
            }
            // full house
            int countfull = 1;
            int countfull2 = 1;
            int leptetofull = 0;
            int leptetofull2 = 0;
            while (countfull != 3 && leptetofull != StoreTMB.Length)
            {
                for (int i = 0; i < StoreTMB.Length; i++)
                {
                    for (int j = 0; j < StoreTMB.Length - 1; j++)
                    {
                        if (StoreTMB[i] == StoreTMB[j + 1])
                        {
                            countfull++;
                        }
                    }
                }
                leptetofull++;
            }
            
            while (countfull2 != 2 && leptetofull2 != StoreTMB.Length)
            {
                for (int i = 0; i < StoreTMB.Length; i++)
                {
                    for (int j = 0; j < StoreTMB.Length -1 ; j++)
                    {
                        if (StoreTMB[i] == StoreTMB[j + 1])
                        {
                            countfull2++;
                        }
                    }
                }
            }
            // ez esetén ide majd le kell írni, hogy a pont amit kapunk 25
            // small straight
            // 1 3 6 5 6
            Array.Sort(StoreTMB, (x, y) => y.CompareTo(x));
            int leptetostraightsmall =2;
            while (StoreTMB[leptetostraightsmall] == StoreTMB.Length)
            {
                for (int i = 0; i < StoreTMB.Length; i++)
                {
                    for (int j = 0; j < StoreTMB.Length - 1; j++)
                    {
                        if (StoreTMB[i] + 1 == StoreTMB[j + 1] && StoreTMB[i] + 2 == StoreTMB[j + 2])
                        {
                            //a bool true
                        }
                    }

                }
                leptetostraightsmall++;
            }
            // Large straight
            int leptetostraightlarge = 2;
            while (StoreTMB[leptetostraightlarge] == StoreTMB.Length)
            {
                for (int i = 0; i < StoreTMB.Length; i++)
                {
                    for (int j = 0; j < StoreTMB.Length - 1; j++)
                    {
                        if (StoreTMB[i] + 1 == StoreTMB[j + 1] && StoreTMB[i] + 2 == StoreTMB[j + 2] && StoreTMB[i] + 3 == StoreTMB[j + 3] && StoreTMB[i] + 4 == StoreTMB[j + 4])
                        {
                            //a bool true
                        }
                    }

                }
                leptetostraightlarge++;
            }
            // chance 
            //mindig true, pontok:
            int chancepont = 0;
            for (int i = 0; i < StoreTMB.Length; i++)
            {
                chancepont += StoreTMB[i];
            }
            //yahtzee
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
                //a bool true
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

            RollsRemaining--;
        }

        //Dice 1 Keeper
        private void CKB_DiceKeeper1_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep1 = true;
            if (CKB_DiceKeeper1.Checked == false)
                DiceKeep1 = false;
        }

        private void CKB_DiceKeeper2_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep2 = true;
            if (CKB_DiceKeeper2.Checked == false)
                DiceKeep2 = false;
        }

        private void CKB_DiceKeeper3_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep3 = true;
            if (CKB_DiceKeeper3.Checked == false)
                DiceKeep3 = false;
        }

        private void CKB_DiceKeeper4_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep4 = true;
            if (CKB_DiceKeeper4.Checked == false)
                DiceKeep4 = false;
        }

        private void CKB_DiceKeeper5_CheckedChanged(object sender, EventArgs e)
        {
            DiceKeep5 = true;
            if (CKB_DiceKeeper5.Checked == false)
                DiceKeep5 = false;
        }
    }
}