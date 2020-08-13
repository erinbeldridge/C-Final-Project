/* Elite Group Project *
 * Erin Merrill        *
 * La'Ray Bush         *
 * Lab 11_12           *
 * ECET 164            *
 * December 7, 2018    */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;

namespace elite_Lab11_12GroupPorject
{
    public partial class firstForm : Form
    {
        string radiobutton; //string literal for switch case
        const int SIZE = 4; //size of every array
        double[] userAnswerArray = new double[SIZE]; //to store user inputs
        double[] correctAnswerArray = new double[SIZE]; //to store correct answers
        int[] firstOperandArray = new int[SIZE]; //to store random numbers assigned to first operand
        int[] secondOperandArray = new int[SIZE]; //to store random numbers assigned to second operand
        double correct = 0; //to store number of correct answers
        double incorrect = 0; //to store number of incorrect answers
        double percent = 0;  //to store percent of answer correct

        public firstForm()
        {
            InitializeComponent();
        }
        private double[] FillEquations(string radiobutton) //Method used to random fill the equations, accepts string
        {
            Random rand = new Random(); //random number generator
            const int SIZE = 4; //sie of all arrays

            for (int index = 0; index < SIZE; index++) //to loop through arrays
            {
                firstOperandArray[index] = rand.Next(1, 10); //assigns random number 1-10 to first operand
            }

            columnA_Factor0.Text = firstOperandArray[0].ToString(); //display values to labels
            columnA_Factor1.Text = firstOperandArray[1].ToString();
            columnA_Factor2.Text = firstOperandArray[2].ToString();
            columnA_Factor3.Text = firstOperandArray[3].ToString();

            for (int index = 0; index < SIZE; index++) //loop through array
            {
                secondOperandArray[index] = rand.Next(1, 10); //assigns random number 1-10 to second operand
            }

            columnB_Factor0.Text = secondOperandArray[0].ToString(); //display values to labels
            columnB_Factor1.Text = secondOperandArray[1].ToString();
            columnB_Factor2.Text = secondOperandArray[2].ToString();
            columnB_Factor3.Text = secondOperandArray[3].ToString();


            switch (radiobutton) //evaluates string sent from method calls in radio button clicks
            {
                case "voltage": //if user clicks the voltage radio button, do the following

                    firstOperandLabel.Text = ("Resistance").ToString(); //change label over first operand
                    secondOperandLabel.Text = ("Current").ToString(); //change label over second operand

                    multiplyLabel0.Text = ("*").ToString(); //change math operate to multiply
                    multiplyLabel1.Text = ("*").ToString();
                    multiplyLabel2.Text = ("*").ToString();
                    multiplyLabel3.Text = ("*").ToString();

                    for (int index = 0; index < 4; index++) //loop through equation and calculate correct answer
                    {
                        correctAnswerArray[index] = (double)firstOperandArray[index] * (double)secondOperandArray[index];
                    }

                    answerTextbox0.Text = "".ToString(); //clear answer textbox
                    answerTextbox1.Text = "".ToString();
                    answerTextbox2.Text = "".ToString();
                    answerTextbox3.Text = "".ToString();

                    break;

                case "resistance": //if user chooses resistance, do the following

                    firstOperandLabel.Text = ("Voltage").ToString(); //change label over first operand
                    secondOperandLabel.Text = ("Current").ToString(); //change label over second operand

                    multiplyLabel0.Text = ("/").ToString(); //change math operator to division
                    multiplyLabel1.Text = ("/").ToString();
                    multiplyLabel2.Text = ("/").ToString();
                    multiplyLabel3.Text = ("/").ToString();

                    for (int index = 0; index < 4; index++) //loop through equations and calculate correct answers
                    {
                        correctAnswerArray[index] = (double)firstOperandArray[index] / (double)secondOperandArray[index];
                    }

                    correctAnswerArray[0] = Math.Round(correctAnswerArray[0], 2); //round correct answers to 2 decimal places
                    correctAnswerArray[1] = Math.Round(correctAnswerArray[1], 2);
                    correctAnswerArray[2] = Math.Round(correctAnswerArray[2], 2);
                    correctAnswerArray[3] = Math.Round(correctAnswerArray[3], 2);

                    userAnswerArray[0] = Math.Round(userAnswerArray[0], 2); //round user answers to 2 decimal places
                    userAnswerArray[1] = Math.Round(userAnswerArray[1], 2);
                    userAnswerArray[2] = Math.Round(userAnswerArray[2], 2);
                    userAnswerArray[3] = Math.Round(userAnswerArray[3], 2);

                    answerTextbox0.Text = "".ToString(); //clear answer textbox
                    answerTextbox1.Text = "".ToString();
                    answerTextbox2.Text = "".ToString();
                    answerTextbox3.Text = "".ToString();

                    break;

                case "current": //if user chooses current do the following

                    firstOperandLabel.Text = ("Voltage").ToString(); //change label over first operand
                    secondOperandLabel.Text = ("Resistance").ToString(); //change label voer second operand

                    multiplyLabel0.Text = ("/").ToString(); //change math operator to division
                    multiplyLabel1.Text = ("/").ToString();
                    multiplyLabel2.Text = ("/").ToString();
                    multiplyLabel3.Text = ("/").ToString();

                    for (int index = 0; index < 4; index++) //loop through equations and calculate correct answers
                    {
                        correctAnswerArray[index] = (double)firstOperandArray[index] / (double)secondOperandArray[index];
                    }

                    correctAnswerArray[0] = Math.Round(correctAnswerArray[0], 2); //round correct answers to 2 decimal places
                    correctAnswerArray[1] = Math.Round(correctAnswerArray[1], 2);
                    correctAnswerArray[2] = Math.Round(correctAnswerArray[2], 2);
                    correctAnswerArray[3] = Math.Round(correctAnswerArray[3], 2);

                    userAnswerArray[0] = Math.Round(userAnswerArray[0], 2); //round user answers to 2 decimal places
                    userAnswerArray[1] = Math.Round(userAnswerArray[1], 2);
                    userAnswerArray[2] = Math.Round(userAnswerArray[2], 2);
                    userAnswerArray[3] = Math.Round(userAnswerArray[3], 2);

                    answerTextbox0.Text = "".ToString(); //clear answer textboxes
                    answerTextbox1.Text = "".ToString();
                    answerTextbox2.Text = "".ToString();
                    answerTextbox3.Text = "".ToString();

                    break;
            }

            answerTextbox0.Focus(); //return cursor to first textbox

            return correctAnswerArray; //send correctAnswerArray to ValidateInputandCompareAnswers Method

        }

        private double[] ValidateInputandCompareAnswers(double[] answerArray, double[] userAnswerArray)
        {
            //validate user input
            if ((double.TryParse(answerTextbox0.Text, out userAnswerArray[0]))
                && (double.TryParse(answerTextbox1.Text, out userAnswerArray[1]))
                && (double.TryParse(answerTextbox1.Text, out userAnswerArray[2]))
                && (double.TryParse(answerTextbox1.Text, out userAnswerArray[3])))
            {
                CorrectAnswers answerForm = new CorrectAnswers(); //create new instance of correct answer form

                userAnswerArray[0] = double.Parse(answerTextbox0.Text); //parse user input 
                userAnswerArray[1] = double.Parse(answerTextbox1.Text);
                userAnswerArray[2] = double.Parse(answerTextbox2.Text);
                userAnswerArray[3] = double.Parse(answerTextbox3.Text);

                statButton.Enabled = true; //allow user to choose stat button option

                if (answerArray[0] == Math.Round(userAnswerArray[0], 2)) //compare user answer and correct answer
                {
                    answerForm.answerLabel0.BackColor = Color.LightGreen; //if they match, turn textbox green
                    correct += 1; //add one to number of correct answers
                }
                else if (answerArray[0] != Math.Round(userAnswerArray[0], 2)) //compare user answer and correct answer
                {
                    answerForm.answerLabel0.BackColor = Color.LightPink; //if they don't match, turn textbox red
                    incorrect += 1; //add one to number of incorrect answers
                }

                if (answerArray[1] == Math.Round(userAnswerArray[1], 2)) //compare user answer and correct answer
                {
                    answerForm.answerLabel1.BackColor = Color.LightGreen; //if they match, turn textbox green
                    correct += 1; //add one to number of correct answers
                }
                else if (answerArray[1] != Math.Round(userAnswerArray[1], 2)) //compare user answer and correct answer
                {
                    answerForm.answerLabel1.BackColor = Color.LightPink; //if they don't match, turn textbox red
                    incorrect += 1; //add one to number of incorrect answers
                }

                if (answerArray[2] == Math.Round(userAnswerArray[2], 2)) //compare user answer and correct answer
                {
                    answerForm.answerLabel2.BackColor = Color.LightGreen; //if they match, turn textbox green
                    correct += 1; //add one to number of correct answers
                }
                else if (answerArray[2] != Math.Round(userAnswerArray[2], 2)) //compare user answer and correct answer
                {
                    answerForm.answerLabel2.BackColor = Color.LightPink; //if they don't match, turn textbox red
                    incorrect += 1; //add one to number of incorrect answers
                }

                if (answerArray[3] == Math.Round(userAnswerArray[3], 2)) //compare user answer and correct answer
                {
                    answerForm.answerLabel3.BackColor = Color.LightGreen; //if they match, turn textbox green
                    correct += 1; //add one to number of correct answers
                }
                else if (answerArray[3] != Math.Round(userAnswerArray[3], 2)) //compare user answer and correct answer
                {
                    answerForm.answerLabel3.BackColor = Color.LightPink; //if they don't match, turn textbox red
                    incorrect += 1; //add one to number of incorrect answers
                }

                if (radiobutton == "voltage") 
                {
                    answerForm.multiplyLabel0.Text = ("*").ToString(); //if user chooses voltage, change math 
                    answerForm.multiplyLabel1.Text = ("*").ToString(); //operator to multiply on answerForm
                    answerForm.multiplyLabel2.Text = ("*").ToString();
                    answerForm.multiplyLabel3.Text = ("*").ToString();
                }

                else if (radiobutton == "resistance")
                {
                    answerForm.multiplyLabel0.Text = ("/").ToString(); //if user chooses resistance, change math
                    answerForm.multiplyLabel1.Text = ("/").ToString(); //operators to division on answerForm
                    answerForm.multiplyLabel2.Text = ("/").ToString();
                    answerForm.multiplyLabel3.Text = ("/").ToString();
                }

                else if (radiobutton == "current")
                {
                    answerForm.multiplyLabel0.Text = ("/").ToString(); //if user chooses current, change math
                    answerForm.multiplyLabel1.Text = ("/").ToString(); //operators to division on answerForm
                    answerForm.multiplyLabel2.Text = ("/").ToString();
                    answerForm.multiplyLabel3.Text = ("/").ToString();
                }

                answerForm.answerLabel0.Text = userAnswerArray[0].ToString("n2"); //display user input on answerForm
                answerForm.answerLabel1.Text = userAnswerArray[1].ToString("n2");
                answerForm.answerLabel2.Text = userAnswerArray[2].ToString("n2");
                answerForm.answerLabel3.Text = userAnswerArray[3].ToString("n2");

                answerForm.correctLabel0.Text = correctAnswerArray[0].ToString("n2"); //display correct answers on answerForm
                answerForm.correctLabel1.Text = correctAnswerArray[1].ToString("n2");
                answerForm.correctLabel2.Text = correctAnswerArray[2].ToString("n2");
                answerForm.correctLabel3.Text = correctAnswerArray[3].ToString("n2");

                answerForm.columnA_Factor0.Text = firstOperandArray[0].ToString(); //display first operands in answerForm
                answerForm.columnA_Factor1.Text = firstOperandArray[1].ToString();
                answerForm.columnA_Factor2.Text = firstOperandArray[2].ToString();
                answerForm.columnA_Factor3.Text = firstOperandArray[3].ToString();

                answerForm.columnB_Factor0.Text = secondOperandArray[0].ToString(); //display second operands in answerForm
                answerForm.columnB_Factor1.Text = secondOperandArray[1].ToString();
                answerForm.columnB_Factor2.Text = secondOperandArray[2].ToString();
                answerForm.columnB_Factor3.Text = secondOperandArray[3].ToString();

                answerForm.ShowDialog(); //display answerForm
                BetweenButtons(); //Call Between Buttons method

            }
            else
            {
                MessageBox.Show("Invalid Input. Try again using only numeric values."); //if user inputs are invalid, display error message
            }

            return userAnswerArray; //return user answers
        }

        private void Statistics()
        {
           
            DisplayStats statForm = new DisplayStats(); //create new instance of statForm
            percent = (correct / 4 * 100); //calculate percentage

            statForm.correctOutput.Text = correct.ToString(); //display number of correct answers on statForm
            statForm.incorrectOutput.Text = incorrect.ToString(); //dispay number of incorrect answers on statForm
            statForm.percentOutput.Text = percent.ToString(); //display percentage to statForm

            if (percent > 89) //Is percentage over 90?
            {
                statForm.gradeOutput.Text = "A"; //display grade of A
            }

            else if (percent > 79) //is percentage over 79 but less than 90?
            {
                statForm.gradeOutput.Text = "B"; //display grade of B
            }

            else if (percent > 69) //is percentage oveer 69 but less than 80
            {
                statForm.gradeOutput.Text = "C"; //display grade of C
            }

            else if (percent > 59) //is percentage over 59 but less than 70?
            {
                statForm.gradeOutput.Text = "D"; //display grade of D
            }

            else
            {
                statForm.gradeOutput.Text = "F"; //otherwise display grade of F
            }

            statForm.ShowDialog(); //show statForm
            Restart(); //Call restart method
            FillEquations("voltage");
            statButton.Enabled = false; //don't allow user to click stat button after closing statForm
            correct = 0;
            incorrect = 0;

        }

        private void BetweenButtons() //doesn't allow user to choose any buttons EXCEPT Show Stats. 
                                       //This keeps user from entering new data without it getting saved in stat method
        {
            Restart(); //Call restart method
            answerButton.Enabled = false; //gray out answer button
            answerTextbox0.Enabled = false; //gray out input textboxes
            answerTextbox1.Enabled = false;
            answerTextbox2.Enabled = false;
            answerTextbox3.Enabled = false;

        }

        private void Restart()
        {
            voltageRadioButton.Focus(); //returns focus to voltage radio button

            firstOperandLabel.Text = ("Resistance").ToString(); //change label of first operand 
            secondOperandLabel.Text = ("Current").ToString(); //change label of second operand

            multiplyLabel0.Text = ("*").ToString(); //change math operators to multiply
            multiplyLabel1.Text = ("*").ToString();
            multiplyLabel2.Text = ("*").ToString();
            multiplyLabel3.Text = ("*").ToString();

            answerTextbox0.Text = "".ToString(); //clear out all user textboxes
            answerTextbox1.Text = "".ToString();
            answerTextbox2.Text = "".ToString();
            answerTextbox3.Text = "".ToString();

            answerButton.Enabled = true; //allow user to click answer button
            answerTextbox0.Enabled = true; //allow user to enter data in textboxes
            answerTextbox1.Enabled = true;
            answerTextbox2.Enabled = true;
            answerTextbox3.Enabled = true;
        }


        private void voltageRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            FillEquations("voltage"); //call fill equations method

        }

        private void resistanceRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            FillEquations("resistance"); //call fill equations method

        }

        private void currentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
           
            FillEquations("current"); //call fill equations method

        }

        private void answerButton_Click(object sender, EventArgs e)
        {
            ValidateInputandCompareAnswers(correctAnswerArray, userAnswerArray); //call method and send both answer arrays
                        
        }

        private void statButton_Click(object sender, EventArgs e)
        {
            Statistics(); //call statistics method
        }

        private void restartButton_Click(object sender, EventArgs e)
        { 
            FillEquations("voltage"); //set voltage to default
            Restart(); //restart method
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); //close program
        }
    }
}