namespace _368_ReverseString
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;

    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ReverseStringForm());
        }
        public static string Reverse(string input)
        {
            Stack<char> stack = new Stack<char>();
            string result = "";

            foreach (char c in input)
            {
                if (c != ' ')
                {
                    stack.Push(c);
                }
                else
                {
                    while (stack.Count > 0)
                    {
                        result += stack.Pop();
                    }
                    result += c;
                }
            }

            
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
    }

    class ReverseStringForm : Form
    {
        private TextBox inputTextBox;
        private Button reverseButton;
        private Label resultLabel;

        public ReverseStringForm()
        {
            inputTextBox = new TextBox { Dock = DockStyle.Top };
            reverseButton = new Button { Text = "Reverse Words", Dock = DockStyle.Top };
            resultLabel = new Label { Dock = DockStyle.Fill };

            reverseButton.Click += ReverseButton_Click;

            Controls.Add(resultLabel);
            Controls.Add(reverseButton);
            Controls.Add(inputTextBox);
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text;
            string reversed = Program.Reverse(input);
            resultLabel.Text = reversed;
        }
    }

}