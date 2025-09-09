using static KikikuruAmagumoViewer.Converter;

namespace KikikuruAmagumoViewer
{
    public class Structure
    {
        /// <summary>
        /// タイル座標およびタイル画像内のピクセル座標(任意)
        /// </summary>
        /// <remarks>デフォルト: (x,y,z)=(13,5,4) 値が範囲外の場合無視 X,Y自動変更、イベントハンドラなど各仕様はコードを確認してください。</remarks>
        public class TileCoordinate
        {
            /// <summary>
            /// <see cref="TileCoordinate"/>のインスタンスを初期化します。値はデフォルト値<c>(x,y,z)=(13,5,4)</c>です。
            /// </summary>
            public TileCoordinate() { }

            /// <summary>
            /// 指定した値で<see cref="TileCoordinate"/>のインスタンスを初期化します。
            /// </summary>
            /// <param name="tileX">X座標</param>
            /// <param name="tileY">Y座標</param>
            /// <param name="tileZ">ズームレベル</param>
            /// <param name="tileSize">タイルサイズ</param>
            public TileCoordinate(int tileX, int tileY, int tileZ, int tileSize = 256)
            {
                TileX = tileX;
                TileY = tileY;
                TileZ = tileZ;
                TileSize = tileSize;
            }

            /// <summary>
            /// 指定した値で<see cref="TileCoordinate"/>のインスタンスを初期化します。
            /// </summary>
            /// <param name="tileX">X座標</param>
            /// <param name="tileY">Y座標</param>
            /// <param name="tileZ">ズームレベル</param>
            /// <param name="pixelX">タイル画像のX座標</param>
            /// <param name="pixelY">タイル画像のY座標</param>
            /// <param name="tileSize">タイルサイズ</param>
            public TileCoordinate(int tileX, int tileY, int tileZ, int pixelX, int pixelY, int tileSize = 256)
            {
                TileX = tileX;
                TileY = tileY;
                TileZ = tileZ;
                PixelX = pixelX;
                PixelY = pixelY;
                TileSize = tileSize;
            }

            /// <summary>
            /// 指定した値で<see cref="TileCoordinate"/>のインスタンスを初期化します。
            /// </summary>
            /// <param name="lat">緯度</param>
            /// <param name="lon">経度</param>
            /// <param name="tileZ">ズームレベル</param>
            /// <param name="tileSize">タイルサイズ</param>
            public TileCoordinate(double lat, double lon, int tileZ, int tileSize = 256)
            {
                var (tileX, pixelX) = Tile.Lon2TileXPixelX(lon, tileZ, tileSize);
                var (tileY, pixelY) = Tile.Lat2TileYPixelY(lat, tileZ, tileSize);
                TileX = tileX;
                TileY = tileY;
                TileZ = tileZ;
                PixelX = pixelX;
                PixelY = pixelY;
                TileSize = tileSize;
            }

            /// <summary>
            /// タイルのX座標
            /// </summary>
            private int _x = 13;

            /// <summary>
            /// タイルのY座標
            /// </summary>
            private int _y = 5;

            /// <summary>
            /// タイルのZ座標
            /// </summary>
            private int _z = 4;

            /// <summary>
            /// タイルの画像のX座標
            /// </summary>
            private int? _px;

            /// <summary>
            /// タイルの画像のY座標
            /// </summary>
            private int? _py;

            /// <summary>
            /// 値が範囲外の場合<see cref="ArgumentOutOfRangeException"/>を出すか
            /// </summary>
            public bool EnableOutOfRangeException = false;

            /// <summary>
            /// Zが変化したときにX,Yを自動で調整するか
            /// </summary>
            /// <remarks>拡大の時</remarks>
            public bool EnableAutoXYChange = false;

            /// <summary>
            /// 値が変化したときのイベント
            /// </summary>
            /// <remarks><c>(object? sender, EventArgs e)</c>です。<see cref="EventArgs"/>は<see cref="EventArgs.Empty"/>です。</remarks>
            public event EventHandler? ValueChanged;

            /// <summary>
            /// タイルサイズ
            /// </summary>
            /// <remarks>ピクセル計算時に使用します</remarks>
            public int TileSize = 256;

            /// <summary>
            /// タイルのX座標
            /// </summary>
            public int TileX
            {
                get => _x;
                set
                {
                    if (value < 0 || value >= (1 << _z))
                    {
                        if (EnableOutOfRangeException)
                            throw new ArgumentOutOfRangeException(nameof(value), $"X must be between 0 and {(1 << _z) - 1}.");
                        return;
                    }
                    if (_x != value)
                        OnValueChanged(1, value);
                }
            }

            /// <summary>
            /// タイルのY座標
            /// </summary>
            public int TileY
            {
                get => _y;
                set
                {
                    if (value < 0 || value >= (1 << _z))
                    {
                        if (EnableOutOfRangeException)
                            throw new ArgumentOutOfRangeException(nameof(value), $"Y must be between 0 and {(1 << _z) - 1}.");
                        return;
                    }
                    if (_y != value)
                        OnValueChanged(2, value);
                }
            }

            /// <summary>
            /// タイルのズームレベル  
            /// </summary>
            /// <remarks><see cref="EnableAutoXYChange"/>が<see cref="true"/>の場合、X,Y座標が自動で変換されます。</remarks>
            public int TileZ
            {
                get => _z;
                set
                {
                    if (value < 0)
                    {
                        if (EnableOutOfRangeException)
                            throw new ArgumentOutOfRangeException(nameof(value), $"Z must be greater than or equal to 0.");
                        return;
                    }
                    if (EnableAutoXYChange)
                        if (value > _z)//拡大
                        {
                            _x <<= value - _z;
                            _y <<= value - _z;
                        }
                        else if (value < _z)
                        {
                            _x >>= _z - value;
                            _y >>= _z - value;
                        }
                    if (_z != value)
                        OnValueChanged(3, value);
                }
            }

            /// <summary>
            /// タイルの画像のX座標
            /// </summary>
            public int? PixelX
            {
                get => _px;
                set
                {
                    if (value < 0 || value >= TileSize)
                    {
                        if (EnableOutOfRangeException)
                            throw new ArgumentOutOfRangeException(nameof(value), $"PixelX must be between 0 and {TileSize - 1}.");
                        return;
                    }
                    _px = value;
                }
            }

            /// <summary>
            /// タイルの画像のY座標
            /// </summary>
            public int? PixelY
            {
                get => _py;
                set
                {
                    if (value < 0 || value >= TileSize)
                    {
                        if (EnableOutOfRangeException)
                            throw new ArgumentOutOfRangeException(nameof(value), $"PixelY must be between 0 and {TileSize - 1}.");
                        return;
                    }
                    _py = value;
                }
            }

            /// <summary>
            /// 値が変化したときに呼ばれる
            /// </summary>
            /// <remarks><see cref="EventArgs"/>は<see cref="EventArgs.Empty"/>です。Zの変化で余計に呼ばないように、かつ値変化を先に</remarks>
            /// <param name="xyz">X=1, Y=2, Z=3</param>
            /// <param name="newValue">新しい値</param>
            protected virtual void OnValueChanged(byte xyz, int newValue)
            {
                switch (xyz)
                {
                    case 1:
                        _x = newValue;
                        break;
                    case 2:
                        _y = newValue;
                        break;
                    case 3:
                        _z = newValue;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(xyz), "xyz must be 1(X), 2(Y), or 3(Z).");
                }
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }

            /// <inheritdoc/>
            /// <remarks>format: <c>$"[tile: x={TileX},y={TileY},z={TileZ} / pixel: x={PixelX},y={PixelY},size={TileSize}]"</c></remarks>
            public override string ToString() => $"[tile: x={TileX},y={TileY},z={TileZ} / pixel: x={PixelX},y={PixelY},size={TileSize}]";

            /// <summary>
            /// URLなど用に<c>Z/X/Y</c>形式で文字列を返します。
            /// </summary>
            /// <returns><c>Z/X/Y</c>形式の文字列</returns>
            public string ToString_TileZXY() => $"{TileZ}/{TileX}/{TileY}";

            /// <summary>
            /// URLなど用に<c>X/Y/Z</c>形式で文字列を返します。
            /// </summary>
            /// <returns><c>X/Y/Z</c>形式の文字列</returns>
            public string ToString_TileXYZ() => $"{TileX}/{TileY}/{TileZ}";

            /// <summary>
            /// 指定されたテキストの特定部分をオブジェクトの値に置換します。
            /// </summary>
            /// <remarks>tile: <c>{x}</c>,<c>{y}</c>,<c>{z}</c> pixel: <c>{px}</c>,<c>{py}</c></remarks>
            /// <param name="text">置換する/された文字</param>
            public string StringReplace(string text) =>
               text.Replace("{x}", TileX.ToString())
                          .Replace("{y}", TileY.ToString())
                          .Replace("{z}", TileZ.ToString())
                          .Replace("{px}", PixelX.ToString())
                          .Replace("{py}", PixelY.ToString());

            /// <summary>
            /// 指定されたテキストの特定部分をオブジェクトの値に置換します。
            /// </summary>
            /// <remarks>tile: <c>{x}</c>,<c>{y}</c>,<c>{z}</c> pixel: <c>{px}</c>,<c>{py}</c></remarks>
            /// <param name="text">置換する文字列</param>
            /// <returns>置換された文字列</returns>
            public void StringReplace(ref string text) => text = StringReplace(text);

        }


    }
}
