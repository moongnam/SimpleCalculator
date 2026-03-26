namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private double _firstNum = 0;      // 첫 번째 숫자 저장
        private string _operator = "";     // 연산자 저장 (+, -, *, /)
        private bool _isNewNum = true;     // 새로 숫자를 입력할 차례인지 확인

        public Form1()
        {
            InitializeComponent();
            // 숫자 버튼 이벤트 연결 (0~9, 점)
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

            // 연산자 및 기능 버튼
            buttonP.Click += OperatorButton_Click; // +
            buttonR.Click += EqualButton_Click;    // =
            buttonCE.Click += (s, e) => { txtResult.Text = "0"; _isNewNum = true; };
            buttonC.Click += ClearAll;
        }

        // 1. 숫자 버튼 클릭 시
        private void NumberButton_Click(object? sender, EventArgs? e)
        {
            if (sender is not Button btn) return;

            // 새로운 숫자를 입력해야 하거나 현재 '0'이면 지우고 새로 씀
            if (_isNewNum || txtResult.Text == "0")
            {
                txtResult.Text = btn.Text;
                _isNewNum = false;
            }
            else
            {
                txtResult.Text += btn.Text;
            }
        }

        // 2. 연산자(+) 버튼 클릭 시
        private void OperatorButton_Click(object? sender, EventArgs? e)
        {
            if (sender is not Button btn) return;

            _firstNum = double.Parse(txtResult.Text); // 현재 입력된 값을 첫 번째 숫자로 저장
            _operator = btn.Text;                     // "+" 저장

            // 위 칸(txtNum1)에 "5 + " 처럼 표시
            txtNum1.Text = _firstNum + " " + _operator + " ";

            _isNewNum = true; // 이제 두 번째 숫자를 받을 준비
        }

        // 3. 결과(=) 버튼 클릭 시
        private void EqualButton_Click(object? sender, EventArgs? e)
        {
            if (string.IsNullOrEmpty(_operator)) return;

            double secondNum = double.Parse(txtResult.Text);
            double result = 0;

            if (_operator == "+") result = _firstNum + secondNum;

            txtNum1.Text = $"{_firstNum} {_operator} {secondNum} = {result}";
            txtResult.Text = result.ToString();

            _isNewNum = true;
            _operator = "";
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
