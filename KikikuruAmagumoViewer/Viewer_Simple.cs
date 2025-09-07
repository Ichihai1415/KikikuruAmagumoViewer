using static KikikuruAmagumoViewer.Structure;

namespace KikikuruAmagumoViewer
{
    public partial class Viewer_Simple : Form
    {
        internal Bitmap? Img = null;
        internal TileCoordinate coordinate = new() { EnableAutoXYChange = true };//4,6,8,10

        public Viewer_Simple()
        {
            InitializeComponent();
            MouseWheel += Viewer_MouseWheel;
            L_message.Text = $"地図データ: 地理院タイル(加工)  tile: {coordinate.Z}/{coordinate.X}/{coordinate.Y}";
        }

        public Viewer_Simple(Bitmap img)
        {
            InitializeComponent();
            Img = img;
        }

        private void Viewer_Load(object sender, EventArgs e)
        {

        }

        internal void UpdateImage(Bitmap img)
        {
            Img = img;
            PB_Main.Image = Img;
        }


        private void Viewer_Simple_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    coordinate.Y--;
                    break;
                case Keys.Down:
                    coordinate.Y++;
                    break;
                case Keys.Right:
                    coordinate.X++;
                    break;
                case Keys.Left:
                    coordinate.X--;
                    break;
                case Keys.Home:
                    coordinate = new TileCoordinate(13, 5, 4);
                    break;
            }
            L_message.Text = $"地図データ: 地理院タイル(加工)  tile: {coordinate.Z}/{coordinate.X}/{coordinate.Y}";
        }

        private void Viewer_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (coordinate.Z >= 14)
                    return;
                coordinate.Z += 2;

            }
            else
            {
                if (coordinate.Z <= 4)
                    return;
                coordinate.Z -= 2;
            }
            L_message.Text = $"地図データ: 地理院タイル(加工)  tile: {coordinate.Z}/{coordinate.X}/{coordinate.Y}";
        }
    }
}
