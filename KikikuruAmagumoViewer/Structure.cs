namespace KikikuruAmagumoViewer
{
    public class Structure
    {
        /// <summary>
        /// タイル座標
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
            /// <param name="x">X座標</param>
            /// <param name="y">Y座標</param>
            /// <param name="z">ズームレベル</param>
            public TileCoordinate(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            /// <summary>
            /// 緯度経度とズームレベルから<see cref="TileCoordinate"/>のインスタンスを初期化します。
            /// </summary>
            /// <param name="lat">緯度</param>
            /// <param name="lon">経度</param>
            /// <param name="zoom">ズームレベル</param>
            public TileCoordinate(double lat, double lon, int zoom)
            {
                X = Converter.Tile.Lon2TileX(lon, zoom);
                Y = Converter.Tile.Lat2TileY(lat, zoom);
                Z = zoom;
            }

            private int _x = 13;
            private int _y = 5;
            private int _z = 4;

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
            /// X座標
            /// </summary>
            public int X
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
            /// Y座標
            /// </summary>
            public int Y
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
            /// ズームレベル  
            /// </summary>
            /// <remarks><see cref="EnableAutoXYChange"/>が<see cref="true"/>の場合、X,Y座標が自動で変換されます。</remarks>
            public int Z
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

            public override string ToString()
            {
                return $"{Z}/{X}/{Y}";
            }
        }
    }
}
