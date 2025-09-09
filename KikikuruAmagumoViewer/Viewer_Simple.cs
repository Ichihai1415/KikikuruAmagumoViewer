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

        // 修正内容: TileCoordinate の必須プロパティ (TileX, TileY, TileZ) をオブジェクト初期化子で設定するよう修正
        private void Viewer_Simple_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Coordinate.TileY--;
                    break;
                case Keys.Down:
                    Coordinate.TileY++;
                    break;
                case Keys.Right:
                    Coordinate.TileX++;
                    break;
                case Keys.Left:
                    Coordinate.TileX--;
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
                if (Coordinate.TileZ >= 14)
                    return;
                Coordinate.TileZ++;

            }
            else
            {
                if (Coordinate.TileZ <= 4)
                    return;
                Coordinate.TileZ--;
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
