using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RomanceHotel.GUI
{
    public partial class FormChatbotAI : Form
    {
        private readonly HttpClient _httpClient;

        // TODO: Thay bằng API key Gemini thật của bạn
        private const string GeminiApiKey = "AIzaSyBDc68k27zknT231MFk_w29_P5ut113MWo";
        // Có thể dùng "gemini-2.5-flash" nếu muốn
        private const string GeminiModel = "gemini-2.5-flash-lite";

        public FormChatbotAI()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

            this.DoubleBuffered = true;
            this.Text = "Trợ lý AI - Gemini";
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            string userText = txtUserInput.Text.Trim();
            if (string.IsNullOrEmpty(userText))
                return;

            // Thêm tin nhắn của bạn (bên phải)
            AppendMessage("Bạn", userText, isUser: true);
            txtUserInput.Clear();

            buttonSend.Enabled = false;
            labelStatus.Text = "Đang suy nghĩ...";
            labelStatus.ForeColor = Color.OrangeRed;

            try
            {
                string reply = await CallGeminiAsync(userText);

                // Thêm tin nhắn của AI (bên trái)
                AppendMessage("AI Gemini", reply, isUser: false);

                labelStatus.Text = "Online";
                labelStatus.ForeColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                AppendMessage("Lỗi", "Không thể gọi AI: " + ex.Message, isUser: false);
                labelStatus.Text = "Lỗi kết nối";
                labelStatus.ForeColor = Color.Red;
            }
            finally
            {
                buttonSend.Enabled = true;
                txtUserInput.Focus();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            flowLayoutPanelChat.Controls.Clear();
        }

        /// <summary>
        /// Tạo một dòng chat dạng bong bóng + avatar.
        /// isUser = true -> bên phải (user), false -> bên trái (AI).
        /// </summary>
        private void AppendMessage(string senderName, string text, bool isUser)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            // Panel chứa cả avatar + bong bóng
            var container = new Panel();
            container.AutoSize = true;
            container.BackColor = Color.Transparent;
            container.Padding = new Padding(5);
            container.Margin = new Padding(0, 5, 0, 5);

            // chiều rộng hiện tại của vùng chat
            int containerWidth = flowLayoutPanelChat.ClientSize.Width - 10;
            container.Width = containerWidth;

            int avatarSize = 36;
            int margin = 8;

            // Avatar
            var picAvatar = new PictureBox();
            picAvatar.Size = new Size(avatarSize, avatarSize);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.BackColor = Color.White;
            picAvatar.Image = isUser
                ? RomanceHotel.Properties.Resources.user
                : RomanceHotel.Properties.Resources.chatbot;
            picAvatar.BorderStyle = BorderStyle.None;

            // Panel bong bóng
            var bubblePanel = new Panel();
            bubblePanel.AutoSize = true;
            bubblePanel.Padding = new Padding(12, 8, 12, 8);
            bubblePanel.Margin = new Padding(0);
            bubblePanel.BackColor = isUser
                ? Color.FromArgb(72, 145, 153)      // xanh user
                : Color.FromArgb(239, 242, 247);   // xám AI

            int maxBubbleWidth = containerWidth - avatarSize - 3 * margin;
            bubblePanel.MaximumSize = new Size(maxBubbleWidth, 0);

            // Label nội dung
            var lblText = new Label();
            lblText.AutoSize = true;
            lblText.MaximumSize = new Size(maxBubbleWidth - 20, 0);
            lblText.Font = new Font("Segoe UI", 10f);
            lblText.ForeColor = isUser ? Color.White : Color.Black;
            lblText.BackColor = Color.Transparent;
            string cleaned = CleanMarkdown(text.Trim());
            lblText.Text = cleaned;

            bubblePanel.Controls.Add(lblText);

            // Thêm vào container trước để tính size
            container.Controls.Add(bubblePanel);
            container.Controls.Add(picAvatar);
            container.PerformLayout();

            // Đảm bảo chiều rộng bong bóng không vượt max
            int bubbleWidth = bubblePanel.PreferredSize.Width;
            if (bubbleWidth > maxBubbleWidth) bubbleWidth = maxBubbleWidth;
            bubblePanel.Size = new Size(bubbleWidth, bubblePanel.PreferredSize.Height);

            // Đặt vị trí theo phía gửi
            if (isUser)
            {
                // User bên phải: avatar sát phải, bong bóng bên trái avatar
                int avatarX = containerWidth - avatarSize - margin;
                int bubbleX = avatarX - margin - bubbleWidth;

                picAvatar.Location = new Point(avatarX, margin);
                bubblePanel.Location = new Point(bubbleX, margin);
            }
            else
            {
                // AI bên trái
                picAvatar.Location = new Point(margin, margin);
                bubblePanel.Location = new Point(picAvatar.Right + margin, margin);
            }

            // Chiều cao container đủ chứa cả avatar + bong bóng
            int contentHeight = Math.Max(avatarSize, bubblePanel.Height) + 2 * margin;
            container.Height = contentHeight;

            // Thêm vào flowLayoutPanel
            flowLayoutPanelChat.Controls.Add(container);
            flowLayoutPanelChat.ScrollControlIntoView(container);
        }

        private string CleanMarkdown(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            string s = input;

            // Loại **bold**
            s = s.Replace("**", "");

            // Loại *italic*
            s = s.Replace("* ", "• "); // giữ bullet nhưng đẹp hơn
            s = s.Replace("*", "");

            // Loại _đậm nghiêng_
            s = s.Replace("_", "");

            // Loại `inline code`
            s = s.Replace("`", "");

            // Nếu có kí tự ### hoặc ## thì xuống dòng thay vì in tiêu đề
            s = s.Replace("###", "")
                 .Replace("##", "")
                 .Replace("#", "");

            return s.Trim();
        }

        private async Task<string> CallGeminiAsync(string prompt)
        {
            if (GeminiApiKey == "YOUR_API_KEY_HERE")
                throw new InvalidOperationException("Chưa cấu hình API key Gemini.");

            string url =
                $"https://generativelanguage.googleapis.com/v1beta/models/{GeminiModel}:generateContent";

            var payload = new
            {
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new[]
                        {
                            new
                            {
                                text =
                                    "Bạn là một trợ lý AI đa năng. " +
                                    "Bạn có thể trả lời về nhiều chủ đề khác nhau như cuộc sống, học tập, công nghệ, kinh doanh, lập trình, v.v. " +
                                    "Hãy trả lời bằng tiếng Việt, thân thiện, dễ hiểu, rõ ràng. " +
                                    "Nếu câu hỏi liên quan đến kiến thức chuyên ngành, hãy giải thích sao cho người không chuyên cũng hiểu được.\n\n" +
                                    "Câu hỏi của người dùng: " + prompt
                            }
                        }
                    }
                }
            };

            string json = JsonConvert.SerializeObject(payload);

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("x-goog-api-key", GeminiApiKey);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Lỗi API {response.StatusCode}: {responseString}");
            }

            dynamic obj = JsonConvert.DeserializeObject(responseString);
            string text = obj.candidates[0].content.parts[0].text;

            return string.IsNullOrWhiteSpace(text) ? "(Không có nội dung trả lời)" : text.Trim();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _httpClient?.Dispose();
        }
    }
}
