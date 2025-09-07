namespace KikikuruAmagumoViewer
{
    public partial class ControlForm : Form
    {
        internal HttpClient client = new();

        public ControlForm()
        {
            InitializeComponent();
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            var sv = new Viewer_Simple();
            sv.Show();

        }
    }
}
