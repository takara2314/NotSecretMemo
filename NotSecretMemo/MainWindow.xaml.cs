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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace NotSecretMemo {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			string username = UserName.Text;
			string password = PasswordMain.Password;

			if (username != "" && password != "") {
				try {
					string path = "user\\" + username + ".txt";
					Encoding encord = Encoding.GetEncoding("Shift_JIS");
					StreamReader reader = new StreamReader(path, encord);
					string DataUsername = reader.ReadLine();
					string DataPassword = reader.ReadLine();
					string time = reader.ReadLine();
					string memo = reader.ReadLine();
					reader.Close();

					if (password == DataPassword) {
						StreamWriter writer = new StreamWriter("user\\temp.txt", false, encord);
						writer.WriteLine(username);
						writer.WriteLine(password);
						writer.WriteLine(time);
						writer.WriteLine(memo);
						writer.Close();

						Memo nsm = new Memo();
						this.Close();
						nsm.Show();
					}
					else
						Error.Content = "IDもしくはパスワードが間違っています。";
				}
				catch (FileNotFoundException) {
					Error.Content = "IDもしくはパスワードが間違っています。";
				}
			}
			else
				Error.Content = "入力されていない項目があります。";
		}

		private void Button_Click_1(object sender, RoutedEventArgs e) {
			Register register = new Register();
			register.Show();
		}
	}
}
