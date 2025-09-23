using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace MainApp;

public partial class MainWindow : Window
{
    private CancellationTokenSource _cts = new();
    private bool _isDownloading = false;

    private static readonly string _fileName = @"2025-05-13-raspios-bookworm-arm64-lite.img.xz";
    private static readonly string _sourceFilePath = @$"https://downloads.raspberrypi.com/raspios_lite_arm64/images/raspios_lite_arm64-2025-05-13/{_fileName}";
    private static readonly string _targetFilePath = @$"c:\downloads\{_fileName}";

    public MainWindow()
    {
        InitializeComponent();

    }

    private async Task DownloadAsync(CancellationToken cancellationToken)
    {
        _isDownloading = true;

        using var http = new HttpClient();
        var res = await http.GetAsync(_sourceFilePath, cancellationToken);

        if (res.IsSuccessStatusCode)
        {
            using var fileStream = new FileStream(_targetFilePath, FileMode.CreateNew);
            await res.Content.CopyToAsync(fileStream, cancellationToken);
        }
    }


    private async void Btn_Download_Click(object sender, RoutedEventArgs e)
    {
        if (_isDownloading)
        {
            _cts.Cancel();
            return;
        }

        try
        {
            Lview_EventLog.Items.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} : Start downloading...");

            _cts = new CancellationTokenSource();
            Btn_Download.Content = "Cancel";

            await DownloadAsync(_cts.Token);

            Lview_EventLog.Items.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} : Download completed.");
        }
        catch (Exception ex)
        {
            Lview_EventLog.Items.Add($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} : {ex.Message}");
        }
        finally
        {
            _isDownloading = false;
            Btn_Download.Content = "Download";
            _cts = null!;
        }

    }
}