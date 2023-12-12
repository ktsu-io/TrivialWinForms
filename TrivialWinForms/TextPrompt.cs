namespace ktsu.io.TrivialWinForms
{
	/// <summary>
	/// A simple text prompt dialog that returns a string, or empty string if the user cancels.
	/// </summary>
	public static class TextPrompt
	{
		private static int Padding => 10;
		private static int Width => 400;
		private static int Height => 75;
		private static int ButtonWidth => 80;
		private static TextBox TextBox { get; }
		private static Button Button { get; }
		private static Form Form { get; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
		static TextPrompt()
		{
			TextBox = new()
			{
				Top = Padding,
				Left = Padding,
				Width = Width - ButtonWidth - (Padding * 5),
			};

			Button = new()
			{
				DialogResult = DialogResult.OK,
				Text = nameof(DialogResult.OK),
				Top = Padding - 2, //needed to vertically center the button with the textbox
				Left = (Padding * 2) + TextBox.Width,
				Width = ButtonWidth,
			};

			Form = new()
			{
				TopMost = true,
				Width = Width,
				Height = Height,
				FormBorderStyle = FormBorderStyle.FixedDialog,
				StartPosition = FormStartPosition.CenterScreen,
				Controls = { TextBox, Button },
				AcceptButton = Button,
				ActiveControl = TextBox,
			};

			Button.Click += (sender, e) => Form.Hide();
		}

		/// <summary>
		/// Shows the text prompt dialog with the given caption.
		/// </summary>
		/// <param name="caption">The caption to show in the title of the prompt.</param>
		/// <returns>The string the user input, or empty string if they hit cancel.</returns>
		public static string Show(string caption)
		{
			Form.Text = caption;
			return Form.ShowDialog() == DialogResult.OK ? TextBox.Text : string.Empty;
		}
	}
}
