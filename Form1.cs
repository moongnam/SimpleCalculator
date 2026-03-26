using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private double _firstNum = 0;
        private string _operator = "";
        private bool _isNewNum = true;

        public Form1()
        {
            InitializeComponent();

            // 숫자 버튼 이벤트 연결
            button_0.Click += NumberButton_Click;
            button_1.Click += NumberButton_Click;
            button_2.Click += NumberButton_Click;
            button_3.Click += NumberButton_Click;
            button_4.Click += NumberButton_Click;
            button_5.Click += NumberButton_Click;
            button_6.Click += NumberButton_Click;
            button_7.Click += NumberButton_Click;
            button_8.Click += NumberButton_Click;
            button_9.Click += NumberButton_Click;

            // 소수점 버튼 연결 (새로 추가)
            button_dot.Click += button_dot_Click;

            // 연산자 및 기능 버튼 연결
            buttonP.Click += OperatorButton_Click;
            buttonM.Click += OperatorButton_Click;
            buttonT.Click += OperatorButton_Click;
            buttonD.Click += OperatorButton_Click;
            buttonR.Click += EqualButton_Click;
            buttonCE.Click += buttonCE_Click_Action;
            buttonC.Click += ClearAll;
            buttonDel.Click += buttonDel_Click;
        }

        // --- 숫자 버튼 로직 (기존과 동일) ---
        private void NumberButton_Click(object? sender, EventArgs? e)
        {
            if (sender is not Button btn) return;

            if (_isNewNum || txtResult.Text == "0")
            {
                txtResult.Text = btn.Text;
                _isNewNum = false;
            }
            else
            {
                txtResult.Text += btn.Text;
            }
            UpdateRealTimeFormula();
        }

        // --- [새로 추가] 소수점 버튼 클릭 로직 ---
        private void button_dot_Click(object? sender, EventArgs? e)
        {
            // 1. 만약 새로운 숫자를 입력해야 하는 타이밍에 점을 찍으면 "0."으로 시작
            if (_isNewNum)
            {
                txtResult.Text = "0.";
                _isNewNum = false;
            }
            // 2. 이미 입력 중인 숫자에 점이 없는 경우에만 점을 추가 (중복 방지)
            else if (!txtResult.Text.Contains("."))
            {
                txtResult.Text += ".";
            }

            UpdateRealTimeFormula();
        }

        // --- 연산자 및 결과 로직 (기존과 동일) ---
        private void OperatorButton_Click(object? sender, EventArgs? e)
        {
            if (sender is not Button btn) return;
            if (!double.TryParse(txtResult.Text, out _firstNum)) return;

            _operator = btn.Text;
            _isNewNum = true;
            txtNum1.Text = _firstNum + " " + _operator + " ";
        }

        private void EqualButton_Click(object? sender, EventArgs? e)
        {
            if (string.IsNullOrEmpty(_operator)) return;
            double secondNum;
            if (!double.TryParse(txtResult.Text, out secondNum)) return;

            double result = 0;
            switch (_operator)
            {
                case "+": result = _firstNum + secondNum; break;
                case "-": result = _firstNum - secondNum; break;
                case "x": result = _firstNum * secondNum; break;
                case "÷":
                    if (secondNum != 0) result = _firstNum / secondNum;
                    else { MessageBox.Show("0으로 나눌 수 없습니다."); return; }
                    break;
            }

            txtNum1.Text = $"{_firstNum} {_operator} {secondNum} = {result}";
            txtResult.Text = result.ToString();
            _isNewNum = true;
            _operator = "";
        }

        private void buttonCE_Click_Action(object? sender, EventArgs? e)
        {
            txtResult.Text = "0";
            _isNewNum = true;
            UpdateRealTimeFormula();
        }

        private void buttonDel_Click(object? sender, EventArgs? e)
        {
            if (txtResult.Text.Length > 0)
            {
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
                if (string.IsNullOrEmpty(txtResult.Text) || txtResult.Text == "-")
                {
                    txtResult.Text = "0";
                    _isNewNum = true;
                }
            }
            UpdateRealTimeFormula();
        }

        private void ClearAll(object? sender, EventArgs? e)
        {
            _firstNum = 0;
            _operator = "";
            _isNewNum = true;
            txtNum1.Text = "";
            txtResult.Text = "0";
        }

        private void UpdateRealTimeFormula()
        {
            if (string.IsNullOrEmpty(_operator))
            {
                txtNum1.Text = txtResult.Text;
            }
            else
            {
                txtNum1.Text = _firstNum + " " + _operator + " " + txtResult.Text;
            }
        }
    }
}