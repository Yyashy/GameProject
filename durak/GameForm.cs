//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)


using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using Label = System.Windows.Forms.Label;


namespace durak
{
    public partial class GameForm : Form
    {
        private const int CardWidth = 96;
        private const int CardHeight = 128;
        private const int CardSpacing = 30;
        private Card currentCard=null;

        private Game game;
        List<Card> cardsOnTable = new List<Card>();
        List<Card>finishedCards=new List<Card>();
        private int dummycardleft=0;

        private PictureBox movingCardPictureBox;
        private Timer animationTimer;
        private const int animationSpeed = 50; //
        Random random=new Random();
        private void AnimateCard(PictureBox p, Panel sourcePanel, Panel destinationPanel,bool flag=false)
        {
            // Create a PictureBox control for the moving card
            Card card = p.Tag as Card;
            movingCardPictureBox = new PictureBox();
            movingCardPictureBox.Size = new Size(CardWidth, CardHeight);
            movingCardPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            movingCardPictureBox.Image = GetCardImage(card); // Assume GetCardImage() returns the image for the given card
            movingCardPictureBox.Tag = card; // Store the corresponding Card object in the Tag property
            movingCardPictureBox.Left = p.Left+sourcePanel.Left;
            movingCardPictureBox.Top = sourcePanel.Top + (sourcePanel.Height - CardHeight) / 2;

            // Add the PictureBox control to the form
            this.Controls.Add(movingCardPictureBox);

            // Initialize the Timer for the animation
            animationTimer = new Timer();
            animationTimer.Interval = animationSpeed;
            if(flag==false)
            {
                animationTimer.Tick += AnimationTimer_Tick;
            }else
            {
                animationTimer.Tick += AnimationTimer_Tick;
            }
            
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Update the position of the moving card PictureBox
            
            int dx = tableHandPanel.Left - movingCardPictureBox.Left +(int)Math.Ceiling(cardsOnTable.Count/2.0-1)*(CardWidth);
         
            int dy = tableHandPanel.Top - movingCardPictureBox.Top;

            // Calculate the distance to the target
            float distance = (float)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

            float ux = dx / distance;
            float uy = dy / distance;
            // Limit movement based on speed and distance
            float movementX = ux*15+1;
            float movementY = uy*15+1;

            // Update the position of the moving card PictureBox using the unit vector components for smooth movement
            movingCardPictureBox.Left += (int)movementX;
            movingCardPictureBox.Top += (int)movementY;
            movingCardPictureBox.BringToFront();
            Debug.Print(movingCardPictureBox.Top.ToString(), movingCardPictureBox.Left.ToString());
            // Check if the moving card PictureBox has reached the destination
            if (Math.Abs(distance) <= 15)
            {
                // Stop the timer when close enough to the target
                animationTimer.Stop();

                // Remove the moving card PictureBox from the form
                this.Controls.Remove(movingCardPictureBox);

                // Add the moving card PictureBox to the table panel
                tableHandPanel.Controls.Add(movingCardPictureBox);
                UpdateUI();
                ComputerTurn();
                determinWinner();
            }

           

            
        }

        int GetAbsoluteLeft(Control control)
        {
            // Convert the control's client coordinates to screen coordinates
            Point screenPoint = control.PointToScreen(new Point(control.Left, control.Top));

            // Convert the screen coordinates to client coordinates of the form
            Point formPoint = this.PointToClient(screenPoint);

            // Return the absolute left position relative to the form
            return formPoint.X;
        }

        public GameForm()
        {
            InitializeComponent();
            game = new Game();
           
        }

        private void InitializeGameUI()
        {
            // Display player's hand
            DisplayPlayerHand(game.player.Hand);

            // Display computer's hand (face down)
            DisplayComputerHand(game.computer.Hand);

            // Display trump card
            DisplayTrumpCard(game.trumpCard);
            DisplayTableCards();

            // Display attacker and defender
            DisplayAttackerDefender();
            DisplayFinishedCards();
            // Other UI elements as needed
        }
        private void DisplayTableCards()
        {
            tableHandPanel.Width = CardWidth * cardsOnTable.Count + CardSpacing * (cardsOnTable.Count ); // Total width of cards + spacing
            tableHandPanel.Width = tableHandPanel.Width / 2+CardWidth+CardSpacing;
            tableHandPanel.Height = CardHeight + 20; // Card height + some padding
            tableHandPanel.Location = new Point((this.ClientSize.Width - tableHandPanel.Width) / 2, (this.ClientSize.Height - tableHandPanel.Height)/2); // Center horizontally and position near the bottom of the form

            // Clear existing controls from the playerHandPanel
            tableHandPanel.Controls.Clear();
            int i = cardsOnTable.Count / 2;

            int idx = 0;
            int leftpos;
            foreach(Card card in cardsOnTable)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = GetCardImage(card);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                pictureBox.Width = CardWidth;
                pictureBox.Height = CardHeight;
                leftpos = (CardWidth + CardSpacing) * (idx / 2)+CardSpacing;
                pictureBox.Top = 0;
               
                if (idx % 2 == 0) // First card in the pair
                {
                    pictureBox.Left = leftpos;
                   
                   
                    
                }
                else // Second card in the pair
                {
                    pictureBox.Left = leftpos - 20;
                    pictureBox.BringToFront();
                    
                }
                idx = idx + 1;
                // pictureBox.Top = this.ClientSize.Height - CardHeight - 10; // Position at the bottom
                pictureBox.Top = 0;
                pictureBox.Tag = card;


                tableHandPanel.Controls.Add(pictureBox);
                pictureBox.BringToFront() ;
                dummycardleft = GetAbsoluteLeft(pictureBox);
            }

            if(cardsOnTable.Count%2==0)
            {
                //display dummy card
                PictureBox dummyCardArea = new PictureBox();
                dummyCardArea.BackColor = Color.Yellow;
                dummyCardArea.Width = CardWidth;
                dummyCardArea.Height = CardHeight;
                
                dummyCardArea.Left = i * (CardWidth + CardSpacing);
                dummyCardArea.Top = 0;
                
                tableHandPanel.Controls.Add(dummyCardArea);
                dummycardleft = GetAbsoluteLeft(dummyCardArea);

            }

            dummycardleft += tableHandPanel.Left;
        }
        private void DisplayPlayerHand(List<Card> hand)
        {
            // Display player's hand
            playerHandPanel.Width = CardWidth * game.player.Hand.Count + CardSpacing * (game.player.Hand.Count - 1); // Total width of cards + spacing
            playerHandPanel.Height = CardHeight + 20; // Card height + some padding
            playerHandPanel.Location = new Point((this.ClientSize.Width - playerHandPanel.Width) / 2, this.ClientSize.Height - playerHandPanel.Height - 20); // Center horizontally and position near the bottom of the form

            // Clear existing controls from the playerHandPanel
            playerHandPanel.Controls.Clear();

            for (int i = 0; i < hand.Count; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = GetCardImage(hand[i]);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                
              
                pictureBox.Width = CardWidth;
                pictureBox.Height = CardHeight;
                pictureBox.Left = i * (CardWidth + CardSpacing);
                // pictureBox.Top = this.ClientSize.Height - CardHeight - 10; // Position at the bottom
                pictureBox.Top = 0;
                pictureBox.Tag = hand[i];
                pictureBox.Click += player_card_click;
                
                playerHandPanel.Controls.Add(pictureBox);
            }
        }

        private void DisplayComputerHand(List<Card> hand)
        {
            // Display computer's hand (face down)
            computerHandPanel.Width = CardWidth * game.computer.Hand.Count + CardSpacing * (game.computer.Hand.Count - 1); // Total width of cards + spacing
            computerHandPanel.Height = CardHeight + 20; // Card height + some padding
            computerHandPanel.Location = new Point((this.ClientSize.Width - computerHandPanel.Width) / 2, 10); // Center horizontally and position near the bottom of the form

            // Clear existing controls from the playerHandPanel
            computerHandPanel.Controls.Clear();

            int totalWidth = computerHandPanel.Width;
            int totalCardWidth = (CardWidth + CardSpacing) * hand.Count - CardSpacing; // Total width of all cards including spacing
            int startX = totalWidth - totalCardWidth - 10;

            for (int i = 0; i < hand.Count; i++)
            {
                PictureBox pictureBox = new PictureBox();
                  pictureBox.Image = Properties.Resources.cardBack_black; // Placeholder image for face-down card
// pictureBox.Image = GetCardImage(hand[i]);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = CardWidth;
                pictureBox.Height = CardHeight;
                pictureBox.Left =  i * (CardWidth + CardSpacing);
                pictureBox.Top = 0; // Position at the top
                pictureBox.Tag = hand[i];
               computerHandPanel.Controls.Add(pictureBox);
            }
        }

        private bool isVaildTurnAsDefender(Card card)
        {

          

            if(card.Suit==currentCard.Suit && card.Rank>currentCard.Rank)
            {
                return true;
            }
            if(card.Suit==game.trumpCard.Suit)
            {
                return true;
            }
            return false;

        }
        private bool isVaildTurnAsAttacker(Card card)
        {
            
            if(cardsOnTable.Count%2==0)
            {
                currentCard = null;
            }
            if(cardsOnTable.Count==0)
            {
                currentCard = card;
                return true;
            }

            if(currentCard!=null)
            {
                if(card.Suit==game.trumpCard.Suit)
                {
                    currentCard = card;
                    return true;
                }
                if(card.Suit==currentCard.Suit && card.Rank > currentCard.Rank)
                {
                    currentCard = card;
                    return true;
                }
                return false;
            }

            foreach(Card c in cardsOnTable)
            {
                if(c.Rank==card.Rank)
                {
                    currentCard = card; 
                    return true;
                }
            }
            return false;

        }
        private void player_card_click(object sender, EventArgs e)
        {
            if(game.player.isTurn==false)
            {
                return;
            }
            if(String.Compare(game.player.Role,"Attacker")==0)
            {
                PictureBox p = sender as PictureBox;
                Card card = p.Tag as Card;
                if (isVaildTurnAsAttacker(card) == false)
                {
                    return;
                }
                p.Visible = false;
                AnimateCard(p, playerHandPanel, tableHandPanel);
                game.player.Hand.Remove(card);
                game.player.isTurn = false;
                game.computer.isTurn = true;
                cardsOnTable.Add(card);
            } else
            {
                PictureBox p = sender as PictureBox;
                Card card = p.Tag as Card;
                if (isVaildTurnAsDefender(card) == false)
                {
                    return;
                }
                p.Visible = false;
                AnimateCard(p, playerHandPanel, tableHandPanel);
                game.player.Hand.Remove(card);
                game.player.isTurn = false;
                game.computer.isTurn = true;
                cardsOnTable.Add(card);

            }
            
            //ComputerTurn();
        }
        private void DisplayTrumpCard(Card trumpCard)
        {

            // if theer is more cards to deal then display card back here
            if(trumpPanel.Controls.Count==0 || game.deck.cards.Count<2)
            {
                trumpPanel.Controls.Clear();
                trumpPanel.Width = 150;
                trumpPanel.Height = 150;
                trumpPanel.Left = 25;
                trumpPanel.Top = (this.ClientSize.Height - CardHeight) / 2;
                if (game.deck.cards.Count >= 2)
                {
                    PictureBox p = new PictureBox();
                    p.Image = Properties.Resources.cardBack_black; // Placeholder image for face-down card
                    p.SizeMode = PictureBoxSizeMode.Zoom;
                    p.Width = CardWidth;
                    p.Height = CardHeight;
                    p.Left = 5;
                    p.Top = 0;
                    trumpPanel.Controls.Add(p);
                }

                if(game.deck.cards.Count >= 1)
                {
                    RotatablePictureBox pictureBox = new RotatablePictureBox();
                    pictureBox.Image = GetCardImage(trumpCard);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = 128;
                    pictureBox.Height = 128;
                    pictureBox.Left = 5;
                    pictureBox.Top = 5;
                    pictureBox.RotationAngle = 90;
                    trumpPanel.Controls.Add(pictureBox);

                }

            }
           

            

        }

        private void DisplayFinishedCards()
        {
            finishedCardPanel.Controls.Clear();
            //finishedCardPanel.BackColor = Color.Red;

            for (int i = 0; i < finishedCards.Count; i++)
            {
                RotatablePictureBox pictureBox = new RotatablePictureBox();
                pictureBox.Image = Properties.Resources.cardBack_black;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;


                pictureBox.Width = 128;
                pictureBox.Height = 128;
                pictureBox.Left = 5;
                // pictureBox.Top = this.ClientSize.Height - CardHeight - 10; // Position at the bottom
                pictureBox.Top = 0;
                pictureBox.Tag = finishedCards[i];
                pictureBox.RotationAngle = i % 2 == 0 ? 90 : 0;

                finishedCardPanel.Controls.Add(pictureBox);
            }
        }
        private void DisplayAttackerDefender()
        {
            // Display attacker and defender
            game.DetermineAttackerAndDefender(game.player.Hand, game.computer.Hand);
            bool playerIsAttacker = false;
            if(string.Compare(game.player.Role, "Attacker")==0)
            {
                playerIsAttacker = true;
                game.player.isTurn = true;
            } else
            {
                game.computer.isTurn = true;
            }

            
            int fontSize = 20;
            Label playerLabel = new Label();
            Font tempFont = new Font(playerLabel.Font.FontFamily, fontSize);
            playerLabel.Font = tempFont;

            playerLabel.Text = playerIsAttacker ? "Player (Attacker)" : "Player (Defender)";
            playerLabel.AutoSize = true;
            playerLabel.ForeColor = playerIsAttacker ? Color.Green : Color.Red;


            // this.Controls.Add(playerLabel);
            playerStatus.Controls.Add(playerLabel);
            playerLabel.Left = 10;
            playerLabel.Top = 0;
            playerStatus.Top = playerHandPanel.Top-playerStatus.Height - 10;
            playerStatus.Left = 0;
            playerStatus.Width = playerLabel.Width + 10;

            Label computerLabel = new Label();
            computerLabel.Font = tempFont;
            computerLabel.Text = playerIsAttacker ? "Computer (Defender)" : "Computer (Attacker)";
            computerLabel.AutoSize = true;
            computerLabel.ForeColor = playerIsAttacker ? Color.Red : Color.Green;
           
            
           computerStatus.Controls.Add(computerLabel);
            computerStatus.Width = computerLabel.Width + 10;
            computerStatus.Left = this.ClientSize.Width - computerLabel.Width - 50;
            computerStatus.Top = playerHandPanel.Top -playerStatus.Height- 10;
            computerLabel.Left = 20;
            computerLabel.Top = 0;
        }

        private Image GetCardImage(Card card)
        {
            // Placeholder logic to get card image based on card details
            // You need to replace this with your actual card image retrieval logic
            // For now, let's assume you have a method GetCardImageFromResources to get card images from resources
            return (Image)Properties.Resources.ResourceManager.GetObject(card.GetImagePath());
        }

    
        private void UpdateUI()
        {
            DisplayPlayerHand(game.player.Hand);
            DisplayComputerHand(game.computer.Hand);
            DisplayTableCards();
            updateStatusLabel();
                
            
            
           
        }

        private void updateStatusLabel()
        {
            if(game.player.isTurn)
            {
                statuslabel.Text = "Status: Player Turn";
            } else
            {
                statuslabel.Text = "Status: Computer Turn";
            }

            deckstatus.Text = "Cards Left on Deck: " + game.deck.cards.Count.ToString();
        }

        private void determinWinner()
        {
            if(game.player.Hand.Count>0 && game.computer.Hand.Count>0){

            } else if(game.computer.Hand.Count==0 && game.player.Hand.Count>0) {
                statuslabel.Text = "Computer Wins!!!";
                game.computer.isTurn = false;
                game.player.isTurn = false;


            }else if(game.player.Hand.Count==0 && game.computer.Hand.Count>0)
            {
                statuslabel.Text = "Player Wins!!!";
                game.computer.isTurn = false;
                game.player.isTurn = false;
            } else if(game.player.Hand.Count==0 && game.computer.Hand.Count==0)
            {
                statuslabel.Text = "Match Draw!!!";
                game.computer.isTurn = false;
                game.player.isTurn = false;
            }
        }
        private void GameForm_Load(object sender, EventArgs e)
        {
            //finishedCards.AddRange(game.deck.Deal(5));
           
            InitializeGameUI();
            btnFinish.Left = tableHandPanel.Left;
            btnFinish.Top = tableHandPanel.Top + tableHandPanel.Height + 20;

            btnTakeCards.Left = btnFinish.Left+btnFinish.Width+30;
            btnTakeCards.Top = tableHandPanel.Top + tableHandPanel.Height + 20;

            finishedCardPanel.Width =  (CardWidth + CardSpacing+20);
            finishedCardPanel.Height = CardHeight;// + 10;
            finishedCardPanel.Top = playerHandPanel.Top - finishedCardPanel.Height - 10;// tableHandPanel.Top+CardHeight+50;
            finishedCardPanel.Left = tableHandPanel.Left - 3 * (CardWidth + CardSpacing);
           // finishedCardPanel.BackColor = Color.Red;
            statuslabel.Text = "Status: Player Turn";
            statuslabel.Top = computerHandPanel.Top + computerHandPanel.Height + 30;
            statuslabel.Left = 10;
            statuslabel.Text = "";
            deckstatus.Top= computerHandPanel.Top + computerHandPanel.Height + 30;
            deckstatus.Left = this.ClientSize.Width - deckstatus.Width - 50;
            updateStatusLabel();
            trumplabel.Text = "Trump: " + game.trumpCard.Suit;
            trumplabel.Top = deckstatus.Top + deckstatus.Height + 20;
            trumplabel.Left = deckstatus.Left;
            ComputerTurn();

          

        }

      
        private void ComputerTurn()
        {

            Card tempcard;
            if (game.computer.isTurn)
            {
                if(game.computer.Role== "Defender")
                {
                    Card card = SelectCardAsDefender();
                    if(card != null)
                    {
                        cardsOnTable.Add(card);
                        game.computer.Hand.Remove(card);
                        game.computer.isTurn = false;
                        game.player.isTurn = true;
                        
                        foreach(Control p in computerHandPanel.Controls)
                        {
                            if(p is PictureBox)
                            {
                                tempcard = p.Tag as Card;
                                if(tempcard.Suit==card.Suit && tempcard.Rank==card.Rank)
                                {
                                    p.Visible = false;
                                    AnimateCard(p as PictureBox, computerHandPanel, tableHandPanel);
                                    break;
                                }
                            }
                        }

                    } else
                    {
                        MessageBox.Show("unable to defend");
                        foreach(Card c in cardsOnTable)
                        {
                            game.computer.Hand.Add(c);
                        }
                        cardsOnTable.Clear();
                        game.player.isTurn = true;
                        game.computer.isTurn = false;
                        UpdateUI();
                    }
                } else {
                    currentCard = null;
                    Card tempCard = game.computer.Hand.OrderBy(card => card.Rank).First();
                    if(cardsOnTable.Count==0)
                    {
                        currentCard = tempCard;
                    } else {
                        foreach(Card c in cardsOnTable)
                        {
                            tempCard = game.computer.Hand.FirstOrDefault(mCard => mCard.Rank == c.Rank);
                            if(tempCard!=null)
                            {
                                currentCard = tempCard;
                                break;
                            }
                        }
                    }
                    if(currentCard!=null)
                    {
                        game.computer.Hand.Remove(currentCard);
                        cardsOnTable.Add(currentCard);
                        game.computer.isTurn = false;
                        game.player.isTurn = true;
                        foreach (Control p in computerHandPanel.Controls)
                        {
                            if (p is PictureBox)
                            {
                                tempcard = p.Tag as Card;
                                if (tempcard.Suit == currentCard.Suit && tempcard.Rank == currentCard.Rank)
                                {
                                    p.Visible = false;
                                    AnimateCard(p as PictureBox, computerHandPanel, tableHandPanel);
                                    break;
                                }
                            }
                        }
                    } else
                    {
                        switchRoles();
                        doFinishCards();
                        ComputerTurn();
                        determinWinner();
                    }
                 
                }
            }
        }

        private Card SelectCardAsDefender()
        {
            // Initialize variables to keep track of the best card to play
            Card bestCardToPlay = null;
            int lowestRankAboveCurrent = int.MaxValue; // Initialize to maximum possible value

            // Check each card in the computer's hand
            foreach (Card card in game.computer.Hand)
            {
                // Check if the card is a valid defending card
                if (IsValidDefendingCard(card))
                {
                    // If the card has the same suit as the current card
                    if (card.Suit == currentCard.Suit)
                    {
                        if (card.Rank > currentCard.Rank && (int)card.Rank < lowestRankAboveCurrent)
                        {
                            bestCardToPlay = card;
                            lowestRankAboveCurrent = (int)card.Rank;
                        }
                    }
                    // If the card is a trump card
                    else if (card.Suit == game.trumpCard.Suit)
                    {
                        if ((int)card.Rank < lowestRankAboveCurrent)
                        {
                            bestCardToPlay = card;
                            lowestRankAboveCurrent = (int)card.Rank;
                        }
                    }
                }
            }

            return bestCardToPlay;
        }

        private bool IsValidDefendingCard(Card defendingCard)
        {
            // Implement the logic to check if the defendingCard is a valid defending card based on the attackingCard
            // For example, you can check if the defendingCard has the same suit as the attackingCard or if it's a trump card
            if (defendingCard.Suit == currentCard.Suit || defendingCard.Suit == game.trumpCard.Suit )
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // AnimateCard(game.player.Hand[0], playerHandPanel, tableHandPanel);
        }

        private void playerHandPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //switch roles
            if (cardsOnTable.Count % 2 == 0 && cardsOnTable.Count > 0)
            {
                switchRoles();
                doFinishCards();
                ComputerTurn();
                determinWinner();
            }
        }
        private void switchRoles()
        {
            bool playerIsAttacker = false;
            if (string.Compare(game.player.Role, "Attacker") == 0)
            {
                game.player.Role = "Defender";
                game.computer.Role = "Attacker";

                game.player.isTurn = false;
                game.computer.isTurn = true;
            }
            else
            {
                game.player.Role = "Attacker";
                game.computer.Role = "Defender";
                playerIsAttacker = true;
                game.computer.isTurn = false;
                game.player.isTurn = true;
            }


            int fontSize = 20;
            playerStatus.Controls.Clear();
            Label playerLabel = new Label();
            Font tempFont = new Font(playerLabel.Font.FontFamily, fontSize);
            playerLabel.Font = tempFont;

            playerLabel.Text = playerIsAttacker ? "Player (Attacker)" : "Player (Defender)";
            playerLabel.AutoSize = true;
            playerLabel.ForeColor = playerIsAttacker ? Color.Green : Color.Red;


            //this.Controls.Add(playerLabel);
            playerStatus.Controls.Add(playerLabel);
            playerLabel.Left = 10;
            playerLabel.Top = 0;// this.ClientSize.Height - CardHeight - 200;

            computerStatus.Controls.Clear();
            Label computerLabel = new Label();
            computerLabel.Font = tempFont;
            computerLabel.Text = playerIsAttacker ? "Computer (Defender)" : "Computer (Attacker)";
            computerLabel.AutoSize = true;
            computerLabel.ForeColor = playerIsAttacker ? Color.Red : Color.Green;


            //this.Controls.Add(computerLabel);
            computerStatus.Controls.Add(computerLabel);
            computerLabel.Left = 20; //this.ClientSize.Width - computerLabel.Width - 50;
            computerLabel.Top = 0;// this.ClientSize.Height - CardHeight - 200;
        }
        private void doFinishCards(int skipCheckPlayerRole=1)
        {
            if (cardsOnTable.Count % 2 == 0 && cardsOnTable.Count > 0)
            {

                finishedCards.AddRange(cardsOnTable);
                cardsOnTable.Clear();

                //draw cards for player
                game.DrawCards();

                //draw cards for computer
                UpdateUI();
                DisplayFinishedCards();
            }
            UpdateUI();
            DisplayFinishedCards();
        }

        private void btnTakeCards_Click(object sender, EventArgs e)
        {
            if(game.player.isTurn==false)
            {
                return;
            }
            if(game.player.Role=="Attacker")
            {
                return;
            }
            foreach (Card c in cardsOnTable)
            {
                game.player.Hand.Add(c);
            }
            cardsOnTable.Clear();
            game.player.isTurn= false;
            game.computer.isTurn = true;
            determinWinner();
            
            UpdateUI();
            updateStatusLabel();
            ComputerTurn();
            determinWinner();

        }
    }
}
