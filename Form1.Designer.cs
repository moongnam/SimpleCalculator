namespace SimpleCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitle = new Label();
            txtNum1 = new TextBox();
            txtResult = new TextBox();
            buttonCE = new Button();
            buttonC = new Button();
            buttonDel = new Button();
            buttonD = new Button();
            button_7 = new Button();
            buttonT = new Button();
            buttonM = new Button();
            buttonP = new Button();
            buttonR = new Button();
            button_8 = new Button();
            button_9 = new Button();
            button_4 = new Button();
            button_5 = new Button();
            button_6 = new Button();
            button_1 = new Button();
            button_2 = new Button();
            button_3 = new Button();
            button_Pm = new Button();
            button_0 = new Button();
            button_dot = new Button();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.AutoSize = true;
            txtTitle.BackColor = Color.AliceBlue;
            txtTitle.Font = new Font("한컴 말랑말랑 Bold", 24F, FontStyle.Bold, GraphicsUnit.Point, 129, true);
            txtTitle.ForeColor = Color.LightSkyBlue;
            txtTitle.Location = new Point(105, 32);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(353, 52);
            txtTitle.TabIndex = 0;
            txtTitle.Text = "Simple Calculator";
            txtTitle.Click += nameLabel1_Click;
            // 
            // txtNum1
            // 
            txtNum1.Location = new Point(82, 98);
            txtNum1.Multiline = true;
            txtNum1.Name = "txtNum1";
            txtNum1.Size = new Size(398, 36);
            txtNum1.TabIndex = 1;
            txtNum1.TextChanged += txtNum1_TextChanged;
            // 
            // txtResult
            // 
            txtResult.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            txtResult.Location = new Point(82, 149);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(398, 36);
            txtResult.TabIndex = 2;
            txtResult.TextChanged += textBox1_TextChanged_1;
            // 
            // buttonCE
            // 
            buttonCE.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonCE.Location = new Point(82, 204);
            buttonCE.Name = "buttonCE";
            buttonCE.Size = new Size(94, 52);
            buttonCE.TabIndex = 3;
            buttonCE.Text = "CE";
            buttonCE.UseVisualStyleBackColor = true;
            buttonCE.Click += buttonCE_Click;
            // 
            // buttonC
            // 
            buttonC.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonC.Location = new Point(186, 204);
            buttonC.Name = "buttonC";
            buttonC.Size = new Size(94, 52);
            buttonC.TabIndex = 4;
            buttonC.Text = "C";
            buttonC.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            buttonDel.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonDel.Location = new Point(286, 204);
            buttonDel.Name = "buttonDel";
            buttonDel.Size = new Size(94, 52);
            buttonDel.TabIndex = 4;
            buttonDel.Text = "Del";
            buttonDel.UseVisualStyleBackColor = true;
            // 
            // buttonD
            // 
            buttonD.Font = new Font("휴먼둥근헤드라인", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonD.ForeColor = Color.Brown;
            buttonD.Location = new Point(386, 204);
            buttonD.Name = "buttonD";
            buttonD.Size = new Size(94, 52);
            buttonD.TabIndex = 5;
            buttonD.Text = "÷";
            buttonD.UseVisualStyleBackColor = true;
            // 
            // button_7
            // 
            button_7.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_7.ForeColor = Color.SteelBlue;
            button_7.Location = new Point(82, 262);
            button_7.Name = "button_7";
            button_7.Size = new Size(94, 52);
            button_7.TabIndex = 6;
            button_7.Text = "7";
            button_7.UseVisualStyleBackColor = true;
            // 
            // buttonT
            // 
            buttonT.Font = new Font("함초롬돋움", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonT.ForeColor = Color.Brown;
            buttonT.Location = new Point(386, 262);
            buttonT.Name = "buttonT";
            buttonT.Size = new Size(94, 52);
            buttonT.TabIndex = 7;
            buttonT.Text = "x";
            buttonT.UseVisualStyleBackColor = true;
            // 
            // buttonM
            // 
            buttonM.Font = new Font("함초롬돋움", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonM.ForeColor = Color.Brown;
            buttonM.Location = new Point(386, 320);
            buttonM.Name = "buttonM";
            buttonM.Size = new Size(94, 52);
            buttonM.TabIndex = 8;
            buttonM.Text = "-";
            buttonM.UseVisualStyleBackColor = true;
            // 
            // buttonP
            // 
            buttonP.Font = new Font("함초롬돋움", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonP.ForeColor = Color.Brown;
            buttonP.Location = new Point(386, 378);
            buttonP.Name = "buttonP";
            buttonP.Size = new Size(94, 52);
            buttonP.TabIndex = 9;
            buttonP.Text = "+";
            buttonP.UseVisualStyleBackColor = true;
            // 
            // buttonR
            // 
            buttonR.Font = new Font("함초롬돋움", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            buttonR.ForeColor = Color.Brown;
            buttonR.Location = new Point(386, 436);
            buttonR.Name = "buttonR";
            buttonR.Size = new Size(94, 52);
            buttonR.TabIndex = 10;
            buttonR.Text = "=";
            buttonR.UseVisualStyleBackColor = true;
            // 
            // button_8
            // 
            button_8.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_8.ForeColor = Color.SteelBlue;
            button_8.Location = new Point(186, 262);
            button_8.Name = "button_8";
            button_8.Size = new Size(94, 52);
            button_8.TabIndex = 11;
            button_8.Text = "8";
            button_8.UseVisualStyleBackColor = true;
            // 
            // button_9
            // 
            button_9.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_9.ForeColor = Color.SteelBlue;
            button_9.Location = new Point(286, 262);
            button_9.Name = "button_9";
            button_9.Size = new Size(94, 52);
            button_9.TabIndex = 12;
            button_9.Text = "9";
            button_9.UseVisualStyleBackColor = true;
            // 
            // button_4
            // 
            button_4.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_4.ForeColor = Color.SteelBlue;
            button_4.Location = new Point(82, 320);
            button_4.Name = "button_4";
            button_4.Size = new Size(94, 52);
            button_4.TabIndex = 13;
            button_4.Text = "4";
            button_4.UseVisualStyleBackColor = true;
            // 
            // button_5
            // 
            button_5.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_5.ForeColor = Color.SteelBlue;
            button_5.Location = new Point(186, 320);
            button_5.Name = "button_5";
            button_5.Size = new Size(94, 52);
            button_5.TabIndex = 14;
            button_5.Text = "5";
            button_5.UseVisualStyleBackColor = true;
            // 
            // button_6
            // 
            button_6.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_6.ForeColor = Color.SteelBlue;
            button_6.Location = new Point(286, 320);
            button_6.Name = "button_6";
            button_6.Size = new Size(94, 52);
            button_6.TabIndex = 15;
            button_6.Text = "6";
            button_6.UseVisualStyleBackColor = true;
            // 
            // button_1
            // 
            button_1.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_1.ForeColor = Color.SteelBlue;
            button_1.Location = new Point(82, 378);
            button_1.Name = "button_1";
            button_1.Size = new Size(94, 52);
            button_1.TabIndex = 16;
            button_1.Text = "1";
            button_1.UseVisualStyleBackColor = true;
            // 
            // button_2
            // 
            button_2.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_2.ForeColor = Color.SteelBlue;
            button_2.Location = new Point(186, 378);
            button_2.Name = "button_2";
            button_2.Size = new Size(94, 52);
            button_2.TabIndex = 17;
            button_2.Text = "2";
            button_2.UseVisualStyleBackColor = true;
            // 
            // button_3
            // 
            button_3.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_3.ForeColor = Color.SteelBlue;
            button_3.Location = new Point(286, 378);
            button_3.Name = "button_3";
            button_3.Size = new Size(94, 52);
            button_3.TabIndex = 18;
            button_3.Text = "3";
            button_3.UseVisualStyleBackColor = true;
            // 
            // button_Pm
            // 
            button_Pm.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_Pm.Location = new Point(82, 436);
            button_Pm.Name = "button_Pm";
            button_Pm.Size = new Size(94, 52);
            button_Pm.TabIndex = 19;
            button_Pm.Text = "+ / -";
            button_Pm.UseVisualStyleBackColor = true;
            // 
            // button_0
            // 
            button_0.Font = new Font("한컴 말랑말랑 Regular", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 129);
            button_0.ForeColor = Color.SteelBlue;
            button_0.Location = new Point(186, 436);
            button_0.Name = "button_0";
            button_0.Size = new Size(94, 52);
            button_0.TabIndex = 20;
            button_0.Text = "0";
            button_0.UseVisualStyleBackColor = true;
            // 
            // button_dot
            // 
            button_dot.Font = new Font("한컴 말랑말랑 Bold", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button_dot.Location = new Point(286, 436);
            button_dot.Name = "button_dot";
            button_dot.Size = new Size(94, 52);
            button_dot.TabIndex = 21;
            button_dot.Text = ".";
            button_dot.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(569, 535);
            Controls.Add(button_dot);
            Controls.Add(button_0);
            Controls.Add(button_Pm);
            Controls.Add(button_3);
            Controls.Add(button_2);
            Controls.Add(button_1);
            Controls.Add(button_6);
            Controls.Add(button_5);
            Controls.Add(button_4);
            Controls.Add(button_9);
            Controls.Add(button_8);
            Controls.Add(buttonR);
            Controls.Add(buttonP);
            Controls.Add(buttonM);
            Controls.Add(buttonT);
            Controls.Add(button_7);
            Controls.Add(buttonD);
            Controls.Add(buttonDel);
            Controls.Add(buttonC);
            Controls.Add(buttonCE);
            Controls.Add(txtResult);
            Controls.Add(txtNum1);
            Controls.Add(txtTitle);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            // 필요 시 구현. 현재는 빈 구현으로 예외 방지.
        }

        private void txtNum1_TextChanged(object sender, EventArgs e)
        {
            // 필요 시 구현. 현재는 빈 구현으로 예외 방지.
        }

        private void nameLabel1_Click(object sender, EventArgs e)
        {
            // 필요 시 구현. 현재는 빈 구현으로 예외 방지.
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            // 필요 시 구현. 현재는 빈 구현으로 예외 방지.
        }

        #endregion

        private Label txtTitle;
        private TextBox txtNum1;
        private TextBox txtResult;
        private Button buttonCE;
        private Button buttonC;
        private Button buttonDel;
        private Button buttonD;
        private Button button_7;
        private Button buttonT;
        private Button buttonM;
        private Button buttonP;
        private Button buttonR;
        private Button button_8;
        private Button button_9;
        private Button button_4;
        private Button button_5;
        private Button button_6;
        private Button button_1;
        private Button button_2;
        private Button button_3;
        private Button button_Pm;
        private Button button_0;
        private Button button_dot;
    }
}
