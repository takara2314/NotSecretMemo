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
	/// Memo.xaml の相互作用ロジック
	/// </summary>
	public partial class Memo : Window {
		public string title;
		public Encoding encord;
		public string username;
		public string password;
		public string time;
		public string memo;
		public Memo() {
			InitializeComponent();
			title = General.Title;
			encord = Encoding.GetEncoding("Shift_JIS");
			StreamReader reader = new StreamReader("user\\temp.txt", encord);
			username = reader.ReadLine();
			password = reader.ReadLine();
			time = reader.ReadLine();
			memo = reader.ReadLine();
			reader.Close();

			UserName.Content = username;
			MemoBox.Text = memo;
			UpdateTime.Content = "最終更新：" + time;
		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			if (memo != MemoBox.Text) {
				string path = "user\\" + username + ".txt";
				StreamWriter writer = new StreamWriter(path, false, encord);
				writer.WriteLine(username);
				writer.WriteLine(password);
				DateTime nowtime = DateTime.Now;
				time = $"{nowtime.Year}年{nowtime.Month}月{nowtime.Day}日 {nowtime.Hour}時{nowtime.Minute}分";
				writer.WriteLine(time);
				writer.WriteLine(MemoBox.Text);
				writer.Close();

				General.Title = title;
				UpdateTime.Content = "最終更新：" + time;
			}
		}

		private void MemoBox_TextChanged(object sender, TextChangedEventArgs e) {
			if (memo == MemoBox.Text)
				General.Title = title;
			else
				General.Title = title + " (未保存)";
		}
	}
}
