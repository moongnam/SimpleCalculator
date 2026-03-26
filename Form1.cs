using System;
using System.Data;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private string _fullExpression = "";
        private bool _isNewNum = true;
        private bool _isCalculated = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            // [중요] 버튼 연결 시 기존에 연결된 이벤트가 있다면 싹 지우고 새로 연결 (중복 방지)
            // 숫자 버튼
            button_0.Click -= NumberButton_Click; button_0.Click += NumberButton_Click;
            button_1.Click -= NumberButton_Click; button_1.Click += NumberButton_Click;
            button_2.Click -= NumberButton_Click; button_2.Click += NumberButton_Click;
            button_3.Click -= NumberButton_Click; button_3.Click += NumberButton_Click;
            button_4.Click -= NumberButton_Click; button_4.Click += NumberButton_Click;
            button_5.Click -= NumberButton_Click; button_5.Click += NumberButton_Click;
            button_6.Click -= NumberButton_Click; button_6.Click += NumberButton_Click;
            button_7.Click -= NumberButton_Click; button_7.Click += NumberButton_Click;
            button_8.Click -= NumberButton_Click; button_8.Click += NumberButton_Click;
            button_9.Click -= NumberButton_Click; button_9.Click += NumberButton_Click;

            // 연산 및 기능 버튼
            buttonP.Click -= OperatorButton_Click; buttonP.Click += OperatorButton_Click;
            buttonM.Click -= OperatorButton_Click; buttonM.Click += OperatorButton_Click;
            buttonT.Click -= OperatorButton_Click; buttonT.Click += OperatorButton_Click;
            buttonD.Click -= OperatorButton_Click; buttonD.Click += OperatorButton_Click;
            buttonR.Click -= EqualButton_Click; buttonR.Click += EqualButton_Click;
            buttonC.Click -= ClearAll; buttonC.Click += ClearAll;
            buttonCE.Click -= buttonCE_Click_Action; buttonCE.Click += buttonCE_Click_Action;
            buttonDel.Click -= buttonDel_Click; buttonDel.Click += buttonDel_Click;
            button_dot.Click -= button_dot_Click; button_dot.Click += button_dot_Click;

            // [괄호 버튼] 중복 방지를 위해 -= 후 += 처리
            button_Left.Click -= button_Left_Click_Internal;
            //button_Left.Click += button_Left_Click_Internal;

            button_Right.Click -= button_Right_Click_Internal;
            button_Right.Click += button_Right_Click_Internal;

            checkTopMost.CheckedChanged += (s, e) => { this.TopMost = checkTopMost.Checked; RemoveButtonFocus(); };
            listHistory.DoubleClick += ListHistory_DoubleClick;
            this.ActiveControl = txtResult;
        }

        // 디자인 창과 코드가 꼬이지 않도록 별도의 내부 핸들러 사용
        private void button_Left_Click_Internal(object? sender, EventArgs e) => AddOpenParenthesis();
        private void button_Right_Click_Internal(object? sender, EventArgs e) => AddCloseParenthesis();

        private void RemoveButtonFocus() { txtResult.Focus(); }

        private void AddOpenParenthesis()
        {
            if (_isCalculated) { ClearAll(null, null); _isCalculated = false; }

            // 숫자 뒤에 바로 ( 가 오면 자동으로 * 추가
            if (txtResult.Text != "0" && !_isNewNum)
            {
                _fullExpression += txtResult.Text + " * ( ";
            }
            else
            {
                _fullExpression += "( ";
            }

            txtNum1.Text = _fullExpression;
            txtResult.Text = "0";
            _isNewNum = true;
            RemoveButtonFocus();
        }

        private void AddCloseParenthesis()
        {
            if (!_isNewNum)
            {
                _fullExpression += txtResult.Text + " ) ";
            }
            else
            {
                // 연산자 뒤에서 바로 닫을 때 (예: 2 + ( 3 + ) )
                _fullExpression += " ) ";
            }

            txtNum1.Text = _fullExpression;
            txtResult.Text = "0";
            _isNewNum = true;
            RemoveButtonFocus();
        }

        private void NumberButton_Click(object? sender, EventArgs? e)
        {
            if (sender is not Button btn) return;
            if (_isCalculated) { ClearAll(null, null); _isCalculated = false; }

            if (_isNewNum || txtResult.Text == "0") { txtResult.Text = btn.Text; _isNewNum = false; }
            else { txtResult.Text += btn.Text; }

            UpdateRealTimeFormula();
            RemoveButtonFocus();
        }

        private void OperatorButton_Click(object? sender, EventArgs? e)
        {
            if (sender is not Button btn) return;
            if (_isCalculated) { _fullExpression = txtResult.Text + " " + btn.Text + " "; _isCalculated = false; }
            else { _fullExpression += txtResult.Text + " " + btn.Text + " "; }

            txtNum1.Text = _fullExpression;
            _isNewNum = true;
            RemoveButtonFocus();
        }

        private void EqualButton_Click(object? sender, EventArgs? e)
        {
            try
            {
                string finalFormula = _fullExpression;
                // 마지막이 )로 끝나지 않았고 새 숫자가 입력된 상태라면 포함
                if (!_fullExpression.Trim().EndsWith(")") && !_isNewNum) { finalFormula += txtResult.Text; }

                string mathExpression = finalFormula.Replace("x", "*").Replace("÷", "/").Replace(" ", "");

                // 괄호 짝 자동 보정
                int openCount = mathExpression.Split('(').Length - 1;
                int closeCount = mathExpression.Split(')').Length - 1;
                while (openCount > closeCount) { mathExpression += ")"; finalFormula += " )"; closeCount++; }

                DataTable dt = new DataTable();
                var result = dt.Compute(mathExpression, "");
                double finalResult = Convert.ToDouble(result);

                listHistory.Items.Insert(0, $"{finalFormula} = {finalResult}");
                txtNum1.Text = $"{finalFormula} = {finalResult}";
                txtResult.Text = finalResult.ToString();

                _fullExpression = ""; _isCalculated = true; _isNewNum = true;
            }
            catch { MessageBox.Show("수식 오류!"); ClearAll(null, null); }
            RemoveButtonFocus();
        }

        private void UpdateRealTimeFormula()
        {
            txtNum1.Text = _fullExpression + (_isNewNum ? "" : txtResult.Text);
        }

        private void ClearAll(object? sender, EventArgs? e)
        {
            _fullExpression = ""; _isNewNum = true; _isCalculated = false;
            txtNum1.Text = ""; txtResult.Text = "0";
            RemoveButtonFocus();
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.D9: e.SuppressKeyPress = true; AddOpenParenthesis(); return;
                    case Keys.D0: e.SuppressKeyPress = true; AddCloseParenthesis(); return;
                    case Keys.D8: e.SuppressKeyPress = true; buttonT.PerformClick(); return;
                    case Keys.Oemplus: e.SuppressKeyPress = true; buttonP.PerformClick(); return;
                }
            }

            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
                string keyVal = e.KeyCode.ToString().Replace("D", "").Replace("NumPad", "");
                Control[] found = this.Controls.Find("button_" + keyVal, true);
                if (found.Length > 0 && found[0] is Button btn) btn.PerformClick();
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Add: e.SuppressKeyPress = true; buttonP.PerformClick(); break;
                case Keys.Subtract: case Keys.OemMinus: e.SuppressKeyPress = true; buttonM.PerformClick(); break;
                case Keys.Multiply: e.SuppressKeyPress = true; buttonT.PerformClick(); break;
                case Keys.Divide: case Keys.OemQuestion: e.SuppressKeyPress = true; buttonD.PerformClick(); break;
                case Keys.Enter: e.SuppressKeyPress = true; buttonR.PerformClick(); break;
                case Keys.Back: case Keys.Delete: e.SuppressKeyPress = true; buttonDel.PerformClick(); break;
                case Keys.Escape: e.SuppressKeyPress = true; buttonC.PerformClick(); break;
                case Keys.Decimal: case Keys.OemPeriod: e.SuppressKeyPress = true; button_dot.PerformClick(); break;
                case Keys.Oemplus: e.SuppressKeyPress = true; buttonR.PerformClick(); break;
            }
        }

        private void buttonCE_Click_Action(object? sender, EventArgs? e) { txtResult.Text = "0"; _isNewNum = true; UpdateRealTimeFormula(); RemoveButtonFocus(); }
        private void buttonDel_Click(object? sender, EventArgs? e) { if (txtResult.Text.Length > 0) { txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1); if (string.IsNullOrEmpty(txtResult.Text)) txtResult.Text = "0"; } UpdateRealTimeFormula(); RemoveButtonFocus(); }
        private void button_dot_Click(object? sender, EventArgs? e) { if (_isNewNum) { txtResult.Text = "0."; _isNewNum = false; } else if (!txtResult.Text.Contains(".")) { txtResult.Text += "."; } UpdateRealTimeFormula(); RemoveButtonFocus(); }
        private void ListHistory_DoubleClick(object? sender, EventArgs e) { if (listHistory.SelectedItem != null) { string selected = listHistory.SelectedItem.ToString()!; string[] parts = selected.Split('='); if (parts.Length > 1) { txtResult.Text = parts[1].Trim(); _isCalculated = true; UpdateRealTimeFormula(); } } RemoveButtonFocus(); }
    }
}