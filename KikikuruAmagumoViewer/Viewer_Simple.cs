using static KikikuruAmagumoViewer.ControlForm;
using static KikikuruAmagumoViewer.ResourceData;
using static KikikuruAmagumoViewer.Structure;

namespace KikikuruAmagumoViewer
{
    public partial class Viewer_Simple : Form
    {
        internal Bitmap? Img = null;
        internal TileCoordinate Coordinate = new() { EnableAutoXYChange = true };//4,6,8,10
        internal Tile_Map MapName;

        public Viewer_Simple()
        {
            MapName = Tile_Map.JMA_gray_cities;
            InitializeComponent();
            L_message.MaximumSize = ClientSize;
            MouseWheel += Viewer_MouseWheel;
            GetImage();
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

        internal async void GetImage()//todo:z奇数だと画像なかったり
        {
            if (MapName == Tile_Map.Null)
                return;
            L_message.Text = "取得中...";
            var img = await GetTileAndData(Coordinate, MapName, Tile_Data.JMA_nowc_hrpns);
            if (img != null)
                UpdateImage(img);
            UpdateMessage();
        }

        private void Viewer_Simple_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Coordinate.Y--;
                    break;
                case Keys.Down:
                    Coordinate.Y++;
                    break;
                case Keys.Right:
                    Coordinate.X++;
                    break;
                case Keys.Left:
                    Coordinate.X--;
                    break;
                case Keys.Home:
                    Coordinate = new TileCoordinate(13, 5, 4);
                    break;
            }
            GetImage();
        }

        private void Viewer_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (Coordinate.Z >= 14)
                    return;
                Coordinate.Z++;

            }
            else
            {
                if (Coordinate.Z <= 4)
                    return;
                Coordinate.Z--;
            }
            GetImage();
        }

        internal void UpdateMessage()
        {
            L_message.Text = $"地図データ: " + MapRights[MapName];//todo:configで付けれるように  tile: {coordinate.Z}/{coordinate.X}/{coordinate.Y}

        }

        private void Viewer_Simple_Resize(object sender, EventArgs e)
        {
            L_message.MaximumSize = ClientSize;
        }
    }
}
