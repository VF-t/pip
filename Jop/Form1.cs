namespace Jop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Size = new System.Drawing.Size(900, 600);

            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";

            SetRoundedShape(panel1, 30);
            //panel1.Paint += panel1_Paint;
        }
        static void SetRoundedShape(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddLine(radius, 0, control.Width - radius, 0);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(control.Width, radius, control.Width, control.Height - radius);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddLine(control.Width - radius, control.Height, radius, control.Height);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, control.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            control.Region = new Region(path);
        }
        public  int c = 0,y = 0 ;
        void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel1.Parent.BackColor);
            Control control = panel1;
            int radius = 30;
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddLine(radius, 0, control.Width - radius, 0);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddLine(control.Width, radius, control.Width, control.Height - radius);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddLine(control.Width - radius, control.Height, radius, control.Height);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.AddLine(0, control.Height - radius, 0, radius);
                path.AddArc(0, 0, radius, radius, 180, 90);
                using (SolidBrush brush = new SolidBrush(control.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            port("Предприятие");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            port("Логистика");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            port("Бугалтерия");
        }
       
        private void label6_Click(object sender, EventArgs e)
        {

        }
        #region Страшные логи бета
        void port(string s)
        {

            // шаманит с записями
            s = s + " " + DateTime.Now;
            Логи.ForeColor = Color.Black;
            y = 0; logi_off();
            if (c == 0) { label4.Text = s; }
            if (c == 1) { label5.Text = s; }
            if (c == 2) { label6.Text = s; }
            if (c == 3) { label7.Text = s; }
            if (c > 3) { c = 0; label4.Text = s; }
            c++;
        }
        void logi_off()
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }
        void logi_on()
        {
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
        }
        private void Логи_Click(object sender, EventArgs e)
        {
            if (y == 0)
            {
                Логи.ForeColor= Color.Red;
                y = 1;
                if (c == 0) { label4.Text = "Логов нет"; label4.Visible = true; }
                else if (c > 0) { logi_on(); }
            }
            else
            {
                Логи.ForeColor = Color.Black;
                y = 0; logi_off();
            }
        }
        #endregion
    }
}