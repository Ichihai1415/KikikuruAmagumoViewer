using static KikikuruAmagumoViewer.ResourceData;
using static KikikuruAmagumoViewer.Structure;

namespace KikikuruAmagumoViewer
{
    public partial class ControlForm : Form
    {
        internal static HttpClient client = new();

        public ControlForm()
        {
            InitializeComponent();
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            var sv = new Viewer_Simple()
            {
                MapName = Tile_Map.JMA_gray_cities
            };
            sv.Show();

        }


        internal async static Task<Bitmap?> GetTileAndData(TileCoordinate tileCoordinate, Tile_Map mapTile, Tile_Data dataTile)
        {
            var url_map = tileCoordinate.StringReplace(MapURL[mapTile]);
            var sr_map = await client.GetStreamAsync(url_map);

            // Indexed âÊëúÇíºê⁄ Graphics Ç…ìnÇπÇ»Ç¢ÇÃÇ≈ÉRÉsÅ[
            using var srcImg = new Bitmap(sr_map);
            var img = new Bitmap(srcImg.Width, srcImg.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (var gTemp = Graphics.FromImage(img))
            {
                gTemp.DrawImage(srcImg, 0, 0, srcImg.Width, srcImg.Height);
            }

            using var g = Graphics.FromImage(img);

            var url_data = tileCoordinate.StringReplace(DataURL[dataTile])
                .Replace("{dateTime}", "20250909080000");
            var sr_data = await client.GetStreamAsync(url_data);

            using var overlay = new Bitmap(sr_data);
            g.DrawImage(overlay, 0, 0, 256, 256);

            return img;

        }

    }
}
