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

            // 모든 연산자 버튼 연결 (민서 님이 정한 이름 그대로!)
            buttonP.Click += OperatorButton_Click; // +
            buttonM.Click += OperatorButton_Click; // -
            buttonT.Click += OperatorButton_Click; // x
            buttonD.Click += OperatorButton_Click; // ÷

            buttonR.Click += EqualButton_Click;    // =

            // 기능 버튼
            buttonCE.Click += (s, e) => { txtResult.Text = "0"; _isNewNum = true; UpdateRealTimeFormula(); };
            buttonC.Click += ClearAll;
            // Del 버튼이 있다면 아래 주석을 해제하고 연결하세요.
            // buttonDel.Click += btnDel_Click; 
        }

        // 1. 숫자 버튼 클릭 시
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

            // [추가] 숫자를 누를 때마다 즉시 수식 업데이트
            UpdateRealTimeFormula();
        }

        // 2. 연산자 버튼 클릭 시
        private void OperatorButton_Click(object? sender, EventArgs? e)
        {
            if (sender is not Button btn) return;

            if (!double.TryParse(txtResult.Text, out _firstNum)) return;

            _operator = btn.Text; // +, -, x, ÷ 저장
            _isNewNum = true;

            // 연산자를 누르는 순간 위 칸을 "숫자 + " 형태로 업데이트
            txtNum1.Text = _firstNum + " " + _operator + " ";
        }

        // 3. 결과(=) 버튼 클릭 시
        private void EqualButton_Click(object? sender, EventArgs? e)
        {
            if (string.IsNullOrEmpty(_operator)) return;

            double secondNum;
            if (!double.TryParse(txtResult.Text, out secondNum)) return;

            double result = 0;

            // 사칙연산 로직 완성
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

            // 결과 표시
            txtNum1.Text = $"{_firstNum} {_operator} {secondNum} = {result}";
            txtResult.Text = result.ToString();

            _isNewNum = true;
            _operator = "";
        }

        // [새로 추가] 실시간 수식 표시 함수
        private void UpdateRealTimeFormula()
        {
            // 연산자가 없는 상태(첫 번째 숫자 입력 중)라면 위 칸에 그대로 표시
            if (string.IsNullOrEmpty(_operator))
            {
                txtNum1.Text = txtResult.Text;
            }
            // 연산자가 있는 상태(두 번째 숫자 입력 중)라면 "첫번째수 + 입력중인수" 표시
            else
            {
                txtNum1.Text = _firstNum + " " + _operator + " " + txtResult.Text;
            }
        }

        private void ClearAll(object? sender, EventArgs? e)
        {
            _firstNum = 0;
            _operator = "";
            _isNewNum = true;
            txtNum1.Text = "";
            txtResult.Text = "0";
        }
    }
}