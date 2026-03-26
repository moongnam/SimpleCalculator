using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private double _firstNum = 0;      // 첫 번째 숫자 저장
        private string _operator = "";     // 연산자 저장 (+, -, x, ÷)
        private bool _isNewNum = true;     // 새로 숫자를 입력할 차례인지 확인

        public Form1()
        {
            InitializeComponent();

            // 숫자 버튼 이벤트 연결 (0~9)
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

            // 모든 연산자 버튼 연결
            buttonP.Click += OperatorButton_Click; // +
            buttonM.Click += OperatorButton_Click; // -
            buttonT.Click += OperatorButton_Click; // x
            buttonD.Click += OperatorButton_Click; // ÷

            buttonR.Click += EqualButton_Click;    // =

            // 기능 버튼 연결
            buttonCE.Click += buttonCE_Click_Action; // CE: 현재 입력값 삭제
            buttonC.Click += ClearAll;               // C: 전체 초기화
            buttonDel.Click += buttonDel_Click;      // Del: 한 글자 삭제
        }

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

        // --- 여기서부터 요청하신 기능들입니다 ---

        // 1. CE (Clear Entry): 현재 입력 중인 피연산자만 삭제
        private void buttonCE_Click_Action(object? sender, EventArgs? e)
        {
            txtResult.Text = "0";
            _isNewNum = true;
            UpdateRealTimeFormula();
        }

        // 2. Del (Backspace): 마지막 글자 하나만 삭제
        private void buttonDel_Click(object? sender, EventArgs? e)
        {
            if (txtResult.Text.Length > 0)
            {
                // 한 글자 지우기
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);

                // 지웠는데 비어있거나 "-"만 남았다면 "0"으로 변경
                if (string.IsNullOrEmpty(txtResult.Text) || txtResult.Text == "-")
                {
                    txtResult.Text = "0";
                    _isNewNum = true;
                }
            }
            UpdateRealTimeFormula();
        }

        // 3. C (Clear): 전체 초기화 (기존 ClearAll 함수 활용)
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