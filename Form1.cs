using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace termpro
{

    public partial class Form1 : Form
    {
        TextBox tb;

        public class OrderDetails
        {
            //선언 목록은 메뉴,갯수,가격
            public string menu;
            public int count; //{ get;  set; }
            public int price;
        }
        public class OrderNum
        {
            public int odnum;
        }
        OrderNum[] ordnum = new OrderNum[]
        {
          new OrderNum() {odnum=0}
        };
    //주문받을 목록들을 배열에 선언+가격도 
        OrderDetails[] orders = new OrderDetails[] {
            new OrderDetails() {menu = "라면", count = 0,price=2500},
            new OrderDetails() { menu = "떡뽁이", count = 0,price=3000},
            new OrderDetails() {menu = "김밥", count = 0,price=2500},
            new OrderDetails() {menu = "콜라", count = 0,price=1500},
            new OrderDetails() {menu = "음료수", count = 0,price=1300}
        };
        
        public Form1()
        {
           InitializeComponent();
           /* tb = textBox1;
            textBox1.Select();
            foreach (TextBox t in this.Controls.OfType<TextBox>())
            {
                t.Click += textBox_Click;
            }
            bool vIn = true;
            int vOut = Convert.ToInt32(vIn);*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "우석 분식";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //전송자료 12-2,12-3
            //
            foreach (Control c in groupBox1.Controls)
            {
                if ((c is CheckBox) && ((CheckBox)c).Checked)
                {
                    foreach (OrderDetails od in orders)
                    {
                        if (c.Text.Contains(od.menu)) od.count++;
                  
                    }
                    ((CheckBox)c).Checked = false; //체크값 초기화
                }
            }
            richTextBox1.Text = ""; //정보표시전 텍스 밀어버려 초기화
            foreach (OrderDetails od in orders)
            {
                richTextBox1.Text += od.menu + ": " + od.count + "\n";
            }
            textBox1.Text = "";
            int total = 0; //총가격 0으로 초기화 한뒤 갯수와각격 곱 계산
            foreach (OrderDetails od in orders)
            {
                total += od.count * od.price;
            }
            textBox1.Text += total.ToString();
           //tb.Focus();
            //SendKeys.Send(total.ToString());
        }

       private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

       private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_Click(object sender, EventArgs e)
        {
            tb = (TextBox)sender;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //주문번호 배열 해결하기
            //if()
            //시간표시해주는 
            MessageBox.Show(DateTime.Now.ToString()+"\n"+"주문번호:"+"\n"+richTextBox1.Text+"\n"+textBox1.Text+":원" +"\n주문완료!");
            for (int i = 0; i < orders.Length; i++)
            {
                //od.count = 0;
                orders[i].count = 0;
            }

           foreach (Control ControlTextBoxClear in this.Controls)
            {
                if (typeof(TextBox) == ControlTextBoxClear.GetType())
                {
                    (ControlTextBoxClear as TextBox).Text = "";
                }
            }
            foreach (Control ControlRichTextBoxClear in this.Controls)
            {
                if (typeof(RichTextBox) == ControlRichTextBoxClear.GetType())
                {
                    (ControlRichTextBoxClear as RichTextBox).Text = "";
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            { foreach (Control c in groupBox1.Controls)
                {
                    if ((c is CheckBox) && ((CheckBox)c).Checked)
                    {
                        foreach (OrderDetails od in orders)
                        {
                            if (c.Text.Contains(od.menu)) od.count--;
                        }
                        ((CheckBox)c).Checked = false;
                    }
                }
            /*이벤트 인위적발생 click 인위발생 -전송자료
            이렇게하는 이유 변수불러오기가 안되어서 중복사용이 안됨->빼기눌렀을땐 배열에 
            마이너스카운트시키고 추가-버튼 배열 실행시켜도 원하는값 얻음*/
                InvokeOnClick(button1, e);
                richTextBox1.Text = "";
               
                foreach (OrderDetails od in orders)
                {
                    //InvokeOnClick(button1, e);
                    richTextBox1.Text += od.menu + ": " + od.count + "\n";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close(); //주문취소하면 창닫음
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //배열 초기화
            // foreach (OrderDetails od in orders)
            for (int i = 0; i < orders.Length; i++)
            {
                //od.count = 0;
                orders[i].count = 0;
            }

                foreach (Control ControlTextBoxClear in this.Controls)
            {
                if (typeof(TextBox) == ControlTextBoxClear.GetType())
                {
                    (ControlTextBoxClear as TextBox).Text = "";
                }
            }
            foreach (Control ControlRichTextBoxClear in this.Controls)
            {
                if (typeof(RichTextBox) == ControlRichTextBoxClear.GetType())
                {
                    (ControlRichTextBoxClear as RichTextBox).Text = "";
                }
            }
        }
    }
}
