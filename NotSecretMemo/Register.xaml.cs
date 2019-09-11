using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace NotSecretMemo {
	/// <summary>
	/// Register.xaml の相互作用ロジック
	/// </summary>
	public partial class Register : Window {
		public Register() {
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			string username = UserName.Text;
			string password = PasswordMain.Password;
			string password_check = PasswordCheck.Password;

			if (username != "" && password != "" && password_check != "") {
				if (username != "temp")
					if (password == password_check) {
						string path = "user\\" + username + ".txt";
						Encoding encord = Encoding.GetEncoding("Shift_JIS");
						StreamWriter writer = new StreamWriter(path, false, encord);
						writer.WriteLine(username);
						writer.WriteLine(password);
						DateTime nowtime = DateTime.Now;
						writer.WriteLine($"{nowtime.Year}年{nowtime.Month}月{nowtime.Day}日 {nowtime.Hour}時{nowtime.Minute}分");
						writer.Close();

						Error.Content = "";
						MessageBox.Show("登録が完了しました。");
						this.Close();
					}
					else
						Error.Content = "確認のパスワードが間違っています。";
				else
					Error.Content = "そのユーザー名は使用できません。";
			}
			else
				Error.Content = "入力されていない項目があります。";
		}
	}
}
